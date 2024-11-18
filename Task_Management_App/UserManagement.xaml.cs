using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
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
using System.Xml.Linq;

namespace Task_Management_App
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : Page
    {
        public UserManagement()
        {
            InitializeComponent();
            refresh();
        }

        Task_managementEntities1 t = new Task_managementEntities1();
        
        public void refresh()
        {
            var ex = t.Tasks.Select(x => new{ x.User.Names, x.User.Email, x.TaskID,x.Title,x.Descriptions,x.Statuss,}).ToList();

            data_grid_all.ItemsSource = ex;

        }

        private void Add_button(object sender, RoutedEventArgs e)
        {
            if (taskID_field.Text == "" || title_field.Text == "" || description_field.Text == "" || Combo_box_status.Text == "" || emp_email_field.Text == "")
            {
                MessageBox.Show("there is Missing Fields");
                return;
            }

            int id;
            try
            {
                id = int.Parse(taskID_field.Text);
            }
            catch(Exception exe)
            {
                MessageBox.Show("Id must be numbers");
                return;
            }

            var emp = t.Users.FirstOrDefault(x => x.Email == emp_email_field.Text);

            if (emp == null)
            {
                MessageBox.Show("not correct user email");
                return;
            }
            

            Task task = new Task();
            task.Title = title_field.Text;
            task.Descriptions = description_field.Text;
            task.Statuss = Combo_box_status.Text;
            task.UserId = emp.UserID;
           
            t.Tasks.Add(task);
            t.SaveChanges();
            refresh();

        }

        private void Update_button(object sender, RoutedEventArgs e)
        {

            if (taskID_field.Text == "" || title_field.Text == "" || description_field.Text == "" || Combo_box_status.Text == "" || emp_email_field.Text == "")
            {
                MessageBox.Show("there is Missing Fields");
                return;
            }

            int id;
            try
            {
                id = int.Parse(taskID_field.Text);
            }
            catch (Exception exe)
            {
                MessageBox.Show("Id must be numbers");
                return;
            }

            var emp = t.Users.FirstOrDefault(x => x.Email == emp_email_field.Text);

            if (emp == null)
            {
                MessageBox.Show("not correct user email");
                return;
            }

            var ta = t.Tasks.FirstOrDefault(x => x.TaskID == id);
            if(ta == null)
            {
                MessageBox.Show("invalid task ID, enter correct one");
                return;
            }

            if (Combo_box_status.Text == "")
            {
                MessageBox.Show("must choose status");
                return;
            }


            ta.Title = title_field.Text;
            ta.Descriptions = description_field.Text;
            ta.Statuss = Combo_box_status.Text;
            ta.UserId = emp.UserID;
            //t.Tasks.AddOrUpdate(ta);
            t.SaveChanges();
            refresh();


        }

        private void Delete_button(object sender, RoutedEventArgs e)
        {

            if (taskID_field.Text == "")
            {
                MessageBox.Show("there is Missing Fields");
                return;
            }

            int id;
            try
            {
                id = int.Parse(taskID_field.Text);
            }
            catch (Exception exe)
            {
                MessageBox.Show("Id must be numbers");
                return;
            }


            var ta = t.Tasks.FirstOrDefault(x => x.TaskID == id);
            if (ta == null)
            {
                MessageBox.Show("invalid task ID, enter correct one");
                return;
            }


            t.Tasks.Remove(ta);
            t.SaveChanges();
            refresh();

        }
    }
}
