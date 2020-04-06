using GameOfLife.Business;
using GameOfLife.DataAccess;
using GameOfLife.Presentation;

namespace GameOfLife
{
    class Program
    {
        private const string ConfigFileName = "appsettings.json";
        
        static void Main(string[] args)
        {
            var simulationConfig = ConfigurationLoader.LoadSimulationConfiguration(ConfigFileName);
            var simulation = new Simulation(simulationConfig, new CommandLinePresenter());
            simulation.Execute();
        }
    }
}