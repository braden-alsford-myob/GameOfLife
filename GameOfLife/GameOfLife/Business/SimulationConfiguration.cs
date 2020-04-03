namespace GameOfLife.Business
{
    public class SimulationConfiguration
    {
        public SimulationConfiguration(int maximumGenerations, int animationDelay)
        {
            MaximumGenerations = maximumGenerations;
            AnimationDelay = animationDelay;
        }

        public int MaximumGenerations { get; private set; }
        public int AnimationDelay { get; private set; }
    }
}