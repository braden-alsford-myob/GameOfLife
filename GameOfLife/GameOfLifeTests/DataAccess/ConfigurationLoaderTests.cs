using System.IO;
using GameOfLife.Business;
using GameOfLife.Business.Exceptions;
using GameOfLife.Business.Grid;
using GameOfLife.DataAccess;
using GameOfLife.DataAccess.RuleSets;
using Newtonsoft.Json;
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
            var expected = new SimulationConfiguration(100, 250, GridType.Glider, RuleSetType.Basic);

            var actual = ConfigurationLoader.LoadSimulationConfiguration(ValidFile);

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
        }
        
        
        [Test]
        public void It_Should_Throw_A_FileNotFoundException_Given_A_Config_That_Doesnt_Exist()
        {
            void LoadConfiguration()
            {
                ConfigurationLoader.LoadSimulationConfiguration(NonexistentFile);
            }
            
            Assert.Throws(Is.TypeOf<FileNotFoundException>(), LoadConfiguration);
        }

        
        [TestCase(InvalidMaxGenerationsTypeFile)]
        [TestCase(NegativeMaxGenerationsFile)]
        [TestCase(InvalidGridTypeFile)]
        [TestCase(MissingConfigurationElementFile)]

        public void It_Should_Throw_An_InvalidSimulationConfigurationException_Given_Invalid_Config_Files(string path)
        {
            void LoadConfiguration()
            {
                ConfigurationLoader.LoadSimulationConfiguration(path);
            }

            Assert.Throws(Is.TypeOf<InvalidSimulationConfigurationException>(), LoadConfiguration);
        }

    }
}