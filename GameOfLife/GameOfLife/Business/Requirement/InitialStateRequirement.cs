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

        public bool HasMet(ReadOnlyCollection<ReadOnlyCollection<ReadOnlyCell>> concernedCells)
        {
            var centerCell = concernedCells[1][1];
            return _initialStates.Contains(centerCell.GetState());
        }
    }
}