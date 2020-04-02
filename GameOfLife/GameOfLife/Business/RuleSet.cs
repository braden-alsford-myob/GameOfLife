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
            var prioritisedRules = GetRulesOrderedInReversePriority();
            
            foreach(var rule in prioritisedRules)
            {
                var nextState = rule.GetNextCellState(neighbours);
                if (nextState != CellState.NoChange) finalCellState = nextState;
            }

            return finalCellState == CellState.NoChange ? neighbours.GetCellState(1, 1) : finalCellState;
        }

        private IEnumerable<Rule> GetRulesOrderedInReversePriority()
        {
            var rules = new List<Rule>();
            
            for (var i = _rules.Count; i > 0; i--)
            {
                rules.Add(_rules[i]);
            }
            
            return rules;
        }
        
    }
}