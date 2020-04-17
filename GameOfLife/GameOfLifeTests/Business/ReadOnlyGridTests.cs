using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class ReadOnlyGridTests
    {
        
        [Test, TestCaseSource(nameof(Grids))]
        public void GetNextCellState_Should_Return_Next_State_Given_Different_Grids(ReadOnlyGrid grid, bool expected)
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            
            Assert.AreEqual(expected, allAliveGrid.Equals(grid));
        }
        
        private static IEnumerable<TestCaseData> Grids
        {
            get
            {
                yield return new TestCaseData(GridCreator.GetAllAliveGrid(), true);
                yield return new TestCaseData(GridCreator.GetOnlyDeadCenterGrid(), false);
                yield return new TestCaseData(GridCreator.GetTwoRowAllAliveGrid(), false);
                yield return new TestCaseData(GridCreator.GetAllDeadGrid(), false);
            }
        }
    }
}