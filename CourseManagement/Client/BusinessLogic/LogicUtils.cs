using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Some Utilities for the Logical Operations
    /// </summary>
    public static class LogicUtils
    {

        /// <summary>
        /// Return a DataTable with 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="additionalColumnNames"></param>
        /// <returns></returns>
        public static DataTable getNewDataTable(object entity, params string[] additionalColumnNames)
        {
            try
            {
                DataTable table = new DataTable();
                foreach (PropertyInfo pi in entity.GetType().GetProperties())
                {
                    table.Columns.Add(pi.Name);
                }
                foreach (string s in additionalColumnNames)
                {
                    table.Columns.Add(s);
                }
                return table;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a list with all propertyNames of the submitted object
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static List<string> getPropertyNames(object entity)
        {
            try
            {
                List<string> names = new List<string>();
                foreach (PropertyInfo pi in entity.GetType().GetProperties())
                {
                    names.Add(pi.Name);
                }
                return names;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns true if the given string is not null
        /// and contains the given string 
        /// </summary>
        public static bool notNullAndContains(string stringToCheck, string like)
        {
            bool result = false;
            if (stringToCheck != null && stringToCheck.ToUpper().Contains(like.ToUpper())) result = true;
            return result;
        }

        /// <summary>
        /// Returns true if the given int? is not null
        /// and cointains the given string
        /// </summary>
        /// <param name="intToCheck"></param>
        /// <param name="like"></param>
        /// <returns></returns>
        public static bool notNullAndContains(int? intToCheck, string like)
        {
            bool result = false;
            if (intToCheck.HasValue) result = notNullAndContains(intToCheck.ToString(), like);
            return result;
        }

        /// <summary>
        /// Create the default DataRow for entity-DataTables
        /// </summary>
        /// <param name="table"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DataRow getNewRow(DataTable table, object entity)
        {
            try
            {
                DataRow row = table.NewRow();
                List<String> names = getPropertyNames(entity);
                for (int i = 0; i < names.Count; i++)
                {
                    row[names[i]] = entity.GetType().GetProperty(names[i]).GetMethod.Invoke(entity, null);
                }
                return row;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
