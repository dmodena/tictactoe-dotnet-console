using System;
namespace Game
{
    public class PredictablePlayer : IPlay
    {
        public uint? Play(uint[] values, uint playerValue)
        {
            uint pos = 0;
            foreach (var v in values)
            {
                if (v == 0)
                    return pos;

                pos++;
            }

            return null;
        }
    }
}
