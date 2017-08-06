using _04.Tracker.Attributes;

[SoftUni("Ventsi")]
class Launcher
{
    [SoftUni("Gosho")]
    static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}