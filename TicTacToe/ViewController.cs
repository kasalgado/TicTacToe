using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ViewController
    {
        public ViewController()
        {
            DisplayPressedKey();
            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
        }

        public void DisplayChar()
        {
            DataManager dataManager = new DataManager();
            char initValue = dataManager.GetMatrixValue(0, 0);
            Console.WriteLine(initValue);

            dataManager.SetMatrixValue('x', 0, 0);
            char newValue = dataManager.GetMatrixValue(0, 0);
            Console.WriteLine(newValue);

            while (Console.ReadKey().Key != ConsoleKey.Enter) { };

            dataManager.SetMatrixValue('o', 0, 0);
            newValue = dataManager.GetMatrixValue(0, 0);
            Console.WriteLine(newValue);

            while (Console.ReadKey().Key != ConsoleKey.Enter) { };

            DisplayPressedKey();

            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
        }

        public void DisplayPressedKey()
        {
            Console.WriteLine(GetPressedKey());
        }

        private ConsoleKey GetPressedKey()
        {
            ConsoleKey pressedKey = Console.ReadKey().Key;

            if (pressedKey >= ConsoleKey.NumPad1 && pressedKey <= ConsoleKey.NumPad9)
            {
                return pressedKey;
            }

            return ConsoleKey.A;
        }
    }
}
