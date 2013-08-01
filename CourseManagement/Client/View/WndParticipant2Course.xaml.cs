using CourseManagement.Client.BusinessLogic;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interactionslogic for wndParticipant2Course.xaml
    /// </summary>
    public partial class WndParticipant2Course : Window
    {
        /// <summary>
        /// Temporary Data Storage with either all courses or all students
        /// to fill the listboxes
        /// </summary>
        DataTable temporaryData = CourseLogic.getInstance().getAll();
        
        int selectedCourse = 0;

        /// <summary>
        /// Standard contructor 
        /// </summary>
        public WndParticipant2Course()
        {
            InitializeComponent();
            fillingListboxeswithData();
        }

        /// <summary>
        /// Custom contructor. Needed when a course was already chosen in main window
        /// </summary>
        /// <param name="selectedCourseFromMainWindow"></param>
        public WndParticipant2Course(int selectedCourseFromMainWindow)
        {
            InitializeComponent();

            fillingListboxeswithData();

            foreach (ListBoxItem aListboxItem in lbxCourses.Items)
            {
                if (Convert.ToInt32(aListboxItem.Tag) == selectedCourseFromMainWindow)
                {
                    lbxCourses.SelectedItem = aListboxItem;
                }
            }
        }

        /// <summary>
        /// Fills left listbox with all courses and right listbox with all students
        /// </summary>
        private void fillingListboxeswithData()
        {            
            foreach (DataRow aDataRow in temporaryData.Rows)
            {
                ListBoxItem ListboxItemCourse = new ListBoxItem();
                ListboxItemCourse.Content = aDataRow["Title"];
                ListboxItemCourse.Tag = aDataRow["CourseNr"];
                lbxCourses.Items.Add(ListboxItemCourse);            
            }
            temporaryData = StudentLogic.getInstance().getAll();
            foreach (DataRow aDataRow in temporaryData.Rows)
            {
                ListBoxItem ListBoxItemStudents = new ListBoxItem();
                string aString = aDataRow["Surname"].ToString() + " " + aDataRow["Forename"].ToString();
                ListBoxItemStudents.Content = aString;
                ListBoxItemStudents.Tag = aDataRow["Id"];
                lbxParticipants.Items.Add(ListBoxItemStudents);
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// Shows every student which is in the course in green color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = Convert.ToInt32(((ListBoxItem)lbxCourses.SelectedItem).Tag);
            DataTable studentsFromSelectedCourse = StudentLogic.getInstance().getByCourse(selectedCourse);

            foreach (ListBoxItem aListBoxItem in lbxParticipants.Items)
            {
                aListBoxItem.Foreground = Brushes.Black;
                foreach (DataRow dr in studentsFromSelectedCourse.Rows)
                {

                    if (Convert.ToInt32(dr["ID"]) == Convert.ToInt32(aListBoxItem.Tag))
                    {
                        aListBoxItem.Foreground = Brushes.Green;
                    }
                }
            }
        }

        /// <summary>
        /// Add selected student as participant to the course if not allready in the course
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddPerson2Course_CLick(object sender, RoutedEventArgs e)
        {
            if(lbxCourses.SelectedItem != null && lbxParticipants.SelectedItems != null)
            {
               foreach(ListBoxItem aListBoxItem in lbxParticipants.SelectedItems)
               {
                   //Every student that has allready been added to the selected course is colored green. this 
                   //secures that if a student is allready in the course he will not be added again
                   if (aListBoxItem.Foreground != Brushes.Green)  
                   {
                       int i = Convert.ToInt32(((ListBoxItem)aListBoxItem).Tag);
                       PaymentLogic.getInstance().create(selectedCourse, i);
                       aListBoxItem.Foreground = Brushes.Green;
                   }
               }
               lbxParticipants.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Removes student from the course if he is listed as a participant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemovePersonFromCourse_CLick(object sender, RoutedEventArgs e)
        {
            if (lbxCourses.SelectedItem != null && lbxParticipants.SelectedItems != null)
            {
                DataTable allPaymentsFromCourse = PaymentLogic.getInstance().getByCourse(selectedCourse);
                foreach (DataRow aDataRow in allPaymentsFromCourse.Rows)
                {
                    foreach (ListBoxItem aListBoxItem in lbxParticipants.SelectedItems)
                    {
                        if (Convert.ToInt32(aDataRow["StudentNr"]) == Convert.ToInt32((aListBoxItem).Tag))
                        {
                            //at this point eventually check if the student has allready paid? 
                            // reason is that a student who has paid will not be removed from course without another user input
                            int payment2Delete = Convert.ToInt32(aDataRow["Id"]);
                            PaymentLogic.getInstance().delete(payment2Delete);
                            aListBoxItem.Foreground = Brushes.Black;
                        }
                    }                    
                }
                lbxParticipants.SelectedIndex = -1;
            }
        }
    }
}
