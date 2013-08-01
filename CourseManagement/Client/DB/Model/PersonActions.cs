using System;
using System.Collections.Generic;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person Model
    /// </summary>
    public abstract partial class Person
    {
        /// <summary>
        /// Calls the Database Query which adds a Person to the Database
        /// </summary>
        public virtual void addToDB()
        {
            try
            {
                PersonQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Persons
        /// </summary>
        /// <returns>Persons</returns>
        public  static List<Person> getAll()
        {
            try
            {
                return PersonQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Person
        /// </summary>
        public virtual void delete()
        {
            try
            {
                PersonQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Person
        /// </summary>
        public virtual void update()
        {
            try
            {
                PersonQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Person by Id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>Person</returns>
        public  static Person getById(int personId)
        {
            try
            {
                return PersonQuery.getById(personId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
