using System;
using System.Collections.Generic;


namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person_Student Model
    /// </summary>
    public partial class Student : Person
    {
        /// <summary>
        /// Calls the Database Query which adds a Person_Student to the Database
        /// </summary>
        public override void addToDB()
        {
            try
            {
                StudentQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Person_Students
        /// </summary>
        /// <returns>Person_Students</returns>
        public static new List<Student> getAll()
        {
            try
            {
                return StudentQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Person_Student
        /// </summary>
        public override void delete()
        {
            try
            {
                StudentQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Person_Student
        /// </summary>
        public override void update()
        {
            try
            {
                StudentQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Person_Student by Id
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Person_Student</returns>
        public static new Student getById(int studentId)
        {
            try
            {
                return StudentQuery.getById(studentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }    
    }
}
