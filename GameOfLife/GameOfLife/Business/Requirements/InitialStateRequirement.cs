using System.Collections.Generic;
using GameOfLife.Business.Cell;

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
            var centerCellPosition = new CellPosition(1, 1);
            return _initialStates.Contains(concernedCells.GetCellState(centerCellPosition));
        }
    }
}