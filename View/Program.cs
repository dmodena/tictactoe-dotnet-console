using System.Text;

void PrintBoard(int[,] values, string[] symbols)
{
    var sb = new StringBuilder();

    sb.Append(string.Format(" {0} | {1} | {2} \n", symbols[values[0, 0]], symbols[values[0, 1]], symbols[values[0, 2]]));
    sb.Append("---|---|---\n");
    sb.Append(string.Format(" {0} | {1} | {2} \n", symbols[values[1, 0]], symbols[values[1, 1]], symbols[values[1, 2]]));
    sb.Append("---|---|---\n");
    sb.Append(string.Format(" {0} | {1} | {2} \n", symbols[values[2, 0]], symbols[values[2, 1]], symbols[values[2, 2]]));

    Console.WriteLine(sb.ToString());
}

int[,] values = { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 0 } };
var symbols = new string[] { " ", "x", "o" };

PrintBoard(values, symbols);
