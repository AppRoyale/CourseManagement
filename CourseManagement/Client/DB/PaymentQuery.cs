using CourseManagement.Client.DB.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CourseManagement.Client.DB
{
    /// <summary>
    /// All Database Queries for the Entity Payment
    /// </summary>
    public static class PaymentQuery
    {
        /// <summary>
        /// Get all Payments from database.
        /// </summary>
        /// <returns>List of Payments</returns>
        public static List<Payment> getAll()
        {
            try
            {
                List<Payment> qry = (from payment in DBConfiguration.getContext().Payments.OfType<Payment>()
                                     select payment).ToList();
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
        /// Creates a new Payment for a Student, wich is also connected to a Course
        /// </summary>
        /// <param name="payment"></param>
        public static void insert(Payment payment)
        {
            try
            {
                DBConfiguration.getContext().Payments.Add(payment);
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
        /// Deletes the submitted Payment from the database.
        /// </summary>
        /// <param name="payment"></param>
        public static void delete(Payment payment)
        {
            try
            {
                DBConfiguration.getContext().Payments.Remove(payment);
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
        /// Saves all changes made on the DataContext.
        /// Parameter is Placeholder for a new database-layer
        /// </summary>
        /// <param name="payment"></param>
        public static void update(Payment payment)
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
        /// Returns the Payment who is bound to the given ID.
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>Payment</returns>
        public static Payment getById(int paymentId)
        {
            try
            {
                return (DBConfiguration.getContext().Payments.Find(paymentId)) as Payment;
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
