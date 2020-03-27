using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Requirement
{
    public interface IRequirement
    {
        public bool HasMet(IReadOnlyList<IReadOnlyList<ICell>> concernedCells);
    }
}