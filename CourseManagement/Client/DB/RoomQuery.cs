using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Room
    /// </summary>
    public static class RoomQuery
    {
        /// <summary>
        /// Get all Rooms from database.
        /// </summary>
        /// <returns>List of Rooms</returns>
        public static List<Room> getAll()
        {
            try
            {
                List<Room> qry = (from room in DBConfiguration.getContext().Rooms.OfType<Room>()
                                  select room).ToList();
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
        /// Add's the submitted Room to database.
        /// </summary>
        /// <param name="room"></param>
        public static void insert(Room room)
        {
            try
            {
                DBConfiguration.getContext().Rooms.Add(room);
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
        /// Deletes the submitted Room from the database.
        /// </summary>
        /// <param name="room"></param>
        public static void delete(Room room)
        {
            try
            {
                DBConfiguration.getContext().Rooms.Remove(room);
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
        /// Returns the Room who is bound to the given ID.
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns>Student</returns>
        public static Room getById(int roomId)
        {
            try
            {
                return (DBConfiguration.getContext().Rooms.Find(roomId)) as Room;
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
        /// <param name="room"></param>
        public static void update(Room room)
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

        /// <summary>
        /// Searching for a tupel of Tutor which contains the submitted string
        /// in property: Forename, Surname, Id
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        public static List<Tutor> search(String like)
        {
            try
            {
                List<Tutor> qry = new List<Tutor>();

                if (DBUtils.isNumber(like))
                {
                    int wert = Convert.ToInt32(like);
                    List<Tutor> listTutor = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                                             select tutor).ToList();
                    foreach (Tutor tutor in listTutor)
                    {
                        if (tutor.Id.ToString().Contains(like)) qry.Add(tutor);
                    }
                }
                else
                {
                    like = like.ToUpper();
                    qry = (from tutor in DBConfiguration.getContext().Persons.OfType<Tutor>()
                           where tutor.Forename.ToUpper().Contains(like)
                           || tutor.Surname.ToUpper().Contains(like)
                           select tutor).ToList();
                }
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
    }
}
