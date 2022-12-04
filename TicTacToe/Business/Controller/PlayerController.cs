using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Business.Controller
{
    public class PlayerController : IPlayerController
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

        public bool IsWinner(Player player)
        {
            if (player.GetPositions().Count >= 3)
            {
                return SearchMatch(player.GetPositions());
            }

            return false;
        }

        private bool SearchMatch(List<int> results)
        {
            List<List<int>> matchedResults = new List<List<int>>
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 1, 5, 9 },
                new List<int>() { 1, 4, 7 },
                new List<int>() { 2, 5, 8 },
                new List<int>() { 3, 5, 7 },
                new List<int>() { 3, 6, 9 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 7, 8, 9 },
            };

            foreach (List<int> match in matchedResults)
            {
                if (!match.Except(results).Any())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
