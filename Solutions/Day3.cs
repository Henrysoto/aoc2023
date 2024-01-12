namespace AdventOfCode_2023.Solutions
{
    internal class Day3
    {
        public static int part1_solution(string[] input)
        {
            int result = 0;

            // Chaque ligne
            for (uint i = 0; i < input.Length; i++)
            {
                List<char> chrs = new List<char>();
                bool dot = true;

                // Chaque caractere
                for (int k = 0; k < input[i].Length; k++)
                {
                    char c = input[i][k];
                    if (c != '.')
                    {
                        if (char.IsAsciiDigit(c))
                        {
                            dot = false;
                            chrs.Add(c);
                        }
                    }
                    else
                    {
                        if (!dot)
                        {
                            chrs.Add(',');
                        }
                        dot = true;
                    }
                }

                // recherche de symboles adjacent
                string str = new string(chrs.ToArray());
                int lastIndex = 0;
                foreach (var num in str.Split(','))
                {
                    if (!string.IsNullOrEmpty(num.Trim()))
                    {
                        bool symbolFound = false;
                        int index = input[i].IndexOf(num, lastIndex);
                        int start = 0;
                        int end = 0;
                        if (index > 0)
                            start = index - 1;
                        if ((index + num.Length - 1) <= input[i].Length)
                            end = index + num.Length;
                        else
                            break;
                        if (index == -1)
                            break;
                        else
                            lastIndex = index;
                        //Console.WriteLine($"\n\nLine: {i}\nNeedle: {num}\nstart: {start} end: {end}");

                        // Current line
                        for (var j = start; j <= end; j++)
                        {
                            if (j > input[i].Length - 1) { break; }
                            char c = input[i][j];
                            if (!char.IsDigit(c) && c != '.')
                            {
                                result += Convert.ToInt32(num);
                                Console.WriteLine($"Line {i + 1} with needle {num} found symbol in: [{input[i][j]}] at index 0/{j} \t\t- Result: {result}");
                                symbolFound = true;
                                break;
                            }
                        }
                        // Up
                        if (i > 0)
                        {
                            for (var j = start; j <= end; j++)
                            {
                                if (j > input[i].Length - 1) { break; }
                                char c = input[i - 1][j];
                                if (!char.IsDigit(c) && c != '.')
                                {
                                    result += Convert.ToInt32(num);
                                    Console.WriteLine($"Line {i + 1} with needle {num} found symbol up: [{input[i - 1][j]}] at index -1/{j} \t\t- Result: {result}");
                                    symbolFound = true;
                                    break;
                                }
                            }
                        }
                        // Down
                        if (i < input.Length - 1 && !symbolFound)
                        {
                            for (var j = start; j <= end; j++)
                            {
                                if (j > input[i].Length - 1) { break; }
                                char c = input[i + 1][j];
                                if (!char.IsDigit(c) && c != '.')
                                {
                                    result += Convert.ToInt32(num);
                                    Console.WriteLine($"Line {i + 1} with needle {num} found symbol dw: [{input[i+1][j]}] at index +1/{j} \t\t- Result: {result}");
                                    symbolFound = true;
                                    break;
                                }
                            }
                        }
                    }      
                }
            }
            
            return result;
        }
    }
}
