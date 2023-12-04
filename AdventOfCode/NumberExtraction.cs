using System.Text.RegularExpressions;

public class NumberExtraction
{
    private static readonly Dictionary<string, int> numberWords = new Dictionary<string, int>
    {
        {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
        {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
        // Add more if needed (ten, eleven, etc.)
    };

    public static List<Tuple<int, int, string>> ExtractNumbers(string input)
    {
        var results = new List<Tuple<int, int, string>>();

        var numberWordsOnly = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var matches = new List<string>();

        for (int i = 0; i < input.Length; i++)
        {
            foreach (var word in numberWordsOnly)
            {
                if (i + word.Length <= input.Length && input.Substring(i, word.Length).Equals(word, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(word);
                }
            }
        }

        var count = 0;
        var currIndex = 0;
        foreach (var match in matches)
        {
            if (count > 0)
            {
                currIndex++;
            }
            currIndex = input.IndexOf(match, currIndex);

            if (!int.TryParse(numberWords.GetValueOrDefault(match).ToString(), out var number)) throw new ArgumentException("failed parsing first match.Value: " + input);

            results.Add(new Tuple<int, int, string>(currIndex, number, match));

            count++;
        }

        // Extracting numbers from the line
        var numbers = Regex.Matches(input, @"\d+").Cast<Match>().Select(m => m.Value).ToArray();

        if (numbers.Length > 0)
        {
            if (!int.TryParse(numbers.First().Substring(0, 1), out var firstNumber)) throw new ArgumentException("failed parsing first: " + input);
            if (!int.TryParse(numbers.Last().Substring(numbers.Last().Length - 1), out var lastNumber)) throw new ArgumentException("failed parsing last: " + input);

            results.Add(new Tuple<int, int, string>(input.IndexOf(firstNumber.ToString()), firstNumber, numbers.First().Substring(0, 1)));
            results.Add(new Tuple<int, int, string>(input.LastIndexOf(lastNumber.ToString()), lastNumber, numbers.Last().Substring(numbers.Last().Length - 1)));
        }

        return results.OrderBy(x => x.Item1).ToList();
    }
}
