namespace Game;
public class Control
{
    public bool Active { get; private set; }
    public uint[] Values { get => GridToValues(); }

    private readonly uint[,] _grid;
    private const uint MaxValue = 2;
    private const uint MaxPosition = 8;

    public Control()
    {
        _grid = new uint[3, 3];
        Active = true;
    }

    public bool SetValue(uint position, uint value)
    {
        if (position > MaxPosition)
            return false;
        if (value > MaxValue)
            return false;

        var (row, col) = MapPosition(position);
        var current = _grid[row, col];

        if (current != 0)
            return false;

        _grid[row, col] = value;
        return true;
    }

    private (uint, uint) MapPosition(uint inPosition)
    {
        var row = inPosition / 3u;
        var col = inPosition % 3u;

        return (row, col);
    }

    private uint[] GridToValues()
    {
        uint[] values = new uint[9];
        int index = 0;

        foreach (var v in _grid)
            values[index++] = v;

        return values;
    }
}
