using TicTacToe.Business;

namespace TicTacToeTests
{
    class DataManagerTests
    {
        private MatrixManager _dataManager;

        [SetUp]
        public void Setup()
        {
            _dataManager = new MatrixManager();
        }
    }
}