using System;
using TicTacToe.Business;

namespace TicTacToe.View.Controller
{
    internal class MainController
    {
        public MainController()
        {
            Console.WriteLine(CreateMatrix());
            DisplayPressedKey();
            Console.WriteLine(Messages.GetMessageByIndex(0));

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

        private string CreateMatrix()
        {
            DataManager dataManager = new DataManager();
            Array matrix = dataManager.GetInitialMatrix();
            StringCreator stringCreator = new StringCreator();

            return stringCreator.CreateTicTacToe(matrix);
        }
    }
}
