using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.DataAccess.Grids
{
    public interface IGrid
    {
        public GridType GetName();
        public List<List<Cell>> GetGrid();
    }
}