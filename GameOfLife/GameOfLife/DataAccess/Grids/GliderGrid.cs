using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.DataAccess.Grids
{
    public class GliderGrid : IGrid
    {
        public GridTypes GetName()
        {
            return GridTypes.Glider;
        }

        public List<List<Cell>> GetGrid()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowSix = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowSeven = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowEight = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive,
                rowSix,
                rowSeven,
                rowEight
            };
        }
    }
}