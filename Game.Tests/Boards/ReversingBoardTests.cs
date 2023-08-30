using Game.Boards;

namespace Game.Tests.Boards;

public class ReversingBoardTests
{
    private ReversingBoard _sut;

    public ReversingBoardTests()
    {
        _sut = new ReversingBoard();
    }

    [Fact]
    public void SetCell_AllowsSettingZeros()
    {
        uint[] line = { 1, 1, 1, 2, 2, 2, 1, 2, 1 };
        uint[] expected = { 0, 1, 1, 2, 2, 2, 1, 2, 1 };
        _sut = new ReversingBoard(line);

        var result = _sut.SetCell(0, 0);

        Assert.True(result);
        Assert.Equal(expected, _sut.Line);
    }

    [Fact]
    public void UnsetCell_SetValueAsZero()
    {
        uint[] line = { 1, 1, 1, 2, 2, 2, 1, 2, 1 };
        uint[] expected = { 0, 0, 0, 2, 2, 0, 1, 2, 1 };
        _sut = new ReversingBoard(line);

        _sut.UnsetCell(0);
        _sut.UnsetCell(1);
        _sut.UnsetCell(2);
        _sut.UnsetCell(5);

        Assert.Equal(expected, _sut.Line);
    }
}
