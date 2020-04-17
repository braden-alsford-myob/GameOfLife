using System.Collections.Generic;
using System.Linq;
using GameOfLife.Business.Cell;
using GameOfLife.Business.Grid;

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
            var prioritisedRuleKeys = GetRuleKeysOrderedInReversePriority();

            var currentState = neighbours.GetCellState(new CellPosition(1, 1));
            foreach(var ruleKey in prioritisedRuleKeys)
            {
                currentState = _rules[ruleKey].GetNextCellState(neighbours, currentState);
            }

            return currentState;
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