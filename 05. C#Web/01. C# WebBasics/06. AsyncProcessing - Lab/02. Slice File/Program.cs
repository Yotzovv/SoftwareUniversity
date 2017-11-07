using System;
using System.IO;
using System.Threading.Tasks;

namespace _02._Slice_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoPath = Console.ReadLine();
            var destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destination, pieces);

            Console.WriteLine("Anything else?");
            while (true) Console.ReadLine();
        }
        static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }

        static void Slice(string sourceFile, string destinationPath, int parts)
        { 
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);

                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    var filepath = string.Format("{0}/Part-{1}{2}",
                                                destinationPath,
                                                currentPart,
                                                fileInfo.Extension);

                    using (var destination = new FileStream(filepath, FileMode.Create))
                    {
                        var buffer = new byte[partLength];

                        while (currentByte <= partLength * currentPart)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }

                        Console.WriteLine("Slice complete.");
                    }
                }
            }
        }
    }
}
