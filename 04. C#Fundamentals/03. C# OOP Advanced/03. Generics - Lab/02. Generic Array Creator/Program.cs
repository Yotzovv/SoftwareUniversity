class Program
{
    static void Main(string[] args)
    {
        string[] strings = ArrayCreator.Create(5, "Pesho");
        int[] integers = ArrayCreator.Create(10, 33);

        foreach (var str in strings)
        {
            System.Console.WriteLine(str + " ");
        }

        foreach (var integer in integers)
        {
            System.Console.WriteLine(integer + " ");
        }
    }
}