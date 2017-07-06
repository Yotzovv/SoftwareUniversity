using Data;
using Data.Errors;
using Models.Models;
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

namespace ExpansesManager
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if(Checks.UsernameIsTaken(UsernameTextBox.Text))
            {
                ErrorLabel.Content = Checks.UsernameIsAlreadyTaken;
                return;
            }

            if (PasswordBox.Password != RepeatPasswordBox.Password)
            {
                ErrorLabel.Content = Checks.PasswordsDoNotMatch;
                return;
            }

            if(!Checks.PasswordIsValid(PasswordBox.Password))
            {
                ErrorLabel.Content = Checks.PasswordIsInvalid;
                return;
            }

            if (Checks.EmailIsValid(EmailtextBox.Text))
            {
                ErrorLabel.Content = Checks.EmailIsNotValid;
                return;
            }

            using (var context = new ExpansesManagerContext())
            {

                User user = new User()
                {
                    Username = UsernameTextBox.Text,
                    Password = PasswordBox.Password,
                    Email = EmailtextBox.Text,
                    DateRegistered = DateTime.UtcNow,
                };

                context.Users.Add(user);
                context.SaveChanges();
            }

            UsernameTextBox.Clear();
            PasswordBox.Clear();
            RepeatPasswordBox.Clear();
            EmailtextBox.Clear();
            ErrorLabel.Content = "Successfully registered!";
        }
    }
}
