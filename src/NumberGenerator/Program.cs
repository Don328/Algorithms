using System.Text;

public static class Program {
    public static void Main(string[] args)
    {
        int countDefault = 10;
        int upperBoundsDefault = 50;
        int count = 0;
        int upperBounds = 0;

        var rand = new Random();
        var nums = new List<int>();

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

        while (nums.Count < count)
        {
            var num = rand.Next(upperBounds + 1);
            if(!nums.Contains(num))
            {
                nums.Add(num);
            }
        }
        var sb = new StringBuilder();

        foreach (var num in nums)
        {
            sb.Append(num.ToString() + ' ');

        }

        File.WriteAllText("../Shared/whitelist.txt", sb.ToString());

        var ints = new List<int>();

        using (TextReader reader = File.OpenText("../Shared/whitelist.txt"))
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
        ints = (from i in ints
            orderby i
            select i).ToList();

        foreach (var i in ints)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine($"int count: {ints.Count}");
        Console.WriteLine();
    }
}



