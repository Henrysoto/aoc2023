public class aoc_utils
{
    public static readonly string[] validstr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    public static readonly string[] validnum = Enumerable.Range(0, 10).Select(x => x.ToString()).ToArray();
}

public class Program
{
    static int day1_solution(string[] input)
    {
        int result = 0;

        foreach (var line in input)
        {
            Dictionary<int, int> values = new Dictionary<int, int>();

            //8sevenkrpqkfxdcn7eightfour7lfpbtztlmfg => wrong: 84 => answer: 87 
            //Debug: [0: 8],[1: 7],[16: 7],[17: 8],[22: 4]

            char[] chrs = line.ToCharArray();
            for (var i = 0; i < aoc_utils.validnum.Length; i++)
            {
                for (var k = 0; k < chrs.Length; k++) 
                { 
                    if (chrs[k].ToString() == aoc_utils.validnum[i] && !values.ContainsKey(k))
                    {
                        values.Add(k, i);
                        i = 0;
                    }
                }
            }
            for (var i = 0; i < line.Length; i++)
            {
                foreach (var word in aoc_utils.validstr.Select((value, i) => new { i, value }))
                {
                    int idx = line.IndexOf(word.value, i);
                    if (idx > -1)
                    {
                        if (!values.ContainsKey(idx))
                        {
                            values.Add(idx, word.i);
                            i = 0;
                        }
                    }
                }
            }
            //foreach (var word in aoc_utils.validstr.Select((value, i) => new { i, value }))
            //{
            //    if (line.Contains(word.value))
            //    {
            //        int idx = line.IndexOf(aoc_utils.validstr[word.i]);
            //        if (values.ContainsKey(idx))
            //        {
            //            idx = line.IndexOf(aoc_utils.validstr[word.i], idx + 1);
            //            Console.WriteLine($"index validstr: {idx}");
            //        }
            //        if (idx > -1)
            //        {
            //            values.Add(idx, word.i);
            //        }
            //    }
            //}

            SortedDictionary<int, int> output = new SortedDictionary<int, int>(values);
            int num = 0;
            if (output.Count == 1)
            {
                num = Convert.ToInt32($"{output.First().Value}");
            }
            else
            {
                num = Convert.ToInt32($"{output.First().Value}{output.Last().Value}");
            }

            Console.WriteLine($"{line} => {num}\nDebug: {string.Join(",", output.Select(kp => $"[{kp.Key}: {kp.Value}]"))}\n");
            result += num;
            values.Clear();
        }

        return result;
    }

    public static void Main()
    {
        // Day 1
        string[] input = File.ReadAllLines("../../../day1.txt");
        Console.WriteLine(day1_solution(input));
    }
}