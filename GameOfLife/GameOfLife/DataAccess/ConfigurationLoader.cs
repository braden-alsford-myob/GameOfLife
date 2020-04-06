using System;
using GameOfLife.Business;
using GameOfLife.DataAccess.Grids;
using GameOfLife.DataAccess.RuleSets;
using Microsoft.Extensions.Configuration;

namespace GameOfLife.DataAccess
{
    public static class ConfigurationLoader
    {
        private const string MaxGenerationsKey = "Maximum Generations";
        private const string AnimationDelayKey = "Animation Delay";
        private const string GridTypeKey = "Grid Type";
        private const string RuleSetTypeKey = "Rule Set Type";
        
        public static SimulationConfiguration LoadSimulationConfiguration(string path)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(path)
                .Build();

            var maxGenerations = int.Parse(config[MaxGenerationsKey]);
            var animationDelay = int.Parse(config[AnimationDelayKey]);
            var gridType = (GridTypes) Enum.Parse(typeof(GridTypes), config[GridTypeKey]);
            var rulesType = (RuleSetTypes) Enum.Parse(typeof(RuleSetTypes), config[RuleSetTypeKey]);
            
            return new SimulationConfiguration(maxGenerations, animationDelay, gridType, rulesType);
        }
    }
}