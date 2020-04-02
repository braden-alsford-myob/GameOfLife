using System.Collections.Generic;
using System.Linq;

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
            
            var prioritisedRuleKeys = GetRuleKeysOrderedInReversePriority();
            
            //TODO change to have the output of one rule the input to the next (chaining)
            foreach(var ruleKey in prioritisedRuleKeys)
            {
                var nextState = _rules[ruleKey].GetNextCellState(neighbours);
                if (nextState != CellState.NoChange) finalCellState = nextState;
            }

            return finalCellState == 
                   CellState.NoChange ? neighbours.GetCellState(new CellPosition(1, 1)) : finalCellState;
        }

        private List<int> GetRuleKeysOrderedInReversePriority()
        {
            var prioritizedRules = _rules.Keys.ToList();
            prioritizedRules.Sort();
            prioritizedRules.Reverse();

            return prioritizedRules;
        }
        
    }
}