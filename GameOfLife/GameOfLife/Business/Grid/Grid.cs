using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Grid
{
    public class Grid
    {
        private readonly List<List<Cell.Cell>> _rows;

        public Grid(List<List<Cell.Cell>> rows)
        {
            _rows = rows;
        }

        public Grid(int height, int width)
        {
            _rows = GenerateRows(height, width);
        }

        public List<List<Cell.Cell>> GetRows()
        {
            return _rows;
        }

        public void AddTemplateToCenter(List<List<Cell.Cell>> template)
        {
            EnsureGridMinimumSize(template);
            
            var templateHeight = template.Count;
            var templateWidth = template[0].Count;
            
            var topLeftRowIndex = (_rows.Count - templateHeight) / 2;
            var topLeftColumnIndex = (_rows[0].Count - templateWidth) / 2;

            var currentTemplateRow = 0;

            for (var i = topLeftRowIndex; i < topLeftRowIndex + templateHeight; i++)
            {
                var row = _rows[i];
                row.RemoveRange(topLeftColumnIndex,  templateWidth);
                row.InsertRange(topLeftColumnIndex, template[currentTemplateRow]);
                currentTemplateRow++;
            }
        }

        private void EnsureGridMinimumSize(List<List<Cell.Cell>> template)
        {
            EnsureGridMinimumHeight(template);
            EnsureGridMinimumWidth(template);
        }

        private void EnsureGridMinimumHeight(List<List<Cell.Cell>> template)
        {
            while (_rows.Count < template.Count)
            {
                var gridWidth = _rows[0].Count;
                var newRow = new List<Cell.Cell>();

                for (var i = 0; i < gridWidth; i++)
                {
                    newRow.Add(new Cell.Cell(CellState.Dead));
                }
                
                _rows.Add(newRow);
            }
        }
        
        private void EnsureGridMinimumWidth(List<List<Cell.Cell>> template)
        {
            while (_rows[0].Count < template[0].Count)
            {
                foreach (var row in _rows)
                {
                   row.Add(new Cell.Cell(CellState.Dead));
                }
            }
        }

        private List<List<Cell.Cell>> GenerateRows(int height, int width)
        {
            var rows = new List<List<Cell.Cell>>();
            
            for (var i = 0; i < height; i++)
            {
                var row = new List<Cell.Cell>();

                for (var j = 0; j < width; j++)
                {
                    row.Add(new Cell.Cell(CellState.Dead));
                }
                
                rows.Add(row);
            }

            return rows;
        }
    }
}