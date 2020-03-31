using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Requirement;
using GameOfLifeTests.Rule.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Rule
{
    public class RuleSetTests
    {
        private RuleSet _ruleSet;
        
        [SetUp]
        public void Setup()
        {
            var overcrowdingRule = RuleCreatorHelper.GetOvercrowdingRule();

            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var eightNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{8});
            
            var superOvercrowdingRequirements = new List<IRequirement> {cellAliveRequirement, eightNeighboursRequirement};
            var superOvercrowdingRule = new GameOfLife.Business.Rule(superOvercrowdingRequirements, CellState.Alive);

            var rules = new Dictionary<int, GameOfLife.Business.Rule>
            {
                {1, superOvercrowdingRule}, {2, overcrowdingRule}
            };

            _ruleSet = new RuleSet(rules);
        }

        [Test]
        public void It_Should_Return_Dead_Given_A_Dead_Cell_Not_Meeting_Any_SubRules()
        {
            var allDeadGrid = GridCreatorHelper.GetAllDeadGrid();
            var nextState = _ruleSet.GetNextCellState(allDeadGrid);
            Assert.AreEqual(CellState.Dead, nextState);
        }

        [Test]
        public void It_Should_Return_Dead_Given_A_Cell_Meeting_Overcrowding_Rule_Only()
        {
            var aliveCenterWithFourAliveNeighboursGrid = GridCreatorHelper.GetAliveCenterWithFourAliveNeighboursGrid();
            var nextState = _ruleSet.GetNextCellState(aliveCenterWithFourAliveNeighboursGrid);
            Assert.AreEqual(CellState.Dead, nextState);
        }

        [Test]
        public void It_Should_Return_Alive_Given_A_Cell_Meeting_Both_Rules_And_SuperOvercrowding_Is_Prioritized()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            var nextState = _ruleSet.GetNextCellState(allAliveGrid);
            Assert.AreEqual(CellState.Alive, nextState);
        }
    }
}