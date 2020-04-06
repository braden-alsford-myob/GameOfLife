using GameOfLife.Business;

namespace GameOfLife.DataAccess.RuleSets
{
    public interface IRuleSet
    {
        public RuleSetTypes GetName();
        public RuleSet GetRuleSet();
    }
}