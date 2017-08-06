namespace _02.High_Quality_Mistakes
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAcessModifiers("Hacker");

            System.Console.WriteLine(result);
        }
    }
}
