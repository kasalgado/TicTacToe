using System;
using System.Collections.Generic;

namespace TicTacToe.View
{
    internal static class Messages
    {
        private static readonly Dictionary<string, string> _messages = new Dictionary<string, string>
        {
            { "welcome.players", "Welcome players" },
            { "game.over", "Game over" },
            { "your.turn", "Your turn: " },
            { "player.name", "Player name: " },
            { "enter.finish", "Press Enter to finish" },
            { "you.won", " you won!" },
        };

        public static string GetMessage(string key)
        {
            return _messages[key];
        }
    }
}
