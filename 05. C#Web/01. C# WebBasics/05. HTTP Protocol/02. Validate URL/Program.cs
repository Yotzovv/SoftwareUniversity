using System;
using System.Net;

namespace _02._Validate_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = WebUtility.UrlDecode(Console.ReadLine());

            var parsedURL = new Uri(url);

            if (string.IsNullOrEmpty(parsedURL.Scheme) || string.IsNullOrEmpty(parsedURL.Host)
             || string.IsNullOrEmpty(parsedURL.AbsolutePath) || parsedURL.Port < 0)
            {
                Console.WriteLine($"Invalid URL");
                return;
            }

            Console.WriteLine($"Protocol: {parsedURL.Scheme}");
            Console.WriteLine($"Host: {parsedURL.Host}");
            Console.WriteLine($"Port: {parsedURL.Port}");
            Console.WriteLine($"Path: {parsedURL.AbsolutePath}");

            if (!string.IsNullOrEmpty(parsedURL.Query))
            {
                Console.WriteLine($"Query: {parsedURL.Query}");
            }

            if (!string.IsNullOrEmpty(parsedURL.Fragment))
            {
                Console.WriteLine($"Fragment: {parsedURL.Fragment}");
            }
        }
    }
}
