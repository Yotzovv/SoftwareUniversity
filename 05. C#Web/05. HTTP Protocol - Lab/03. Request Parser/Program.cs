using System;
using System.Collections.Generic;

namespace _03._Request_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var validURLs = new Dictionary<string, HashSet<string>>();
            string input;

            while((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                var path = $"/{tokens[0]}";
                var method = tokens[1];

                if(!validURLs.ContainsKey(path))
                {
                    validURLs[path] = new HashSet<string>();
                }

                validURLs[path].Add(method);
            }

            var request = Console.ReadLine();

            var requestTokens = request.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var methodR = requestTokens[0];
            var pathR = requestTokens[1];
            var protocolR = requestTokens[2];

            if (validURLs.ContainsKey(pathR) && validURLs[pathR].Contains(methodR.ToLower()))
            {
                Console.WriteLine($"{protocolR} 200 OK");
                Console.WriteLine($"Content-Length: 2");
                Console.WriteLine($"Content-Type: text/plain");
                Console.WriteLine($"{Environment.NewLine} OK");
            }
            else
            {
                Console.WriteLine($"{protocolR} 404 Not Found");
                Console.WriteLine($"Content-Length: {("Not Found").Length}");
                Console.WriteLine($"Content-Type text/plain");
                Console.WriteLine($"{Environment.NewLine}NotFound");
            }
        }
    }
}
