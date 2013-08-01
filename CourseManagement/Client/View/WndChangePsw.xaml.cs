using CourseManagement.Client.BusinessLogic;
using System;
using System.Windows;
using System.Windows.Input;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndChangePsw.xaml
    /// </summary>
    public partial class WndChangePsw : Window
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WndChangePsw()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves the changed password or shows a Messagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ActiveUser.correctPasswort(pswBxOld.Password)) MessageBox.Show("Altes Passwort ist falsch");
                else if (!ActiveUser.possiblePassword(pswBxNew.Password)) MessageBox.Show("Neues Passwort entspricht nicht den Anforderungen:\nMindestens 5 Zeichen.");
                else if (pswBxNew.Password != pswBxNew2.Password) MessageBox.Show("Wiederholung unterscheidet sich vom Neuen Passwort");
                else
                {
                    ActiveUser.changePassword(pswBxNew.Password);
                    MessageBox.Show("Passwort wurde geändert");
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler\n Exception: " + err.Message);
                this.Close();
            }
            
        }

        /// <summary>
        /// Calls the btn_save_click-method if enter is pressed in window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void key_down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) btn_save_Click(null, null);
        }
    }
}
