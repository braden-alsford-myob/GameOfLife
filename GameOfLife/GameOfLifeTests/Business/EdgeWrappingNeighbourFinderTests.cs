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
            var aliveReadOnlyCenterCellGrid = Helpers.GridCreator.GetAliveTopLeftGrid();
            _edgeWrappingNeighbourFinder = new EdgeWrappingNeighbourFinder(aliveReadOnlyCenterCellGrid);
        }


        [TestCase(0, 0, 1, 1)]
        [TestCase(0, 2, 1, 2)]
        [TestCase(2, 2, 2, 2)]
        [TestCase(2, 0, 2, 1)]
        [TestCase(1, 1, 0, 0)]
        
        public void NeighbourFinder_Should_Find_Wrapped_Neighbours(int targetRow, int targetColumn, int expectedAliveCellRow, int expectedAliveCellColumn)
        {
            var targetCell = new CellPosition(targetRow, targetColumn);
            
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(targetCell);

            var expectedAliveCell = neighbours.Grid[expectedAliveCellRow][expectedAliveCellColumn];
            Assert.AreEqual(CellState.Alive, expectedAliveCell.GetState());
        }
    }
}