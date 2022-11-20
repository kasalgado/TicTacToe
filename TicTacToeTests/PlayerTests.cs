using TicTacToe.Business;

namespace TicTacToeTests
{
    class PlayerTests
    {
        private Player _player1;
        private Player _player2;

        [SetUp]
        public void Setup()
        {
            _player1 = new Player(1);
            _player2 = new Player(2);
        }

        [Test]
        public void Get_Player_From_Id()
        {
            Assert.That(_player1, Is.InstanceOf<Player>());
            Assert.That(1, Is.EqualTo(_player1.Id));

            Assert.That(_player2, Is.InstanceOf<Player>());
            Assert.That(2, Is.EqualTo(_player2.Id));
        }
    }
}
