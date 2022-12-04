using System;

namespace TicTacToe.View
{
    internal class MatrixCreator : IMatrixCreator
    {
        public string Create(Array matrix)
        {
            string result = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result += matrix.GetValue(i, j);

                    if (j < 2)
                    {
                        result += "|";
                    }
                }

                result += Environment.NewLine;

                if (i < 2)
                {
                    result += "-----" + Environment.NewLine;
                }
            }

            return result;
        }
    }
}
