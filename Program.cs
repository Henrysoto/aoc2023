namespace AdventOfCode_2023
{
    public class Program
    {
        public static void Main()
        {
            string[] input;
            string path = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\\Inputs\\";

            // Day 1
            input = File.ReadAllLines($"{path}day1.txt");
            Console.WriteLine($"Day 1 solution: {AdventOfCode_2023.Solutions.Day1.solution(input)}");

            // Day 2
            input = File.ReadAllLines($"{path}day2.txt");
            Console.WriteLine($"Day 2 solution: {AdventOfCode_2023.Solutions.Day2.solution(input)}");
        }
    }
}
