using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirement;
using NUnit.Framework;

namespace GameOfLifeTests.Requirement
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
            var allActiveRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Alive)
            };
            
            var allActiveRows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(allActiveRow),
                new ReadOnlyCollection<ReadOnlyCell>(allActiveRow),
                new ReadOnlyCollection<ReadOnlyCell>(allActiveRow)
            };
            
            var allActiveConcernedCells = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allActiveRows);
            
            Assert.True(_fourOrMoreActiveNeighbourRequirement.HasMet(allActiveConcernedCells));
        }
        
        [Test]
        public void It_Should_Return_Zero_Given_A_Grid_Of_Dead_Cells()
        {
            var allDeadRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var allDeadRows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow)
            };
            
            var allActiveConcernedCells = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allDeadRows);
            
            Assert.False(_fourOrMoreActiveNeighbourRequirement.HasMet(allActiveConcernedCells));
        }
    }
}