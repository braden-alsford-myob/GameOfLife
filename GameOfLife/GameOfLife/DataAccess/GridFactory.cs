using System;
using System.Collections.Generic;
using GameOfLife.Business;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

namespace GameOfLife.DataAccess
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
        
        private List<List<Cell>> CreateGliderRows()
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
        
        private static List<List<Cell>> CreateTumblerRows()
        {
            var rowZero = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowThree = new List<Cell>
            {                
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
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
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowSix = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
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
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            return new List<List<Cell>>
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