using System;
using System.Collections.Generic;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Course Model
    /// </summary>
    public partial class Course
    {
        /// <summary>
        /// Calls the Database Query which adds a Course to the Database
        /// </summary>
        public void addToDB()
        {
            try
            {
                CourseQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Courses
        /// </summary>
        /// <returns>Courses</returns>
        public static List<Course> getAll()
        {
            try
            {
                return CourseQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Course
        /// </summary>
        public  void delete()
        {
            try
            {
                CourseQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Course
        /// </summary>
        public  void update()
        {
            try
            {
                CourseQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Course by Id
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns>Course</returns>
        public static Course getById(int courseNr)
        {
            try
            {
                return CourseQuery.getById(courseNr);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which search a resultset of Courses by a search-string
        /// </summary>
        /// <param name="like"></param>
        /// <returns>Courses</returns>
        public static List<Course> search(string like)
        {
            try
            {
                return CourseQuery.search(like);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
