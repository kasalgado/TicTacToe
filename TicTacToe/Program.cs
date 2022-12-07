using TicTacToe.View.Controller;
using TicTacToe.Business;
using TicTacToe.Business.Controller;
using TicTacToe.View;
using System;
using System.IO;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            PlayerController playerController = new PlayerController();
            MatrixCreator matrixCreator = new MatrixCreator();

            GameController game = new GameController(dataManager, playerController, matrixCreator);
            game.ShowInstructions();
            game.EnterPlayers();
            game.Start();
        }
    }
}
