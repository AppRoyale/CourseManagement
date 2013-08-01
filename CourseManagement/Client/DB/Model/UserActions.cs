using System;
using System.Collections.Generic;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person_User Model
    /// </summary>
    public partial class User : Person
    {
        /// <summary>
        /// Calls the Database Query which adds a Person_User to the Database
        /// </summary>
        public override void addToDB()
        {
            try
            {
                UserQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Person_Users
        /// </summary>
        /// <returns>Person_Users</returns>
        public static new List<User> getAll()
        {
            try
            {
                return UserQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Person_User
        /// </summary>
        public override void delete()
        {
            try
            {
                UserQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Person_User
        /// </summary>
        public override void update()
        {
            try
            {
                UserQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Person_User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Person_User</returns>
        public static new User getById(int userId)
        {
            try
            {
                return UserQuery.getById(userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Person_User by username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Person_User</returns>
        public static User getByUserName(string userName)
        {
            try
            {
                return UserQuery.getByUserName(userName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
        }
    }
}
