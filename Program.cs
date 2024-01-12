namespace AdventOfCode_2023
{
    public class Program
    {
        public static void Main()
        {
            string[] input;
            string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Inputs\\";

            // Day 1
            //input = File.ReadAllLines($"{path}day1.txt");
            //Console.WriteLine($"Day 1 part 1 solution: {AdventOfCode_2023.Solutions.Day1.part1_solution(input)}");
            //Console.WriteLine($"Day 1 part 2 solution: {AdventOfCode_2023.Solutions.Day1.part2_solution(input)}\n");

            // Day 2
            //input = File.ReadAllLines($"{path}day2.txt");
            //Console.WriteLine($"Day 2 part 1 solution: {AdventOfCode_2023.Solutions.Day2.part1_solution(input)}");
            //Console.WriteLine($"Day 2 part 2 solution: {AdventOfCode_2023.Solutions.Day2.part2_solution(input)}\n");

            // Day 3
            input = File.ReadAllLines($"{path}day3.txt");
            Console.WriteLine($"Day 3 part 1 solution: {AdventOfCode_2023.Solutions.Day3.part1_solution(input)}");

        }
    }
}
