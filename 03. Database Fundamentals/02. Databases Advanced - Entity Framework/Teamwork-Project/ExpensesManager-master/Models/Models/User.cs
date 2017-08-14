using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
	public class User
	{
		public User()
		{
			this.Groups = new HashSet<Group>();
			this.IsActive = true;
		}

		[Key]
		public int Id { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		public string Email { get; set; }

		public DateTime DateRegistered { get; set; }


		public bool IsActive { get; set; }

		public virtual ICollection<Group> Groups { get; set; }
	}
}
