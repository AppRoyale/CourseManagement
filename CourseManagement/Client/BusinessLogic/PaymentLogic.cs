using CourseManagement.Client.DB.Model;
using System;
using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all logical operations of a Payment
    /// Implements some standard operations from the AbstractLogic
    /// </summary>
    public class PaymentLogic : AbstractLogic
    {
        private PaymentLogic() { }

        /// <summary>
        /// Getting an instance of PaymentLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static PaymentLogic getInstance()
        {
            PaymentLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new PaymentLogic();
            return temp;
        }

        /// <summary>
        /// Method for specific PaymentDataTable-changes to the default DataTable-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            try
            {
                return LogicUtils.getNewDataTable(new Payment(),"StudentNr","CourseName");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Creates a new datatable containing all Payments and returns this datatable
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allPayments = getNewDataTable();

                foreach (Payment payment in Payment.getAll())
                {
                    allPayments.Rows.Add(getNewRow(allPayments, payment));
                }

                return allPayments;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Required because of the abstract class but it is not
        /// necessary to search for Payments because they are connected to a Person
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override System.Data.DataTable search(string search)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a datatable and get one Payment by id and fills the datatable with all property names and
        /// the data from the Payment
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public override DataTable getById(int paymentId)
        {
            try
            {
                Payment payment = Payment.getById(paymentId);
                DataTable aPayment = getNewDataTable();
                if (payment != null)
                {
                    aPayment.Rows.Add(getNewRow(aPayment, payment));
                }
                return aPayment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for specific PaymentRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, Payment payment)
        {
            DataRow row = LogicUtils.getNewRow(table, payment);
            row["Course"] = payment.Course.CourseNr;
            row["Student"] = payment.Student.Forename + " " + payment.Student.Surname;
            row["StudentNr"] = payment.Student.Id;
            row["CourseName"] =payment.Course.Title ;
            return row;

        }

        /// <summary>
        /// Get one Payment by id and manages the remove from database of this Payment
        /// </summary>
        /// <param name="paymentId"></param>
        public override void delete(int paymentId)
        {
            try
            {
                Payment payment = Payment.getById(paymentId);
                if (payment != null) payment.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a new Payment and connect it to the selected Course and Student
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        public int create(int courseId, int studentId)
        {
            try
            {
                Payment payment = new Payment();
                payment.IsPaid = false;
                payment.Student = Student.getById(studentId);
                payment.Course = Course.getById(courseId);
                payment.addToDB();
                return payment.Id;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Payments of the submitted Student
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public DataTable getByStudent(int studentNr)
        {
            try
            {
                DataTable allOfStudent = getNewDataTable();
                foreach (Payment payment in Student.getById(studentNr).Payments)
                {
                    allOfStudent.Rows.Add(getNewRow(allOfStudent, payment));
                }
                return allOfStudent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calculates the balance of the selected Student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public String getStudentBalance(int studentId)
        {
            decimal sum = 0.00M;
            foreach (Payment aPayment in Student.getById(studentId).Payments)
            {
                if (aPayment.IsPaid == false)
                {
                    Course course = aPayment.Course;
                    sum -= (decimal)course.AmountInEuro;
                    course.update();
                }
            }
            return sum + " €";
        }

        /// <summary>
        /// Return a DataTable containing all Payments of the submitted Course
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        /// public DataTable getByCourse(int courseNr)
        public DataTable getByCourse(int courseNr)
        {
            try
            {
                DataTable allOfCourse = getNewDataTable();
                foreach (Payment payment in Course.getById(courseNr).Payments)
                {
                    allOfCourse.Rows.Add(getNewRow(allOfCourse, payment));
                }
                return allOfCourse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Set the payment paid/unpaid
        /// </summary>
        /// <param name="paymentId"></param>
        /// <param name="isPaid"></param>
        public void changeProperties(int paymentId, bool? isPaid)
        {
            Payment payment = Payment.getById(paymentId);

            if (payment.IsPaid != isPaid)
            {
                payment.IsPaid = isPaid;
                payment.update();
            }
        }

        /// <summary>
        /// Get one Payment by courseNr, studentNr and manage the remove from database of this Payment
        /// </summary>
        /// <param name="courseNr"></param>
        /// <param name="studentNr"></param>
        public void delete(int courseNr, int studentNr)
        {
            try
            {
                Payment tmp = null;
                foreach (Payment payment in Payment.getAll())
                {
                    if (payment.Course.CourseNr == courseNr && payment.Student.Id == studentNr) tmp = payment;
                }
                if(tmp!=null) tmp.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
