using TicTacToe.View.Controller;
using TicTacToe.Business;
using TicTacToe.Business.Controller;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            IPlayerController playerController = new PlayerController();

            GameController game = new GameController(dataManager, playerController);
            game.Start();
        }
    }
}
