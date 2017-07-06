using Data;
using ExpansesManager.Core;
using ExpansesManager.ViewModels;
using Models.Models;
using System;
using System.Collections;
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

namespace ExpansesManager
{
    /// <summary>
    /// Interaction logic for MainGroups.xaml
    /// </summary>
    public partial class MainGroups : Window
    {
        public MainGroups()
        {
            InitializeComponent();
            var vm = new MainAppViewModel();
            User currentUser = AuthenticationManager.GetCurrentUser();

            using (var context = new ExpansesManagerContext())
            {
                var groups = context.Groups.Where(c => c.UserId == currentUser.Id);
                var list = new List<StatisticsViewModel>();
                 
                foreach (var gr in groups)
                {
                    foreach (var item in gr.SubGroups)
                    {
                        list.Add(new StatisticsViewModel()
                        {
                            GroupName = gr.Name,
                            SubGroupName = item.Name,
                            TotalSubGroupPrice = item.Elements.Sum(e => e.Price),
                            DayPrice = item.Elements.Where(e => e.DateBought.Date == DateTime.Today.Date).Sum(e => e.Price),
                            WeekPrice = item.Elements.Where(e => e.DateBought <= DateTime.Today.AddDays(-7) && e.DateBought <= DateTime.Today).Sum(e => e.Price),
                            MonthPrice = item.Elements.Where(e => e.DateBought <= DateTime.Today.AddMonths(-1) && e.DateBought <= DateTime.Today).Sum(e => e.Price),
                            YearPrice = item.Elements.Where(e => e.DateBought.Year <= DateTime.Today.AddYears(-1).Year && e.DateBought.Date <= DateTime.Today.Date).Sum(e => e.Price),
                        });
                    }
                }
                this.lvUsers.ItemsSource = list;
            }

        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            using (var ex= new ExpansesManagerContext())
            {
               // ex.Groups
            }
        
            EditModeMainApp ed = new EditModeMainApp();
            this.Close();
            ed.ShowDialog(); 
            
        }        

             private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainApp edit = new MainApp();
            this.Close();
            edit.ShowDialog();
        }
        
                  private void ExportGroup_Click(object sender, RoutedEventArgs e)
        {
            ExportGroupToJson ex = new ExportGroupToJson();
            this.Close();
            ex.ShowDialog();
        }
    }
}




