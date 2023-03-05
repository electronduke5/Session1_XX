using Session1_XX.dbSessionTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class AuthPage : Page
    {
        public static DataSet dataSet;
        public static UsersTableAdapter usersAdapter;
        public static QueriesTableAdapter authAdaptor;      
        private readonly MainWindow mainWindow;

        private DispatcherTimer failedAuthTimer;
        private TimeSpan retryAuthOffset;
        private int loginAttempts;
       
        public AuthPage(MainWindow mainWindow)
        {
            InitializeComponent();
            usersAdapter = new UsersTableAdapter();
            authAdaptor = new QueriesTableAdapter();            
            this.mainWindow = mainWindow;          
        }       

        private void Auth(string login, string password) 
        {            
            var loggedUserID = authAdaptor.User_login(login, password);
            Console.WriteLine(loggedUserID);
            if (loggedUserID == null)
            {
                MessageBox.Show("Invalid data");
                OnAuthFailed();
                return;
            }

            var user = usersAdapter.GetData().Where((u) => u.ID == loggedUserID).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Invalid data");
                OnAuthFailed();
                return;
            }

            if (!user.Active)
            {
                MessageBox.Show("Account was disabled");                
                return;
            }
            switch (user.RoleID)
            {
                case 1:
                    this.NavigationService.Navigate(new AdminPage(mainWindow));
                    //appFrame.Navigate(new AdminPage());
                    break;
                case 2:
                    this.NavigationService.Navigate(new UsersPage(mainWindow, user));
                    break;
                default:
                    break;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Auth(tbLogin.Text, tbPassword.Text);           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void OnAuthFailed()
        {
            loginAttempts++;
            if (loginAttempts < 3)
            {
                return;
            }

            ChangeUiState(false);
            retryAuthOffset = TimeSpan.FromSeconds(10);
            TbFailedTimer.Text = $"Please, wait 10 sec.";
            TbFailedTimer.Visibility = Visibility.Visible;
            failedAuthTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, delegate
            {
                OnFailedAuthTimerTick();
            }, Application.Current.Dispatcher);
        }

        private void OnFailedAuthTimerTick()
        {
            var retrySeconds = retryAuthOffset.Add(TimeSpan.FromSeconds(-1)).Seconds;
            retryAuthOffset = TimeSpan.FromSeconds(retrySeconds);
            if (retrySeconds <= 0)
            {
                ChangeUiState(true);
                TbFailedTimer.Visibility = Visibility.Collapsed;
                loginAttempts = 0;
                failedAuthTimer.Stop();
            }
            TbFailedTimer.Text = $"Try again in {retryAuthOffset.Seconds} sec.";
        }

        private void ChangeUiState(bool state)
        {
            tbLogin.IsEnabled = state;
            tbPassword.IsEnabled = state;
            btnLogin.IsEnabled = state;
        }       
    }
}
