using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.View.Controller
{
    internal static class SoundController
    {
        public static void Play(string name)
        {
            int herz = 100;
            int seconds = 1000;
            int count = 0;

            switch (name)
            {
                case "start":
                    herz = 500;
                    seconds = 500;
                    count = 3;
                    break;

                case "play":
                    herz = 600;
                    seconds = 200;
                    count = 5;
                    break;

                case "error":
                    herz = 300;
                    seconds = 1000;
                    count = 1;
                    break;

                case "winner":
                    herz = 1000;
                    seconds = 1000;
                    count = 3;
                    break;
            }

            Generate(count, herz, seconds);
        }

        private static void Generate(int count, int herz, int seconds)
        {
            for (int c = 1; c <= count; c++)
            {
                Console.Beep(herz * c, seconds);
            }
        }
    }
}
