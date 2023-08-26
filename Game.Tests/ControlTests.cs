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
    [InlineData(9u)]
    [InlineData(999u)]
    public void SetValue_ReturnsFalse_WhenInvalidPosition(uint position)
    {
        var value = 1u;

        var result = _sut.SetValue(position, value);

        Assert.False(result);
    }

    [Theory]
    [InlineData(3u)]
    [InlineData(999u)]
    public void SetValue_ReturnsFalse_WhenInvalidValue(uint value)
    {
        var position = 1u;

        var result = _sut.SetValue(position, value);

        Assert.False(result);
    }

    [Theory]
    [InlineData(1u, 1u)]
    [InlineData(1u, 2u)]
    [InlineData(2u, 1u)]
    [InlineData(2u, 2u)]
    public void SetValue_ReturnsFalse_WhenValueAlreadySet
        (uint initialValue, uint newValue)
    {
        var position = 1u;
        _sut.SetValue(position, initialValue);

        var result = _sut.SetValue(position, newValue);

        Assert.False(result);
    }

    [Theory]
    [InlineData(1u, 2u)]
    [InlineData(2u, 1u)]
    [InlineData(5u, 1u)]
    [InlineData(8u, 2u)]
    public void SetValue_ReturnsTrue_WhenValueSet(uint position, uint value)
    {
        var result = _sut.SetValue(position, value);

        Assert.True(result);
    }

    [Fact]
    public void Values_ReturnCorrectValuesForGrid()
    {
        _sut.SetValue(0, 1);
        _sut.SetValue(2, 1);
        _sut.SetValue(5, 2);
        _sut.SetValue(7, 1);
        _sut.SetValue(8, 2);

        uint[] expected = { 1, 0, 1, 0, 0, 2, 0, 1, 2 };
        var result = _sut.Values;

        Assert.Equal(expected, result);
    }
}
