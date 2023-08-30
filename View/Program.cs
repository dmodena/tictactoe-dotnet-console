using System.Text;
using Game;

static void PrintBoard(uint[] values, string[] symbols)
{
    var sb = new StringBuilder();

    sb.Append(string.Format(" {0} | {1} | {2} \n", symbols[values[0]], symbols[values[1]], symbols[values[2]]));
    sb.Append("---|---|---\n");
    sb.Append(string.Format(" {0} | {1} | {2} \n", symbols[values[3]], symbols[values[4]], symbols[values[5]]));
    sb.Append("---|---|---\n");
    sb.Append(string.Format(" {0} | {1} | {2} \n", symbols[values[6]], symbols[values[7]], symbols[values[8]]));

    Console.WriteLine(sb.ToString());
}

static uint? GetUserPosition()
{
    bool validInput = false;

    do
    {
        Console.Write("\nChoose position (1-9): ");
        var input = Console.ReadLine();

        var parsed = uint.TryParse(input, out uint inputValue);
        if (!parsed)
            continue;

        if (inputValue < 1 || inputValue > 9)
            continue;

        return inputValue - 1u;

    } while (!validInput);

    return null;
}

var gameControl = new Control();
var cpu = new MinimaxPlayer(new ReversingBoard());
var symbols = new string[] { " ", "x", "o" };


Console.Write("Would you like to start? (Y/n): ");
var input = Console.ReadLine();
var humanFirst = input?.ToLower().Trim() == "y";

var (humanValue, cpuValue) = (1u, 2u);
uint? pos;

if (!humanFirst)
{
    pos = cpu.Play(gameControl.Values, cpuValue);
    if (pos != null)
        gameControl.SetValue(pos.Value, cpuValue);
}

do
{
    Console.WriteLine();
    PrintBoard(gameControl.Values, symbols);
    pos = GetUserPosition();
    if (pos != null)
        gameControl.SetValue(pos.Value, humanValue);

    pos = cpu.Play(gameControl.Values, cpuValue);
    if (pos != null)
        gameControl.SetValue(pos.Value, cpuValue);

} while (gameControl.Active);

PrintBoard(gameControl.Values, symbols);
Console.WriteLine("Game over");
