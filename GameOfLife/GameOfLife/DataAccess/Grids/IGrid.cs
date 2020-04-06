using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.DataAccess.Grids
{
    public interface IGrid
    {
        public GridTypes GetName();
        public List<List<Cell>> GetGrid();
    }
}