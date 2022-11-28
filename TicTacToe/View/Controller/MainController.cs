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
            Console.WriteLine(Messages.GetMessage("welcome.players") + Environment.NewLine);
            EnterPlayers();

            DataManager dataManager = new DataManager();
            _matrix = dataManager.GetMatrix();
            ConsoleKey pressedKey;
            PlayerController playerController = new PlayerController();
            Player currentPlayer = playerController.NextPlayer(_player1, _player2);
            
            do
            {
                RunGame(currentPlayer);
                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey >= ConsoleKey.NumPad1 && pressedKey <= ConsoleKey.NumPad9)
                {
                    int position = dataManager.MapNumber(pressedKey, currentPlayer.Symbol);
                    currentPlayer.SetPosition(position);

                    if (playerController.IsWinner(currentPlayer))
                    {
                        RunGame(currentPlayer);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(currentPlayer.Name + Messages.GetMessage("you.won"));
                        Console.ResetColor();
                        break;
                    }

                    currentPlayer = playerController.NextPlayer(_player1, _player2);
                }
            } while (pressedKey != ConsoleKey.Enter);
                
            Console.WriteLine(Messages.GetMessage("game.over"));
            Console.ReadKey(true);
        }

        private string CreateMatrix(Array matrix)
        {
            StringCreator stringCreator = new StringCreator();

            return stringCreator.CreateTicTacToe(matrix);
        }

        private void EnterPlayers()
        {
            Console.Write("X " + Messages.GetMessage("player.name"));
            String name1 = Console.ReadLine();
            _player1 = new Player(name1, 'X');

            Console.Write("O " + Messages.GetMessage("player.name"));
            String name2 = Console.ReadLine();
            _player2 = new Player(name2, 'O');
        }

        private void RunGame(Player currentPlayer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Messages.GetMessage("your.turn") + currentPlayer.Name + Environment.NewLine);
            Console.ResetColor();
            Console.WriteLine(CreateMatrix(_matrix));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Messages.GetMessage("enter.finish"));
            Console.ResetColor();
        }
    }
}
