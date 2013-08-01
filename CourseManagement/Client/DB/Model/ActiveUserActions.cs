using System;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the ActiveUser
    /// </summary>
    public static class ActiveUserActions
    {
        /// <summary>
        /// Close the DB-Connection
        /// </summary>
        public static void closeContext()
        {
            try
            {
                DBConfiguration.closeContext();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
