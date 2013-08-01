using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Client.DB.Model;
using System.Data;



namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Student
    /// </summary>
    public static class StudentQuery
    {
        /// <summary>
        /// Get all Students from database.
        /// </summary>
        /// <returns>List of Students</returns>
        public static List<Student> getAll()
        {
            try
            {
                List<Student> qry = (from student in DBConfiguration.getContext().Persons.OfType<Student>()
                                     select student).ToList();

                return qry;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Add's the submitted Student to database.
        /// </summary>
        /// <param name="student"></param>
        public static void insert(Student student)
        {
            try
            {
                DBConfiguration.getContext().Persons.Add(student);
                DBConfiguration.getContext().SaveChanges();
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deletes the submitted Student from the database.
        /// </summary>
        /// <param name="student"></param>
        public static void delete(Student student)
        {
            try
            {
                DBConfiguration.getContext().Persons.Remove(student);
                DBConfiguration.getContext().SaveChanges();
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns the Student who is bound to the given ID.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>Student</returns>
        public static Student getById(int studentId)
        {
            try
            {
                return (DBConfiguration.getContext().Persons.Find(studentId)) as Student;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="student"></param>
        public static void update(Student student)
        {
            try
            {
                DBConfiguration.getContext().SaveChanges();
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Searching for a tupel which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Student> search(string like)
        {
            try
            {
                List<Student> qry = new List<Student>();

                if (DBUtils.isNumber(like))
                {
                    int wert = Convert.ToInt32(like);
                    List<Student> listStudent = (from student in DBConfiguration.getContext().Persons.OfType<Student>()
                                                 select student).ToList();
                    foreach (Student student in listStudent)
                    {
                        if (student.Id.ToString().Contains(like)) qry.Add(student);
                    }
                }
                else
                {
                    like = like.ToUpper();
                    qry = (from student in DBConfiguration.getContext().Persons.OfType<Student>()
                           where student.Forename.ToUpper().Contains(like)
                           || student.Surname.ToUpper().Contains(like)
                           select student).ToList();
                }
                return qry;
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
