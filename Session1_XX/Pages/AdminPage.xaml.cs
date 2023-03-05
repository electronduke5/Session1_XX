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
    public partial class AdminPage : Page
    {

        private readonly UsersDataTableAdapter joinedUsers;
        private readonly UsersTableAdapter users;
        private readonly OfficesTableAdapter offices;

        private AddUserWindow addUserWindow;
        private  EditRoleWindow editRoleWindow;

        private List<dbSession.UsersDataRow> usersList;
        private int officeId = -1;

        private readonly MainWindow mainWindow;

        public AdminPage(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();

            joinedUsers = new UsersDataTableAdapter();
            users = new UsersTableAdapter();
            offices = new OfficesTableAdapter();

            usersList = joinedUsers.GetData().ToList();
            dgUsers.ItemsSource = usersList;
            InitOffices();

        }

        private void InitOffices()
        {
            cbOffices.ItemsSource = offices.GetData().ToList();
            cbOffices.DisplayMemberPath = "Title";
            cbOffices.SelectionChanged += CbOffices_SelectionChanged;
        }

        private void CbOffices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = cbOffices.SelectedItem;
            if (selected == null) return;
            var office = selected as dbSession.OfficesRow;
            officeId = office.ID;
            FilterByOffice();
        }

        private void FilterByOffice()
        {
            usersList = joinedUsers.GetData().Where((ud) => officeId == -1 || ud.OfficeID == officeId).ToList();
            dgUsers.ItemsSource = usersList;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            addUserWindow = new AddUserWindow();
            addUserWindow.Closing += ModalWindowClosed;
            addUserWindow.ShowDialog();
        }
        private void ModalWindowClosed(object sender, EventArgs e)
        {
            FilterByOffice();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new AuthPage(mainWindow));
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            officeId = -1;
            cbOffices.SelectedIndex = officeId;
            FilterByOffice();
        }

        private void btnChangeRole_Click(object sender, RoutedEventArgs e)
        {
            var selected = dgUsers.SelectedItem;
            if (selected == null) return;
            var selectedUser = selected as dbSession.UsersDataRow;
            var user = users.GetData().Where((u) => u.ID == selectedUser.IDUser).FirstOrDefault();
            editRoleWindow = new EditRoleWindow(user);
            editRoleWindow.Closing += ModalWindowClosed;
            editRoleWindow.ShowDialog();
        }

        private void btnToggleActive_Click(object sender, RoutedEventArgs e)
        {
            var selected = dgUsers.SelectedItem;
            if(selected == null) return;
            var selectedUser = selected as dbSession.UsersDataRow;
            var user = users.GetData().Where((u) => u.ID == selectedUser.IDUser).FirstOrDefault();
            if(user == null) return;
            user.Active = !user.Active;
            var dataset = new dbSession();
            dataset.Users.ImportRow(user);
            users.Update(dataset.Users);
            FilterByOffice();
        }
    }
}
