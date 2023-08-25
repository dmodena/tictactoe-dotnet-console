namespace Game;
public class Control
{

    public bool Active { get; private set; }
    private int[,] Values;

    private const int MinValue = 0;
    private const int MaxValue = 2;
    private const int MinPosition = 0;
    private const int MaxPosition = 8;

    public Control()
    {
        Values = new int[3, 3];
        Active = true;
    }


    public bool SetValue(int position, int value)
    {
        if (position < MinPosition || position > MaxPosition)
            return false;
        if (value < MinValue || value > MaxValue)
            return false;

        var (row, col) = MapPosition(position);
        var current = Values[row, col];

        if (current != 0)
            return false;

        Values[row, col] = value;
        return true;
    }

    private (int, int) MapPosition(int inPosition)
    {
        var row = inPosition / 3;
        var col = inPosition % 3;

        return (row, col);
    }
}
