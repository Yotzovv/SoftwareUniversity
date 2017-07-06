using System;
using System.Linq;
using Data;
using Models.Models;

namespace ExpansesManager.Core
{
	public class AuthenticationManager
	{
		private static User currentUser;
		private static Group currentGroup;

		public static void Login(string username, string password)
		{
			using (var context = new ExpansesManagerContext())
			{
				User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

				if (currentUser != null)
				{
					throw new ArgumentException("You should logout first!");
				}

				if (user == null)
				{
					throw new ArgumentException("Invalid username or password!");
				}

				currentUser = user;
			}

		}

		public static void Login(User user)
		{
			using (var context = new ExpansesManagerContext())
			{
				// user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
				if (currentUser != null)
				{
					throw new ArgumentException("You should logout first!");
				}

				if (user == null)
				{
					throw new ArgumentException("Invalid username or password!");
				}

				currentUser = user;
			}
		}

		public static void Logout()
		{
			if (currentUser == null)
			{
				throw new InvalidOperationException("You should log in first in order to logout.");
			}

			currentUser = null;
		}

		public static User GetCurrentUser()
		{
			return currentUser;
		}


		public static Group GetGroupById(int id)
		{
			using (var context = new ExpansesManagerContext())
			{
				 currentGroup = context.Groups.FirstOrDefault(gr => gr.Id == id);
			}
			return currentGroup;
		}


	}
}
