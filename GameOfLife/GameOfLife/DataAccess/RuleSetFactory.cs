using System;
using GameOfLife.DataAccess.RuleSets;

namespace GameOfLife.DataAccess
{
    public class RuleSetFactory
    {
        public IRuleSet Create(RuleSetType type)
        {
            return type switch
            {
                RuleSetType.Basic => new BasicRuleSet(),
                _ => throw new Exception()
            };
        }
    }
}