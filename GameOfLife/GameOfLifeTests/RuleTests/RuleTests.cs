using GameOfLife.Business;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.RuleTests
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
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(allAliveGrid));
        }

        [Test]
        public void It_Should_Return_NoChange_Given_An_Dead_Cell_With_Eight_Alive_Neighbours()
        {
            var deadCenterOnlyGrid = GridCreator.GetOnlyDeadCenterGrid();
            Assert.AreEqual(CellState.NoChange, _overcrowdingRule.GetNextCellState(deadCenterOnlyGrid));
        }

        [Test]
        public void It_Should_Return_NoChange_Given_An_Alive_Cell_With_No_Alive_Neighbours()
        {
            var onlyAliveCenterGrid = GridCreator.GetOnlyAliveCenterGrid();
            Assert.AreEqual(CellState.NoChange, _overcrowdingRule.GetNextCellState(onlyAliveCenterGrid));
        }
        
        [Test]
        public void It_Should_Return_NoChange_Given_A_Dead_Cell_With_No_Alive_Neighbours()
        {
            var allDeadGrid = GridCreator.GetAllDeadGrid();
            Assert.AreEqual(CellState.NoChange, _overcrowdingRule.GetNextCellState(allDeadGrid));
        }
        
    }
}