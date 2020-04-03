using System.IO;
using GameOfLife.Business;
using Microsoft.Extensions.Configuration;

namespace GameOfLife.DataAccess
{
    public class ConfigurationLoader
    {
        private const string MaxGenerations = "Maximum Generations";
        private const string AnimationDelay = "Animation Delay";
        
        public static SimulationConfiguration LoadSimulationConfiguration(string path)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();

            var maxGenerations = int.Parse(config[MaxGenerations]);
            var animationDelay = int.Parse(config[AnimationDelay]);
            
            return new SimulationConfiguration(maxGenerations, animationDelay);
        }
    }
}