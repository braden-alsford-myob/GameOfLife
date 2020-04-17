using GameOfLife.Business.Grid;

namespace GameOfLife.Business.Requirements
{
    public interface IRequirement
    {
        public bool HasMet(ReadOnlyGrid concernedCells);
    }
}