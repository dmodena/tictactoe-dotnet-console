namespace Game
{
    public class Board : IBoard
    {
        public uint[] Line { get => _line; }
        public uint[] AvailablePositions { get => GetAvailablePositions(); }
        public uint? Winner { get => GetWinner(); }

        private readonly uint[] _line;
        private const uint LineLength = 9;
        private const uint MaxPosition = 8;
        private const uint MaxCellValue = 2;

        public Board() : this(new uint[9]) { }

        public Board(uint[] line)
        {
            ValidateLine(line);
            _line = line;
        }

        public bool SetCell(uint position, uint value)
        {
            ValidatePosition(position);
            ValidateValue(value);

            if (_line[position] != 0)
                return false;

            _line[position] = value;
            return true;
        }

        private uint[] GetAvailablePositions()
        {
            var positions = new List<uint>();

            for (uint i = 0; i < LineLength; i++)
            {
                if (_line[i] == 0)
                    positions.Add(i);
            }

            return positions.ToArray();
        }

        private uint? GetWinner()
        {
            if (_line[0] != 0 && _line[0] == _line[1] && _line[0] == _line[2])
                return _line[0];

            if (_line[3] != 0 && _line[3] == _line[4] && _line[3] == _line[5])
                return _line[3];

            if (_line[6] != 0 && _line[6] == _line[7] && _line[6] == _line[8])
                return _line[6];

            if (_line[0] != 0 && _line[0] == _line[3] && _line[0] == _line[6])
                return _line[0];

            if (_line[1] != 0 && _line[1] == _line[4] && _line[1] == _line[7])
                return _line[1];

            if (_line[2] != 0 && _line[2] == _line[5] && _line[2] == _line[8])
                return _line[2];

            if (_line[0] != 0 && _line[0] == _line[4] && _line[0] == _line[8])
                return _line[0];

            if (_line[2] != 0 && _line[2] == _line[4] && _line[2] == _line[6])
                return _line[2];

            if (Array.IndexOf(_line, 0u) == -1)
                return 0u;

            return null;
        }

        private void ValidateLine(uint[] line)
        {
            if (line.Length != LineLength)
                throw new ArgumentException($"Line must be of length { LineLength }", nameof(line));

            foreach (var v in line)
                ValidateValue(v);
        }

        private void ValidateValue(uint value)
        {
            if (value > MaxCellValue)
                throw new ArgumentException($"Cell value cannot exceed { MaxCellValue }", nameof(value));
        }

        private void ValidatePosition(uint position)
        {
            if (position > MaxPosition)
                throw new ArgumentException($"Position cannot exceed { MaxPosition }", nameof(position));
        }
    }
}
