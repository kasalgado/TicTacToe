using System;
using System.Collections.Generic;

namespace TicTacToe.View
{
    internal static class Translator
    {
        private static readonly Dictionary<string, string> _messages = new Dictionary<string, string>
        {
            { "welcome.players", "Welcome players" },
            { "game.over", "Game finished" },
            { "your.turn", "Your turn: " },
            { "player.name", "player name: " },
            { "enter.finish", "(Press Enter to finish)" },
            { "you.won", " you won!" },
            { "wrong.key", "Please press a number from 1-9 and use the number pad!" },
            { "pressed.number", "This number was already pressed!" },
        };

        public static string Translate(string key)
        {
            return _messages[key];
        }
    }
}
