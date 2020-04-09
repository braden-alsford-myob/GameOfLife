using System.Collections.Generic;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirements;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business.RuleTests
{
    public class InitialStateRequirementTests
    {
        private InitialStateRequirement _aliveCenterCellRequirement;

        [SetUp]
        public void Setup()
        {
            _aliveCenterCellRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
        }

        [Test]
        public void It_Should_Return_True_Given_An_Active_Center_Cell()
        {
            var aliveCenterGrid = GridCreator.GetOnlyAliveCenterGrid();
            Assert.True(_aliveCenterCellRequirement.HasMet(aliveCenterGrid));
        }

        [Test]
        public void It_Should_Return_False_Given_An_Active_Center_Cell()
        {
            var allDeadGrid = GridCreator.GetAllDeadGrid();
            Assert.False(_aliveCenterCellRequirement.HasMet(allDeadGrid));
        }
    }
}