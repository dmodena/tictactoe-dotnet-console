namespace Game
{
    public class PredictablePlayer : IPlay
    {
        public uint? Play(uint[] values, uint playerValue)
        {
            var pos = Array.IndexOf(values, 0u);

            return pos != -1 ? (uint?)pos : null;
        }
    }
}
