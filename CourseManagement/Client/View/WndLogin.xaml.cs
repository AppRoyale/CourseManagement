using CourseManagement.Client.BusinessLogic;
using System;
using System.Windows;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndLogin.xaml
    /// </summary>
    public partial class WndLogin : Window
    {
        private int countLoginAttempts = 0;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WndLogin()
        {
            InitializeComponent(); 
        }

        /// <summary>
        /// Opens main window if password and username is correct
        /// in feature releases there could the function, that the user
        /// will be deactivated after a certain amount of attempts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (checkPassword(tbUsername.Text,pwbPassword.Password))
            {
                DialogResult = true;
            }
            else
            {
                tbPasswordStatus.Text = "Passwort falsch(" + ++countLoginAttempts + ". Versuch)";
            }
        }

        /// <summary>
        /// checks if submitted username and password are correct
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool checkPassword(string userName, string password)
        {
            bool passwordOkay = false;
            try
            {
                passwordOkay= ActiveUser.login(userName, password);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return passwordOkay;
        }


        /// <summary>
        /// Finish the application if login-window is closed by user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult.HasValue == false || DialogResult.Value == false)
            {
                Application.Current.Shutdown();
            }
        }



    }
}
