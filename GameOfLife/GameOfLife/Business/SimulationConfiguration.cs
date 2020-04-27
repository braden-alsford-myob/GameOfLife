using GameOfLife.Business.GridObjects;
using GameOfLife.Business.RuleSetObjects;

namespace GameOfLife.Business
{
    public class SimulationConfiguration
    {
        public int MaximumGenerations { get; }
        public int AnimationDelay { get; }
        public GridType GridType { get; }
        public RuleSetType RuleSetType { get; }
        public int Height { get; }
        public int Width { get; }
        
        public SimulationConfiguration(int maximumGenerations, int animationDelay, GridType gridType, RuleSetType ruleSetType, int height, int width)
        {
            MaximumGenerations = maximumGenerations;
            AnimationDelay = animationDelay;
            GridType = gridType;
            RuleSetType = ruleSetType;
            Height = height;
            Width = width;
        }
    }
}