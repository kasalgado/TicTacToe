using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Checker
    {
        private Array _matrix;

        public Checker(Array matrix)
        {
            _matrix = matrix;
        }

        public bool IsWinner()
        {
            return true;
        }

        public Array getMatrix()
        {
            return _matrix;
        }

        private void Check()
        {
            
        }
    }
}
