using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Online_Radio_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(new[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string author = input[0];
                    string name = input[1];

                    if(input.Length < 4)
                    {
                        throw new ArgumentException("Invalid song length.");
                    }

                    long minutes = long.Parse(input[2]);
                    long seconds = long.Parse(input[3]);

                    try
                    {
                        Song song = new Song(author, name, minutes, seconds);
                        playlist.Add(song);
                        Console.WriteLine("Song added.");
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }           

            Console.WriteLine($"Songs added: {playlist.Count}");

            TimeSpan playlistDuration = TimeSpan.FromSeconds(playlist.Sum(s => s.Duration.TotalSeconds));
            Console.WriteLine($"Playlist length: {playlistDuration.Hours}h {playlistDuration.Minutes}m {playlistDuration.Seconds}s");
        }
    }
}
