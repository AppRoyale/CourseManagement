using CourseManagement.Client.DB.Model;
using System;
using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all logical operations of a Student
    /// Implements some standard operations from the AbstractLogic
    /// </summary>
    public class StudentLogic:AbstractLogic
    {
        private StudentLogic() { }

        /// <summary>
        /// Getting an instance of StudentLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static StudentLogic getInstance()
        {
            StudentLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new StudentLogic();
            return temp;
        }

        /// <summary>
        /// Returns a DataTable containing all Students in DB
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allStudents = getNewDataTable();


                foreach (Student student in Student.getAll())
                {
                    allStudents.Rows.Add(getNewRow(allStudents,student));
                }

                return allStudents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Search all students by the parameter in the columns studentNr, surname and forename
        /// A datatable with the resultset will be returned
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allStudents = getNewDataTable();

                foreach (Student student in Student.getAll())
                {
                    if (LogicUtils.notNullAndContains(student.Forename, search)
                        || LogicUtils.notNullAndContains(student.Surname, search)
                        || LogicUtils.notNullAndContains(student.Id,search))
                    {
                        allStudents.Rows.Add(getNewRow(allStudents,student));
                    }
                }

                return allStudents;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }
        
        /// <summary>
        /// Method for specific StudentDataTable-changes to the default DataTable-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            DataTable table = LogicUtils.getNewDataTable(new Student());

            return table;
            
        }

        /// <summary>
        /// Method for specific StudentRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, Student student)
        {
            DataRow row = LogicUtils.getNewRow(table, student);
            row["Payments"] = student.Payments.Count;
            return row;
        }

        /// <summary>
        /// Creates a new Student in the database and return the studentNr
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="birthyear"></param>
        /// <param name="street"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="mail"></param>
        /// <param name="fax"></param>
        /// <param name="privatePhone"></param>
        /// <param name="gender"></param>
        /// <param name="active"></param>
        /// <param name="title"></param>
        /// <param name="city"></param>
        /// <param name="citycode"></param>
        /// <param name="iban"></param>
        /// <param name="bic"></param>
        /// <param name="depositor"></param>
        /// <param name="nameOfBank"></param>
        /// <returns></returns>
        public int create(string surname, string forename, string birthyear, string street,
            string mobilePhone, string mail, string fax, string privatePhone, string gender,
            bool active, string title, string city, string citycode, string iban, string bic,
            string depositor, string nameOfBank)
        {
            try
            {
                Student student = new Student();
                student.Surname = surname;
                student.Forename = forename;
                student.Birthyear = birthyear;
                student.Street = street;
                student.MobilePhone = mobilePhone;
                student.Mail = mail;
                student.Fax = fax;
                student.PrivatePhone = privatePhone;
                student.Gender = gender;
                student.Active = active;
                student.Title = title;
                student.City = city;
                student.CityCode = citycode;
                student.IBAN = iban;
                student.BIC = bic;
                student.Depositor = depositor;
                student.NameOfBank = nameOfBank;

                student.addToDB();
                return student.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Creates a new Student in the database and return the studentNr
        /// </summary>
        /// <param name="studentNr"></param>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="birthyear"></param>
        /// <param name="street"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="mail"></param>
        /// <param name="fax"></param>
        /// <param name="privatePhone"></param>
        /// <param name="gender"></param>
        /// <param name="isActive"></param>
        /// <param name="title"></param>
        /// <param name="city"></param>
        /// <param name="citycode"></param>
        /// <param name="iban"></param>
        /// <param name="bic"></param>
        /// <param name="depositor"></param>
        /// <param name="nameOfBank"></param>
        public void changeProperties(int studentNr,string surname, string forename, string birthyear, string street,
            string mobilePhone, string mail, string fax, string privatePhone, string gender,
            bool? isActive, string title, string city, string citycode, string iban, string bic,
            string depositor, string nameOfBank)
        {
            try
            {
                Student student = Student.getById(studentNr);
                student.Surname = surname;
                student.Forename = forename;
                student.Birthyear = birthyear;
                student.Street = street;
                student.MobilePhone = mobilePhone;
                student.Mail = mail;
                student.Fax = fax;
                student.PrivatePhone = privatePhone;
                student.Gender = gender;
                student.Active = isActive;
                student.Title = title;
                student.City = city;
                student.CityCode = citycode;
                student.IBAN = iban;
                student.BIC = bic;
                student.Depositor = depositor;
                student.NameOfBank = nameOfBank;

                student.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Student.
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public override DataTable getById(int studentNr)
        {
            try
            {
                DataTable dtStudent = getNewDataTable();
                Student student = Student.getById(studentNr);
                if (student != null)
                {
                    dtStudent.Rows.Add(getNewRow(dtStudent, student));
                }
                return dtStudent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Get one student by id manage the remove from database of this student
        /// </summary>
        /// <param name="studentNr"></param>
        public override void delete(int studentNr)
        {
            try
            {
                Student student = Student.getById(studentNr);
                if (student != null && student.Payments.Count == 0) student.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Return a DataTable containing all Students of the submitted Cours
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        public DataTable getByCourse(int courseNr)
        {
            try
            {
                DataTable students = getNewDataTable();
                foreach (Payment payment in Course.getById(courseNr).Payments)
                {
                    students.Rows.Add(getNewRow(students, payment.Student));
                }

                return students;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
