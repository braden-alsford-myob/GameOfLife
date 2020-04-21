using System;
using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Grid
{
    public class GridFactory
    {
        public Grid Create(GridType type, int configHeight, int configWidth)
        {
            var template = type switch
            {
                GridType.Glider => new Grid(CreateGliderRows()),
                GridType.Tumbler => new Grid(CreateTumblerRows()),
                _ => throw new Exception()
            };

            var gridHeight = GetGridHeight(template.GetRows().Count, configHeight);
            var gridWidth = GetGridWidth(template.GetRows()[0].Count, configWidth);

            var grid = GenerateEmptyGrid(gridWidth, gridHeight);
            
            return MergeGrids(template.GetRows(), grid);
        }

        private static int GetGridWidth(int templateWidth, int configWidth)
        {
            return configWidth < templateWidth ? templateWidth : configWidth;
        }

        private static int GetGridHeight(int templateHeight, int configHeight)
        {
            return configHeight < templateHeight ? templateHeight : configHeight;
        }

        private static List<List<Cell.Cell>> GenerateEmptyGrid(int width, int height)
        {
            var emptyGrid = new List<List<Cell.Cell>>();
            
            for (var i = 0; i < height; i++)
            {
                var row = new List<Cell.Cell>();

                for (var j = 0; j < width; j++)
                {
                    row.Add(new Cell.Cell(CellState.Dead));
                }
                
                emptyGrid.Add(row);
            }

            return emptyGrid;
        }

        private Grid MergeGrids(List<List<Cell.Cell>> template, List<List<Cell.Cell>> grid)
        {
            var templateHeight = template.Count;
            var templateWidth = template[0].Count;
            
            var topLeftRowIndex = (grid.Count - templateHeight) / 2;
            var topLeftColumnIndex = (grid[0].Count - templateWidth) / 2;

            var templateRow = 0;

            for (int i = topLeftRowIndex; i < topLeftRowIndex + templateHeight; i++)
            {
                var row = grid[i];
                row.RemoveRange(topLeftColumnIndex,  templateWidth);
                row.InsertRange(topLeftColumnIndex, template[templateRow]);
                templateRow++;
            }

            return new Grid(grid);
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
                new Cell.Cell(CellState.Dead),
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