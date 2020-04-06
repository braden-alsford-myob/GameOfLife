using System.IO;
using GameOfLife.Business.Exceptions;
using GameOfLife.DataAccess;
using GameOfLife.DataAccess.Grids;
using GameOfLife.DataAccess.RuleSets;
using NUnit.Framework;

namespace GameOfLifeTests.DataAccess
{
    public class ConfigurationLoaderTests
    {
        private const string ValidFile = "validappsettings.json";
        private const string NonexistentFile = "asdf.json";
        private const string InvalidMaxGenerationsTypeFile = "invalidMaxGenerationsType.json";
        private const string NegativeMaxGenerationsFile = "negativeMaxGenerations.json";
        private const string InvalidGridTypeFile = "invalidGridType.json";
        private const string MissingConfigurationElementFile = "missingConfigurationElement.json";
        
        [Test]
        public void It_Should_Create_A_SimulationConfiguration_Given_A_Valid_Config_file()
        {
            const int expectedMaxGenerations = 100;
            const int expectedAnimationDelay = 250;
            const RuleSetType expectedRuleSet = RuleSetType.Basic;
            const GridType expectedGridType = GridType.Glider;
            
            var simulationConfig = ConfigurationLoader.LoadSimulationConfiguration(ValidFile);
            
            Assert.AreEqual(expectedMaxGenerations, simulationConfig.MaximumGenerations);
            Assert.AreEqual(expectedAnimationDelay, simulationConfig.AnimationDelay);
            Assert.AreEqual(expectedRuleSet, simulationConfig.RuleSetType);
            Assert.AreEqual(expectedGridType, simulationConfig.GridType);
        }
        
        [Test]
        public void It_Should_Throw_A_FileNotFoundException_Given_A_Config_That_Doesnt_Exist()
        {
            Assert.Throws(Is.TypeOf<FileNotFoundException>(),
                delegate
                { ConfigurationLoader.LoadSimulationConfiguration(NonexistentFile); });
        }

        [Test]
        public void It_Should_Throw_A_InvalidSimulationConfigurationException_Given_A_Config_With_Invalid_Parameter_Types()
        {
            var expectedMessage = "The simulation configuration is not valid. " +
                                  "\nMaximum Generations must be an integer. 'one hundred' is not an integer";
            
            Assert.Throws(
                Is.TypeOf<InvalidSimulationConfigurationException>()
                    .And.Message.EqualTo(expectedMessage),
                delegate { ConfigurationLoader.LoadSimulationConfiguration(InvalidMaxGenerationsTypeFile); });
        }

        [Test]
        public void It_Should_Throw_A_InvalidSimulationConfigurationException_Given_A_Config_With_Negative_Parameters()
        {
            var expectedMessage = "The simulation configuration is not valid. " +
                                  "\nMaximum Generations must be at least 1. '-100' is too small.";
            
            Assert.Throws(
                Is.TypeOf<InvalidSimulationConfigurationException>()
                    .And.Message.EqualTo(expectedMessage),
                delegate { ConfigurationLoader.LoadSimulationConfiguration(NegativeMaxGenerationsFile); });
        }

        [Test]
        public void It_Should_Throw_A_InvalidSimulationConfigurationException_Given_A_Config_With_Invalid_Enum_Types()
        {
            var expectedMessage = "The simulation configuration is not valid. " +
                                  "\n'Not a valid type' is not a recognised grid type.";
            
            Assert.Throws(
                Is.TypeOf<InvalidSimulationConfigurationException>()
                    .And.Message.Contains(expectedMessage),
                delegate { ConfigurationLoader.LoadSimulationConfiguration(InvalidGridTypeFile); });
        }

        [Test]
        public void It_Should_Throw_A_InvalidSimulationConfigurationException_Given_A_Config_With_Missing_Elements()
        {
            Assert.Throws(
                Is.TypeOf<InvalidSimulationConfigurationException>(),
                delegate { ConfigurationLoader.LoadSimulationConfiguration(MissingConfigurationElementFile); });
        }
    }
}