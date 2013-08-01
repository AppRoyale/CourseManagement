using System.Data;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Defines some abstract standard Methods for all Logical Operations
    /// </summary>
    public abstract class AbstractLogic
    {
        /// <summary>
        /// Get all Datasets of one Entity
        /// </summary>
        /// <returns></returns>
        public abstract DataTable getAll();

        /// <summary>
        /// Searching for a resultset of entities by a search string
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public abstract DataTable search(string search);

        /// <summary>
        /// Get one Entitie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract DataTable getById(int id);

        /// <summary>
        /// Deletes one Entitie by Id
        /// </summary>
        /// <param name="id"></param>
        public abstract void delete(int id);

        //public int create(mit unterschiedlichen Parametern je nach Entity) --- return ist die jeweilige id
        //public void changeProperties()
        
        //private DataTable getNewTable()
        //private DataRow getNewRow()
    }
}
