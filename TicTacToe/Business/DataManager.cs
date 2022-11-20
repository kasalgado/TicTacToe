using System;

namespace TicTacToe.Business
{
    public class DataManager
    {
        private Array _matrix;

        public DataManager()
        {
            this.InitMatrix();
        }

        private void InitMatrix()
        { 
            _matrix = new char[3, 3]
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
        }

        public void SetMatrixValue(char value, int index1, int index2)
        {
            _matrix.SetValue(value, index1, index2);
        }

        public char GetMatrixValue(int index1, int index2)
        {
            return (char)_matrix.GetValue(index1, index2);
        }

        public Array GetInitialMatrix()
        {
            return _matrix;
        }
    }
}
