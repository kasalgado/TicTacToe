using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
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
