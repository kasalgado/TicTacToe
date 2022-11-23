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

        public void MapNumber(ConsoleKey number, char value)
        {
            switch (number)
            {
                case ConsoleKey.NumPad1:
                    _matrix.SetValue(value, 0, 0);
                    break;
                case ConsoleKey.NumPad2:
                    _matrix.SetValue(value, 0, 1);
                    break;
                case ConsoleKey.NumPad3:
                    _matrix.SetValue(value, 0, 2);
                    break;
                case ConsoleKey.NumPad4:
                    _matrix.SetValue(value, 1, 0);
                    break;
                case ConsoleKey.NumPad5:
                    _matrix.SetValue(value, 1, 1);
                    break;
                case ConsoleKey.NumPad6:
                    _matrix.SetValue(value, 1, 2);
                    break;
                case ConsoleKey.NumPad7:
                    _matrix.SetValue(value, 2, 0);
                    break;
                case ConsoleKey.NumPad8:
                    _matrix.SetValue(value, 2, 1);
                    break;
                case ConsoleKey.NumPad9:
                    _matrix.SetValue(value, 2, 2);
                    break;
            }
        }

        public void SetMatrixValue(char value, int index1, int index2)
        {
            _matrix.SetValue(value, index1, index2);
        }

        public char GetMatrixValue(int index1, int index2)
        {
            return (char)_matrix.GetValue(index1, index2);
        }

        public Array GetMatrix()
        {
            return _matrix;
        }
    }
}
