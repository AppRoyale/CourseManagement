using System;
using System.Collections.Generic;


namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person_Tutor Model
    /// </summary>
    public partial class Tutor : Person
    {
        /// <summary>
        /// Calls the Database Query which adds a Person_Tutor to the Database
        /// </summary>
        public override void addToDB()
        {
            try
            {
                TutorQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Person_Tutors
        /// </summary>
        /// <returns>Person_Tutors</returns>
        public static new List<Tutor> getAll()
        {
            try
            {
                return TutorQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Person_Tutor
        /// </summary>
        public override void delete()
        {
            try
            {
                TutorQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Person_Tutor
        /// </summary>
        public override void update()
        {
            try
            {
                TutorQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Person_Tutor by Id
        /// </summary>
        /// <param name="tutorId"></param>
        /// <returns>Person_Tutor</returns>
        public static new Tutor getById(int tutorId)
        {
            try
            {
                return TutorQuery.getById(tutorId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
