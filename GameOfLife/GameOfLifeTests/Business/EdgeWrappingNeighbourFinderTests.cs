using System.Collections.Generic;
using GameOfLife.Business.CellObjects;
using GameOfLife.Business.NeighbourFinderObjects;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class EdgeWrappingNeighbourFinderTests
    {
        private NeighbourFinder _edgeWrappingNeighbourFinder;
        
        [SetUp]
        public void Setup()
        {
            var aliveReadOnlyCenterCellGrid = Helpers.GridCreator.GetAliveTopLeftGrid();
            var edgeWrappingIndexFinder = new EdgeWrappingIndexFinder();
            _edgeWrappingNeighbourFinder = new NeighbourFinder(aliveReadOnlyCenterCellGrid, edgeWrappingIndexFinder);
        }

        
        [Test, TestCaseSource(nameof(CellPositions))]
        public void NeighbourFinder_Should_Find_Wrapped_Neighbours(CellPosition targetCell, CellPosition expectedAliveCell)
        {
            var neighbours = _edgeWrappingNeighbourFinder.GetThreeByThreeGridAroundCell(targetCell);

            var expectedAliveCellState = neighbours.GetCellState(expectedAliveCell);
            Assert.AreEqual(CellState.Alive, expectedAliveCellState);
        }
        
        private static IEnumerable<TestCaseData> CellPositions
        {
            get
            {
                yield return new TestCaseData(
                    new CellPosition(0, 0), 
                    new CellPosition(1, 1));
                
                yield return new TestCaseData(
                    new CellPosition(0, 2), 
                    new CellPosition(1, 2));

                yield return new TestCaseData(
                    new CellPosition(2, 2), 
                    new CellPosition(2, 2));

                yield return new TestCaseData(
                    new CellPosition(2, 0), 
                    new CellPosition(2, 1));

                yield return new TestCaseData(
                    new CellPosition(1, 1), 
                    new CellPosition(0, 0));
            }
        }
    }
}