using System.Text.RegularExpressions;

namespace AdventOfCode_2023.Solutions
{
    internal class Day2
    {
        public static int solution(string[] input)
        {
            int valid_ids = 0;
            const int MAX_RED = 12;
            const int MAX_GREEN = 13;
            const int MAX_BLUE = 14;

            foreach (var line in input.Select((value, id) => new { id, value }))
            {
                bool validLine = true;
                string[] cubes = line.value.Split(':')[1].Split(';');
                foreach (string colors in cubes)
                {
                    string[] parts = Regex.Split(colors, @"(?<=\d) |, ");
                    for (uint i = 0; i < parts.Length; i++)
                    {
                        if (int.TryParse(parts[i], out var v))
                        {
                            switch (parts[i + 1])
                            {
                                case "red":
                                    if (v > MAX_RED)
                                        validLine = false;
                                    break;
                                case "green":
                                    if (v > MAX_GREEN)
                                        validLine = false;
                                    break;
                                case "blue":
                                    if (v > MAX_BLUE)
                                        validLine = false;
                                    break;
                                default:
                                    Console.WriteLine($"Switch error: {parts[i + 1]} -> {v}");
                                    break;
                            }
                        }
                    }
                }

                if (validLine)
                {
                    valid_ids += line.id + 1;
                }
            }

            return valid_ids;
        }
    }
}
