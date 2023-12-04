using Day2;

public class Day2Logic : IDayTask
{
    int _red = 0;
    int _green = 0;
    int _blue = 0;
    public void GetPreRequisites()
    {
        Console.WriteLine("\nRed");
        _red = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGreen");
        _green = int.Parse(Console.ReadLine());
        Console.WriteLine("\nBlue");
        _blue = int.Parse(Console.ReadLine());
    }

    public void RunTask()
    {
        GetPreRequisites();
        Console.WriteLine("Day 2 Executed!");
        string path = "./Data/day2.txt"; // Change this to the path of your text file

        try
        {
            string[] lines = File.ReadAllLines(path);
            var sum = 0;
            var count = 0;

            List<DiceGameResults> diceGames = new List<DiceGameResults>();
            foreach (string line in lines)
            {
                var results = new DiceGameResults(line);
                diceGames.Add(results);
            }
            var result = 0;
            foreach (var games in diceGames)
            {
                var results = games.Games.SelectMany(x => x.results).ToList();
                var red = results.Where(x => x.Key == "red").Select(x => x.Value).Any(x => x > _red);
                var green = results.Where(x => x.Key == "green").Select(x => x.Value).Any(x => x > _green);
                var blue = results.Where(x => x.Key == "blue").Select(x => x.Value).Any(x => x > _blue);

                if (red || green || blue)
                {
                    Console.WriteLine("Failed: " + games.GameId);
                }
                else
                {
                    result += games.GameIdInt;
                    Console.WriteLine("Success: " + games.GameIdInt);
                }
            }


            Console.WriteLine("RESULT: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
