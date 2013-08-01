using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB;
using CourseManagement.Client.DB.Model;
using System.Data;

namespace TestCourseManagement
{
    [TestClass]
    public class TestAppointmentLogic
    {
        DateTime anfang = new DateTime(1998, 1, 1, 1, 1, 1);
        DateTime ende = new DateTime(1998, 2, 2, 2, 2, 2);
        

        [TestMethod]
        public void TestCreate()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            AppointmentLogic logic = AppointmentLogic.getInstance();
            int roomNr = Room.getAll()[0].RoomNr;
            int courseNr = Course.getAll()[0].CourseNr;
            int? test = logic.create(courseNr, roomNr, anfang, ende);
            Assert.IsNotNull(test);
            int? test2 = logic.create(courseNr, roomNr, anfang, ende);
            Assert.IsNull(test2);
            logic.delete(test.Value);

            ActiveUser.logout();

        }

        [TestMethod]
        public void TestChangeProperties()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            int id = Appointment.getAll()[0].Id;
            Appointment app = Appointment.getById(id);
            DateTime startDate = app.StartDate;
            DateTime endDate = app.EndDate;
            AppointmentLogic.getInstance().changeProperties(id, app.Course.CourseNr, app.Room.RoomNr, anfang, ende);
            app = Appointment.getById(id);
            Assert.AreEqual(ende, app.EndDate);
            Assert.AreEqual(anfang, app.StartDate);
            AppointmentLogic.getInstance().changeProperties(id, app.Course.CourseNr, app.Room.RoomNr, startDate, endDate);
            app = Appointment.getById(id);
            Assert.AreEqual(endDate, app.EndDate);
            Assert.AreEqual(startDate, app.StartDate);
            ActiveUser.logout();
        }

        [TestMethod]
        public void TestDelete()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            int roomNr = Room.getAll()[0].RoomNr;
            int courseNr = Course.getAll()[0].CourseNr;
            int? id = AppointmentLogic.getInstance().create(courseNr, roomNr, anfang, ende);
            Assert.IsNotNull(Appointment.getById(id.Value));
            AppointmentLogic.getInstance().delete(id.Value);
            Assert.IsNull(Appointment.getById(id.Value));

            ActiveUser.logout();
        }

        [TestMethod]
        public void TestGetBy()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            DataTable dataTbl = AppointmentLogic.getInstance().getById(Appointment.getAll()[0].Id);
            Assert.AreEqual(dataTbl.Columns.Count, 5);
            Assert.AreEqual(dataTbl.Rows.Count, 1);
            dataTbl = AppointmentLogic.getInstance().getById(-88);
            Assert.AreEqual(dataTbl.Columns.Count, 5);
            Assert.AreEqual(dataTbl.Rows.Count, 0);
            ActiveUser.logout();
        }

    }
}
