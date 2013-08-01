using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseManagement.Client.BusinessLogic;
using CourseManagement.Client.DB;
using CourseManagement.Client.DB.Model;
using System.Data;
using System.Data.EntityClient;
using System.IO;
using System.Reflection;


namespace TestCourseManagement
{
    class UnitHelper
    {
        /// <summary>
        /// Returns the ConnectionString for the testdb-Context
        /// </summary>
        /// <returns></returns>
        public static string getUnitConnectionString()
        {
            EntityConnectionStringBuilder ec = new EntityConnectionStringBuilder();
            ec.ProviderConnectionString = "data source=scott-speed.selfhost.bz;initial catalog=Diamondback;persist security info=True;user id=sa;password=Diamond2013;MultipleActiveResultSets=True;App=EntityFramework";
            string help = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))));
            help += "\\CourseManagement\\obj\\Debug\\edmxResourcesToEmbed\\Client\\DB\\Model\\DiamondbackModel";
            help = help + ".csdl|" + help + ".ssdl|" + help + ".msl";
            ec.Metadata = help;
            ec.Provider = "System.Data.SqlClient";
            return ec.ToString();
        }
    }
}
