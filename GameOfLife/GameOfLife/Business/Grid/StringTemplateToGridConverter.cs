using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Grid
{
    public static class StringTemplateToGridConverter
    {
        public static Grid Convert(string template)
        {
            var convertedTemplate = new List<List<Cell.Cell>>();

            foreach (var row in template.Split('\n'))
            {
                var convertedRow = new List<Cell.Cell>();

                foreach (var cell in row)
                { 
                    var convertedCell = cell == '0' ? new Cell.Cell(CellState.Dead) : new Cell.Cell(CellState.Alive);
                    convertedRow.Add(convertedCell);
                }
                
                convertedTemplate.Add(convertedRow);
            }

            return new Grid(convertedTemplate);
        }
    }
}