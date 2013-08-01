using System;
using System.Data;
using CourseManagement.Client.DB.Model;


namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all Methods for the interaction between Co
    /// </summary>
    public class CourseLogic:AbstractLogic
    {
        private CourseLogic() { }

        /// <summary>
        /// Getting an instance of CourseLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static CourseLogic getInstance()
        {
            CourseLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new CourseLogic();
            return temp;
        }
        
        /// <summary>
        /// Creates a datatable and fills it with the property names and all the data
        /// from the entity Courses
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allCourses = getNewDataTable();
                foreach (Course course in Course.getAll())
                {
                    allCourses.Rows.Add(getNewRow(allCourses, course));
                }


                return allCourses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Creates a new Course by the given parameters
        /// </summary>
        /// <param name="title"></param>
        /// <param name="amountInEuro"></param>
        /// <param name="description"></param>
        /// <param name="maxMember"></param>
        /// <param name="minMember"></param>
        /// <param name="tutorNr"></param>
        /// <param name="validityInMonth"></param>
        /// <returns></returns>
        public int create(String title, decimal? amountInEuro, String description, int? maxMember, int? minMember, int tutorNr,
                                         int? validityInMonth)
        {
            try
            {
                Course course = new Course();
                course.Title = title;
                course.AmountInEuro = amountInEuro;
                course.Description = description;
                course.MaxMember = maxMember;
                course.MinMember = minMember;
                if (maxMember < minMember)
                {
                    course.MaxMember = course.MinMember = null;
                }
                course.Tutor = Tutor.getById(tutorNr);
                course.ValidityInMonth = validityInMonth;
                course.addToDB();
                return course.CourseNr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }
        
        /// <summary>
        /// Method for changing Properties of the Course with the submitted id.
        /// All Parameters have to be submitted.
        /// </summary>
        /// <param name="courseNr"></param>
        /// <param name="title"></param>
        /// <param name="amountInEuro"></param>
        /// <param name="description"></param>
        /// <param name="maxMember"></param>
        /// <param name="minMember"></param>
        /// <param name="tutorNr"></param>
        /// <param name="validityInMonth"></param>
        public void changeProperties(int courseNr, String title, decimal? amountInEuro, String description, int? maxMember, 
            int? minMember, int? tutorNr, int? validityInMonth)
        {
            try
            {
                Course course = Course.getById(courseNr);
                course.Title = title;
                course.AmountInEuro = amountInEuro;
                course.Description = description;
                course.MaxMember = maxMember;
                course.MinMember = minMember;
                if (maxMember < minMember)
                {
                    course.MaxMember = course.MinMember = null;
                }
                if (tutorNr.HasValue)
                {
                    course.Tutor = Tutor.getById(tutorNr.Value);
                }
                course.ValidityInMonth = validityInMonth;
                course.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a datatable and get one Course by id and fills the datatable with all property names and
        /// the data from the Course
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        public override DataTable getById(int courseNr)
        {
            try
            {
                Course dtcourse = Course.getById(courseNr);
                DataTable aCourse = getNewDataTable();

                if (aCourse != null)
                {
                    aCourse.Rows.Add(getNewRow(aCourse, dtcourse));
                }

                return aCourse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Method for specific CourseRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, Course course)
        {
                DataRow row = LogicUtils.getNewRow(table,course);
                row["Tutor"] = course.Tutor.Surname + ", " + course.Tutor.Forename;
                row["Payments"] = course.Payments.Count;
                row["Appointments"] = course.Appointments.Count;

                return row;
        }

        /// <summary>
        /// Method for specific CourseTable-changes to the default Table-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            DataTable table = LogicUtils.getNewDataTable(new Course());
            
            return table;
        }

        /// <summary>
        /// Search all courses by the parameter in the columns CourseNr, Title and Description
        /// A datatable with the resultset will be returned
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allCourses = getNewDataTable();

                foreach (Course course in Course.getAll())
                {
                    if (LogicUtils.notNullAndContains(course.CourseNr, search)
                        || LogicUtils.notNullAndContains(course.Title, search)
                        || LogicUtils.notNullAndContains(course.Description, search))
                    {
                        allCourses.Rows.Add(getNewRow(allCourses, course));
                    }
                }

                return allCourses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Get one course by id manage the remove from database of this course
        /// </summary>
        /// <param name="courseNr"></param>
        public override void delete(int courseNr)
        {
            try
            {
                Course course = Course.getById(courseNr);
                if (course != null) course.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Return a DataTable containing all Courses of the submitted Student
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public DataTable getByStudent(int studentNr)
        {
            try
            {
                DataTable allOfStudent = getNewDataTable();
                foreach (Payment payment in Student.getById(studentNr).Payments )
                {
                    allOfStudent.Rows.Add(getNewRow(allOfStudent, payment.Course));
                }
                return allOfStudent;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  Return a DataTable containing all Courses of the submitted Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getByPerson(int id)
        {
            try
            {
                Person person = Person.getById(id);
                DataTable table = getNewDataTable();
                if (person is Student) table=  getByStudent(id);
                else if (person is Tutor) table = getByTutor(id);
                return table;

                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Courses of the submitted Tutor
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <returns></returns>
        public DataTable getByTutor(int tutorNr)
        {
            try
            {
                DataTable allOfTutor = getNewDataTable();
                foreach (Course course in Tutor.getById(tutorNr).Courses)
                {
                    allOfTutor.Rows.Add(getNewRow(allOfTutor, course));
                }
                return allOfTutor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calculates the overall amount from the selected course
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        public String getOverAllAmount(int courseNr)
        {
            try
            {
                decimal overallAmount = 0.0M;
                Course course = Course.getById(courseNr);

                overallAmount += (decimal)course.AmountInEuro;
                overallAmount *= course.Payments.Count;
                course.update();

                return overallAmount + " €";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calculates the amount of the selected course
        /// </summary>
        /// <param name="coursrNr"></param>
        /// <returns></returns>
        public String getBalance(int coursrNr)
        {
            try
            {
                decimal paidAmount = 0.0M;
                Course course = Course.getById(coursrNr);
                decimal courseAmount = (decimal)course.AmountInEuro;
                paidAmount += (courseAmount * course.Payments.Count);


                foreach (Payment payment in course.Payments)
                {
                    if (payment.IsPaid == true)
                    {
                        paidAmount -= courseAmount;
                        course.update();
                    }
                }

                return paidAmount + " €";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
