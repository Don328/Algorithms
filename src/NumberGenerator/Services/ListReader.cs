

namespace NumberGenerator.Services
{
    public static class ListReader
    {
    public static List<int> CreteListFromFile()
    {
        var ints = new List<int>();

        using (TextReader reader = File.OpenText(Constants.filePath))
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

    public static List<int> SortList(List<int> ints)
    {
        ints = (from i in ints
                orderby i
                select i).ToList();
        return ints;
    }
    }
}