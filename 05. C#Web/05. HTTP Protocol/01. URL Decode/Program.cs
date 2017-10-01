using System;
using System.Net;

namespace _01._URL_Decode
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = Console.ReadLine();

            var decodedURL = WebUtility.UrlDecode(url);
            Console.WriteLine(decodedURL);
        }
    }
}
