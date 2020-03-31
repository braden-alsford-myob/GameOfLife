using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirement;
using GameOfLifeTests.Rule.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Rule
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
            var aliveCenterGrid = GridCreatorHelper.GetOnlyAliveCenterGrid();
            Assert.True(_aliveCenterCellRequirement.HasMet(aliveCenterGrid));
        }

        [Test]
        public void It_Should_Return_False_Given_An_Active_Center_Cell()
        {
            var allDeadGrid = GridCreatorHelper.GetAllDeadGrid();
            Assert.False(_aliveCenterCellRequirement.HasMet(allDeadGrid));
        }
    }
}