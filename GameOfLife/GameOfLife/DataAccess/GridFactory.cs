using System;
using GameOfLife.DataAccess.Grids;

namespace GameOfLife.DataAccess
{
    public class GridFactory
    {
        public IGrid Create(GridTypes types)
        {
            return types switch
            {
                GridTypes.Glider => new GliderGrid(),
                _ => throw new Exception()
            };
        }
    }
}