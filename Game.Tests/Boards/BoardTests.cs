using Game.Boards;

namespace Game.Tests.Boards;

public class BoardTests
{
    private Board _sut;

    public BoardTests()
    {
        _sut = new Board();
    }

    [Fact]
    public void Constructor_Throws_IfLineIsTooLong()
    {
        var line = new uint[10];

        var construct = () => { new Board(line); };

        Assert.Throws<ArgumentException>(construct);
    }

    [Fact]
    public void Constructor_Throws_IfLineHasInvalidCell()
    {
        uint[] line = { 0, 0, 0, 1, 1, 1, 2, 3, 0 };

        var construct = () => { new Board(line); };

        Assert.Throws<ArgumentException>(construct);
    }

    [Fact]
    public void Line_ReturnsZeros_ForEmptyBoard()
    {
        var expected = new uint[9];

        var result = _sut.Line;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Line_ReturnsValues_ForProvidedLine()
    {
        uint[] line = { 0, 1, 1, 2, 0, 2, 1, 2, 0 };
        _sut = new Board(line);

        var result = _sut.Line;

        Assert.Equal(line, result);
    }

    [Fact]
    public void Line_RetunrsValues_AfterSettingCellValues()
    {
        uint[] expected = { 0, 1, 0, 0, 2, 1, 0, 0, 0 };
        _sut = new Board();
        _sut.SetCell(1, 1);
        _sut.SetCell(4, 2);
        _sut.SetCell(5, 1);

        var result = _sut.Line;

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new uint[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new uint[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 })]
    [InlineData(new uint[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 }, new uint[] { 0, 1, 2 })]
    [InlineData(new uint[] { 0, 1, 0, 1, 1, 0, 2, 0, 2 }, new uint[] { 0, 2, 5, 7 })]
    [InlineData(new uint[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new uint[] { })]
    public void AvailablePositions_ReturnsPositionsForZeros(uint[] line, uint[] positions)
    {
        _sut = new Board(line);

        var result = _sut.AvailablePositions;

        Assert.Equal(positions, result);
    }

    [Theory]
    [InlineData(new uint[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, null)]
    [InlineData(new uint[] { 1, 2, 0, 1, 0, 0, 2, 0, 2 }, null)]
    [InlineData(new uint[] { 0, 2, 2, 2, 1, 1, 1, 2, 0 }, null)]
    [InlineData(new uint[] { 2, 1, 2, 2, 1, 1, 1, 2, 1 }, 0u)]
    [InlineData(new uint[] { 1, 1, 2, 2, 2, 1, 1, 2, 1 }, 0u)]
    [InlineData(new uint[] { 1, 1, 2, 2, 1, 1, 1, 2, 1 }, 1u)]
    [InlineData(new uint[] { 1, 1, 2, 1, 2, 1, 1, 2, 1 }, 1u)]
    [InlineData(new uint[] { 1, 2, 2, 1, 2, 1, 2, 2, 1 }, 2u)]
    [InlineData(new uint[] { 2, 1, 1, 2, 2, 2, 1, 2, 1 }, 2u)]
    public void Winner_ReturnsCorrectValue(uint[] line, uint? winner)
    {
        _sut = new Board(line);

        var result = _sut.Winner;

        Assert.Equal(winner, result);
    }

    [Fact]
    public void SetCell_Throws_IfInvalidPosition()
    {
        var setCell = () => { _sut.SetCell(9, 1); };

        Assert.Throws<ArgumentException>(setCell);
    }

    [Fact]
    public void SetCell_Throws_IfInvalidValue()
    {
        var setCell = () => { _sut.SetCell(1, 3); };

        Assert.Throws<ArgumentException>(setCell);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(0, 2)]
    [InlineData(2, 1)]
    [InlineData(2, 2)]
    public void SetCell_ReturnsFalse_IfCellNotEmpty(uint position, uint value)
    {
        uint[] line = { 1, 0, 2, 0, 0, 0, 0, 0, 0 };
        _sut = new Board(line);

        var result = _sut.SetCell(position, value);

        Assert.False(result);
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(5, 2)]
    [InlineData(8, 1)]
    public void SetCell_ReturnsTrue_IfValueSet(uint position, uint value)
    {
        var result = _sut.SetCell(position, value);

        Assert.True(result);
    }
}
