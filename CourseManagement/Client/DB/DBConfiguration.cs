using System;
using CourseManagement.Client.DB.Model;
using System.Data;


namespace CourseManagement.Client.DB
{
    /// <summary>
    /// This class manage the Connection to the Database
    /// </summary>
    public static class DBConfiguration
    {

        private static DiamondbackModelContainer context = null;

        /// <summary>
        /// For using another Database then the default Database
        /// Realize that only one Database Access will be created
        /// You get also the same Database Access back
        /// </summary>
        /// <param name="dbModelNameOrConnectionString"></param>
        /// <returns></returns>
        public static DiamondbackModelContainer getContext(string dbModelNameOrConnectionString)
        {
            try
            {
                if (context == null) context = new DiamondbackModelContainer(dbModelNameOrConnectionString);
                return context;
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
        /// For using the default Database
        /// You get also the same Database Access back
        /// </summary>
        /// <returns></returns>
        public static DiamondbackModelContainer getContext()
        {
            try
            {
                return DBConfiguration.getContext("name=DiamondbackModelContainer");
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
        /// Closes the Database Access
        /// </summary>
        public static void closeContext()
        {
            try
            {
                context.SaveChanges();
                context.Dispose();
                context = null;
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
