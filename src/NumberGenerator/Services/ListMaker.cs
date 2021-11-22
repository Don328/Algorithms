using System.Text;

namespace NumberGenerator.Services
{
    public static class ListMaker
    {
        public static int countDefault = 10;
        public static int upperBoundsDefault = 50;
        public static int count = 0;
        public static int upperBounds = 0;
        public static List<int> nums = new();
    
        static Random rand = new();
    
        public static void CreateNumbersListFile(string[] args)
        {
            ParseArgs(args);
            CreateNumsList();
            var numString = CreateNumString();
            WriteListToFile(numString);
        }

        public static void ParseArgs(string[] args)
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

        public static void CreateNumsList()
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
        public static string CreateNumString()
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
            File.WriteAllText(Constants.filePath, numString);
        }
    }
}