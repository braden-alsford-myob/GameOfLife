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
                GridType.Glider => new Grid(CreateGliderRows()),
                GridType.Tumbler => new Grid(CreateTumblerRows()),
                _ => throw new Exception()
            };

            return MergeTemplateWithFullGrid(template, height, width);
        }

        
        
        
        
        
        private Grid MergeTemplateWithFullGrid(Grid template, int height, int width)
        {
            //handles the min spec stuff

            var templateHeight = template.GetRows().Count;
            var templateWidth = template.GetRows()[0].Count;

            if (height < templateHeight)
            {
                height = templateHeight;
            }

            if (width < templateWidth)
            {
                width = templateWidth;
            }
            
            //makes the full grid
            
            var fullGrid = new List<List<Cell.Cell>>();

            for (var i = 0; i < height; i++)
            {
                var row = new List<Cell.Cell>();

                for (var j = 0; j < width; j++)
                {
                    row.Add(new Cell.Cell(CellState.Dead));
                }
                
                fullGrid.Add(row);
            }
            
            
            //merge them
            var topLeftRowIndex = (height - templateHeight) / 2;
            var topLeftColumnIndex = (width - templateWidth) / 2;

            var templateRow = 0;

            for (int i = topLeftRowIndex; i < topLeftRowIndex + templateHeight; i++)
            {
                var row = fullGrid[i];
                row.RemoveRange(topLeftColumnIndex,  templateWidth);
                row.InsertRange(topLeftColumnIndex, template.GetRows()[templateRow]);
                templateRow++;
            }

            return new Grid(fullGrid);
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