using System;
using TicTacToe.Business;
using TicTacToe.Business.Controller;

namespace TicTacToe.View.Controller
{
    internal class GameController
    {
        private Array _matrix;
        private Player _player1;
        private Player _player2;

        private DataManager _dataManager;
        private IPlayerController _playerController;

        public GameController(DataManager dataManager, IPlayerController playerController)
        {
            _dataManager = dataManager;
            _playerController = playerController;
        }

        public void Start()
        {
            Console.WriteLine(Messages.GetMessage("welcome.players") + Environment.NewLine);
            CreatePlayers();

            _matrix = _dataManager.GetMatrix();
            ConsoleKey pressedKey;
            Player currentPlayer = _playerController.NextPlayer(_player1, _player2);

            do
            {
                RunGame(currentPlayer);
                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey >= ConsoleKey.NumPad1 && pressedKey <= ConsoleKey.NumPad9)
                {
                    int position = _dataManager.MapNumber(pressedKey, currentPlayer.Symbol);
                    currentPlayer.SetPosition(position);

                    if (_playerController.IsWinner(currentPlayer))
                    {
                        RunGame(currentPlayer);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(currentPlayer.Name + Messages.GetMessage("you.won"));
                        Console.ResetColor();
                        break;
                    }

                    currentPlayer = _playerController.NextPlayer(_player1, _player2);
                }
            } while (pressedKey != ConsoleKey.Enter);

            Console.WriteLine(Messages.GetMessage("game.over"));
            Console.ReadKey(true);
        }

        private string CreateMatrix(Array matrix)
        {
            MatrixCreator matrixCreator = new MatrixCreator();

            return matrixCreator.Create(matrix);
        }

        private void CreatePlayers()
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
