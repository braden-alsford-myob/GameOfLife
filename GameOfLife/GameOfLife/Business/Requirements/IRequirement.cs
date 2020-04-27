using GameOfLife.Business.GridObjects;

namespace GameOfLife.Business.Requirements
{
    public interface IRequirement
    {
        bool HasMet(ReadOnlyGrid concernedCells);
    }
}