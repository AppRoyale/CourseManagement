using CourseManagement.Client.DB.Model;
using System;
using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all logical operations of a Tutor
    /// Implements some standard operations from the AbstractLogic
    /// </summary>
    public class TutorLogic:AbstractLogic
    {
        private TutorLogic() { }

        /// <summary>
        /// Getting an instance of TutorLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static TutorLogic getInstance()
        {
            TutorLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new TutorLogic();
            return temp;
        }

        /// <summary>
        /// Returns a DataTable containing all Tutors in DB
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allTutors = getNewDataTable();


                foreach (Tutor tutor in Tutor.getAll())
                {
                    allTutors.Rows.Add(getNewRow(allTutors, tutor));
                }

                return allTutors;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Returns a DataTable containing all Tutors in DB
        /// with the search-Value in Forename, Surname or tutorNr
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allTutors = getNewDataTable();

                foreach (Tutor tutor in Tutor.getAll())
                {
                    if (LogicUtils.notNullAndContains(tutor.Forename, search)
                        || LogicUtils.notNullAndContains(tutor.Surname, search)
                        || LogicUtils.notNullAndContains(tutor.Id, search))
                    {
                        allTutors.Rows.Add(getNewRow(allTutors, tutor));
                    }
                }

                return allTutors;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Method for specific TutorDataTable-changes to the default DataTable-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            DataTable table = LogicUtils.getNewDataTable(new Tutor());
            table.Columns["Courses"].SetOrdinal(table.Columns.Count - 1);
            
            return table;
        }

        /// <summary>
        /// Method for specific TutorRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tutor"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, Tutor tutor)
        {
            DataRow row = LogicUtils.getNewRow(table, tutor);
            row["Courses"] = tutor.Courses.Count;
            return row;
        }


        /// <summary>
        /// Creates a new Tutor in the database
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="birthyear"></param>
        /// <param name="street"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="mail"></param>
        /// <param name="fax"></param>
        /// <param name="privatePhone"></param>
        /// <param name="gender"></param>
        /// <param name="isActive"></param>
        /// <param name="title"></param>
        /// <param name="city"></param>
        /// <param name="citycode"></param>
        public int create( string surname, string forename, string birthyear, string street,
             string mobilePhone, string mail, string fax, string privatePhone, string gender,
             bool? isActive, string title, string city, string citycode)
        {
            try
            {
                Tutor tutor = new Tutor();
                tutor.Surname = surname;
                tutor.Forename = forename;
                tutor.Birthyear = birthyear;
                tutor.Street = street;
                tutor.MobilePhone = mobilePhone;
                tutor.Mail = mail;
                tutor.Fax = fax;
                tutor.PrivatePhone = privatePhone;
                tutor.Gender = gender;
                tutor.Active = isActive;
                tutor.Title = title;
                tutor.City = city;
                tutor.CityCode = citycode;

                tutor.addToDB();
                return tutor.Id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Returns a DataTable containing one or zero Tutor.
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <returns></returns>
        public override DataTable getById(int tutorNr)
        {
            try
            {
                DataTable dtTutor = getNewDataTable();
                Tutor tutor = Tutor.getById(tutorNr);
                if (tutor != null)
                {
                    dtTutor.Rows.Add(getNewRow(dtTutor, tutor));
                }
                return dtTutor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  

        }


        /// <summary>
        /// Updates the Tutorproperties.
        /// Tupel will be find by tutornr
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <param name="surname"></param>
        /// <param name="forename"></param>
        /// <param name="birthyear"></param>
        /// <param name="street"></param>
        /// <param name="mobilePhone"></param>
        /// <param name="mail"></param>
        /// <param name="fax"></param>
        /// <param name="privatePhone"></param>
        /// <param name="gender"></param>
        /// <param name="isActive"></param>
        /// <param name="title"></param>
        /// <param name="city"></param>
        /// <param name="citycode"></param>
        public void changeProperties(int tutorNr, string surname, string forename, string birthyear, string street,
            string mobilePhone, string mail, string fax, string privatePhone, string gender,
            bool? isActive, string title, string city, string citycode)
        {
            try
            {
                Tutor tutor = Tutor.getById(tutorNr);
                tutor.Surname = surname;
                tutor.Forename = forename;
                tutor.Birthyear = birthyear;
                tutor.Street = street;
                tutor.MobilePhone = mobilePhone;
                tutor.Mail = mail;
                tutor.Fax = fax;
                tutor.PrivatePhone = privatePhone;
                tutor.Gender = gender;
                tutor.Active = isActive;
                tutor.Title = title;
                tutor.City = city;
                tutor.CityCode = citycode;

                tutor.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get one tutor by id manage the remove from database of this tutor
        /// </summary>
        /// <param name="tutorNr"></param>
        public override void delete(int tutorNr)
        {
            try
            {
                Tutor tutor = Tutor.getById(tutorNr);
                if (tutor != null && tutor.Courses.Count==0) tutor.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }
    }
}
