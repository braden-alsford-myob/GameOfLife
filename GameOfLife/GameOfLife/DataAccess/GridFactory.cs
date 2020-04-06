using System;
using GameOfLife.DataAccess.Grids;

namespace GameOfLife.DataAccess
{
    public class GridFactory
    {
        public IGrid Create(GridType type)
        {
            return type switch
            {
                GridType.Glider => new GliderGrid(),
                _ => throw new Exception()
            };
        }
    }
}