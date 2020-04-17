using GameOfLife.Business.Grid;
using GameOfLife.DataAccess.RuleSets;

namespace GameOfLife.Business
{
    public class SimulationConfiguration
    {
        public SimulationConfiguration(int maximumGenerations, int animationDelay, GridType gridType, RuleSetType ruleSetType)
        {
            MaximumGenerations = maximumGenerations;
            AnimationDelay = animationDelay;
            GridType = gridType;
            RuleSetType = ruleSetType;
        }

        public int MaximumGenerations { get; private set; }
        public int AnimationDelay { get; private set; }
        public GridType GridType { get; private set; }
        public RuleSetType RuleSetType { get; private set; }
    }
}