using CourseManagement.Client.BusinessLogic;
using System;
using System.Data;
using System.Windows;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interactionlogic for Room.xaml
    /// </summary>
    public partial class WndRoom : Window
    {

        private DataTable selectedRoom = null;
        private int capacity = 0;
        private string building = null;
        private string street = null;
        private string cityCode = null;
        private string city = null;
        private int roomNr = 0;

        /// <summary>
        /// default constructor for window room
        /// </summary>
        public WndRoom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Custom Constructor beeing called if user wants to change a room
        /// </summary>
        /// <param name="selectedRoom"></param>
        public WndRoom(DataTable selectedRoom)
        {
            InitializeComponent();

            lblNewRoom.Content = "Kurs bearbeiten";
            this.Title = "Kurs bearbeiten";
            this.selectedRoom = selectedRoom;

            setGuiElemntsToExistingCourseData();
        }

        /// <summary>
        /// Closes window if abort button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRoomAbort_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// runs method to insert course in db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveRoom_Click(object sender, RoutedEventArgs e)
        {
            insertRoom();
        }

        /// <summary>
        /// saves a room with the submitted data in the database
        /// </summary>
        private void insertRoom()
        {
            referencingLocalVariables();
            try
            {
                if (selectedRoom == null & roomNr == 0)
                {
                    RoomLogic.getInstance().create(building, capacity, city, cityCode, street);
                    this.DialogResult = true;
                }
                else
                {
                    RoomLogic.getInstance().changeProperties(roomNr, building, capacity, city, cityCode, street);
                    this.DialogResult = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Datenbankfehler. \nException " + e.Message);
            }
        }

        /// <summary>
        /// fills the textboxes of the window with previous user data
        /// of the room that should be changed
        /// </summary>
        /// <param name="selectedRoom"></param>
        private void setGuiElemntsToExistingCourseData()
        {
            roomNr = Convert.ToInt32(selectedRoom.Rows[0]["roomNr"]);
            tbCapacity.Text = selectedRoom.Rows[0]["capacity"].ToString();
            tbStreet.Text = selectedRoom.Rows[0]["street"].ToString();
            tbCityCode.Text = selectedRoom.Rows[0]["citycode"].ToString();
            tbCity.Text = selectedRoom.Rows[0]["city"].ToString();
        }



        /// <summary>
        /// referencing local variables with data from the textboxes
        /// </summary>
        /// <returns></returns>
        private void referencingLocalVariables()
        {
            street = tbStreet.Text.ToString();
            city = tbCity.Text.ToString();
            cityCode = tbCityCode.Text.ToString();
            try
            {
                capacity = Convert.ToInt32(tbCapacity.Text);
            }
            catch
            {
                capacity = 0;
            }
        }
    }
}
