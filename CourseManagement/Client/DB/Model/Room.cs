//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseManagement.Client.DB.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public Room()
        {
            this.Appointments = new HashSet<Appointment>();
        }
    
        public int RoomNr { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
    
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}