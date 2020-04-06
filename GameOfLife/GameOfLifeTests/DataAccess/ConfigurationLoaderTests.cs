using System;
using System.IO;
using GameOfLife.DataAccess;
using GameOfLife.DataAccess.Grids;
using GameOfLife.DataAccess.RuleSets;
using NUnit.Framework;

namespace GameOfLifeTests.DataAccess
{
    public class ConfigurationLoaderTests
    {
        private const string ValidFile = "validappsettings.json";
        private const string InvalidFormatFile = "invalidFormatAppsettings.json";
        private const string InvalidTypeFile = "invalidTypeAppsettings.json";
        private const string NonexistentFile = "asdf.json";
        
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
        public void It_Should_Throw_A_FormatException_Given_A_Config_Missing_Parameters()
        {
            Assert.Throws(Is.TypeOf<FormatException>(),
                delegate
                { ConfigurationLoader.LoadSimulationConfiguration(InvalidFormatFile); });
        }
        
        [Test]
        public void It_Should_Throw_A_FormatException_Given_A_Config_Of_Invalid_Format()
        {
            Assert.Throws(Is.TypeOf<FormatException>(),
                delegate
                { ConfigurationLoader.LoadSimulationConfiguration(InvalidTypeFile); });
        }
        
        [Test]
        public void It_Should_Throw_A_FileNotFoundException_Given_A_Config_Of_Invalid_Format()
        {
            Assert.Throws(Is.TypeOf<FileNotFoundException>(),
                delegate
                { ConfigurationLoader.LoadSimulationConfiguration(NonexistentFile); });
        }
    }
}