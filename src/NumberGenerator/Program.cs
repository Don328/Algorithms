public static class Program {
    public const string filePath = "../Shared/whitelist.txt";
    
    public static void Main(string[] args)
    {
        ListGenerator.CreateNumbersListFile(args);
        WriteToConsole(ListReader.CreteListFromFile());
    }

    private static void WriteToConsole(List<int> ints)
    {
        foreach (var i in ints)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine($"int count: {ints.Count}");
        Console.WriteLine();
    }
}



