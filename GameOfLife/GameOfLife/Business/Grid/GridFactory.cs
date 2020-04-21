using System;
using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Grid
{
    public class GridFactory
    {
        public Grid Create(GridType type, int height, int width)
        {
            var template = type switch
            {
                GridType.Glider => CreateGliderRows(),
                GridType.Tumbler => CreateTumblerRows(),
                _ => throw new Exception()
            };

            var grid = new Grid(height, width);
            grid.AddTemplateToCenter(template);

            return grid;
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
            };

            var rowTwo = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead)
            };

            var rowThree = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead)
            };

            var rowFour = new List<Cell.Cell>
            {
                new Cell.Cell(CellState.Dead),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Alive),
                new Cell.Cell(CellState.Dead)
            };
            
            var rowFive = new List<Cell.Cell>
            {
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
                rowFive
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