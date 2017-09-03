using RecyclingStation.BusinessLogic.Contracts.IO;

namespace RecyclingStation.BusinessLogic.Models
{
    public class Writer : IWriter
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
