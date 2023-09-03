namespace Game.Players
{
    public class RandomPlayer : IPlayer
    {
        public uint? Play(uint[] values, uint playerValue)
        {
            var possiblePositions = new List<int>();

            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] == 0u)
                {
                    possiblePositions.Add(i);
                }
            }

            if (possiblePositions.Count == 0)
                return null;

            var idx = new Random().Next(possiblePositions.Count);
            return (uint?)possiblePositions[idx];
        }
    }
}
