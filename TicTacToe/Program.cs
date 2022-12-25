using TicTacToe.View.Controller;
using TicTacToe.Business.Controller;
using TicTacToe.View;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatrixController matrixController = new MatrixController();
            PlayerCreator playerCreator = new PlayerCreator();
            PlayerController playerController = new PlayerController();
            MatrixCreator matrixCreator = new MatrixCreator();

            GameController game = new GameController(matrixController, playerCreator, playerController, matrixCreator);
            game.ShowInstructions();
            game.EnterPlayers();
            game.Run();
        }
    }
}
