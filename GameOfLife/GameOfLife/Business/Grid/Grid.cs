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

        public List<List<Cell.Cell>> GetRows()
        {
            return _rows;
        }
    }
}