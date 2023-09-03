using System.Text;
using Game.Boards;
using Game.Players;

namespace Client;

public enum Difficulty { Easy, Medium, Hard }

public class GameControl : IGameControl
{
    private readonly string[] _symbols = { " ", "x", "o" };
    private uint _userValue;
    private uint _cpuValue;
    private bool _cpuStarts;
    private Difficulty _difficulty;
    private readonly IBoard _board;
    private readonly IReversingBoard _reversingBoard;
    private IPlayer _cpu;

    public GameControl(IBoard board, IPlayer player, IReversingBoard reversingBoard)
    {
        _userValue = 1u;
        _cpuValue = 2u;
        _cpuStarts = false;
        _difficulty = Difficulty.Easy;
        _board = board;
        _cpu = player;
        _reversingBoard = reversingBoard;
    }

    public void Start()
    {
        SetValues();
        SetDifficulty();
        SetCpuPlayer();
        SetCpuStarts();

        uint? position;

        if (_cpuStarts)
        {
            position = _cpu.Play(_board.Line, _cpuValue);
            if (position != null)
                _board.SetCell(position.Value, _cpuValue);
        }

        do
        {
            Console.WriteLine();
            PrintBoard(_board.Line);

            position = GetUserPosition();
            if (position != null)
                _board.SetCell(position.Value, _userValue);

            position = _cpu.Play(_board.Line, _cpuValue);
            if (position != null)
                _board.SetCell(position.Value, _cpuValue);

        } while (_board.Winner == null);

        PrintBoard(_board.Line);
        PrintWinner();

    }

    private void PrintBoard(uint[] line)
    {
        var sb = new StringBuilder();

        sb.Append(string.Format(" {0} | {1} | {2} \n", _symbols[line[0]], _symbols[line[1]], _symbols[line[2]]));
        sb.Append("---|---|---\n");
        sb.Append(string.Format(" {0} | {1} | {2} \n", _symbols[line[3]], _symbols[line[4]], _symbols[line[5]]));
        sb.Append("---|---|---\n");
        sb.Append(string.Format(" {0} | {1} | {2} \n", _symbols[line[6]], _symbols[line[7]], _symbols[line[8]]));

        Console.WriteLine(sb.ToString());
    }

    private void PrintWinner()
    {
        string message = _board.Winner switch
        {
            0u => "It's a tie!",
            > 0u => $"{_symbols[_board.Winner.Value]} won!",
            _ => string.Empty
        };

        if (!string.IsNullOrEmpty(message))
            Console.WriteLine(message);

        Console.WriteLine("\nGame over.");
    }

    private uint? GetUserPosition()
    {
        bool validInput = false;

        do
        {
            Console.Write("\nChoose position (1-9): ");
            var input = Console.ReadLine();
            var parsed = uint.TryParse(input, out uint inputValue);

            if (!parsed || inputValue < 1 || inputValue > 9)
                continue;

            return inputValue - 1u;

        } while (!validInput);

        return null;
    }

    private void SetValues()
    {
        Console.Write("Play as 'x' or 'o'? (X/o): ");
        var input = Console.ReadLine();
        _userValue = input?.ToLower().Trim() == "o" ? 2u : 1u;
        _cpuValue = _userValue == 1u ? 2u : 1u;
    }

    private void SetDifficulty()
    {
        Console.Write("Difficulty 1-Easy (default), 2-Medium, 3-Hard (1-3): ");
        var input = Console.ReadLine();
        var parsed = int.TryParse(input, out int inputValue);

        if (parsed)
        {
            _difficulty = ToDifficulty(inputValue);
        }
    }

    private void SetCpuPlayer()
    {
        switch (_difficulty)
        {
            case Difficulty.Easy:
                _cpu = new PredictablePlayer();
                break;
            case Difficulty.Medium:
                _cpu = new RandomPlayer();
                break;
            case Difficulty.Hard:
                _cpu = new MinimaxPlayer(_reversingBoard);
                break;
            default:
                break;
        }
    }

    private void SetCpuStarts()
    {
        Console.Write("CPU starts? (y/N): ");
        var input = Console.ReadLine();
        _cpuStarts = input?.ToLower().Trim() == "y";
    }

    private Difficulty ToDifficulty(int value)
    {
        return value switch
        {
            1 => Difficulty.Easy,
            2 => Difficulty.Medium,
            3 => Difficulty.Hard,
            _ => Difficulty.Easy
        };
    }
}
