using System;
using GameOfLife.Business;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.Grid;
using GameOfLife.Business.RuleSet;
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

            Validate(config);

            var maxGenerations = int.Parse(config[MaxGenerationsKey]);
            var animationDelay = int.Parse(config[AnimationDelayKey]);
            var gridType = (GridType) Enum.Parse(typeof(GridType), config[GridTypeKey]);
            var rulesType = (RuleSetType) Enum.Parse(typeof(RuleSetType), config[RuleSetTypeKey]);

            return new SimulationConfiguration(maxGenerations, animationDelay, gridType, rulesType);
        }

        private static void Validate(IConfiguration config)
        {
            ValidatePositiveInteger(config[MaxGenerationsKey], MaxGenerationsKey);
            ValidatePositiveInteger(config[AnimationDelayKey], AnimationDelayKey);

            ValidateGridEnum(config[GridTypeKey]);
            ValidateRuleSetEnum(config[RuleSetTypeKey]);
        }

        private static void ValidatePositiveInteger(string potentialInteger, string key)
        {
            if (!int.TryParse(potentialInteger, out var i))
            {
                throw new InvalidSimulationConfigurationException(
                    $"{key} must be an integer. '{potentialInteger}' is not an integer"
                    );
            }

            if (i < 1)
            {
                throw new InvalidSimulationConfigurationException(
                    $"{key} must be at least 1. '{potentialInteger}' is too small."
                );
            }
        }

        private static void ValidateGridEnum(string potentialEnum)
        {
            if (Enum.IsDefined(typeof(GridType), potentialEnum)) return;
            
            var options = string.Join(", ", Enum.GetNames(typeof(GridType)));

            throw new InvalidSimulationConfigurationException(
                $"'{potentialEnum}' is not a recognised grid type. " +
                $"/n Valid grid types include {options}."
            );
        }

        private static void ValidateRuleSetEnum(string potentialEnum)
        {
            if (Enum.IsDefined(typeof(RuleSetType), potentialEnum)) return;

            var options = string.Join(", ", Enum.GetNames(typeof(RuleSetType)));
            
            throw new InvalidSimulationConfigurationException(
                $"'{potentialEnum}' is not a recognised rule set type. " +
                $"Valid rule set types include {options}."
            );
        }

    }
}