using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Requirement;
using NUnit.Framework;
using Rule = GameOfLife.Business.Rule;

namespace GameOfLifeTests
{
    public class RuleTests
    {

        private Rule _overcrowdingRule;

        private List<ReadOnlyCell> _allAliveRow;
        private List<ReadOnlyCell> _allDeadRow;

        [SetUp]
        public void Setup()
        {
            var cellAliveRequirement = new InitialStateRequirement(new HashSet<CellState>{CellState.Alive});
            var moreThanThreeNeighboursRequirement = new ActiveNeighbourRequirement(new HashSet<int>{4, 5, 6, 7, 8});
            var requirements = new List<IRequirement> {cellAliveRequirement, moreThanThreeNeighboursRequirement};
            
            _overcrowdingRule = new Rule(requirements, CellState.Dead);
            
            _allAliveRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Alive)
            };
            
            _allDeadRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead)
            };   
            
        }

        [Test]
        public void It_Should_Return_Dead_Given_An_Alive_Cell_With_Eight_Alive_Neighbours()
        {
            var allAliveGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(_allAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(_allAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(_allAliveRow)
            };
            
            var allAliveReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allAliveGrid);

            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(allAliveReadOnlyGrid));
        }

        [Test]
        public void It_Should_Return_Dead_Given_An_Dead_Cell_With_Eight_Alive_Neighbours()
        {
            var deadCenterRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Alive)
            };
            
            var deadCenterGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(_allAliveRow),
                new ReadOnlyCollection<ReadOnlyCell>(deadCenterRow),
                new ReadOnlyCollection<ReadOnlyCell>(_allAliveRow)
            };
            
            var deadCenterReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(deadCenterGrid);

            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(deadCenterReadOnlyGrid));
        }

        [Test]
        public void It_Should_Return_Alive_Given_An_Alive_Cell_With_No_Alive_Neighbours()
        {
            var aliveCenterRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var aliveCenterGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(_allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(aliveCenterRow),
                new ReadOnlyCollection<ReadOnlyCell>(_allDeadRow)
            };
            
            var aliveCenterReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(aliveCenterGrid);

            Assert.AreEqual(CellState.Alive, _overcrowdingRule.GetNextCellState(aliveCenterReadOnlyGrid));
        }
        
        [Test]
        public void It_Should_Return_Dead_Given_A_Dead_Cell_With_No_Alive_Neighbours()
        {
            var allDeadGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(_allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(_allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(_allDeadRow)
            };
            
            var allDeadReadOnlyGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(allDeadGrid);
        
            Assert.AreEqual(CellState.Dead, _overcrowdingRule.GetNextCellState(allDeadReadOnlyGrid));
        }
        
    }
}