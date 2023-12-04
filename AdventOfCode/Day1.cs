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
            var count = 0;
            foreach (string line in lines)
            {
                var numbersFromStrings = NumberExtraction.ExtractNumbers(line);
                var firstNumberFromStringOrInt = numbersFromStrings[0];
                var lastNumberFromStringOrInt = numbersFromStrings[numbersFromStrings.Count - 1];

                int.TryParse(firstNumberFromStringOrInt.Item2.ToString() + lastNumberFromStringOrInt.Item2.ToString(), out var concatenatedInt);

                sum += concatenatedInt;

                Console.WriteLine(count + ") " + concatenatedInt + " - line: " + line + " - FIRST: " + firstNumberFromStringOrInt.Item3 + " - LAST: " + lastNumberFromStringOrInt.Item3);

                count++;
            }
            // 54988 - too high
            // 54995 - too high
            Console.WriteLine("Total: " + sum);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

    }
}
