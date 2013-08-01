using System.Windows;
using CourseManagement.Client.View;

namespace CourseManagement.Client.Controller
{
    public partial class Start : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            
            
            WndLogin startWindow = new WndLogin();
            WndIndex mainWindow = new WndIndex();
            if (startWindow.ShowDialog() == true)
            {
                mainWindow.Show();
            }
        }

    }
}

