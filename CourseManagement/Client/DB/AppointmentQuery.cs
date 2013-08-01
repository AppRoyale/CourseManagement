using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Client.DB.Model;
using System.Data;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Appointment
    /// </summary>
    public static class AppointmentQuery
    {
 
        /// <summary>
        /// Get all Appointments from database.
        /// </summary>
        /// <returns>List of Appointments</returns>
        public static List<Appointment> getAll()
        {
            try
            {
                List<Appointment> qry = (from appointment in DBConfiguration.getContext().Appointments.OfType<Appointment>()
                                         select appointment).ToList();
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
        /// Add's the submitted Appointment to database.
        /// </summary>
        /// <param name="appointment"></param>
        public static void insert(Appointment appointment)
        {
            try
            {
                DBConfiguration.getContext().Appointments.Add(appointment);
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
        /// Deletes the submitted Appointment from the database.
        /// </summary>
        /// <param name="appointment"></param>
        public static void delete(Appointment appointment)
        {
            try
            {
                DBConfiguration.getContext().Appointments.Remove(appointment);
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
        /// Returns the Appointment who is bound to the given ID.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns>Student</returns>
        public static Appointment getById(int appointmentId)
        {
            try
            {
                return (DBConfiguration.getContext().Appointments.Find(appointmentId)) as Appointment;
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
        /// <param name="appointment"></param>
        public static void update(Appointment appointment)
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
               
    }
}