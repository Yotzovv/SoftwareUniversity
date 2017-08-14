using Data;
using ExpansesManager.Core;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using AuthenticationManager = ExpansesManager.Core.AuthenticationManager;

namespace ExpansesManager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Utility.InitializeDB();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			using (var context = new ExpansesManagerContext())
			{
				if (context.Users.Any(u => u.Username == UsernameTextBox.Text && u.Password == PasswordBox.Password))
				{
					MessageBox.Show("Successfully logged in!");
					
				}
				else
				{
					ErrorLabel.Content = ("Username or password is invalid.");
					return;
				}

				AuthenticationManager.Login(UsernameTextBox.Text, PasswordBox.Password);
				
				UsernameTextBox.Clear();
				PasswordBox.Clear();
			}

			MainApp mainApp = new MainApp();
			this.Close();
			mainApp.ShowDialog();

		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			RegisterWindow register = new RegisterWindow();
			this.Close();
			register.ShowDialog();
		}
	}
}
