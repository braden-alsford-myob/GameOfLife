using GameOfLife.DataAccess.Grids;
using GameOfLife.DataAccess.RuleSets;

namespace GameOfLife.Business
{
    public class SimulationConfiguration
    {
        public SimulationConfiguration(int maximumGenerations, int animationDelay, GridTypes gridTypes, RuleSetTypes ruleSetTypes)
        {
            MaximumGenerations = maximumGenerations;
            AnimationDelay = animationDelay;
            GridTypes = gridTypes;
            RuleSetTypes = ruleSetTypes;
        }

        public int MaximumGenerations { get; private set; }
        public int AnimationDelay { get; private set; }
        public GridTypes GridTypes { get; private set; }
        public RuleSetTypes RuleSetTypes { get; private set; }
    }
}