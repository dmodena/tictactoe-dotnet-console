using Game.Boards;
using Game.Players;

namespace Game.Tests.Players;

public class MinimaxPlayerTests
{
    private IReversingBoard _reversingBoard;
    private Board _board;    
    private MinimaxPlayer _sut;
    private const uint PlayerValue = 1u;

    public MinimaxPlayerTests()
    {
        _reversingBoard = new ReversingBoard();
        _board = new Board();
        _sut = new MinimaxPlayer(_reversingBoard);
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
    [InlineData(new uint[] { 1, 1, 2, 2, 1, 2, 2, 0, 0 }, 7u)]
    [InlineData(new uint[] { 1, 2, 2, 1, 2, 1, 0, 0, 0 }, 6u)]
    [InlineData(new uint[] { 1, 0, 0, 0, 1, 2, 0, 0, 2 }, 2u)]
    [InlineData(new uint[] { 0, 2, 1, 0, 2, 2, 0, 1, 0 }, 3u)]
    [InlineData(new uint[] { 1, 2, 2, 1, 1, 2, 2, 0, 0 }, 8u)]
    [InlineData(new uint[] { 2, 1, 2, 2, 1, 1, 0, 2, 2 }, 6u)]
    public void Play_ReturnsBestAvailablePosition(uint[] line, uint? expected)
    {
        _board = new Board(line);

        var result = _sut.Play(_board.Line, PlayerValue);

        Assert.Equal(expected, result);
    }
}
