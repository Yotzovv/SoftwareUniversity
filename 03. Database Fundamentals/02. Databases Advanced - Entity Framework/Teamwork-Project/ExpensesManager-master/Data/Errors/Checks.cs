using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Errors
{
	public class Checks
	{
		public const string PasswordsDoNotMatch = "Passwords do not match!";
		public const string PasswordIsInvalid = "Password is invalid!";
		public const string EmailIsNotValid = "Provided email is not valid!";
		public const string UsernameIsAlreadyTaken = "Username is already taken!";

		public static bool EmailIsValid(string email)
		{
			if (email.IndexOf("@") < 1 || !(email.Contains(".")))
			{
				return true;
			}
			return false;
		}

		public static bool UsernameIsTaken(string username)
		{
			using (var context = new ExpansesManagerContext())
			{
				if (context.Users.Any(u => u.Username == username))
				{
					return true;
				}
				return false;
			}
		}

		public static bool PasswordIsValid(string password)
		{
			if (password.Length >= 6)
			{
				return true;
			}
			return false;
		}

		public static class ErrorMessages
		{
			public const string FileNotFound = "Path {0} is not valid!";
			public const string ImportErrorMessage = "Error: Invalid data.";

		}
	}
}
