using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Client.DB.Model;
using System.Data;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Course
    /// </summary>
    public static class CourseQuery
    {
 
        /// <summary>
        /// Get all courses from database.
        /// </summary>
        /// <returns>List of courses</returns>
        public static List<Course> getAll()
        {
            try
            {
                List<Course> qry = (from course in DBConfiguration.getContext().Courses
                                    select course).ToList();


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
        /// Add's the submitted course to database.
        /// </summary>
        /// <param name="course"></param>
        public static void insert(Course course)
        {
            try
            {
                DBConfiguration.getContext().Courses.Add(course);
                update(course);
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
        /// Deletes the submitted course from the database.
        /// </summary>
        /// <param name="course"></param>
        public static void delete(Course course)
        {
            try
            {
                DBConfiguration.getContext().Courses.Remove(course);
                update(course);
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
        /// Returns the course who is bound to the given ID.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>Student</returns>
        public static Course getById(int courseId)
        {
            try
            {
                return (DBConfiguration.getContext().Courses.Find(courseId));
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
        /// <param name="course"></param>
        public static void update(Course course)
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
        /// Searching for a tupel of course which contains the submitted string
        /// in property: Title, CourseNr
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Course> search(string like)
        {
            try
            {
                List<Course> qry = new List<Course>();

                if (DBUtils.isNumber(like))
                {
                    int wert = Convert.ToInt32(like);
                    List<Course> listCourse = (from course in DBConfiguration.getContext().Courses
                                               select course).ToList();
                    foreach (Course course in listCourse)
                    {
                        if (course.CourseNr.ToString().Contains(like)) qry.Add(course);
                    }
                }
                else
                {
                    like = like.ToUpper();
                    qry = (from course in DBConfiguration.getContext().Courses
                           where course.Title.ToUpper().Contains(like)

                           select course).ToList();
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