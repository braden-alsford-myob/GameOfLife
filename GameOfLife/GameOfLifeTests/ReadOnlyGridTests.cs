using GameOfLifeTests.Rule.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class ReadOnlyGridTests
    {
        [Test]
        public void It_Should_Return_True_For_An_Identical_ReadOnlyGrid()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            Assert.True(allAliveGrid.Equals(allAliveGrid));
        }
        
        [Test]
        public void It_Should_Return_False_For_A_Subtly_Different_ReadOnlyGrid()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            var onlyDeadCenterGrid = GridCreatorHelper.GetOnlyDeadCenterGrid();
            Assert.False(allAliveGrid.Equals(onlyDeadCenterGrid));
        }
        
        [Test]
        public void It_Should_Return_False_Given_A_ReadOnlyGrid_Of_Different_Size()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            var twoRowAllAliveGrid = GridCreatorHelper.GetTwoRowAllAliveGrid();
            Assert.False(allAliveGrid.Equals(twoRowAllAliveGrid));
        }
        
        [Test]
        public void It_Should_Return_False_For_A_Completely_Different_ReadOnlyGrid()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            var allDeadGrid = GridCreatorHelper.GetAllDeadGrid();
            Assert.False(allAliveGrid.Equals(allDeadGrid));
        }
    }
}