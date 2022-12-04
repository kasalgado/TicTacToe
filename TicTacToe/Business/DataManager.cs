using System;

namespace TicTacToe.Business
{
    public class DataManager
    {
        private Array _matrix;

        public DataManager()
        {
            _matrix = new char[3, 3]
            {
                { '7', '8', '9' },
                { '4', '5', '6' },
                { '1', '2', '3' },
            };
        }

        public Array GetMatrix()
        {
            return _matrix;
        }

        public int MapNumber(ConsoleKey number, char value)
        {
            int positionNumber = 0;

            switch (number)
            {
                case ConsoleKey.NumPad1:
                    _matrix.SetValue(value, 2, 0);
                    positionNumber = 1;
                    break;
                case ConsoleKey.NumPad2:
                    _matrix.SetValue(value, 2, 1);
                    positionNumber = 2;
                    break;
                case ConsoleKey.NumPad3:
                    _matrix.SetValue(value, 2, 2);
                    positionNumber = 3;
                    break;
                case ConsoleKey.NumPad4:
                    _matrix.SetValue(value, 1, 0);
                    positionNumber = 4;
                    break;
                case ConsoleKey.NumPad5:
                    _matrix.SetValue(value, 1, 1);
                    positionNumber = 5;
                    break;
                case ConsoleKey.NumPad6:
                    _matrix.SetValue(value, 1, 2);
                    positionNumber = 6;
                    break;
                case ConsoleKey.NumPad7:
                    _matrix.SetValue(value, 0, 0);
                    positionNumber = 7;
                    break;
                case ConsoleKey.NumPad8:
                    _matrix.SetValue(value, 0, 1);
                    positionNumber = 8;
                    break;
                case ConsoleKey.NumPad9:
                    _matrix.SetValue(value, 0, 2);
                    positionNumber = 9;
                    break;
            }

            return positionNumber;
        }
    }
}
