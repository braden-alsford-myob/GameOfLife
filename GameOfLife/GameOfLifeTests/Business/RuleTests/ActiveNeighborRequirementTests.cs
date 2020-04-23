using System.Collections.Generic;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.Requirements;
using GameOfLifeTests.Helpers;
using NUnit.Framework;

namespace GameOfLifeTests.Business.RuleTests
{
    public class ActiveNeighborRequirementTests
    {
        private ActiveNeighbourRequirement _fourOrMoreActiveNeighboursRequirement;

        [SetUp]
        public void Setup()
        {
            _fourOrMoreActiveNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{4, 5, 6, 7, 8});
        }

        [Test]
        public void It_Should_Return_True_Given_A_Grid_Of_Active_Cells()
        {
            var allAliveGrid = GridCreator.GetAllAliveGrid();
            Assert.True(_fourOrMoreActiveNeighboursRequirement.HasMet(allAliveGrid));
        }
        
        [Test]
        public void It_Should_Return_Zero_Given_A_Grid_Of_Dead_Cells()
        {
            var allDeadGrid = GridCreator.GetAllDeadGrid();
            Assert.False(_fourOrMoreActiveNeighboursRequirement.HasMet(allDeadGrid));
        }

        [Test]
        public void It_Should_Throw_A_RequirementInvalidException_Given_An_Invalid_Requirement()
        {
            void CreateInvalidRequirement()
            {
                var invalidRequirement = new ActiveNeighbourRequirement(new HashSet<int>{-1, 10});
            }
            
            Assert.Throws(Is.TypeOf<RequirementInvalidException>(), CreateInvalidRequirement);
        }
    }
}