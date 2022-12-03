namespace TicTacToe.Business.Controller
{
    internal interface IPlayerController
    {
        Player NextPlayer(Player player1, Player player2);
        bool IsWinner(Player player);
    }
}
