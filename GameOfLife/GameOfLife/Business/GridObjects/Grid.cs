using System.Collections.Generic;
using GameOfLife.Business.CellObjects;

namespace GameOfLife.Business.GridObjects
{
    public class Grid
    {
        private readonly List<List<Cell>> _rows;

        public Grid(List<List<Cell>> rows)
        {
            _rows = rows;
        }

        public Grid(int height, int width)
        {
            _rows = GenerateRows(height, width);
        }

        public List<List<Cell>> GetRows()
        {
            return _rows;
        }

        public void AddTemplateToCenter(Grid template)
        {
            EnsureGridMinimumSize(template);

            var templateRows = template.GetRows();
            
            var templateHeight = templateRows.Count;
            var templateWidth = templateRows[0].Count;
            
            var topLeftRowIndex = (_rows.Count - templateHeight) / 2;
            var topLeftColumnIndex = (_rows[0].Count - templateWidth) / 2;

            var currentTemplateRow = 0;

            for (var i = topLeftRowIndex; i < topLeftRowIndex + templateHeight; i++)
            {
                var row = _rows[i];
                row.RemoveRange(topLeftColumnIndex,  templateWidth);
                row.InsertRange(topLeftColumnIndex, templateRows[currentTemplateRow]);
                currentTemplateRow++;
            }
        }

        private void EnsureGridMinimumSize(Grid template)
        {
            EnsureGridMinimumHeight(template);
            EnsureGridMinimumWidth(template);
        }

        private void EnsureGridMinimumHeight(Grid template)
        {
            while (_rows.Count < template.GetRows().Count)
            {
                var gridWidth = _rows[0].Count;
                var newRow = new List<Cell>();

                for (var i = 0; i < gridWidth; i++)
                {
                    newRow.Add(new Cell(CellState.Dead));
                }
                
                _rows.Add(newRow);
            }
        }
        
        private void EnsureGridMinimumWidth(Grid template)
        {
            while (_rows[0].Count < template.GetRows()[0].Count)
            {
                foreach (var row in _rows)
                {
                   row.Add(new Cell(CellState.Dead));
                }
            }
        }

        private List<List<Cell>> GenerateRows(int height, int width)
        {
            var rows = new List<List<Cell>>();
            
            for (var i = 0; i < height; i++)
            {
                var row = new List<Cell>();

                for (var j = 0; j < width; j++)
                {
                    row.Add(new Cell(CellState.Dead));
                }
                
                rows.Add(row);
            }

            return rows;
        }
    }
}