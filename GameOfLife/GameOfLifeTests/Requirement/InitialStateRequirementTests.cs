using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirement;
using NUnit.Framework;

namespace GameOfLifeTests.Requirement
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
            var aliveCenterCellRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var allDeadRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var allActiveRows = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(aliveCenterCellRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow)
            };
            
            var aliveCenterCellGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allActiveRows);
            
            Assert.True(_aliveCenterCellRequirement.HasMet(aliveCenterCellGrid));
        }

        [Test]
        public void It_Should_Return_False_Given_An_Active_Center_Cell()
        {

            var allDeadRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var allDeadGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow)
            };
            
            var allDeadReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allDeadGrid);
            
            Assert.False(_aliveCenterCellRequirement.HasMet(allDeadReadOnlyGrid));
        }
    }
}