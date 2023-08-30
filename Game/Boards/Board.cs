namespace Game.Boards
{
    public class Board : IBoard
    {
        public uint[] Line { get => line; }
        public uint[] AvailablePositions { get => GetAvailablePositions(); }
        public uint? Winner { get => GetWinner(); }

        protected readonly uint[] line;
        private const uint LineLength = 9;
        private const uint MaxPosition = 8;
        private const uint MaxCellValue = 2;

        public Board() : this(new uint[9]) { }

        public Board(uint[] line)
        {
            ValidateLine(line);
            this.line = line;
        }

        public virtual bool SetCell(uint position, uint value)
        {
            ValidatePosition(position);
            ValidateValue(value);

            if (line[position] != 0)
                return false;

            line[position] = value;
            return true;
        }

        private uint[] GetAvailablePositions()
        {
            var positions = new List<uint>();

            for (uint i = 0; i < LineLength; i++)
            {
                if (line[i] == 0)
                    positions.Add(i);
            }

            return positions.ToArray();
        }

        private uint? GetWinner()
        {
            if (line[0] != 0 && line[0] == line[1] && line[0] == line[2])
                return line[0];

            if (line[3] != 0 && line[3] == line[4] && line[3] == line[5])
                return line[3];

            if (line[6] != 0 && line[6] == line[7] && line[6] == line[8])
                return line[6];

            if (line[0] != 0 && line[0] == line[3] && line[0] == line[6])
                return line[0];

            if (line[1] != 0 && line[1] == line[4] && line[1] == line[7])
                return line[1];

            if (line[2] != 0 && line[2] == line[5] && line[2] == line[8])
                return line[2];

            if (line[0] != 0 && line[0] == line[4] && line[0] == line[8])
                return line[0];

            if (line[2] != 0 && line[2] == line[4] && line[2] == line[6])
                return line[2];

            if (Array.IndexOf(line, 0u) == -1)
                return 0u;

            return null;
        }

        protected void ValidateLine(uint[] line)
        {
            if (line.Length != LineLength)
                throw new ArgumentException($"Line must be of length { LineLength }", nameof(line));

            foreach (var v in line)
                ValidateValue(v);
        }

        protected void ValidateValue(uint value)
        {
            if (value > MaxCellValue)
                throw new ArgumentException($"Cell value cannot exceed { MaxCellValue }", nameof(value));
        }

        protected void ValidatePosition(uint position)
        {
            if (position > MaxPosition)
                throw new ArgumentException($"Position cannot exceed { MaxPosition }", nameof(position));
        }
    }
}
