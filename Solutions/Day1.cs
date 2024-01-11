﻿namespace AdventOfCode_2023.Solutions
{
    internal class Day1
    {
        public static int solution(string[] input)
        {
            int result = 0;

            foreach (var line in input)
            {
                Dictionary<int, int> values = new Dictionary<int, int>();

                char[] chrs = line.ToCharArray();
                for (var i = 0; i < Utils.validnum.Length; i++)
                {
                    for (var k = 0; k < chrs.Length; k++)
                    {
                        if (chrs[k].ToString() == Utils.validnum[i] && !values.ContainsKey(k))
                        {
                            values.Add(k, i);
                            i = 0;
                        }
                    }
                }
                for (var i = 0; i < line.Length; i++)
                {
                    foreach (var word in Utils.validstr.Select((value, i) => new { i, value }))
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

                SortedDictionary<int, int> output = new SortedDictionary<int, int>(values);
                int num = 0;
                if (output.Count == 1)
                {
                    num = Convert.ToInt32($"{output.First().Value}{output.First().Value}");
                }
                else
                {
                    num = Convert.ToInt32($"{output.First().Value}{output.Last().Value}");
                }

                //Console.WriteLine($"{line} => {num}\nDebug: {string.Join(",", output.Select(kp => $"[{kp.Key}: {kp.Value}]"))}\n");
                result += num;
                values.Clear();
            }

            return result;
        }
    }
}