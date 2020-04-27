using GameOfLife.Business;
using GameOfLife.Business.GridObjects;
using GameOfLife.Business.RuleSetObjects;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class BoardTests
    {
        private RuleSet _basicRuleSet;

        [SetUp]
        public void Setup()
        {
            _basicRuleSet = new RuleSetFactory().Create(RuleSetType.Basic);
        }
        

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(4, 5)]

        public void Board_Successfully_Updates_From_Frame_To_Frame(int startingFrame, int expectedFrame)
        {
            var grid = BasicGliderFrameCreator.GetFrame(startingFrame);

            var board = new Board(_basicRuleSet, grid);
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrame(expectedFrame));
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }
    }
}