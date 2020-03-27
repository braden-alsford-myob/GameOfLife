using System.Collections.Generic;

namespace GameOfLife.Business
{
    public interface IRequirement
    {
        public bool Met(IReadOnlyList<IReadOnlyList<Cell>> concernedCells);
    }
}