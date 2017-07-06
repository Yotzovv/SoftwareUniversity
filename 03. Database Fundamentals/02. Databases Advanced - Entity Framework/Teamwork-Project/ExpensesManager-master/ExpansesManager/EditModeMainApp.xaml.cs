using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using Data;
using ExpansesManager.Core;
using ExpansesManager.ViewModels;
using Models.Models;

namespace ExpansesManager
{
    /// <summary>
    /// Interaction logic for EditModeMainApp.xaml
    /// </summary>
    public partial class EditModeMainApp : Window
    {
        public EditModeMainApp()
        {
            InitializeComponent();

            var vm = new MainAppViewModel();
            User currentUser = AuthenticationManager.GetCurrentUser();
            using (var contex = new ExpansesManagerContext())
            {
                textBox.Text = "Welcome " + " " + currentUser.Username;
                var user = contex.Users.Find(currentUser.Id);
                vm.Groups = new ObservableCollection<GroupViewModel>(Mapper.Instance.Map<IEnumerable<Group>, ObservableCollection<GroupViewModel>>(user.Groups));
                this.GroupsGrid.DataContext = vm;
                this.GroupsGrid.ItemsSource = vm.Groups;
            }
        }
        private void ButtonSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = this.GroupsGrid.DataContext as MainAppViewModel;
            var gridGroups = Mapper.Instance.Map<ObservableCollection<GroupViewModel>, IEnumerable<Group>>(vm.Groups);

            using (var db = new ExpansesManagerContext())
            {
                foreach (var group in gridGroups)
                {
                    if (group.Id > 0)
                    {
                        var dbGroup = db.Groups.Find(group.Id);
                        if (dbGroup != null)
                        {
                            if (dbGroup.Name != group.Name)
                            {
                                dbGroup.Name = group.Name;
                                db.SaveChanges();
                            }
                            var existingSubGroups = group.SubGroups.Where(s => s.Id != 0).ToList();
                            existingSubGroups.ForEach(eg =>
                            {
                                var dbSubGroup = dbGroup.SubGroups.FirstOrDefault(g => g.Id == eg.Id);
                                if (dbSubGroup != null)
                                {
                                    if (dbSubGroup.Name != eg.Name)
                                    {
                                        dbSubGroup.Name = eg.Name;
                                        db.SaveChanges();
                                    }
                                    foreach (var element in eg.Elements)
                                    {
                                        var dbElement = dbSubGroup.Elements.FirstOrDefault(el => el.Id == element.Id);
                                        if (dbElement != null && element.Id > 0)
                                        {
                                            if (dbElement.Name != element.Name || dbElement.Price != element.Price || dbElement.DateBought != element.DateBought)
                                            {
                                                dbElement.Name = element.Name;
                                                dbElement.Price = element.Price;
                                                dbElement.DateBought = element.DateBought;
                                                db.SaveChanges();
                                            }
                                        }
                                        else
                                        {
                                            dbSubGroup.Elements.Add(element);
                                            db.SaveChanges();
                                        }
                                    }
                                }
                            });

                            var newSubGroups = group.SubGroups.Where(s => s.Id == 0).ToList();
                            if (newSubGroups.Count > 0)
                            {
                                newSubGroups.ForEach(sg =>
                                {
                                    dbGroup.SubGroups.Add(sg);
                                    db.SaveChanges();

                                    foreach (var element in sg.Elements)
                                    {
                                        var dbElement = sg.Elements.FirstOrDefault(el => el.Id == element.Id);
                                        if (dbElement != null && element.Id > 0)
                                        {
                                            if (dbElement.Name != element.Name || dbElement.Price != element.Price || dbElement.DateBought != element.DateBought)
                                            {
                                                dbElement.Name = element.Name;
                                                dbElement.Price = element.Price;
                                                dbElement.DateBought = element.DateBought;
                                                db.SaveChanges();
                                            }
                                        }
                                        else
                                        {
                                            sg.Elements.Add(element);
                                            db.SaveChanges();
                                        }
                                    }
                                });
                            }
                        }
                    }
                }

                var newGroups = gridGroups.Where(g => g.Id == 0).ToList();
                var currentUser = db.Users.Find(AuthenticationManager.GetCurrentUser().Id);
                newGroups.ForEach(g =>
                {
                    currentUser.Groups.Add(g);
                    db.SaveChanges();
                });

                vm.Groups = new ObservableCollection<GroupViewModel>(Mapper.Instance.Map<IEnumerable<Group>, ObservableCollection<GroupViewModel>>(currentUser.Groups));
            }
            this.GroupsGrid.UpdateLayout();
            MessageBox.Show("Successfully saved");
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainApp mainApp = new MainApp();
            this.Close();
            mainApp.ShowDialog();
        }

        private void DeleteGroup_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var group = btn?.Tag as GroupViewModel;
            if (group != null)
            {
                using (var db = new ExpansesManagerContext())
                {
                    var removeDbGroup = db.Groups.Find(group.Id);
                    if (removeDbGroup != null)
                    {
                        db.Groups.Remove(removeDbGroup);
                        db.SaveChanges();
                        var currentUser = db.Users.Find(AuthenticationManager.GetCurrentUser().Id);
                        var vm = this.GroupsGrid.DataContext as MainAppViewModel;
                        vm.Groups = new ObservableCollection<GroupViewModel>(Mapper.Instance.Map<IEnumerable<Group>, ObservableCollection<GroupViewModel>>(currentUser.Groups));
                        this.GroupsGrid.ItemsSource = null;
                        
                        this.GroupsGrid.ItemsSource = vm.Groups;
                    }
                }
            }
        }

        private void DeleteSubGroup_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var subGroup = btn?.Tag as SubGroupViewModel;
            if (subGroup != null)
            {
                using (var db = new ExpansesManagerContext())
                {
                    (this.SubGroupsGrid.ItemsSource as ObservableCollection<SubGroupViewModel>).Remove(subGroup);
                    var removeDbSubGroup = db.SubGroups.Find(subGroup.Id);
                    if (removeDbSubGroup != null)
                    {
                        db.SubGroups.Remove(removeDbSubGroup);
                        db.SaveChanges();
                    }
                }
            }
        }

        private void DeleteElement_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var element = btn?.Tag as ElementViewModel;
            if (element != null)
            {
                using (var db = new ExpansesManagerContext())
                {
                    (this.ElementsGrid.ItemsSource as ObservableCollection<ElementViewModel>).Remove(element);
                    var removeDbelement = db.Elements.Find(element.Id);
                    if (removeDbelement != null)
                    {
                        db.Elements.Remove(removeDbelement);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
