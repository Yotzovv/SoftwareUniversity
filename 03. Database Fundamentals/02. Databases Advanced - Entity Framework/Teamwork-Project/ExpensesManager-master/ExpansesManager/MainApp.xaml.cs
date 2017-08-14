using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
	/// Interaction logic for MainApp.xaml
	/// </summary>
	public partial class MainApp : Window
	{
		public MainApp()
		{
			InitializeComponent();
			var vm = new MainAppViewModel();
			User currentUser = AuthenticationManager.GetCurrentUser();

			using (var contex = new ExpansesManagerContext())
			{
				var user = contex.Users.Find(currentUser.Id);
				vm.Groups = new ObservableCollection<GroupViewModel>(Mapper.Instance.Map<IEnumerable<Group>, ObservableCollection<GroupViewModel>>(user.Groups));

				foreach (var group in contex.Groups.Where(g => g.IsActive == true))
				{
					TreeViewGroups.Items.Add(group.Name);
				}
			}
		}

		private void LogoutButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindow main = new MainWindow();
			AuthenticationManager.Logout();
			this.Close();
			main.ShowDialog();
		}

		private void RemoveGroupButton_Click(object sender, RoutedEventArgs e)
		{
			using (var context = new ExpansesManagerContext())
			{
				if (TreeView1.SelectedItem == null)
				{
					MessageBox.Show("Please select first.");
					return;
				}
				//context.Groups.FirstOrDefault(g => g.Name == TreeView1.SelectedItem.ToString() && g.IsActive == true).IsActive = false;
                var group = context.Groups.FirstOrDefault(g => g.Name == TreeView1.SelectedItem.ToString() && g.IsActive == true);
                context.Groups.Remove(group);
				context.SaveChanges();
			}

			TreeViewItem newGroup = new TreeViewItem();
			newGroup.Name = TreeView1.SelectedItem.ToString();

			MainApp mApp = new MainApp();
			this.Close();
			mApp.ShowDialog();
		}

		private void AddGroupButton_Click(object sender, EventArgs e)
		{
			using (var context = new ExpansesManagerContext())
			{
				AddWindow addWindow = new AddWindow();
				addWindow.ShowDialog();

				Group group = new Group();
				group.Name = addWindow.textBox.Text;
				group.UserId = AuthenticationManager.GetCurrentUser().Id;

				context.Groups.Add(group);
				context.SaveChanges();

				TreeViewItem newGroup = new TreeViewItem();
				newGroup.Header = addWindow.textBox.Text;
				TreeViewGroups.Items.Add(newGroup);
			}
		}

		private void EditPasswordButton1_Click(object sender, RoutedEventArgs e)
		{
			UserEditPassword edit = new UserEditPassword();
			this.Close();
			edit.ShowDialog(); 
		}
		private void Statisyic_Clik(object sender, RoutedEventArgs e)
		{
			MainGroups edit = new MainGroups();
			this.Close();
			edit.ShowDialog(); 
		}
	   
			private void ExportGroup_Clik(object sender, RoutedEventArgs e)
		{
			ExportGroupToJson ex = new ExportGroupToJson();
			this.Close();
			ex.ShowDialog();
		}

		private void AddSubGroupButton_Click_1(object sender, RoutedEventArgs e)
		{
			using (var context = new ExpansesManagerContext())
			{
				AddWindow addWindow = new AddWindow();
				addWindow.ShowDialog();

				SubGroup subGroup = new SubGroup()
				{
					Name = addWindow.textBox.Text,
				};

				context.Groups.FirstOrDefault(g => g.Name == TreeView1.SelectedItem.ToString()).SubGroups.Add(subGroup);
				context.SaveChanges();

				TreeViewItem group = new TreeViewItem()
				{
					Header = TreeView1.SelectedItem.ToString(),
				};

				TreeViewItem newSubGroup = new TreeViewItem();
				newSubGroup.Header = addWindow.textBox.Text;

				group.Items.Add(newSubGroup);

			}
		}

		private void EditButton_Click(object sender, RoutedEventArgs e)
		{
			EditModeMainApp edit = new EditModeMainApp();
			this.Close();
			edit.ShowDialog();
		}

		private void Import_Click(object sender, RoutedEventArgs e)
		{
			ImportGroupFromJson import = new ImportGroupFromJson();
			import.ShowDialog();
		}
	}
}