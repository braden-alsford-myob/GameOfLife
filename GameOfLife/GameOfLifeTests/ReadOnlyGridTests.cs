using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class ReadOnlyGridTests
    {
        [Test]
        public void It_Should_Return_True_For_An_Identical_ReadOnlyGrid()
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            Assert.True(allAliveGrid.Equals(allAliveGrid));
        }
        
        [Test]
        public void It_Should_Return_False_For_A_Subtly_Different_ReadOnlyGrid()
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            var onlyDeadCenterGrid = GridCreator.GetOnlyDeadCenterGrid();
            Assert.False(allAliveGrid.Equals(onlyDeadCenterGrid));
        }
        
        [Test]
        public void It_Should_Return_False_Given_A_ReadOnlyGrid_Of_Different_Size()
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            var twoRowAllAliveGrid = GridCreator.GetTwoRowAllAliveGrid();
            Assert.False(allAliveGrid.Equals(twoRowAllAliveGrid));
        }
        
        [Test]
        public void It_Should_Return_False_For_A_Completely_Different_ReadOnlyGrid()
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            var allDeadGrid = GridCreator.GetAllDeadGrid();
            Assert.False(allAliveGrid.Equals(allDeadGrid));
        }
    }
}