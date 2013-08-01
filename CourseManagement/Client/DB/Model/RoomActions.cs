using System;
using System.Collections.Generic;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the Person Model
    /// </summary>
    public partial class Room
    {
        /// <summary>
        /// Calls the Database Query for inserting a Room
        /// </summary>
        public void addToDB()
        {
            try
            {
                RoomQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query to get all Rooms
        /// </summary>
        /// <returns>A List of all Rooms</returns>
        public static List<Room> getAll()
        {
            try
            {
                return RoomQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes a Room
        /// </summary>
        public void delete()
        {
            try
            {
                RoomQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates a Room
        /// </summary>
        public void update()
        {
            try
            {
                RoomQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which get one Room by Id
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Room</returns>
        public static Room getById(int roomId)
        {
            try
            {
                return RoomQuery.getById(roomId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
