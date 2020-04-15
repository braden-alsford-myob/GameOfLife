using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business.RuleTests
{
    public class RuleTests
    {

        private Rule _overcrowdingRule;

        [SetUp]
        public void Setup()
        {
            _overcrowdingRule = RuleCreator.GetOvercrowdingRule();
        }

        [Test]
        public void It_Should_Return_Dead_Given_An_Alive_Cell_With_Eight_Alive_Neighbours()
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            var initialState = allAliveGrid.GetCellState(new CellPosition(1, 1));
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(allAliveGrid, initialState));
        }

        [Test]
        public void It_Should_Return_NoChange_Given_An_Dead_Cell_With_Eight_Alive_Neighbours()
        {
            var deadCenterOnlyGrid = GridCreator.GetOnlyDeadCenterGrid();
            var initialState = deadCenterOnlyGrid.GetCellState(new CellPosition(1, 1));
            Assert.AreEqual(initialState, _overcrowdingRule.GetNextCellState(deadCenterOnlyGrid, initialState));
        }

        [Test]
        public void It_Should_Return_NoChange_Given_An_Alive_Cell_With_No_Alive_Neighbours()
        {
            var onlyAliveCenterGrid = GridCreator.GetOnlyAliveCenterGrid();
            var initialState = onlyAliveCenterGrid.GetCellState(new CellPosition(1, 1));
            Assert.AreEqual(initialState, _overcrowdingRule.GetNextCellState(onlyAliveCenterGrid, initialState));
        }
        
        [Test]
        public void It_Should_Return_NoChange_Given_A_Dead_Cell_With_No_Alive_Neighbours()
        {
            var allDeadGrid = GridCreator.GetAllDeadGrid();
            var initialState = allDeadGrid.GetCellState(new CellPosition(1, 1));
            Assert.AreEqual(initialState, _overcrowdingRule.GetNextCellState(allDeadGrid, initialState));
        }
        
    }
}