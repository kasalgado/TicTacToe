namespace TicTacToe.Business
{
    public class Player
    {
        private string _name;

        public string Name { get => _name;  }

        public bool Active { get; set; }

        public Player(string name)
        {
            _name = name;
        }
    }
}
