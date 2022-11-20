using System;

namespace TicTacToe.View
{
    internal static class Messages
    {
        private static readonly Array _messages = new string[1]
        {
            "First message"
        };

        public static string GetMessageByIndex(int index)
        {
            return _messages.GetValue(index).ToString();
        }
    }
}
