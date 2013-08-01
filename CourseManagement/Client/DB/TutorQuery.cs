using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Client.DB.Model;
using System.Data;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Tutor
    /// </summary>
    public static class TutorQuery
    {
        /// <summary>
        /// Get all Users from database.
        /// </summary>
        /// <returns>List of Tutors</returns>
        public static List<Tutor> getAll()
        {
            try
            {
                List<Tutor> qry = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                                   select tutor).ToList();

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
        /// Add's the submitted Tutor to database.
        /// </summary>
        /// <param name="tutor"></param>
        public static void insert(Tutor tutor)
        {
            try
            {
                DBConfiguration.getContext().Persons.Add(tutor);
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
        /// Deletes the submitted Tutor from the database.
        /// </summary>
        /// <param name="tutor"></param>
        public static void delete(Tutor tutor)
        {
            try
            {
                DBConfiguration.getContext().Persons.Remove(tutor);
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
        /// Returns the Tutor who is bound to the given ID.
        /// </summary>
        /// <param name="tutorId"></param>
        /// <returns>Student</returns>
        public static Tutor getById(int tutorId)
        {
            try
            {
                return (DBConfiguration.getContext().Persons.Find(tutorId)) as Tutor;
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
        /// <param name="tutor"></param>
        public static void update(Tutor tutor)
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
        /// Searching for a tupel of Tutor which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Tutor> search(String like)
        {
            try
            {
                List<Tutor> qry = new List<Tutor>();

                if (DBUtils.isNumber(like))
                {
                    int wert = Convert.ToInt32(like);
                    List<Tutor> listTutor = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                                             select tutor).ToList();
                    foreach (Tutor tutor in listTutor)
                    {
                        if (tutor.Id.ToString().Contains(like)) qry.Add(tutor);
                    }
                }
                else
                {
                    like = like.ToUpper();
                    qry = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                           where tutor.Forename.ToUpper().Contains(like)
                           || tutor.Surname.ToUpper().Contains(like)
                           select tutor).ToList();
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