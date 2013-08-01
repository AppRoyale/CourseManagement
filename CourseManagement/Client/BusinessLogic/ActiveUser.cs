using System;
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Responsible class for the logged in user
    /// </summary>
    public static class ActiveUser
    {
        private static User currentUser = null;

        /// <summary>
        /// Log in a User by checking userName and correct password.
        /// Log in a user is not possible while a user is logged in.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool login(string userName, string password)
        {
            try
            {
                bool loginSuccessful = false;

                User userToCheck = User.getByUserName(userName);

                if (!userIsLoggedIn() && userToCheck != null &&
                    userToCheck.Active == true && userToCheck.Password == password)
                {
                    loginSuccessful = true;
                    currentUser = userToCheck;
                    currentUser.LastLogin = DateTime.Now;
                    currentUser.update();
                }
                return loginSuccessful;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Logout the current User and close the DB-Connection
        /// </summary>
        public static void logout()
        {
            try
            {
                currentUser = null;
                ActiveUserActions.closeContext();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// change the password of the logged in user
        /// </summary>
        /// <param name="newPassword"></param>
        public static bool changePassword(string newPassword)
        {
            try
            {
                bool changed = false;
                if (userIsLoggedIn() && possiblePassword(newPassword))
                {
                    currentUser.Password = newPassword;
                    changed = true;
                    currentUser.update();
                }
                return changed;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return true if a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static bool userIsLoggedIn()
        {
                return currentUser != null;
        }

        /// <summary>
        /// Return true if the current user is an admin
        /// </summary>
        /// <returns></returns>
        public static bool userIsAdmin()
        {
            try
            {
                bool isAdmin = false;
                if (userIsLoggedIn()) isAdmin = currentUser.Admin.GetValueOrDefault(false);
                return isAdmin;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Check rules for a new password
        /// length>=6,
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool possiblePassword(string newPassword)
        {
            return newPassword.Length >= 5;
        }


        /// <summary>
        /// check if the submitted password is the password of the active user
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool correctPasswort(string password)
        {
            return currentUser.Password == password;
        }

    }
}
