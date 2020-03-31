using GameOfLife.Business;
using GameOfLifeTests.Rule.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Rule
{
    public class RuleTests
    {

        private GameOfLife.Business.Rule _overcrowdingRule;

        [SetUp]
        public void Setup()
        {
            _overcrowdingRule = RuleCreatorHelper.GetOvercrowdingRule();
        }

        [Test]
        public void It_Should_Return_Dead_Given_An_Alive_Cell_With_Eight_Alive_Neighbours()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(allAliveGrid));
        }

        [Test]
        public void It_Should_Return_Dead_Given_An_Dead_Cell_With_Eight_Alive_Neighbours()
        {
            var deadCenterOnlyGrid = GridCreatorHelper.GetOnlyDeadCenterGrid();
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(deadCenterOnlyGrid));
        }

        [Test]
        public void It_Should_Return_Alive_Given_An_Alive_Cell_With_No_Alive_Neighbours()
        {
            var onlyAliveCenterGrid = GridCreatorHelper.GetOnlyAliveCenterGrid();
            Assert.AreEqual(CellState.Alive, _overcrowdingRule.GetNextCellState(onlyAliveCenterGrid));
        }
        
        [Test]
        public void It_Should_Return_Dead_Given_A_Dead_Cell_With_No_Alive_Neighbours()
        {
            var allDeadGrid = GridCreatorHelper.GetAllDeadGrid();
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(allDeadGrid));
        }
        
    }
}