using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.GridObjects;
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
        
        
        [Test, TestCaseSource(nameof(RuleGrids))]
        public void GetNextCellState_Should_Get_Next_State_For_Given_Grid(ReadOnlyGrid grid, CellState expectedState)
        {
            var initialState = grid.GetCellState(new CellPosition(1, 1));
            Assert.AreEqual(expectedState, _overcrowdingRule.GetNextCellState(grid, initialState));
        }
        
        
        private static IEnumerable<TestCaseData> RuleGrids
        {
            get
            {
                yield return new TestCaseData(GridCreator.GetAllAliveGrid(), CellState.Dead);
                yield return new TestCaseData(GridCreator.GetOnlyDeadCenterGrid(), CellState.Dead);
                yield return new TestCaseData(GridCreator.GetOnlyAliveCenterGrid(), CellState.Alive);
                yield return new TestCaseData(GridCreator.GetAllDeadGrid(), CellState.Dead);
            }
        }
    }
}