using System.Collections.Generic;

namespace GameOfLife.Business.Requirements
{
    public class InitialStateRequirement : IRequirement
    {
        private readonly HashSet<CellState> _initialStates;

        public InitialStateRequirement(HashSet<CellState> initialStates)
        {
            _initialStates = initialStates;
        }

        public bool HasMet(ReadOnlyGrid concernedCells)
        {
            return _initialStates.Contains(concernedCells.GetCellState(1, 1));
        }
    }
}