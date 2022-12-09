using System;
using System.Linq;
using TicTacToe.Business;
using TicTacToe.Business.Controller;

namespace TicTacToe.View.Controller
{
    internal class GameController
    {
        private Array _matrix;
        private Player _player1;
        private Player _player2;
        private string _notification;

        private MatrixManager _dataManager;
        private PlayerController _playerController;
        private MatrixCreator _matrixCreator;

        private int[] _matrixPositions = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public GameController(MatrixManager dataManager, PlayerController playerController, MatrixCreator matrixCreator)
        {
            _dataManager = dataManager;
            _playerController = playerController;
            _matrixCreator = matrixCreator;
        }

        public void Start()
        {
            _matrix = _dataManager.GetMatrix();
            ConsoleKey pressedKey;
            Player currentPlayer = _player1;

            do
            {
                DisplayGame(currentPlayer);
                pressedKey = Console.ReadKey(true).Key;

                if (pressedKey >= ConsoleKey.NumPad1 && pressedKey <= ConsoleKey.NumPad9)
                {
                    string strNumber = pressedKey.ToString();
                    int position = int.Parse(strNumber.Substring(strNumber.Length - 1));

                    if (Array.IndexOf(_matrixPositions, position) != -1)
                    {
                        currentPlayer.SetPosition(position);
                        _dataManager.MapNumber(pressedKey, currentPlayer.Symbol);

                        if (_playerController.IsWinner(currentPlayer))
                        {
                            DisplayGame(currentPlayer);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(Environment.NewLine + currentPlayer.Name + Messages.GetMessage("you.won"));
                            Console.ResetColor();
                            SoundController.Play("winner");
                            break;
                        }

                        currentPlayer = _playerController.NextPlayer(_player1, _player2);
                        RemoveMatrixPosition(position);
                        _notification = null;
                    }
                    else
                    {
                        _notification = "pressed.number";
                    }
                }
                else
                {
                    _notification = "wrong.key";
                }
            } while (pressedKey != ConsoleKey.Enter);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine + Messages.GetMessage("game.over"));
            Console.ReadKey(true);
        }

        public void EnterPlayers()
        {
            Console.WriteLine(Messages.GetMessage("welcome.players") + Environment.NewLine);

            _player1 = CreatePlayer('X');
            _player2 = CreatePlayer('O');

            SoundController.Play("play");
        }

        private Player CreatePlayer(char symbol)
        {
            Console.Write($"[{symbol}] {Messages.GetMessage("player.name")}");
            String name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.Write($"[{symbol}] {Messages.GetMessage("player.name")}");
                name = Console.ReadLine();
            }

            return new Player(name, symbol);
        }

        public void ShowInstructions()
        {
            foreach (string line in System.IO.File.ReadLines(@"c:\temp\GameInstructions.txt"))
            {
                Console.WriteLine(line);
            }

            SoundController.Play("start");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void DisplayGame(Player currentPlayer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Messages.GetMessage("your.turn") + currentPlayer.Name + Environment.NewLine);
            Console.ResetColor();
            
            Console.WriteLine(_matrixCreator.Create(_matrix));
            Console.Beep();

            if (!String.IsNullOrEmpty(_notification) && !_playerController.IsWinner(currentPlayer))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Messages.GetMessage(_notification) + Environment.NewLine);
                Console.ResetColor();
                SoundController.Play("error");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Messages.GetMessage("enter.finish"));
            Console.ResetColor();
        }

        private void RemoveMatrixPosition(int position)
        {
            _matrixPositions = _matrixPositions.Where(e => e != position).ToArray();
        }
    }
}
