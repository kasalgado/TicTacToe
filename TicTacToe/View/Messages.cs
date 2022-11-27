using System;

namespace TicTacToe.View
{
    internal static class Messages
    {
        private static readonly Array _messages = new string[]
        {
            "Welcome players",
            "Game over",
            "Your turn: ",
            "Player name: ",
            "Press Enter to finish",
            " you won!",
        };

        public static string GetMessageByIndex(int index)
        {
            return _messages.GetValue(index).ToString();
        }
    }
}
