using System;
using System.Data.Entity.Migrations;
using System.Windows;
using Data;
using Data.Errors;
using ExpansesManager.Core;
using Models.Models;

namespace ExpansesManager
{
	/// <summary>
	/// Interaction logic for UserEditPassword.xaml
	/// </summary>
	public partial class UserEditPassword : Window
	{

		private readonly User _user = AuthenticationManager.GetCurrentUser();
		public UserEditPassword()
		{
			InitializeComponent();
			UsernameTextBox.Text = _user.Username;
		}


		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			bool isPasswordDiff = OldPasswordBox.Password != PasswordBox.Password &&
			                      OldPasswordBox.Password != RepeatPasswordBox.Password;
			bool isOldPassCorrect = _user.Password == OldPasswordBox.Password;

			bool isPasswordSame = PasswordBox.Password == RepeatPasswordBox.Password;

			if ( isOldPassCorrect && isPasswordDiff &&  isPasswordSame)
			{
				using (var context = new ExpansesManagerContext())
				{
					_user.Password = PasswordBox.Password;

					context.Users.AddOrUpdate(_user);
					context.SaveChanges();
				}

				UsernameTextBox.Clear();
				PasswordBox.Clear();
				RepeatPasswordBox.Clear();
				OldPasswordBox.Clear();
				ErrorLabel.Content = "Successfully Changed Password !";
			}
			else
			{
				ErrorLabel.Content = Checks.PasswordsDoNotMatch;
			}

		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
            MainApp mainApp = new MainApp();
            mainApp.ShowDialog();
            App.Current.MainWindow.Close();

        }
    }
}
