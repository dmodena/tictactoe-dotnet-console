namespace Game.Boards
{
    public interface IReversingBoard : IBoard
    {
        void UnsetCell(uint position);
    }
}
