using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.DB;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB.Model;

namespace TestCourseManagement
{
    [TestClass]
    public class TestCourseLogic
    {
        [TestMethod]
        public void TestCreate()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            CourseLogic logic = CourseLogic.getInstance();
            int id = Tutor.getAll()[0].Id;
            int? test = logic.create("abc", Convert.ToDecimal(12.12), "abc", 12, 5, id, 24);
            Assert.IsNotNull(test);
            logic.delete(test.Value);

            ActiveUser.logout();
        }

        /*[TestMethod]
        public void TestChangeProperties()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            int id = Course.getAll()[0].Id;
            Course course = Course.getById(id);
            
            CourseLogic.getInstance().changeProperties(id, course.Course.CourseNr, course.Room.RoomNr, anfang, ende);
            course = Appointment.getById(id);
            Assert.AreEqual(ende, course.EndDate);
            Assert.AreEqual(anfang, course.StartDate);
            CourseLogic.getInstance().changeProperties(id, course.Course.CourseNr, course.Room.RoomNr, startDate, endDate);
            course = Appointment.getById(id);
            Assert.AreEqual(endDate, course.EndDate);
            Assert.AreEqual(startDate, course.StartDate);
            ActiveUser.logout();
        }

        /*[TestMethod]
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
        }*/
    }
}
