using System;
using System.Collections.Generic;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Appointment Model
    /// </summary>
    public partial class Appointment
    {
        /// <summary>
        /// Calls the Database Query which adds a Appointment to the Database
        /// </summary>
        public void addToDB()
        {
            try
            {
                AppointmentQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Appointments
        /// </summary>
        /// <returns>Appointments</returns>
        public static List<Appointment> getAll()
        {
            try
            {
                return AppointmentQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Appointment
        /// </summary>
        public void delete()
        {
            try
            {
                AppointmentQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Appointment
        /// </summary>
        public void update()
        {
            try
            {
                AppointmentQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Appointment by Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>Appointment</returns>
        public static Appointment getById(int appointmentId)
        {
            try
            {
                return AppointmentQuery.getById(appointmentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
