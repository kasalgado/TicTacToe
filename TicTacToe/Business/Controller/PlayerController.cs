namespace TicTacToe.Business.Controller
{
    public class PlayerController
    {
        public Player NextPlayer(Player player1, Player player2)
        {
            if (player1.Active)
            {
                player1.Active = false;
                player2.Active = true;

                return player1;
            }
            else
            {
                player1.Active = true;
                player2.Active = false;

                return player2;
            }
        }
    }
}
