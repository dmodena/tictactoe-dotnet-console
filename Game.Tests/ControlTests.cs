using Game;

namespace Game.Tests;

public class ControlTests
{
    private Control _sut;

    public ControlTests()
    {
        _sut = new Control();
    }

    [Theory]
    [InlineData(-999)]
    [InlineData(-1)]
    [InlineData(9)]
    [InlineData(999)]
    public void SetValue_ReturnsFalse_WhenInvalidPosition(int position)
    {
        var value = 1;

        var result = _sut.SetValue(position, value);

        Assert.False(result);
    }

    [Theory]
    [InlineData(-999)]
    [InlineData(-1)]
    [InlineData(3)]
    [InlineData(999)]
    public void SetValue_ReturnsFalse_WhenInvalidValue(int value)
    {
        var position = 1;

        var result = _sut.SetValue(position, value);

        Assert.False(result);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    public void SetValue_ReturnsFalse_WhenValueAlreadySet
        (int initialValue, int newValue)
    {
        var position = 1;
        _sut.SetValue(position, initialValue);

        var result = _sut.SetValue(position, newValue);

        Assert.False(result);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(5, 1)]
    [InlineData(8, 2)]
    public void SetValue_ReturnsTrue_WhenValueSet(int position, int value)
    {
        var result = _sut.SetValue(position, value);

        Assert.True(result);
    }
}