using System;
using GameOfLife.DataAccess.RuleSets;

namespace GameOfLife.DataAccess
{
    public class RuleSetFactory
    {
        public IRuleSet Create(RuleSetTypes types)
        {
            return types switch
            {
                RuleSetTypes.Basic => new BasicRuleSet(),
                _ => throw new Exception()
            };
        }
    }
}