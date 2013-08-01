using System;
using System.Collections.Generic;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Acts like a controler for the PaymentModel
    /// </summary>
    public partial class Payment
    {
        /// <summary>
        /// Calls the Database Query which adds a Payment to the Database
        /// </summary>
        public void addToDB()
        {
            try
            {
                PaymentQuery.insert(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which gets a List of all Payment
        /// </summary>
        /// <returns>Payment</returns>
        public static List<Payment> getAll()
        {
            try
            {
                return PaymentQuery.getAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which deletes the selected Payment
        /// </summary>
        public void delete()
        {
            try
            {
                PaymentQuery.delete(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which calls a Payment by Id
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns>Payment</returns>
        public static Payment getById(int paymentId)
        {
            try
            {
                return PaymentQuery.getById(paymentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Calls the Database Query which updates the selected Payment
        /// </summary>
        public virtual void update()
        {
            try
            {
                PaymentQuery.update(this);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
