namespace Game
{
    public class ReversingBoard : Board, IReversingBoard
    {
        public ReversingBoard() : base() { }

        public ReversingBoard(uint[] values) : base(values) { }

        public override bool SetCell(uint position, uint value)
        {
            ValidatePosition(position);
            ValidateValue(value);

            line[position] = value;
            return true;
        }

        public void UnsetCell(uint position)
        {
            _ = SetCell(position, 0);
        }
    }
}
