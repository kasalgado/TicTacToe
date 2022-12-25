using System;
using TicTacToe.Business;

namespace TicTacToe.View.Controller
{
    internal class PlayerCreator
    {
        public Player CreatePlayer(char symbol)
        {
            Console.Write($"[{symbol}] {Translator.Translate("player.name")}");
            String name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.Write($"[{symbol}] {Translator.Translate("player.name")}");
                name = Console.ReadLine();
            }

            return new Player(name, symbol);
        }
    }
}
