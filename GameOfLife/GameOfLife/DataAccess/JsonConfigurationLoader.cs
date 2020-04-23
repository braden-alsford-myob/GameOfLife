using System;
using GameOfLife.Business;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.Grid;
using GameOfLife.Business.RuleSet;
using Microsoft.Extensions.Configuration;

namespace GameOfLife.DataAccess
{
    public class JsonConfigurationLoader : IConfigurationLoader
    {
        private readonly string _path;

        public JsonConfigurationLoader(string path)
        {
            _path = path;
        }

        public SimulationConfiguration Load()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(_path)
                .Build();
            
            var validator = new JsonValidator(config);
            validator.Validate();

            return BuildSimulationConfiguration(config);
        }

        private SimulationConfiguration BuildSimulationConfiguration(IConfiguration config)
        {
            var maxGenerations = int.Parse(config[JsonConfigurationKeyConstants.MaxGenerationsKey]);
            var animationDelay = int.Parse(config[JsonConfigurationKeyConstants.AnimationDelayKey]);
            var gridType = (GridType) Enum.Parse(typeof(GridType), config[JsonConfigurationKeyConstants.GridTypeKey]);
            var rulesType = (RuleSetType) Enum.Parse(typeof(RuleSetType), config[JsonConfigurationKeyConstants.RuleSetTypeKey]);
            var height = int.Parse(config[JsonConfigurationKeyConstants.HeightKey]);
            var width = int.Parse(config[JsonConfigurationKeyConstants.WidthKey]);

            return new SimulationConfiguration(maxGenerations, animationDelay, gridType, rulesType, height, width);
        }


    }
}