using TicTacToe.View.Controller;
using TicTacToe.Business;
using TicTacToe.Business.Controller;
using TicTacToe.View;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            IPlayerController playerController = new PlayerController();
            IMatrixCreator matrixCreator = new MatrixCreator();

            GameController game = new GameController(dataManager, playerController, matrixCreator);
            game.EnterPlayers();
            game.Start();
        }
    }
}
