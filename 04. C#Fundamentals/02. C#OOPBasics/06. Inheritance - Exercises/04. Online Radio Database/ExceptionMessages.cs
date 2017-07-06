using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Online_Radio_Database.Exception
{
    public class ExceptionMessages
    {
        public const string InvalidSong = "Invalid song.";
        public const string InvalidArtistNameException = "Artist name should be between 3 and 20 symbols.";
        public const string InvalidSongNameException = "Song name should be between 3 and 30 symbols.";
        public const string InvalidSongLengthException = "Invalid song length.";
        public const string InvalidSongMinutesException = "Song minutes should be between 0 and 14.";
        public const string InvalidSongSecondsException = "Song seconds should be between 0 and 59.";
    }
}
