using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;
using GameOfLife.Business.Requirements;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business.RuleTests
{
    public class RuleSetTests
    {
        private RuleSet _ruleSet;
        
        [SetUp]
        public void Setup()
        {
            var overcrowdingRule = RuleCreator.GetOvercrowdingRule();

            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var eightNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{8});
            
            var superOvercrowdingRequirements = new List<IRequirement> {cellAliveRequirement, eightNeighboursRequirement};
            var superOvercrowdingRule = new Rule(superOvercrowdingRequirements, CellState.Alive);

            var rules = new Dictionary<int, Rule>
            {
                {1, superOvercrowdingRule}, 
                {2, overcrowdingRule}
            };

            _ruleSet = new RuleSet(rules);
        }

        [Test, TestCaseSource(nameof(RuleGrids))]
        public void GetNextCellState_Should_Return_Next_State_Given_Different_Grids(ReadOnlyGrid grid, CellState expectedState)
        {
            var nextState = _ruleSet.GetNextCellState(grid);
            
            Assert.AreEqual(expectedState, nextState);
        }
        
        private static IEnumerable<TestCaseData> RuleGrids
        {
            get
            {
                yield return new TestCaseData(GridCreator.GetAllDeadGrid(), CellState.Dead);
                yield return new TestCaseData(GridCreator.GetAliveCenterWithFourAliveNeighboursGrid(), CellState.Dead);
                yield return new TestCaseData(GridCreator.GetAllAliveGrid(), CellState.Alive);
            }
        }
    }
}