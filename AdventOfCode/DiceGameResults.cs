using System.Text.RegularExpressions;

namespace Day2
{

    class DiceGameResults
    {
        private string line;
        public readonly List<DiceGame> Games;
        private string _gameId;
        public int GameIdInt { get; private set; }

        public string GameId
        {
            get => _gameId;
            set
            {
                _gameId = value;
                GameIdInt = int.TryParse(Regex.Replace(_gameId, @"[^0-9]", ""), out int result) ? result : 0;
            }
        }

        public DiceGameResults(string line)
        {
            Games = new List<DiceGame>();

            this.line = line;
            var spitLineData = line.Split(':');
            var gameId = spitLineData[0];
            var gamesData = spitLineData[1];

            GameId = gameId;

            foreach (var gameData in gamesData.Split(';'))
            {
                var game = new DiceGame(gameData);
                Games.Add(game);
            }
        }
    }

    class DiceGame
    {
        private string? gameData;
        public readonly Dictionary<string, int> results = new Dictionary<string, int>();
        public DiceGame(string? gameData)
        {
            this.gameData = gameData;
            AddResults(gameData);

        }

        private void AddResults(string? gameData)
        {
            var draws = gameData.Split(",");
            foreach (var draw in draws)
            {
                var color = Regex.Replace(draw, @"[^a-zA-Z]", "");
                var numbersString = Regex.Replace(draw, @"[^0-9]", "");
                var numbers = int.Parse(numbersString);
                results.Add(color, numbers);
            }
        }
    }
}