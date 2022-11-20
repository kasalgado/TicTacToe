﻿using System;

namespace TicTacToe.View
{
    internal class StringCreator
    {
        public string CreateTicTacToe(Array matrix)
        {
            string result = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result += matrix.GetValue(i, j) + "|";
                }

                result += Environment.NewLine;
                result += "-----" + Environment.NewLine;
            }

            return result;
        }
    }
}