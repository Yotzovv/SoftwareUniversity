using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateUser.Models
{
    class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Username
        {
            get
            {
                if (Username.Length < 4)
                {
                    throw new Exception("Username cannot be less than 4 characters long.");
                }
                return Username;
            }
            set
            {
                this.Username = value;
            }
        }

        [Required]
        [StringLength(60)]
        public string Password
        {
            get
            {
                if(Password.Length >= 6)
                {
                    bool ContainslowerCase = false;
                    bool ContainsupperCase = false;
                    bool ContainsDigit = false;
                    bool ContainsSymbol = false;

                    foreach (var letter in Password)
                    {
                        if(!(ContainslowerCase) && char.IsLower(letter))
                        {
                            ContainslowerCase = true;
                        }
                        else if(!(ContainsupperCase) && char.IsUpper(letter))
                        {
                            ContainsupperCase = true;
                        }
                        else if(!(ContainsDigit) && char.IsDigit(letter))
                        {
                            ContainsDigit = true;
                        }
                        else if(!(ContainsSymbol) && char.IsSymbol(letter))
                        {
                            ContainsSymbol = true;
                        }
                    }

                    if ((ContainslowerCase || ContainsupperCase || ContainsDigit || ContainsSymbol))
                    {

                    }
                    else
                    {
                        throw new Exception("Password sux cox");
                    }
                }

                return Password;
            }
            set
            {
                Password = value;
            }
        }

    }
}
