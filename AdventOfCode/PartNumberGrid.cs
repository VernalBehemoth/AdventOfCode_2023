using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Day3
{

    class PartNumberGrid
    {
        public readonly List<PartNumberGridCoordinate> coordinates;

        public PartNumberGrid(string[] lines)
        {
            coordinates = new List<PartNumberGridCoordinate>();
            var countY = 0;
            foreach (var line in lines)
            {
                var countX = 0;
                foreach (var ch in line)
                {
                    coordinates.Add(new PartNumberGridCoordinate(countX, countY, ch.ToString()));
                    countX++;
                }
                countY++;
            }

        }

        public IEnumerable<PartNumberGridCoordinate> GetSymbolTiles()
        {
            return coordinates.Where(x => Regex.IsMatch(x.value, @"[^a-zA-Z0-9.]"));
        }

        internal List<int> GetAdjacentNumbersInFull(IEnumerable<PartNumberGridCoordinate> adjacentNumericTiles)
        {
            var numbers = new List<int>();

            var partNumberTilesAll = new List<List<PartNumberGridCoordinate>>();

            foreach (var tile in adjacentNumericTiles)
            {
                List<PartNumberGridCoordinate> partNumberGridCoordinate = new List<PartNumberGridCoordinate>();
                partNumberGridCoordinate.Add(tile);

                int offset = 1;
                while (Regex.IsMatch(coordinates.FirstOrDefault(x => x.x == tile.x + offset && x.y == tile.y)?.value ?? "N", @"[0-9]"))
                {
                    partNumberGridCoordinate.Add(coordinates.First(x => x.x == tile.x + offset && x.y == tile.y));
                    offset++;
                }

                offset = 1;
                while (Regex.IsMatch(coordinates.FirstOrDefault(x => x.x == tile.x - offset && x.y == tile.y)?.value ?? "N", @"[0-9]"))
                {
                    partNumberGridCoordinate.Add(coordinates.First(x => x.x == tile.x - offset && x.y == tile.y));
                    offset++;
                }
                var firstNumberCoordinates = partNumberGridCoordinate.OrderBy(x => x.x).First();

                if(!(partNumberTilesAll.Exists(x => x.OrderBy(x => x.x).First() == firstNumberCoordinates)))
                {
                    partNumberTilesAll.Add(partNumberGridCoordinate.OrderBy(x => x.x).ToList());
                    numbers.Add(int.Parse(string.Join("", partNumberGridCoordinate.OrderBy(x => x.x).SelectMany(x => x.value))));
                }
            }

            return numbers;
        }

        internal List<int> GetAdjacentNumbersInFullGearRaatio(IEnumerable<PartNumberGridCoordinate> adjacentNumericTiles)
        {
            var numbers = new List<int>();

            var partNumberTilesAll = new List<List<PartNumberGridCoordinate>>();

            foreach (var tile in adjacentNumericTiles)
            {
                List<PartNumberGridCoordinate> partNumberGridCoordinate = new List<PartNumberGridCoordinate>();
                partNumberGridCoordinate.Add(tile);

                int offset = 1;
                while (Regex.IsMatch(coordinates.FirstOrDefault(x => x.x == tile.x + offset && x.y == tile.y)?.value ?? "N", @"[0-9]"))
                {
                    partNumberGridCoordinate.Add(coordinates.First(x => x.x == tile.x + offset && x.y == tile.y));
                    offset++;
                }

                offset = 1;
                while (Regex.IsMatch(coordinates.FirstOrDefault(x => x.x == tile.x - offset && x.y == tile.y)?.value ?? "N", @"[0-9]"))
                {
                    partNumberGridCoordinate.Add(coordinates.First(x => x.x == tile.x - offset && x.y == tile.y));
                    offset++;
                }
                var firstNumberCoordinates = partNumberGridCoordinate.OrderBy(x => x.x).First();

                if (!(partNumberTilesAll.Exists(x => x.OrderBy(x => x.x).First() == firstNumberCoordinates)))
                {
                    partNumberTilesAll.Add(partNumberGridCoordinate.OrderBy(x => x.x).ToList());                    
                    numbers.Add(int.Parse(string.Join("", partNumberGridCoordinate.OrderBy(x => x.x).SelectMany(x => x.value))));
                }
            }

            return numbers;
        }

        internal IEnumerable<PartNumberGridCoordinate> GetAdjacentNumericTiles(IEnumerable<PartNumberGridCoordinate> symbolTiles)
        {
            var adjacentTiles = new List<PartNumberGridCoordinate>();


            foreach (var symbolTile in symbolTiles)
            {

                // Assuming coordinates is accessible here and is a collection of PartNumberGridCoordinate
                var tiles = coordinates.Where(x =>
                    (symbolTile.x == x.x && (symbolTile.y == x.y - 1 || symbolTile.y == x.y + 1)) || // Same column, adjacent row
                    (symbolTile.y == x.y && (symbolTile.x == x.x - 1 || symbolTile.x == x.x + 1)) || // Same column, adjacent row
                    (symbolTile.y == x.y - 1 && symbolTile.x == x.x - 1) || // adjacent column, adjacent row
                    (symbolTile.y == x.y + 1 && symbolTile.x == x.x + 1) || // adjacent column, adjacent row
                    (symbolTile.y == x.y - 1 && symbolTile.x == x.x + 1) || // adjacent column, adjacent row
                    (symbolTile.y == x.y + 1 && symbolTile.x == x.x - 1)
                );

                var filteredTiles = tiles.Where(x => Regex.IsMatch(x.value, @"[0-9]"));

                if (symbolTile.value == "*")
                {
                    filteredTiles.ToList().ForEach(x=> x.IsGear = "*");
                }

                adjacentTiles.AddRange(filteredTiles);

            }

            return adjacentTiles;
        }
    }

    class PartNumberGridCoordinate
    {
        public int x { get; set; }
        public int y { get; set; }
        public string value { get; set; }

        public PartNumberGridCoordinate(int x, int y, string value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }
        public override string ToString()
        {
            return value.ToString();
        }

        internal bool IsNextToNumeric(PartNumberGridCoordinate neighbourOne, PartNumberGridCoordinate neighbourTwo)
        {
            return Regex.IsMatch(neighbourOne.value, @"[0-9]") || Regex.IsMatch(neighbourTwo.value, @"[0-9]");
        }
    }
}