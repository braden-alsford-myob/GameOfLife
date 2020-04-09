using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.NeighbourFinder;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class EdgeWrappingNeighbourFinderTests
    {
        private EdgeWrappingNeighbourFinder _edgeWrappingNeighbourFinder;
        
        [SetUp]
        public void Setup()
        {
            var aliveCellLeftRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Alive),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var allDeadRow = new List<ReadOnlyCell>
            {
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead),
                new ReadOnlyCell(CellState.Dead)
            };
            
            var aliveCenterCellGrid = new List<ReadOnlyCollection<ReadOnlyCell>>
            {
                new ReadOnlyCollection<ReadOnlyCell>(aliveCellLeftRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow),
                new ReadOnlyCollection<ReadOnlyCell>(allDeadRow)
            };
            
            var aliveReadOnlyCenterCellGrid = new ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>>(aliveCenterCellGrid);
            _edgeWrappingNeighbourFinder = new EdgeWrappingNeighbourFinder(new ReadOnlyGrid(aliveReadOnlyCenterCellGrid));
        }
        
        [Test]
        public void It_Should_Return_The_Active_Cell_In_The_Middle_Of_The_Neighbours_Grid_Given_The_Top_Left_Cell() {
            var centerCell = new CellPosition(0, 0);
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(centerCell);
            
            Assert.AreEqual(CellState.Alive, neighbours.Grid[1][1].GetState());
        }
        
        [Test]
        public void It_Should_Return_The_Active_Cell_In_The_Middle_Right_Of_The_Neighbours_Grid_Given_The_Top_Right_Cell() {
            var centerCell = new CellPosition(0, 2);
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(centerCell);
            
            Assert.AreEqual(CellState.Alive, neighbours.Grid[1][2].GetState());
        }
        
        [Test]
        public void It_Should_Return_The_Active_Cell_In_The_Bottom_Right_Of_The_Neighbours_Grid_Given_The_Bottom_Right_Cell() {
            var centerCell = new CellPosition(2, 2);
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(centerCell);
            
            Assert.AreEqual(CellState.Alive, neighbours.Grid[2][2].GetState());
        }
        
        [Test]
        public void It_Should_Return_The_Active_Cell_In_The_Bottom_Center_Of_The_Neighbours_Grid_Given_The_Bottom_Left_Cell() {
            var centerCell = new CellPosition(2, 0);
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(centerCell);
            
            Assert.AreEqual(CellState.Alive, neighbours.Grid[2][1].GetState());
        }
        
        [Test]
        public void It_Should_Return_The_Active_Cell_In_The_Top_Right_Of_The_Neighbours_Grid_Given_The_Center_Cell() {
            var centerCell = new CellPosition(1, 1);
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(centerCell);
            
            Assert.AreEqual(CellState.Alive, neighbours.Grid[0][0].GetState());
        }
    }
}