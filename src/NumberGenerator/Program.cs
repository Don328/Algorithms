using System.Text;

public static class Program {
    const string filePath = "../Shared/whitelist.txt";
    static int countDefault = 10;
    static int upperBoundsDefault = 50;
    static int count = 0;
    static int upperBounds = 0;
    static Random rand = new();
    static List<int> nums = new();
    
    public static void Main(string[] args)
    {
        CreateNumbersListFile(args);
        WriteToConsole(CreteListFromFile());
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

    private static List<int> SortList(List<int> ints)
    {
        ints = (from i in ints
                orderby i
                select i).ToList();
        return ints;
    }

    private static void CreateNumbersListFile(string[] args)
    {
        ParseArgs(args);
        CreateNumsList();
        var numString = CreateNumString();
        WriteListToFile(numString);
    }

    private static List<int> CreteListFromFile()
    {
        var ints = new List<int>();

        using (TextReader reader = File.OpenText(filePath))
        {
            string text = reader.ReadLine();
            string[] strings = text.Split(' ');
            foreach (var val in strings)
            {
                int i;
                int.TryParse(val, out i);
                if (i > 0)
                {
                    ints.Add(i);
                }
            }
        }
        ints = SortList(ints);
        return ints;
    }

    private static void WriteListToFile(string numString)
    {
        File.WriteAllText(filePath, numString);
    }

    private static string CreateNumString()
    {
        var sb = new StringBuilder();

        foreach (var num in nums)
        {
            sb.Append(num.ToString() + ' ');

        }

        return sb.ToString();
    }

    private static void CreateNumsList()
    {
        while (nums.Count < count)
        {
            var num = rand.Next(upperBounds + 1);
            if (!nums.Contains(num)
                && num > 0)
            {
                nums.Add(num);
            }
        }
    }

    private static void ParseArgs(string[] args)
    {
        if (args.Length > 1)
        {
            int.TryParse(args[0], out count);
            int.TryParse(args[1], out upperBounds);

            if (count == 0)
            {
                count = countDefault;
            }

            if (upperBounds == 0)
            {
                upperBounds = upperBoundsDefault;
            }
        }
        else
        {
            count = countDefault;
            upperBounds = upperBoundsDefault;
        }
    }
}



