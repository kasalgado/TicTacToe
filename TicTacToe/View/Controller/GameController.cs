using System;
using System.Linq;
using TicTacToe.Business;
using TicTacToe.Business.Controller;

namespace TicTacToe.View.Controller
{
    internal class GameController
    {
        private const char PLAYER_SYMBOL_X = 'X';
        private const char PLAYER_SYMBOL_O = 'O';

        private Array _matrix;
        private Player _player1;
        private Player _player2;
        private string _notification;

        private MatrixController _matrixController;
        private PlayerController _playerController;
        private MatrixCreator _matrixCreator;

        private int[] _matrixPositions = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public GameController(MatrixController matrixController, PlayerController playerController, MatrixCreator matrixCreator)
        {
            _matrixController = matrixController;
            _playerController = playerController;
            _matrixCreator = matrixCreator;
        }

        public void Start()
        {
            _matrix = _matrixController.GetMatrix();
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
                        _matrixController.SetSymbol(pressedKey, currentPlayer.Symbol);

                        if (_playerController.IsWinner(currentPlayer))
                        {
                            DisplayGame(currentPlayer);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(Environment.NewLine + currentPlayer.Name + Translator.Translate("you.won"));
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
            Console.WriteLine(Environment.NewLine + Translator.Translate("game.over"));
            Console.ReadKey(true);
        }

        public void EnterPlayers()
        {
            Console.WriteLine(Translator.Translate("welcome.players") + Environment.NewLine);

            _player1 = CreatePlayer(PLAYER_SYMBOL_X);
            _player2 = CreatePlayer(PLAYER_SYMBOL_O);

            SoundController.Play("play");
        }

        private Player CreatePlayer(char symbol)
        {
            Console.Write($"[{symbol}] {Translator.Translate("player.name")}");
            String name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.Write($"[{symbol}] {Translator.Translate("player.name")}");
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
            Console.WriteLine(Translator.Translate("your.turn") + currentPlayer.Name + Environment.NewLine);
            Console.ResetColor();
            
            Console.WriteLine(_matrixCreator.Create(_matrix));
            Console.Beep();

            if (!String.IsNullOrEmpty(_notification) && !_playerController.IsWinner(currentPlayer))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Translator.Translate(_notification) + Environment.NewLine);
                Console.ResetColor();
                SoundController.Play("error");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Translator.Translate("enter.finish"));
            Console.ResetColor();
        }

        private void RemoveMatrixPosition(int position)
        {
            _matrixPositions = _matrixPositions.Where(e => e != position).ToArray();
        }
    }
}
