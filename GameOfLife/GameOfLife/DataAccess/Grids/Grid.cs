using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.DataAccess.Grids
{
    public class Grid
    {
        public List<List<Cell>> Rows { get; private set; }

        public Grid(List<List<Cell>> rows)
        {
            Rows = rows;
        }
    }
}