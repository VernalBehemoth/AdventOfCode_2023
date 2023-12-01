using System.Text.RegularExpressions;

public class Day1 : IDayTask
{
    public void RunTask()
    {
        Console.WriteLine("Day 1 Executed!");

        string path = "./Data/day1.txt"; // Change this to the path of your text file

        try
        {
            string[] lines = File.ReadAllLines(path);
            var sum = 0;
            foreach (string line in lines)
            {
                // Extracting numbers from the line
                var numbers = Regex.Matches(line, @"\d+").Cast<Match>().Select(m => m.Value).ToArray();

                if (numbers.Length > 0)
                {
                    string firstNumber = numbers.First().Substring(0, 1);
                    string lastNumber = numbers.Last().Substring(numbers.Last().Length - 1);

                    int.TryParse(firstNumber + lastNumber, out var concatenatedInt);

                    sum += concatenatedInt;

                    Console.WriteLine(concatenatedInt);
                }
            }

            Console.WriteLine("Total: " + sum);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

    }
}
