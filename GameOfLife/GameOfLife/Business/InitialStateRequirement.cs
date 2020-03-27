using System.Collections.Generic;
using GameOfLife.Business.Exceptions;

namespace GameOfLife.Business
{
    public class InitialStateRequirement : IRequirement
    {
        private readonly HashSet<CellState> _initialStates;

        public InitialStateRequirement(HashSet<CellState> initialStates)
        {
            _initialStates = initialStates;
        }

        public bool Met(IReadOnlyList<IReadOnlyList<Cell>> concernedCells)
        {
            var centerCell = concernedCells[1][1];
            return _initialStates.Contains(centerCell.GetState());
        }
    }
}