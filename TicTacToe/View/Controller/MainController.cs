using System;
using TicTacToe.Business;
using TicTacToe.Business.Controller;

namespace TicTacToe.View.Controller
{
    internal class MainController
    {
        private Array _matrix;
        private Player _player1;
        private Player _player2;

        public MainController()
        {
            Console.WriteLine(Messages.GetMessageByIndex(0) + Environment.NewLine);

            InputPlayers();

            DataManager dataManager = new DataManager();
            _matrix = dataManager.GetMatrix();
            ConsoleKey pressedKey;
            PlayerController playerController = new PlayerController();
            
            do
            {
                Console.Clear();

                Player nextPlayer = playerController.NextPlayer(_player1, _player2);
                Console.WriteLine(Messages.GetMessageByIndex(2) + nextPlayer.Name + Environment.NewLine);
                Console.WriteLine(CreateMatrix(_matrix));
                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey >= ConsoleKey.NumPad1 && pressedKey <= ConsoleKey.NumPad9)
                {
                    dataManager.MapNumber(pressedKey, 'X');
                }
            } while (pressedKey != ConsoleKey.Enter);

            Console.WriteLine(Messages.GetMessageByIndex(1));
            Console.ReadKey(true);
        }

        private string CreateMatrix(Array matrix)
        {
            StringCreator stringCreator = new StringCreator();

            return stringCreator.CreateTicTacToe(matrix);
        }

        private Player CreatePlayer(string name)
        {
            return new Player(name);
        }

        private void InputPlayers()
        {
            Console.Write("1 " + Messages.GetMessageByIndex(3));
            String name1 = Console.ReadLine();
            _player1 = CreatePlayer(name1);

            Console.Write("2 " + Messages.GetMessageByIndex(3));
            String name2 = Console.ReadLine();
            _player2 = CreatePlayer(name2);
        }
    }
}
