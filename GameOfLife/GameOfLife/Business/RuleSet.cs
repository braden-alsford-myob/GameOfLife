using System.Collections.Generic;

namespace GameOfLife.Business
{
    public class RuleSet
    {
        private readonly Dictionary<int, Rule> _rules;

        public RuleSet(Dictionary<int, Rule> rules)
        {
            _rules = rules;
        }

        public CellState GetNextCellState(ReadOnlyGrid neighbours)
        {
            var finalCellState = CellState.NoChange;

            for (var i = _rules.Count; i > 0; i--) // Reverse through to apply highest priority last.
            {
                var nextState = _rules[i].GetNextCellState(neighbours);
                if (nextState != CellState.NoChange) finalCellState = nextState;
            }

            return finalCellState == CellState.NoChange ? neighbours.GetCellState(1, 1) : finalCellState;
        }
    }
}