using CourseManagement.Client.DB.Model;
using System;
using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Contains all logical operations of a Room
    /// Implements some standard operations from the AbstractLogic
    /// </summary>
    public class RoomLogic:AbstractLogic
    {
        private RoomLogic() { }

        /// <summary>
        /// Getting an instance of RoomLogic is only possible if
        /// a user is logged in.
        /// </summary>
        /// <returns></returns>
        public static RoomLogic getInstance()
        {
            RoomLogic temp = null;
            if (ActiveUser.userIsLoggedIn()) temp = new RoomLogic();
            return temp;
        }

        /// <summary>
        /// Creates a new room by the given parameters
        /// </summary>
        /// <param name="building"></param>
        /// <param name="capacity"></param>
        /// <param name="city"></param>
        /// <param name="cityCode"></param>
        /// <param name="street"></param>
        /// <returns></returns>
        public int create(String building, int? capacity, String city, String cityCode, String street)
        {
            try
            {
                Room room = new Room();
                room.Building = building;
                room.Capacity = capacity;
                room.City = city;
                room.CityCode = cityCode;
                room.Street = street;

                room.addToDB();
                return room.RoomNr;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Method for changing Properties of the Room with the submitted id.
        /// All Parameters have to be submitted.
        /// </summary>
        /// <param name="roomNr"></param>
        /// <param name="building"></param>
        /// <param name="capacity"></param>
        /// <param name="city"></param>
        /// <param name="cityCode"></param>
        /// <param name="street"></param>
        public void changeProperties(int roomNr, String building, int? capacity, String city, String cityCode, String street)
        {
            try
            {
                Room room = Room.getById(roomNr);
                room.Building = building;
                room.Capacity = capacity;
                room.City = city;
                room.CityCode = cityCode;
                room.RoomNr = roomNr;
                room.Street = street;

                room.update();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method for specific RoomDataTable-changes to the default DataTable-Method in LogicUtils
        /// </summary>
        /// <returns></returns>
        private DataTable getNewDataTable()
        {
            try
            {
                return LogicUtils.getNewDataTable(new Room());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Method for specific RoomRow-changes to the default Row-Method in LogicUtils
        /// </summary>
        /// <param name="table"></param>
        /// <param name="room"></param>
        /// <returns></returns>
        private DataRow getNewRow(DataTable table, Room room)
        {
            DataRow row = LogicUtils.getNewRow(table, room);
            row["Appointments"] = room.Appointments.Count;
            return row;
        }

        /// <summary>
        /// Creates a new datatable containing all rooms and returns this datatable
        /// </summary>
        /// <returns></returns>
        public override DataTable getAll()
        {
            try
            {
                DataTable allRooms = getNewDataTable();

                foreach (Room room in Room.getAll())
                {
                    allRooms.Rows.Add(getNewRow(allRooms, room));
                }

                return allRooms;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Search all rooms by the parameter in the columns roomNr, Street and Building
        /// A datatable with the resultset will be returned
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public override DataTable search(string search)
        {
            try
            {
                DataTable allRooms = getNewDataTable();

                foreach (Room room in Room.getAll())
                {
                    if (LogicUtils.notNullAndContains(room.Building, search)
                        || LogicUtils.notNullAndContains(room.Street, search)
                        || LogicUtils.notNullAndContains(room.RoomNr, search))
                    {
                        allRooms.Rows.Add(getNewRow(allRooms, room));
                    }
                }

                return allRooms;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Creates a datatable and get one Room by id and fills the datatable with all property names and
        /// the data from the Room
        /// </summary>
        /// <param name="roomNr"></param>
        /// <returns></returns>
        public override DataTable getById(int roomNr)
        {
            try
            {
                Room room = Room.getById(roomNr);
                DataTable aRoom = LogicUtils.getNewDataTable(room);
                if (room != null)
                {
                    aRoom.Rows.Add(getNewRow(aRoom, room));
                }

                return aRoom;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Get one Room by id manage the remove from database of this Room
        /// </summary>
        /// <param name="roomNr"></param>
        public override void delete(int roomNr)
        {
            try
            {
                Room room = Room.getById(roomNr);
                if (room != null && room.Appointments.Count==0) room.delete();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }  
        }

        /// <summary>
        /// Return a DataTable containing all Rooms of the submitted Course
        /// </summary>
        /// <param name="courseNr"></param>
        /// <returns></returns>
        public DataTable getByCourse(int courseNr)
        {
            try
            {
                DataTable courses = getNewDataTable();
                foreach (Appointment appointment in Course.getById(courseNr).Appointments)
                {
                    courses.Rows.Add(getNewRow(courses,appointment.Room));
                }
                return courses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Rooms of the submitted Student
        /// </summary>
        /// <param name="studentNr"></param>
        /// <returns></returns>
        public DataTable getByStudent(int studentNr)
        {
            try
            {
                DataTable courses = getNewDataTable();
                foreach (Payment payment in Student.getById(studentNr).Payments)
                {
                    foreach (Appointment appointment in payment.Course.Appointments)
                    {
                        courses.Rows.Add(getNewRow(courses, appointment.Room));
                    }
                }
                return courses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Return a DataTable containing all Rooms of the submitted Tutor
        /// </summary>
        /// <param name="tutorNr"></param>
        /// <returns></returns>
        public DataTable getByTutor(int tutorNr)
        {
            try
            {
                DataTable courses = getNewDataTable();
                foreach (Course course in Tutor.getById(tutorNr).Courses)
                {
                    foreach (Appointment appointment in course.Appointments)
                    {
                        courses.Rows.Add(getNewRow(courses, appointment.Room));
                    }
                }
                return courses;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
