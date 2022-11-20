namespace TicTacToe.Business
{
    public class Player
    {
        private int _id;

        public int Id { get => _id;  }

        public bool Active { get; set; }

        public Player(int id)
        {
            _id = id;
        }
    }
}
