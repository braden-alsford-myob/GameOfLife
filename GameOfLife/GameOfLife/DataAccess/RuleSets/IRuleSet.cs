using GameOfLife.Business;

namespace GameOfLife.DataAccess.RuleSets
{
    public interface IRuleSet
    {
        public RuleSetType GetName();
        public RuleSet GetRuleSet();
    }
}