using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.DB;
using CourseManagement.Client.BusinessLogic;

namespace TestCourseManagement
{
    [TestClass]
    public class TestActiveUser
    {
        [TestMethod]
        public void TestLoginLogout()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            
            //Check if an admin is able to use all Logic-classes.
            ActiveUser.login("admin", "admin");
            Assert.IsNotNull(AppointmentLogic.getInstance());
            Assert.IsNotNull(CourseLogic.getInstance());
            Assert.IsNotNull(PaymentLogic.getInstance());
            Assert.IsNotNull(PersonLogic.getInstance());
            Assert.IsNotNull(RoomLogic.getInstance());
            Assert.IsNotNull(StudentLogic.getInstance());
            Assert.IsNotNull(TutorLogic.getInstance());
            Assert.IsNotNull(UserLogic.getInstance());

            //Check if the access to all Logic-classes is denied after logout.
            ActiveUser.logout();
            Assert.IsNull(AppointmentLogic.getInstance());
            Assert.IsNull(CourseLogic.getInstance());
            Assert.IsNull(PaymentLogic.getInstance());
            Assert.IsNull(PersonLogic.getInstance());
            Assert.IsNull(RoomLogic.getInstance());
            Assert.IsNull(StudentLogic.getInstance());
            Assert.IsNull(TutorLogic.getInstance());
            Assert.IsNull(UserLogic.getInstance());

            //Check if a normal user is not able to use user-logic class. but all other
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("user", "user");
            Assert.IsNotNull(AppointmentLogic.getInstance());
            Assert.IsNotNull(CourseLogic.getInstance());
            Assert.IsNotNull(PaymentLogic.getInstance());
            Assert.IsNotNull(PersonLogic.getInstance());
            Assert.IsNotNull(RoomLogic.getInstance());
            Assert.IsNotNull(StudentLogic.getInstance());
            Assert.IsNotNull(TutorLogic.getInstance());
            Assert.IsNull(UserLogic.getInstance());

            ActiveUser.logout();
        }

        [TestMethod]
        public void TestUserIsLoggedInUserIsAdmin()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            Assert.IsTrue(ActiveUser.userIsLoggedIn());
            Assert.IsTrue(ActiveUser.userIsAdmin());

            ActiveUser.logout();
            Assert.IsFalse(ActiveUser.userIsLoggedIn());
            Assert.IsFalse(ActiveUser.userIsAdmin());

            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("user", "user");
            Assert.IsTrue(ActiveUser.userIsLoggedIn());
            Assert.IsFalse(ActiveUser.userIsAdmin());

            ActiveUser.logout();
        }

        [TestMethod]
        public void TestChangePassword()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            ActiveUser.login("admin", "admin");
            Assert.IsTrue(ActiveUser.changePassword("testpsw"));
            ActiveUser.logout();
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            Assert.IsFalse(ActiveUser.login("admin", "admin"));
            Assert.IsTrue(ActiveUser.login("admin", "testpsw"));
            ActiveUser.changePassword("admin");
            ActiveUser.logout();
            
        }

    }
}
