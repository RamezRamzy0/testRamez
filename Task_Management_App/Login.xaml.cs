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

namespace Task_Management_App
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        Task_managementEntities1 db = new Task_managementEntities1();

        private void Login_button(object sender, RoutedEventArgs e)
        {
            var rec = db.Users.FirstOrDefault(x => x.Email == email_login_field.Text);

            if (email_login_field.Text == "" || password_login_field.Text == "")
            {
                MessageBox.Show("there are Missing fields");
                return;
            }
            else if (rec == null)
            {
                MessageBox.Show("email not correct or not found");
                return;
            }
            else if (rec.Passwords != password_login_field.Text)
            {
                MessageBox.Show("password not correct");
            }
            else
            {
                if (rec.Roles == "Manager")
                {
                    this.NavigationService.Navigate(new UserManagement());
                }
                else
                {
                    this.NavigationService.Navigate(new ViewTasks(rec.Names));
                }
                
            }




        }
    }
}
