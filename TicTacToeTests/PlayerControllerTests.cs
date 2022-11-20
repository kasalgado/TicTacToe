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
            _player1 = new Player(1);
            _player1.Active = true;

            _player2 = new Player(2);
            _player2.Active = false;

            _playerController = new PlayerController();
        }

        [Test]
        public void Iterate_Next_Player()
        {
            Player nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That(1, Is.EqualTo(nextPlayer.Id));

            nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That(2, Is.EqualTo(nextPlayer.Id));

            nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That(1, Is.EqualTo(nextPlayer.Id));

            nextPlayer = _playerController.NextPlayer(_player1, _player2);
            Assert.That(2, Is.EqualTo(nextPlayer.Id));
        }
    }
}
