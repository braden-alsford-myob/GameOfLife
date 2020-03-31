using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirement;
using GameOfLifeTests.Rule.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Rule
{
    public class ActiveNeighborRequirementTests
    {
        private ActiveNeighbourRequirement _fourOrMoreActiveNeighbourRequirement;

        [SetUp]
        public void Setup()
        {
            _fourOrMoreActiveNeighbourRequirement = new ActiveNeighbourRequirement(new HashSet<int>{4, 5, 6, 7, 8});
        }

        [Test]
        public void It_Should_Return_True_Given_A_Grid_Of_Active_Cells()
        {
            var allAliveGrid = GridCreatorHelper.GetAllAliveGrid();
            Assert.True(_fourOrMoreActiveNeighbourRequirement.HasMet(allAliveGrid));
        }
        
        [Test]
        public void It_Should_Return_Zero_Given_A_Grid_Of_Dead_Cells()
        {
            var allDeadGrid = GridCreatorHelper.GetAllDeadGrid();
            Assert.False(_fourOrMoreActiveNeighbourRequirement.HasMet(allDeadGrid));
        }
    }
}