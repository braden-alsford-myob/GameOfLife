using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameOfLife.Business.Cell;

namespace GameOfLife.Business.Requirement
{
    public class InitialStateRequirement : IRequirement
    {
        private readonly HashSet<CellState> _initialStates;

        public InitialStateRequirement(HashSet<CellState> initialStates)
        {
            _initialStates = initialStates;
        }

        public bool HasMet(ThreeByThreeGrid concernedCells)
        {
            return _initialStates.Contains(concernedCells.GetCellState(1, 1));
        }
    }
}