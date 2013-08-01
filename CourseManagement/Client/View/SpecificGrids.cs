using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Class for uniform DataTables
    /// </summary>
    public static class SpecificTables
    {
        /// <summary>
        /// uniform DataTable for Person
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgPerson( DataGrid datagrid, DataTable table)
        {

            table.Columns["Title"].SetOrdinal(1);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["Active"].ToString() == "True") table.Rows[i]["Active"] = "ja";
                else if (table.Rows[i]["Active"].ToString() == "False") table.Rows[i]["Active"] = "nein";
            }

            datagrid.DataContext = table;
           
            changeColumnTitles(datagrid);

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for Student
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgStudent(DataGrid datagrid, DataTable table)
        {
            table.Columns["IBAN"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["BIC"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["Depositor"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["NameOfBank"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["Payments"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["Title"].SetOrdinal(1);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["Active"].ToString() == "True") table.Rows[i]["Active"] = "ja";
                else if (table.Rows[i]["Active"].ToString() == "False") table.Rows[i]["Active"] = "nein";
            }

            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[18].Header = "Kurse";

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for User
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgUser(DataGrid datagrid, DataTable table)
        {
            table.Columns["UserName"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["Password"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["LastLogin"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["RegistrationDate"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["Admin"].SetOrdinal(table.Columns.Count - 1);
            table.Columns["Title"].SetOrdinal(1);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["Active"].ToString() == "True") table.Rows[i]["Active"] = "ja";
                else if (table.Rows[i]["Active"].ToString() == "False") table.Rows[i]["Active"] = "nein";
                if (table.Rows[i]["Admin"].ToString() == "True") table.Rows[i]["Admin"] = "ja";
                else if (table.Rows[i]["Admin"].ToString() == "False") table.Rows[i]["Admin"] = "nein";
            }

            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for Appointment
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgAppointment(DataGrid datagrid, DataTable table)
        {
            table.Columns["CourseName"].SetOrdinal(4);  
 
            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[0].Visibility = Visibility.Hidden;

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for Course
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgCourse(DataGrid datagrid, DataTable table)
        {
            table.Columns["MinMember"].SetOrdinal(4);
            table.Columns["Description"].SetOrdinal(2);
            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[8].Header = "Teilnehmer";

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for Payment
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgPayment(DataGrid datagrid, DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["IsPaid"].ToString() == "True") table.Rows[i]["IsPaid"] = "ja";
                else if (table.Rows[i]["IsPaid"].ToString() == "False") table.Rows[i]["IsPaid"] = "nein";
            }

            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[0].Visibility = Visibility.Hidden;

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for Room
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgRoom(DataGrid datagrid, DataTable table)
        {
            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[2].Visibility = Visibility.Hidden;

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// uniform DataTable for Room
        /// </summary>
        /// <param name="table"></param>
        /// <param name="datagrid"></param>
        /// <returns></returns>
        public static void changeDgTutor(DataGrid datagrid, DataTable table)
        {
            table.Columns["Title"].SetOrdinal(1);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["Active"].ToString() == "True") table.Rows[i]["Active"] = "ja";
                else if (table.Rows[i]["Active"].ToString() == "False") table.Rows[i]["Active"] = "nein";
            }

            datagrid.DataContext = table;

            changeColumnTitles(datagrid);

            datagrid.Columns[datagrid.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        /// <summary>
        /// Changes the header of the submitted datagrid the german, if the english header is in the englishGerman-Array
        /// </summary>
        public static void changeColumnTitles(DataGrid datagrid)
        {
            string[,] englishGerman = new string[,] 
            {
                {"Id","Id"},{"IsPaid","Bezahlt"},{"Student","Student"},{"Course","Kurs-Nr."},{"CourseNr","Kurs-Nr."},{"Title","Titel"},
                {"AmountInEuro","Betrag in €"},{"Description","Beschreibung"},{"MaxMember","max. Teilnehmer"},{"MinMember","min. Teilnehmer"},
                {"ValidityInMonth","Gültigkeit (Monate)"},{"Tutor","Tutor"},{"Payments","Zahlungen"},{"Appointments","Termine"},
                {"RoomNr","RaumNr"},{"Capacity","Kapazität"},{"Building","Gebäude"},{"Street","Straße"},{"City","Stadt"},{"CityCode","PLZ"},
                {"StartDate","StartDatum"},{"EndDate","EndDatum"},{"Room","Raum"},{"Surname","Nachname"},{"Forename","Vorname"},
                {"Birthyear","Geburtsjahr"},{"MobilePhone","HandyNummer"},{"Mail","Mail"},{"Fax","Fax"},{"PrivatePhone","Telefon"},{"Gender","Geschlecht"},
                {"Active","Aktiv"},{"IBAN","IBAN"},{"BIC","BIC"},{"Depositor","Kontoinhaber"},{"NameOfBank","Bank"},{"UserName","Benutzername"},
                {"Password","Passwort"},{"LastLogin","LetztesLogin"},{"RegistrationDate","Registrierungsdatum"},  {"Admin","Admin"}, {"Courses","Kurse"},
                {"StudentName","StudentenName"}, {"CourseName","Kursbezeichnung"}
            };

            for (int i = 0; i < datagrid.Columns.Count; i++)
            {
                for (int j = 0; j < englishGerman.GetLength(0); j++)
                {
                    if (datagrid.Columns[i].Header.ToString() == englishGerman[j, 0]) datagrid.Columns[i].Header = englishGerman[j, 1];
                }
            }
            

        }

    }
}
