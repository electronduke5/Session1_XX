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
using System.Windows.Shapes;

namespace Session1_XX.Pages
{    
    public partial class EditRoleWindow : Window
    {
        private readonly OfficesTableAdapter offices;
        private readonly UsersTableAdapter users;
        private int officeId = -1;

        private dbSession.UsersRow user;

        public EditRoleWindow(dbSession.UsersRow user)
        {
            InitializeComponent();
            offices = new OfficesTableAdapter();
            users = new UsersTableAdapter();
            this.user = user;
            tbEmail.Text = user.Email;
            tbFirstName.Text = user.FirstName;
            tbLastName.Text = user.LastName;
            officeId = user.OfficeID;
            rbAdmin.IsChecked = user.RoleID == 1;
            rbUser.IsChecked = user.RoleID == 2;           

            //TODO:  Индекс выбранного офиса                       
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
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (Validation(tbEmail.Text)) return;
            if (Validation(tbFirstName.Text)) return;
            if (Validation(tbLastName.Text)) return;
            if (officeId == -1)
            {
                ShowMessageBox();
                return;
            }
            user.Email = tbEmail.Text;
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.OfficeID = officeId;
            user.RoleID = rbUser.IsChecked.Value ? 2 : 1;
            users.Update(user);
            this.Close();
        }

        private bool Validation(string text)
        {
            if (text == null || text.Trim() == "")
            {
                ShowMessageBox();
                return true;
            }
            return false;
        }

        private void ShowMessageBox()
        {
            MessageBox.Show("Not all fields are filled in!", "Error!", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
