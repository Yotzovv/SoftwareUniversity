using _04.Online_Radio_Database.Exception;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Online_Radio_Database
{
    public class Song
    {
        private string author;
        private string name;
        private long minutes;
        private long seconds;
        private TimeSpan duration;

        public Song(string author, string name, long minutes, long seconds)
        {
            this.Author = author;
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.duration = TimeSpan.FromSeconds(Minutes * 60 + seconds);
        }        

        public string Author
        {
            get { return this.author; }
            private set
            {
                if(value.Length < 3 || 20 < value.Length)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidArtistNameException);
                }

                this.author = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(value.Length < 3 || 20 < value.Length)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongNameException);
                }

                this.name = value;
            }
        }

        private long Minutes
        {
            get { return this.minutes; }
            set
            {
                if(value < 0 || 14 < value)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongMinutesException);
                }

                this.minutes = value;
            }
        }

        private long Seconds
        {
            get { return this.seconds; }
            set
            {
                if(value < 0 || 59 < value)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSongSecondsException);
                }

                this.seconds = value;
            }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
            private set
            {
                this.duration = value;
            }
        }

    }
}
