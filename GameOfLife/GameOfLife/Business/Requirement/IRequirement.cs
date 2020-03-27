using System.Collections.ObjectModel;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Requirement
{
    public interface IRequirement
    {
        public bool HasMet(ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> concernedCells);
    }
}