using System.Text;

public static class FileGenerator
{
    static int countDefault = 10;
    static int upperBoundsDefault = 50;
    static int count = 0;
    static int upperBounds = 0;
    static Random rand = new();
    static List<int> nums = new();
    public static void CreateNumbersListFile(string[] args)
    {
        ParseArgs(args);
        CreateNumsList();
        var numString = CreateNumString();
        WriteListToFile(numString);
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
    private static string CreateNumString()
    {
        var sb = new StringBuilder();

        foreach (var num in nums)
        {
            sb.Append(num.ToString() + ' ');

        }

        return sb.ToString();
    }

    private static void WriteListToFile(string numString)
    {
        File.WriteAllText(Program.filePath, numString);
    }
}