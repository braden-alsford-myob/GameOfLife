using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class BoardTests
    {
        private RuleSet _basicRuleSet;
        
        [SetUp]
        public void Setup()
        {
            var basicRules = new Dictionary<int, GameOfLife.Business.Rule>
            {
                {1, RuleCreator.GetReproductionRule()},
                {2, RuleCreator.GetOvercrowdingRule()},
                {3, RuleCreator.GetUnderpopulationRule()}
            };
            
            _basicRuleSet = new RuleSet(basicRules);
        }

        [Test]
        public void It_Should_Successfully_Update_From_Frame_One_To_Frame_Two_Given_A_Basic_Ruleset()
        {
            var board = new Board(_basicRuleSet, BasicGliderFrameCreator.GetFrameOne());
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrameTwo());
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }

        [Test]
        public void It_Should_Successfully_Update_From_Frame_Two_To_Frame_Three_Given_A_Basic_Ruleset()
        {
            var board = new Board(_basicRuleSet, BasicGliderFrameCreator.GetFrameTwo());
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrameThree());
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }
    }
}