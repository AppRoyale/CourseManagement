using CourseManagement.Client.DB.Model;
using System;
using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all logical operations of a Appointment
    /// Implements some standard operations from the AbstractLogic
    /// </summary>
    public class AppointmentLogic:AbstractLogic
    {
        private AppointmentLogic() { }

        /// <summary>
        /// Getting an instance of AppointmentLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static AppointmentLogic getInstance()
        {
            AppointmentLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new AppointmentLogic();
            return temp;
        }
        
        /// <summary>
        /// Creates a new Appointment by the given parameters.
        /// liability to submit all parameter
        /// </summary>
        /// <param name="courseNr"></param>
        /// <param name="roomNr"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public int? create(int courseNr, int roomNr, DateTime startDate, DateTime endDate)
        {
            try
            {
                int? id = null;
                if(isPossibleNewAppointment(courseNr,roomNr,startDate,endDate))
                {
                Appointment appointment = new Appointment();
                appointment.Course = Course.getById(courseNr);
                appointment.Room = Room.getById(roomNr);
                appointment.StartDate = startDate;
                appointment.EndDate = endDate;

                appointment.addToDB();
                id = appointment.Id;
                }
                return id;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for specific AppointmentRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, Appointment appointment)
        {
            DataRow row = LogicUtils.getNewRow(table, appointment);
            row["Course"] = appointment.Course.CourseNr;
            row["Room"] = appointment.Room.RoomNr;
            row["CourseName"] = appointment.Course.Title;

            return row;
        }
        
        /// <summary>
        /// Method for specific AppointmentTable-changes to the default Table-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            DataTable table = LogicUtils.getNewDataTable(new Appointment(),"CourseName");
            return table;
        }

        /// <summary>
        /// Return a table with all Appointment's which are stored in DB.
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allAppointments = getNewDataTable();

                foreach (Appointment appointment in Appointment.getAll())
                {
                    allAppointments.Rows.Add(getNewRow(allAppointments,appointment));
                }
                return allAppointments;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Search all appointments by the parameter in the columns Id, RoomNr and CourseNr
        /// A datatable with the resultset will be returned
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allAppointments = getNewDataTable();

                foreach (Appointment appointment in Appointment.getAll())
                {
                    if (LogicUtils.notNullAndContains(appointment.Id, search)
                        || LogicUtils.notNullAndContains(appointment.Room.RoomNr, search)
                        || LogicUtils.notNullAndContains(appointment.Course.CourseNr, search))
                    {
                        allAppointments.Rows.Add(getNewRow(allAppointments, appointment));
                    }
                }

                return allAppointments;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a datatable and get one Appointment by id and fills the datatable with all property names and
        /// the data from the Appointment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override DataTable getById(int id)
        {
            try
            {
                DataTable dtappointment = getNewDataTable();
                Appointment appointment = Appointment.getById(id);
                if (appointment != null)
                {
                    dtappointment.Rows.Add(getNewRow(dtappointment, appointment));
                }
                return dtappointment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get one appointment by id manage the remove from database of this appointment
        /// </summary>
        /// <param name="appointmentNr"></param>
        public override void delete(int appointmentNr)
        {
            try
            {
                Appointment appointment = Appointment.getById(appointmentNr);
                if (appointment != null) appointment.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Return a DataTable containing all Appointments of the submitted course
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        public DataTable getByCourse(int courseNr)
        {
            try
            {
                DataTable allOfCourse = getNewDataTable();
                foreach (Appointment appointment in Course.getById(courseNr).Appointments)
                {
                    allOfCourse.Rows.Add(getNewRow(allOfCourse, appointment));
                }
                return allOfCourse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Appointments of the submitted Room
        /// </summary>
        /// <param name="roomNr"></param>
        /// <returns></returns>
        public DataTable getByRoom(int roomNr)
        {
            try
            {
                DataTable allOfRoom = getNewDataTable();
                foreach (Appointment appointment in Room.getById(roomNr).Appointments)
                {
                    allOfRoom.Rows.Add(getNewRow(allOfRoom, appointment));
                }
                return allOfRoom;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Appointments of the submitted Tutor
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <returns></returns>
        public DataTable getByTutor(int tutorNr)
        {
            try
            {
                DataTable allOfTutor = getNewDataTable();
                foreach (Course course in Tutor.getById(tutorNr).Courses)
                {
                    foreach (Appointment appointment in course.Appointments)
                    {
                        allOfTutor.Rows.Add(getNewRow(allOfTutor, appointment));
                    }
                }
                return allOfTutor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for changing Properties of the Appointment with the submitted id.
        /// All Parameters have to be submitted.
        /// </summary>
        /// <param name="idToChange"></param>
        /// <param name="courseNr"></param>
        /// <param name="roomNr"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void changeProperties(int idToChange,int courseNr, int roomNr, DateTime startDate, DateTime endDate)
        {
            try
            {
                Appointment appointment = Appointment.getById(idToChange);
                 appointment.Course = Course.getById(courseNr);
                 appointment.Room = Room.getById(roomNr);
                if(startDate!=null) appointment.StartDate = startDate;
                if (endDate !=null) appointment.EndDate = endDate;

                appointment.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Check if a new Appointment is possible with the submitted parameters.
        /// </summary>
        /// <param name="courseNr"></param>
        /// <param name="roomNr"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool isPossibleNewAppointment(int courseNr, int roomNr, DateTime startDate, DateTime endDate)
        {
            try
            {
                bool possible = true;

                foreach (Appointment appointment in Room.getById(roomNr).Appointments)
                {
                    if ((startDate > endDate) ||
                        (startDate >= appointment.StartDate && startDate < appointment.EndDate) ||
                        (endDate >= appointment.StartDate && endDate <= appointment.EndDate) ||
                        (startDate <= appointment.StartDate && endDate >= appointment.EndDate))
                    {
                        possible = false;
                    }
                }
                
                if (possible)
                {
                    foreach (Course course in Course.getById(courseNr).Tutor.Courses)
                    {
                        foreach (Appointment appointment in course.Appointments)
                        {
                            if ((startDate > endDate) ||
                                (startDate >= appointment.StartDate && startDate < appointment.EndDate) ||
                                (endDate >= appointment.StartDate && endDate <= appointment.EndDate) ||
                                (startDate <= appointment.StartDate && endDate >= appointment.EndDate))
                            {
                                possible = false;
                            }
                        }
                    }
                }
             
                return possible;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }      
    }
}
