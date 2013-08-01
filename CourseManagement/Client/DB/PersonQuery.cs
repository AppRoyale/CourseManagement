using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Client.DB.Model;
using System.Data;


namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Person
    /// </summary>
    public static class PersonQuery
    {
        /// <summary>
        /// Get all Students from database.
        /// </summary>
        /// <returns>List of Students</returns>
        public static List<Person> getAll()
        {
            try
            {
                List<Person> qry = (from person in DBConfiguration.getContext().Persons
                                    select person).ToList();

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
        /// <param name="person"></param>
        public static void insert(Person person)
        {
            try
            {
                DBConfiguration.getContext().Persons.Add(person);
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
        /// <param name="person"></param>
        public static void delete(Person person)
        {
            try
            {
                DBConfiguration.getContext().Persons.Remove(person);
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
        /// <param name="personId"></param>
        /// <returns>Student</returns>
        public static Person getById(int personId)
        {
            try
            {
                return (DBConfiguration.getContext().Persons.Find(personId));
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
        /// <param name="person"></param>
        public static void update(Person person)
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
    }

}
