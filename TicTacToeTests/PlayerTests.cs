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
            _player1 = new Player("kas", 'X');
            _player2 = new Player("nms", 'O');
        }

        [Test]
        public void Get_Player_From_Id()
        {
            Assert.That(_player1, Is.InstanceOf<Player>());
            Assert.That("kas", Is.EqualTo(_player1.Name));

            Assert.That(_player2, Is.InstanceOf<Player>());
            Assert.That("nms", Is.EqualTo(_player2.Name));
        }
    }
}
