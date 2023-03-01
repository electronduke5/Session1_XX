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

namespace Session1_XX.Pages
{
    public partial class AuthPage : Page
    {
        public static DataSet dataSet;
        public static UsersTableAdapter usersAdapter;
        public static  QueriesTableAdapter authAdaptor;
        

        public AuthPage()
        {
            InitializeComponent();
        }

        private int? Auth() 
        {
            int? role = authAdaptor.Auth(tbLogin.Text, tbPassword.Text);
            return role;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            switch (authAdaptor.Auth(tbLogin.Text, tbPassword.Text))
            {
                case 1:
                    appFrame.Content = new AdminPage();
                    break;
                case 2:
                    appFrame.Content = new UsersPage();
                    break;
                default:
                    break;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //Exit program
        }
    }
}
