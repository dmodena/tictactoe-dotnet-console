namespace Game
{
    public class MinimaxPlayer : IPlay
    {
        private IReversingBoard _board;
        private uint _maximizerValue;
        private uint _minimizerValue;

        public MinimaxPlayer(IReversingBoard board) => _board = board;

        public uint? Play(uint[] values, uint playerValue)
        {
            _board = new ReversingBoard(values);
            SetValues(playerValue);

            return BestPosition();
        }

        private void SetValues(uint playerValue)
        {
            _maximizerValue = playerValue;
            _minimizerValue = playerValue == 1u ? 2u : 1u;
        }

        private uint? BestPosition()
        {
            uint? position = null;
            var maxEval = int.MinValue;

            foreach (var p in _board.AvailablePositions)
            {
                _board.SetCell(p, _maximizerValue);

                var eval = Minimax(_board, 0);
                if (eval > maxEval)
                {
                    maxEval = eval;
                    position = p;
                }

                _board.UnsetCell(p);
            }

            return position;
        }

        private int Minimax(IReversingBoard board, int depth, bool maximizer = false)
        {
            if (board.Winner.HasValue)
            {
                return EvalWinner(board.Winner, depth);
            }

            if (maximizer)
            {
                var maxEval = int.MinValue;

                foreach (var p in board.AvailablePositions)
                {
                    board.SetCell(p, _maximizerValue);

                    var eval = Minimax(board, depth + 1, false);
                    maxEval = Math.Max(eval, maxEval);

                    board.UnsetCell(p);
                }

                return maxEval;
            }
            else // minimizer
            {
                var minEval = int.MaxValue;

                foreach (var p in board.AvailablePositions)
                {
                    board.SetCell(p, _minimizerValue);

                    var eval = Minimax(board, depth + 1, true);
                    minEval = Math.Min(eval, minEval);

                    board.UnsetCell(p);
                }

                return minEval;
            }
        }

        private int EvalWinner(uint? winner, int depth = 0)
        {
            if (winner == _minimizerValue)
                return -10 + depth;

            if (winner == _maximizerValue)
                return 10 - depth;

            return 0;
        }
    }
}
