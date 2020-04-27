using System.Collections.Generic;
using GameOfLife.Business.CellObjects;

namespace GameOfLife.Business.GridObjects
{
    public static class StringTemplateToGridConverter
    {
        public static Grid Convert(string template)
        {
            var convertedTemplate = new List<List<Cell>>();

            foreach (var row in template.Split('\n'))
            {
                var convertedRow = new List<Cell>();

                foreach (var cell in row)
                { 
                    var convertedCell = cell == '0' ? new Cell(CellState.Dead) : new Cell(CellState.Alive);
                    convertedRow.Add(convertedCell);
                }
                
                convertedTemplate.Add(convertedRow);
            }

            return new Grid(convertedTemplate);
        }
    }
}