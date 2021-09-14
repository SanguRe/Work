using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkDateRus.Entities;
using WorkDateRus.Viewmodels;

namespace WorkDateRus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkDaysEntities db = new WorkDaysEntities();

        public MainWindow()
        {
            InitializeComponent();
            UpdateNew();

        }

        private void UpdateNew()
        {
            List<Sehedule> sehedules = db.Sehedule.ToList();
            List<UserWorkList> users = new List<UserWorkList>();

            DGMain.ItemsSource = users;

            foreach (var item in sehedules)
            {
                if (users.FirstOrDefault(p => p.UserId == item.WorkerId) != null)
                {
                    users.FirstOrDefault(p => p.UserId == item.WorkerId).sehedules.Add(item);
                }
                else
                {
                    UserWorkList user = new UserWorkList();
                    user.UserId = item.WorkerId;
                    user.Name = item.Worker.FirstName;
                    user.sehedules = new List<Sehedule>();
                    user.sehedules.Add(item);
                    users.Add(user);
                }
            }

            foreach (var user in users)
            {
                user.sehedules = user.sehedules.Where(p => p.StartDate > DateTime.Now.Date).OrderBy(p => p.StartDate).ToList();
            }

            for (int i = 0; i <= 4; i++)
            {
                DGMain.Columns[i + 1].Header = DateTime.Now.Date.AddDays(i);
            }

        }

        private void Update()
        {
            List<Sehedule> sehe = db.Sehedule.ToList().Where(i => i.StartDate >= DateTime.Now && i.EndDate <= DateTime.Now.AddDays(5)).ToList();
            DGMain.ItemsSource = sehe;

            DGMain.Columns.Add(new DataGridTextColumn()
            {
                Header = "Name",
                Binding = new Binding("Worker.FirstName")
            });

            for (int i = 0; i <= 4; i++)
            {
                var templateColumn = new DataGridCheckBoxColumn()
                {
                    //Header = DataTime
                };
                DGMain.Columns.Add(templateColumn);
            }
        }

        class UserWorkList
        {
            public int UserId { get; set; }
            public string Name { get; set; }
            public List<Sehedule> sehedules { get; set; }
        }
    }
}
