using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models.Accounts.Operations
{
    public class UserCMDs
    {
        public void Register(string Username, string Password, string Email)
        {
            if (char.IsDigit(Username.First()) || Username.Any(c => c.Equals(char.IsPunctuation(c))))
            {
                throw new ArgumentException("Username can only contain letters and digits.");
            }
            if(Username.Length < 3)
            {
                throw new ArgumentException("Username must be longer than 3 symbols.");
            }

            if(Password.Length > 6)
            {
                if(!(Password.Any(c => c.Equals(char.IsLower(c))) && Password.Any(c => c.Equals(char.IsUpper(c))) && Password.Any(c => c.Equals(char.IsDigit(c)))))
                {
                    throw new ArgumentException("Password must contain one lowercase letter, uppercase letter and digit.");
                }
            }
            else
            {
                throw new ArgumentException("Password must be longer than 6 symbols.");
            }

            if(Email.IndexOf('@') < 1 && Email.First() == '.' && Email.First() == '-' && Email.First() == '_')
            {
                throw new ArgumentException("Email should start with letter.");
            }

            if(Email.i)
        }
    }
}
