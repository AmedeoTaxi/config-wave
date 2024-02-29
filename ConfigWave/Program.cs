namespace ConfigWave
{
    public class Program
    {
        public static void Main()
        {
            /*
             * Rules:
             * Sea <-> Shore
             * Shore <-> Land
             * Shore <-> Sea
             * Land <-> Shore
             * Land <-> Mountain
            */

            var random = new Random();
            int size = 10;

            Tile[,] set = new Tile[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    set[i, j] = new Tile
                    {
                        Type = Type.None
                    };
                }
            }

            set[random.Next(size), random.Next(size)].Type = (Type)random.Next(Enum.GetValues(typeof(Type)).Length - 1);

            Print(set);

            Collapse(set, size);
        }

        private static void Print(Tile[,] set)
        {
            for (int i = 0; i < set.GetLength(0); i++)
            {
                for (int j = 0; j < set.GetLength(1); j++)
                {
                    Console.Write($"{set[i, j].Type}\t");
                }

                Console.Write("\n");
            }
        }

        private static void Collapse(Tile[,] set, int size)
        {
            var definedTiles = new List<(int, int)>();
            var eligibleTiles = new List<(int, int)>();

            for (int i = 0; i < set.GetLength(0);i++)
            {
                for (int j = 0; j < set.GetLength(1); j++)
                {
                    if (set[i, j].Type != Type.None)
                    {
                        definedTiles.Add((i, j));
                        Console.WriteLine($"Defined: {i}, {j}");
                    }
                }
            }

            foreach (var tile in definedTiles)
            {
                if (tile.Item1 > 0 && set[tile.Item1 - 1, tile.Item2].Type != Type.None)
                    eligibleTiles.Add((tile.Item1 - 1, tile.Item2));

                if (tile.Item1 < size - 1 && set[tile.Item1 + 1, tile.Item2].Type != Type.None)
                    eligibleTiles.Add((tile.Item1 + 1, tile.Item2));

                if (tile.Item2 > 0 && set[tile.Item1, tile.Item2 - 1].Type != Type.None)
                    eligibleTiles.Add((tile.Item1, tile.Item2 - 1));

                if (tile.Item2 < size - 1 && set[tile.Item1, tile.Item2 + 1].Type != Type.None)
                    eligibleTiles.Add((tile.Item1, tile.Item2 + 1));
            }

            foreach (var eligible in eligibleTiles)
            {
                EvaluateCollapsability(eligible);   // can be parallelized
            }
        }
    }
}
