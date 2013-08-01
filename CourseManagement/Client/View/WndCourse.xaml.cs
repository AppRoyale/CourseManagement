using CourseManagement.Client.BusinessLogic;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interactionlogic for WndCourse.xaml
    /// </summary>
    public partial class WndCourse : Window
    {
        private DataTable selectedCourse = null;
        private string titeL = "";
        private string description = "";
        private int validInMonths = 0;
        private int maxParticipants = 0;
        private int minParticipants = 0;
        private int tutor = 0;
        private decimal amountInEuro = 0;

        /// <summary>
        /// Standard constructor for window newCourse
        /// </summary>
        public WndCourse()
        {
            InitializeComponent();
            setGuiValues();
        }

        /// <summary>
        /// Custom constructor for changing a course
        /// </summary>
        /// <param name="selectedCourse"></param>
        public WndCourse(DataTable selectedCourse)
        {
            InitializeComponent();
            setGuiValues();

            this.selectedCourse = selectedCourse;
            lblCourse.Content = "Kurs bearbeiten";
            this.Title = "Kurs bearbeiten";


            fillingDataFieldsWithProvidedData();
        }

        /// <summary>
        /// Fills the data fields of this window with the data of the course that should be changed
        /// </summary>
        private void fillingDataFieldsWithProvidedData()
        {
            tbMaxParticipants.Text = selectedCourse.Rows[0]["MaxMember"].ToString();

            tbMinParticipants.Text = selectedCourse.Rows[0]["MinMember"].ToString();

            tbCourseTitle.Text = selectedCourse.Rows[0]["Title"].ToString();

            tbCosts.Text = selectedCourse.Rows[0]["AmountInEuro"].ToString();

            tbDescription.Text = selectedCourse.Rows[0]["Description"].ToString();

            tbValidInMonth.Text = selectedCourse.Rows[0]["ValidityInMonth"].ToString();

            foreach (ComboBoxItem cbItem in cbTutor.Items)
            {
                if (selectedCourse.Rows[0]["Tutor"].ToString() == cbItem.Content.ToString())
                {
                    cbTutor.SelectedItem = cbItem;
                }
            }
        }

        /// <summary>
        /// Fills the Combobox with all tutors
        /// </summary>
        private void setGuiValues()
        {
            DataTable allTutors = TutorLogic.getInstance().getAll();
            foreach (DataRow aDataRow in allTutors.Rows)
            {
                ComboBoxItem aComboBoxItem = new ComboBoxItem();
                string name = aDataRow["Surname"].ToString() + ", " + aDataRow["Forename"].ToString();
                aComboBoxItem.Content = name;
                aComboBoxItem.Tag = aDataRow["Id"];
                cbTutor.Items.Add(aComboBoxItem);
            }
        }

        /// <summary>
        /// Saves course in db if a tutor is selected
        /// </summary>
        private void insertCourse()
        {
            referencingLocalVariables();
            if(cbTutor.SelectedItem != null)
            {
                tutor = Convert.ToInt32(((ComboBoxItem)cbTutor.SelectedItem).Tag);
            try
            {
                if (selectedCourse == null)
                {
                    CourseLogic.getInstance().create(titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
                    this.DialogResult = true;
                }
                else
                {
                    int CourseNr = Convert.ToInt32(selectedCourse.Rows[0]["CourseNr"]);
                    CourseLogic.getInstance().changeProperties(CourseNr, titeL, amountInEuro, description, maxParticipants, minParticipants, tutor, validInMonths);
                    this.DialogResult = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler \nException:" + e.Message);
            }   
            }
            else { MessageBox.Show("Bitte Tutor auswählen"); }

        }

        /// <summary>
        /// Runs method to insert course in db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            insertCourse();
        }

        /// <summary>
        /// Closes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAport_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


        /// <summary>
        /// Referencing local variables with data from the textboxes
        /// </summary>
        private void referencingLocalVariables()
        {
            titeL = tbCourseTitle.Text;
            try { amountInEuro = Convert.ToDecimal(tbCosts.Text); }
            catch { amountInEuro = 0; }
            description = tbDescription.Text;
            try { maxParticipants = Convert.ToInt32(tbMaxParticipants.Text); }
            catch { amountInEuro = 0; }
            try { minParticipants = Convert.ToInt32(tbMinParticipants.Text); }
            catch { minParticipants = 0; }
            
            try { validInMonths = Convert.ToInt32(tbValidInMonth.Text); }
            catch { validInMonths = 0; }
        }
    }
}
