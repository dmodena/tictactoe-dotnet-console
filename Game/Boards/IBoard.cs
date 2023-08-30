namespace Game.Boards
{
    public interface IBoard
    {
        uint[] Line { get; }
        uint[] AvailablePositions { get; }
        uint? Winner { get; }
        bool SetCell(uint position, uint value);
    }
}
