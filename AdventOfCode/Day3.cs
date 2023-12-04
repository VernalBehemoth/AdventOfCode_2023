using Day2;
using Day3;
public class Day3Logic : IDayTask
{
    public void RunTask()
    {
        Console.WriteLine("Day 3 Executed!");
        string path = "./Data/day3.txt"; // Change this to the path of your text file

        try
        {
            string[] lines = File.ReadAllLines(path);
            var sum = 0;
            var count = 0;

            var results = new PartNumberGrid(lines);
            var symbolTiles = results.GetSymbolTiles();

            Console.WriteLine("Symbol Tiles: " + string.Join(", ", symbolTiles));

            Console.WriteLine("--------------------------");

            var adjacentNumericTiles = results.GetAdjacentNumericTiles(symbolTiles);

            Console.WriteLine("Adjacent Numeric Tiles: " + string.Join(", ", adjacentNumericTiles));

            var numbersFromAdjacentTiles = results.GetAdjacentNumbersInFull(adjacentNumericTiles);

            Console.WriteLine("Numbers From Adjacent Tiles: " + string.Join(", ", numbersFromAdjacentTiles));

            var adjacentTilesSum = numbersFromAdjacentTiles.Sum();

            Console.WriteLine("RESULT: " + string.Join(", ", adjacentTilesSum));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}
