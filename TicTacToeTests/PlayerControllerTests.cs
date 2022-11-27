using TicTacToe.Business.Controller;
using TicTacToe.Business;

namespace TicTacToeTests
{
    class PlayerControllerTests
    {
        private Player _player1;
        private Player _player2;
        private PlayerController _playerController;

        [SetUp]
        public void Setup()
        {
            _player1 = new Player("kas", 'X');
            _player1.Active = true;

            _player2 = new Player("nms", 'O');
            _player2.Active = false;

            _playerController = new PlayerController();
        }

        [Test]
        public void Iterate_Next_Player()
        {
            Player nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That("kas", Is.EqualTo(nextPlayer.Name));

            nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That("nms", Is.EqualTo(nextPlayer.Name));

            nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That("kas", Is.EqualTo(nextPlayer.Name));

            nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That("nms", Is.EqualTo(nextPlayer.Name));
        }
    }
}
