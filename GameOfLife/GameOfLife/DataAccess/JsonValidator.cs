using System;
using System.Linq;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.Grid;
using GameOfLife.Business.RuleSet;
using Microsoft.Extensions.Configuration;

namespace GameOfLife.DataAccess
{
    public class JsonValidator
    {
        private readonly IConfiguration _configuration;

        public JsonValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void Validate()
        {
            ValidatePositiveInteger(JsonConfigurationKeyConstants.MaxGenerationsKey);
            ValidatePositiveInteger(JsonConfigurationKeyConstants.AnimationDelayKey);
            ValidatePositiveInteger(JsonConfigurationKeyConstants.HeightKey);
            ValidatePositiveInteger(JsonConfigurationKeyConstants.WidthKey);
            
            ValidateGridEnum(JsonConfigurationKeyConstants.GridTypeKey);
            ValidateRuleSetEnum(JsonConfigurationKeyConstants.RuleSetTypeKey);
        }

        private void ValidatePositiveInteger(string key)
        {
            ValidateKeyExists(key);

            var potentialInteger = _configuration[key];
            
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

        private void ValidateGridEnum(string key)
        {
            ValidateKeyExists(key);
            var potentialEnum = _configuration[key];
            
            if (Enum.IsDefined(typeof(GridType), potentialEnum)) return;
            
            var options = string.Join(", ", Enum.GetNames(typeof(GridType)));

            throw new InvalidSimulationConfigurationException(
                $"'{potentialEnum}' is not a recognised grid type. " +
                $"/n Valid grid types include {options}."
            );
        }

        private void ValidateRuleSetEnum(string key)
        {
            ValidateKeyExists(key);
            var potentialEnum = _configuration[key];

            if (Enum.IsDefined(typeof(RuleSetType), potentialEnum)) return;

            var options = string.Join(", ", Enum.GetNames(typeof(RuleSetType)));
            
            throw new InvalidSimulationConfigurationException(
                $"'{potentialEnum}' is not a recognised rule set type. " +
                $"Valid rule set types include {options}."
            );
        }
        
        private void ValidateKeyExists(string key)
        {
            var keyValuePairs = _configuration.AsEnumerable();
            
            if (keyValuePairs.All(keyValuePair => keyValuePair.Key != key))
            {
                throw new InvalidSimulationConfigurationException($"Missing key: {key}");
            }
        }
    }
}