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
                Player currentPlayer = playerController.NextPlayer(_player1, _player2);
                Display(currentPlayer);
                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey >= ConsoleKey.NumPad1 && pressedKey <= ConsoleKey.NumPad9)
                {
                    int position = dataManager.MapNumber(pressedKey, currentPlayer.Symbol);
                    currentPlayer.SetPosition(position);

                    if (playerController.IsWinner(currentPlayer))
                    {
                        Display(currentPlayer);
                        Console.WriteLine(currentPlayer.Name + Messages.GetMessageByIndex(5));
                        break;
                    }
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

        private void InputPlayers()
        {
            Console.Write("X " + Messages.GetMessageByIndex(3));
            String name1 = Console.ReadLine();
            _player1 = new Player(name1, 'X');

            Console.Write("O " + Messages.GetMessageByIndex(3));
            String name2 = Console.ReadLine();
            _player2 = new Player(name2, 'O');
        }

        private void Display(Player currentPlayer)
        {
            Console.Clear();
            Console.WriteLine(Messages.GetMessageByIndex(2) + currentPlayer.Name + Environment.NewLine);
            Console.WriteLine(CreateMatrix(_matrix));
            Console.WriteLine(Messages.GetMessageByIndex(4));
        }
    }
}
