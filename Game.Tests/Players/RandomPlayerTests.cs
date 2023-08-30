using Game.Boards;
using Game.Players;

namespace Game.Tests.Players;

public class RandomPlayerTests
{
    private Board _board;
    private RandomPlayer _sut;
    private const uint PlayerValue = 1u;

    public RandomPlayerTests()
    {
        _board = new Board();
        _sut = new RandomPlayer();
    }

    [Fact]
    public void Play_ReturnsNull_WhenNoEmptyPosition()
    {
        uint[] line = { 1, 1, 1, 2, 2, 2, 1, 1, 1 };
        _board = new Board(line);

        var result = _sut.Play(_board.Line, PlayerValue);

        Assert.Null(result);
    }

    [Theory]
    [InlineData(new uint[] { 1, 0, 1, 2, 1, 0, 1, 1, 0 })]
    [InlineData(new uint[] { 1, 0, 0, 0, 1, 0, 1, 1, 0 })]
    [InlineData(new uint[] { 0, 0, 0, 0, 0, 0, 1, 1, 0 })]
    [InlineData(new uint[] { 1, 1, 1, 2, 1, 2, 1, 0, 0 })]
    [InlineData(new uint[] { 1, 1, 1, 2, 1, 0, 1, 1, 2 })]
    public void Play_ReturnsRandomAvailablePosition(uint[] line)
    {
        _board = new Board(line);
        var positions = _board.AvailablePositions;

        var result = _sut.Play(_board.Line, PlayerValue);

        Assert.True(Array.IndexOf(positions, result) > -1);
    }
}
