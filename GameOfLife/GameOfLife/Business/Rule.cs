using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.Exceptions;

namespace GameOfLife.Business
{
    public class Rule
    {
        private readonly HashSet<CellState> _requiredInitialStates;
        private readonly CellState _resultantState;
        private readonly HashSet<int> _requiredActiveNeighbourCounts;

        public Rule(HashSet<CellState> requiredInitialStates, HashSet<int> requiredActiveNeighbourCounts,
            CellState resultantState)
        {
            _validateRule(requiredInitialStates, requiredActiveNeighbourCounts);
            
            _requiredInitialStates = requiredInitialStates;
            _requiredActiveNeighbourCounts = requiredActiveNeighbourCounts;
            _resultantState = resultantState;
        }

        public CellState GetNextCellState(int activeNeighbourCount, CellState initialState)
        {
            return _meetsRequirements(activeNeighbourCount, initialState) ? _resultantState : initialState;
        }

        private bool _meetsRequirements(int activeNeighbourCount, CellState initialState)
        {
            return _requiredActiveNeighbourCounts.Contains(activeNeighbourCount) && 
                   _requiredInitialStates.Contains(initialState);
        }

        private void _validateRule(HashSet<CellState> requiredInitialStates, HashSet<int> requiredActiveNeighbourCounts)
        {
            if (requiredInitialStates.Count == 0) throw new RuleInvalidException(requiredInitialStates);
            
            if (requiredActiveNeighbourCounts.Any(number => number < 0 || number > 8))
            {
                throw new RuleInvalidException(requiredActiveNeighbourCounts);
            }
        }
    }
}