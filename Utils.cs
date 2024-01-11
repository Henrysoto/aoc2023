namespace AdventOfCode_2023
{
    internal class Utils
    {
        public static readonly string[] validstr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        public static readonly string[] validnum = Enumerable.Range(0, 10).Select(x => x.ToString()).ToArray();
    }
}
