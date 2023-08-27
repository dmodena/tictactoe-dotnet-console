namespace Game
{
    public class MinimaxPlayer : IPlay
    {
        private uint _maximizerValue;
        private uint _minimizerValue;

        public uint? Play(uint[] values, uint playerValue)
        {
            _maximizerValue = playerValue;
            _minimizerValue = _maximizerValue == 2u ? 1u : 2u;

            var result = MinimaxWrapper(values);

            Console.WriteLine($"values before:{string.Join(", ", values)}");
            Console.WriteLine($"result:{result}");

            return result;
        }

        private uint? MinimaxWrapper(uint[] values)
        {
            uint? position = null;
            var maxEval = int.MinValue;
            var availablePositions = AvailablePositions(values);

            foreach (var p in availablePositions)
            {
                values[p] = _maximizerValue;

                var eval = Minimax(values, 0);
                if (eval > maxEval)
                {
                    maxEval = eval;
                    position = p;
                }

                values[p] = 0u;
            }

            return position;
        }

        private int Minimax(uint[] values, int depth, bool maximizer = false)
        {
            var winner = Winner(values);
            if (winner != null)
            {
                return EvalWinner(Winner(values), depth);
            }

            if (maximizer)
            {
                var maxEval = int.MinValue;
                var availablePositions = AvailablePositions(values);

                foreach (var p in availablePositions)
                {
                    values[p] = _maximizerValue;

                    var eval = Minimax(values, depth + 1, false);
                    maxEval = Math.Max(eval, maxEval);

                    values[p] = 0u;
                }

                return maxEval;
            }
            else // maximizer == false
            {
                var minEval = int.MaxValue;
                var availablePositions = AvailablePositions(values);

                foreach (var p in availablePositions)
                {
                    values[p] = _minimizerValue;

                    var eval = Minimax(values, depth + 1, true);
                    minEval = Math.Min(eval, minEval);

                    values[p] = 0u;
                }

                return minEval;
            }
        }

        private uint[] AvailablePositions(uint[] values)
        {
            var possiblePositions = new List<uint>();

            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] == 0u)
                {
                    possiblePositions.Add((uint)i);
                }
            }

            return possiblePositions.ToArray();
        }

        private int EvalWinner(uint? winner, int depth = 0)
        {
            if (winner == _minimizerValue)
                return -10 + depth;

            if (winner == _maximizerValue)
                return 10 - depth;

            return 0;
        }

        private uint? Winner(uint[] values)
        {
            if (values[0] != 0u && values[0] == values[1] && values[0] == values[2])
                return values[0];

            if (values[3] != 0u && values[3] == values[4] && values[3] == values[5])
                return values[3];

            if (values[6] != 0u && values[6] == values[7] && values[6] == values[8])
                return values[6];

            if (values[0] != 0u && values[0] == values[3] && values[0] == values[6])
                return values[0];

            if (values[1] != 0u && values[1] == values[4] && values[1] == values[7])
                return values[1];

            if (values[2] != 0u && values[2] == values[5] && values[2] == values[8])
                return values[2];

            if (values[0] != 0u && values[0] == values[4] && values[0] == values[8])
                return values[0];

            if (values[2] != 0u && values[2] == values[4] && values[2] == values[6])
                return values[2];

            if (Array.IndexOf(values, 0u) == -1)
                return 0u;

            return null;
        }
    }
}
