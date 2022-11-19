using TicTacToe;

namespace TicTacToeTests
{
    class DataManagerTests
    {
        private DataManager _dataManager;

        [SetUp]
        public void Setup()
        {
            _dataManager = new DataManager();
        }

        [Test]
        public void Return_Initial_Matrix_Values()
        {
            char matrixValue = _dataManager.GetMatrixValue(0, 0);

            Assert.That(matrixValue, Is.EqualTo('1'));
        }

        [Test]
        public void Set_Value_In_Matrix()
        {
            _dataManager.SetMatrixValue('x', 0, 0);
            char matrixValue = _dataManager.GetMatrixValue(0, 0);

            Assert.That(matrixValue, Is.EqualTo('x'));
        }
    }
}