using GameOfLife.Business.Grid;

namespace GameOfLife.Business.Requirements
{
    public interface IRequirement
    {
        bool HasMet(ReadOnlyGrid concernedCells);
    }
}