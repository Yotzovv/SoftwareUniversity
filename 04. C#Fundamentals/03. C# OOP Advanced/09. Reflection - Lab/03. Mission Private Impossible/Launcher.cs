namespace _03.Mission_Private_Impossible
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Hacker");

            System.Console.WriteLine(result);
        }
    }
}
