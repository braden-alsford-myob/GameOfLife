using System.Collections.Generic;
using GameOfLife;
using GameOfLife.Business;
using GameOfLife.Business.NeighbourFinder;
using GameOfLife.DataAccess;
using GameOfLife.DataAccess.Grids;
using GameOfLife.DataAccess.RuleSets;
using GameOfLifeTests.Helpers;
using Moq;
using NUnit.Framework;

namespace GameOfLifeTests
{
    public class BoardTests
    {
        private IRuleSet _basicRuleSet;
        private NeighbourFinderType _neighbourFinderType;

        [SetUp]
        public void Setup()
        {
            _basicRuleSet = new RuleSetFactory().Create(RuleSetTypes.Basic);
            _neighbourFinderType = NeighbourFinderType.EdgeWrapping;
        }

        [Test]
        public void It_Should_Successfully_Update_From_Frame_One_To_Frame_Two_Given_A_Basic_Ruleset()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(mock => mock.GetGrid()).Returns(BasicGliderFrameCreator.GetFrameOne);
            
            var board = new Board(_basicRuleSet, _neighbourFinderType, mockGrid.Object);
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrameTwo());
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }
        
        [Test]
        public void It_Should_Successfully_Update_From_Frame_Two_To_Frame_Three_Given_A_Basic_Ruleset()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(mock => mock.GetGrid()).Returns(BasicGliderFrameCreator.GetFrameTwo);
            
            var board = new Board(_basicRuleSet, _neighbourFinderType, mockGrid.Object);
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrameThree());
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }
        
        [Test]
        public void It_Should_Successfully_Update_From_Frame_Three_To_Frame_Four_Given_A_Basic_Ruleset()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(mock => mock.GetGrid()).Returns(BasicGliderFrameCreator.GetFrameThree);
            
            var board = new Board(_basicRuleSet, _neighbourFinderType, mockGrid.Object);
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrameFour());
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }
        
        [Test]
        public void It_Should_Successfully_Update_From_Frame_Four_To_Frame_Five_Given_A_Basic_Ruleset()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(mock => mock.GetGrid()).Returns(BasicGliderFrameCreator.GetFrameFour);
            
            var board = new Board(_basicRuleSet, _neighbourFinderType, mockGrid.Object);
            board.UpdateToNextGeneration();
            var expectedGrid = new ReadOnlyGrid(BasicGliderFrameCreator.GetFrameFive());
            var actualGrid = board.GetGrid();
            
            Assert.True(expectedGrid.Equals(actualGrid));
        }
    }
}