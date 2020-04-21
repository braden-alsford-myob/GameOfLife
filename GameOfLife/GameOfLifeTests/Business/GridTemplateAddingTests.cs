using System.Collections.Generic;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;
using NUnit.Framework;

namespace GameOfLifeTests.Business
{
    public class GridTemplateAddingTests
    {
        [TestCaseSource(nameof(Grids))]
        public void It_Should_Successfully_Add_The_Template_To_The_Grid(Grid grid, ReadOnlyGrid expected)
        {
            var template = new Grid(new List<List<Cell>>
            {
                new List<Cell>{new Cell(CellState.Alive), new Cell(CellState.Dead)},
                new List<Cell>{new Cell(CellState.Dead), new Cell(CellState.Alive)} 
            });
            
            grid.AddTemplateToCenter(template);
            
            var readOnlyGrid = new ReadOnlyGrid(grid);
            Assert.True(readOnlyGrid.Equals(expected));
        }

        private static IEnumerable<TestCaseData> Grids
        {
            get
            {
                yield return new TestCaseData(
                    new Grid(2, 2),
                    new ReadOnlyGrid(new Grid(new List<List<Cell>>
                    {
                        new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive)}
                    })));
                
                yield return new TestCaseData(
                    new Grid(3, 3),
                    new ReadOnlyGrid(new Grid(new List<List<Cell>>
                    {
                        new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
                    })));
                
                yield return new TestCaseData(
                    new Grid(4, 4),
                    new ReadOnlyGrid(new Grid(new List<List<Cell>>
                    {
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead), new Cell(CellState.Dead)}
                    })));
                
                yield return new TestCaseData(
                    new Grid(1, 1),
                    new ReadOnlyGrid(new Grid(new List<List<Cell>>
                    {
                        new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive)}
                    })));
                
                yield return new TestCaseData(
                    new Grid(1, 3),
                    new ReadOnlyGrid(new Grid(new List<List<Cell>>
                    {
                        new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive), new Cell(CellState.Dead)},
                    })));
                
                yield return new TestCaseData(
                    new Grid(3, 1),
                    new ReadOnlyGrid(new Grid(new List<List<Cell>>
                    {
                        new List<Cell> {new Cell(CellState.Alive), new Cell(CellState.Dead)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Alive)},
                        new List<Cell> {new Cell(CellState.Dead), new Cell(CellState.Dead)},
                    })));
            }
        }
        
    }
}