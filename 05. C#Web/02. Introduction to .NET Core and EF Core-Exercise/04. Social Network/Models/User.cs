using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

public class User
{
    private string password;
    private string email;

    public User(string username, string password, string email, Picture profilePicture, DateTime registeredOn, DateTime? lastTimeLoggedIn, byte age, bool isDeleted, List<User> friends)
    {
        Username = username;
        Password = password;
        Email = email;
        ProfilePicture = profilePicture;
        RegisteredOn = registeredOn;
        LastTimeLoggedIn = lastTimeLoggedIn;
        Age = age;
        IsDeleted = isDeleted;
        Friends = friends;
    }

    public User()
    {
        Friends = new List<User>();
    }

    public int Id { get; set; }

    [Required, MinLength(4), MaxLength(30)]
    public string Username { get; set; }

    [Required, MinLength(6), MaxLength(50)]
    public string Password
    {
        get => password;
        set
        {
            if (!(value.Any(c => char.IsLower(c)) && value.Any(c => char.IsUpper(c) && value.Contains('w') && value.Any(x => char.IsPunctuation(x)))))
            {
                throw new ArgumentException("Password is invalid!");
            }

            password = value;
        }
    }

    [Required]
    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is invalid!")]
    public string Email { get; set; }

    public Picture ProfilePicture { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime? LastTimeLoggedIn { get; set; }

    [Range(1, 120)]
    public byte Age { get; set; }

    public bool IsDeleted { get; set; }

    public List<User> Friends { get; set; }

    public List<UsersAlbums> Albums { get; set; }
}
