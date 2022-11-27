using TicTacToe;

namespace TicTacToeTests
{
    public class CheckerTests
    {
        [Test]
        public void CheckThereIsAWinner()
        {
            Array matrix = new char[3, 3]
            {
                { 'X', '8', '9' },
                { '4', 'X', '6' },
                { '1', '2', 'X' },
            };

            Checker checker = new Checker(matrix);

            Assert.That(matrix, Is.EqualTo(checker.getMatrix()));
            Assert.IsTrue(checker.IsWinner());
        }
    }
}
