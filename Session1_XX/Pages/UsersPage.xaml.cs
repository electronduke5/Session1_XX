using Session1_XX.dbSessionTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Session1_XX.Pages
{    
    public partial class UsersPage : Page
    {
        private readonly UsersTableAdapter users;
        private readonly ActivityTableAdapter activities;

        private List<dbSession.ActivityRow> activitiesList;
        private readonly MainWindow mainWindow;
        private dbSession.UsersRow loggedUser;

        private DispatcherTimer timer;
        private DateTime StartTime;
        private TimeSpan spentTime;

        public UsersPage(MainWindow mainWindow, dbSession.UsersRow loggedUser)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            users = new UsersTableAdapter(); 
            activities = new ActivityTableAdapter();
            this.loggedUser = loggedUser;
            InitDgActivities();
            tbFullName.Text = loggedUser.LastName + ' ' + loggedUser.FirstName;

            StartTime = DateTime.Now;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            spentTime = DateTime.Now - StartTime;            
            tbTimer.Text = spentTime.Hours.ToString("00") + ":" + spentTime.Minutes.ToString("00") + ":" + spentTime.Seconds.ToString("00");
        }

        private void InitDgActivities() 
        {
            activitiesList = activities.GetData().ToList().Where((a) => a.UserID == loggedUser.ID).ToList();
            dgActivities.ItemsSource = activitiesList;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            activities.Insert(StartTime, DateTime.Now, spentTime, "", loggedUser.ID);           
            mainWindow.mainFrame.Navigate(new AuthPage(mainWindow));
        }
    }
}
