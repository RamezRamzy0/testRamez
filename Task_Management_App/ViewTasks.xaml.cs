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
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Task_Management_App
{
    /// <summary>
    /// Interaction logic for ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : Page
    {
        public ViewTasks(string s)
        {
            InitializeComponent();
            hello_username_field.Content = s;
            name = s;
            refresh_datagrid_tasks();
            refresh_datagrid_complete_tasks();
        }
        public string name;

        Task_managementEntities1 t = new Task_managementEntities1();
        //Where(x => x.Statuss != "Completed").ToList()
        public void refresh_datagrid_tasks()
        {
            //var user = t.Users.FirstOrDefault(x => x.Names == name);
            var ex = t.Tasks.Where(x => x.Statuss != "Completed" && x.User.Names == name).Select(x => new
            {
                x.TaskID,
                x.Title,
                x.Descriptions,
                x.Statuss,
            }).ToList();

            Data_grid_tasks.ItemsSource = ex;
        }

        public void refresh_datagrid_complete_tasks()
        {
            var ex = t.Tasks.Where(x => x.Statuss == "Completed" && x.User.Names == name).Select(x => new
            {
                x.TaskID,
                x.Title,
                x.Descriptions,
                x.Statuss,
            }).ToList();

            Data_grid_complete_tasks.ItemsSource = ex;
        }

        private void Save_button(object sender, RoutedEventArgs e)
        {
            

            if (TaskID_field.Text == "")
            {
                MessageBox.Show("can't save, must enter ID for the task");
                return;
            }

            int id = int.Parse(TaskID_field.Text);
            var rec = t.Tasks.FirstOrDefault(x => x.TaskID == id && x.User.Names == name);

            if (rec == null)
            {
                MessageBox.Show("invalid Task ID, not exist OR not belong to this user");
            }
            else
            {
                if (Combo_box.Text == null || Combo_box.Text == "")
                {
                    MessageBox.Show("choose the status of the task first to save");
                }
                else
                {
                    rec.Statuss = Combo_box.Text;
                    t.Tasks.AddOrUpdate(rec);
                    t.SaveChanges();
                    
                }
                
            }

            refresh_datagrid_tasks();
            refresh_datagrid_complete_tasks();

        }
    }
}
