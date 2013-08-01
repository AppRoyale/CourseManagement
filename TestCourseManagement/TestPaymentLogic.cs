using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB;
using System;
using CourseManagement.Client.DB.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TestCourseManagement
{
    [TestClass]
    public class TestPaymentLogic
    {
        [TestMethod]
        public void TestgetStudentBalance()
        {
            DBConfiguration.getContext(UnitHelper.getUnitConnectionString());
            if(!ActiveUser.userIsLoggedIn()) ActiveUser.login("admin", "admin");
            PaymentLogic paymentLogic = PaymentLogic.getInstance();
            List<Student> studentList = Student.getAll();
            String testObject = "";
            if (studentList != null)
            {
                Student student = studentList[0];
                testObject = paymentLogic.getStudentBalance(student.Id);
            }
            testObject = "1888877876545474747547398686872,88 €";
            Assert.IsTrue(testObject.Contains(" €"));

            //Assert.IsTrue(new Regex(@"\d{1,4}[,](\d{2})?").Match(testObject).Success);
            Assert.IsTrue(new Regex(@"^\d{1,4}[,]\d{2}\s[€]$").Match(testObject).Success);
        }
    }
}
