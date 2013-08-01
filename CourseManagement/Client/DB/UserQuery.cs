using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity User
    /// </summary>
    public static class UserQuery
    {
        /// <summary>
        /// Get all Users from database.
        /// </summary>
        /// <returns>List of Users</returns>
        public static List<User> getAll()
        {
            try
            {
                List<User> qry = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                                  select user).ToList();
                return qry;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Add's the submitted User to database.
        /// </summary>
        /// <param name="user"></param>
        public static void insert(User user)
        {
            try
            {
                DBConfiguration.getContext().Persons.Add(user);
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
        /// Deletes the submitted User from the database.
        /// </summary>
        /// <param name="user"></param>
        public static void delete(User user)
        {
            try
            {
                DBConfiguration.getContext().Persons.Remove(user);
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
        /// Returns the User who is bound to the given ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Student</returns>
        public static User getById(int userId)
        {
            try
            {
                return (DBConfiguration.getContext().Persons.Find(userId)) as User;
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
        /// <param name="user"></param>
        public static void update(User user)
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
        /// Searching for a tupel of User which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<User> search(String like)
        {
            try
            {
                List<User> qry = new List<User>();

                if (DBUtils.isNumber(like))
                {
                    int wert = Convert.ToInt32(like);
                    List<User> listUser = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                                           select user).ToList();
                    foreach (User user in listUser)
                    {
                        if (user.Id.ToString().Contains(like)) qry.Add(user);
                    }
                }
                else
                {
                    like = like.ToUpper();
                    qry = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                           where user.Forename.ToUpper().Contains(like)
                           || user.Surname.ToUpper().Contains(like)
                           select user).ToList();
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

        /// <summary>
        /// Return a user or null.
        /// Search for the username in DB
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static User getByUserName(string userName)
        {
            try
            {
                User qry = null;
                if (userName != "" && userName != null)
                {
                    try
                    {
                        qry = (from user in DBConfiguration.getContext().Persons.OfType<User>()
                               where user.UserName.Equals(userName)
                               select user).FirstOrDefault();
                    }
                    catch (EntityException e)
                    {
                        throw new Exception(e.Message);
                    }
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
