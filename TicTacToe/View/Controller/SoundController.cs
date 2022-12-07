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
            int hertz = 100;
            int seconds = 1000;
            int count = 0;

            switch (name)
            {
                case "start":
                    hertz = 500;
                    seconds = 500;
                    count = 3;
                    break;

                case "play":
                    hertz = 600;
                    seconds = 200;
                    count = 5;
                    break;

                case "error":
                    hertz = 300;
                    seconds = 1000;
                    count = 1;
                    break;

                case "winner":
                    hertz = 500;
                    seconds = 1200;
                    count = 3;
                    break;
            }

            Generate(count, hertz, seconds);
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
