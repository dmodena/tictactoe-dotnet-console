namespace Game;
public class Control
{
    public bool Active { get; private set; }
    public readonly uint[,] Values;

    private const uint MaxValue = 2;
    private const uint MaxPosition = 8;

    public Control()
    {
        Values = new uint[3, 3];
        Active = true;
    }


    public bool SetValue(uint position, uint value)
    {
        if (position > MaxPosition)
            return false;
        if (value > MaxValue)
            return false;

        var (row, col) = MapPosition(position);
        var current = Values[row, col];

        if (current != 0)
            return false;

        Values[row, col] = value;
        return true;
    }

    private (uint, uint) MapPosition(uint inPosition)
    {
        var row = inPosition / 3u;
        var col = inPosition % 3u;

        return (row, col);
    }
}
