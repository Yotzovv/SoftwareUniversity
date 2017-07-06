using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Mordor_s_Cruelty_Plan
{
    public class Mood
    {
        private string name;
        private int points;

        public string MoodName
        {
            get
            {
                if (points < -5)
                {
                    name = "Angry";
                }
                else if (points >= -5 && 0 >= points)
                {
                    name = "Sad";
                }
                else if (points >= 1 && 15 >= points)
                {
                    name = "Happy";
                }
                else if (points > 15)
                {
                    name = "JavaScript";
                }

                return this.name;
            }
        }

        public int Points { get { return this.points; }
        set
            {
                points = value;
            }
        }
    }
}
