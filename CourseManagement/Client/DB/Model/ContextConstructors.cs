using System.Data.Entity;

namespace CourseManagement.Client.DB.Model
{
    /// <summary>
    /// Extends the DbContext
    /// </summary>
    public partial class DiamondbackModelContainer : DbContext
    {
        /// <summary>
        ///  Allows to change the database connection
        /// </summary>
        /// <param name="DBModelContainerNameOrConnectionString"></param>
        public DiamondbackModelContainer(string DBModelContainerNameOrConnectionString)
            : base(DBModelContainerNameOrConnectionString)
        {
        }
    }
}
