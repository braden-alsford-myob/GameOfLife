using System;
using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Grid
{
    public class GridFactory
    {
        public Grid Create(GridType type)
        {
            return type switch
            {
                GridType.Glider => new Grid(CreateGliderRows()),
                GridType.Tumbler => new Grid(CreateTumblerRows()),
                _ => throw new Exception()
            };
        }

        private List<List<Cell.Cell>> CreateGliderRows()
        {
            var rowOne = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowTwo = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowThree = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowFour = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowFive = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowSix = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowSeven = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowEight = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            return new List<List<Cell.Cell>>
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

        private static List<List<Cell.Cell>> CreateTumblerRows()
        {
            var rowZero = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowOne = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowTwo = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowThree = new List<Cell.Cell>
            {                
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowFour = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowFive = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowSix = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowSeven = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowEight = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            return new List<List<Cell.Cell>>
            {
                rowZero,
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