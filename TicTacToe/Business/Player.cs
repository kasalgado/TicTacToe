using System.Collections.Generic;

namespace TicTacToe.Business
{
    public class Player
    {
        private string _name;
        private char _symbol;
        private List<int> _positions;

        public string Name { get => _name;  }

        public char Symbol { get => _symbol; }

        public bool Active { get; set; }

        public Player(string name, char symbol)
        {
            _name = name;
            _symbol = symbol;
            _positions = new List<int>();
        }

        public void SetPosition(int position)
        {
            _positions.Add(position);
        }

        public List<int> GetPositions()
        {
            return _positions;
        }
    }
}
