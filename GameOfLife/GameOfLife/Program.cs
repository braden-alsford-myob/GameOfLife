using GameOfLife.Business;
using GameOfLife.Business.TimerObjects;
using GameOfLife.DataAccess;
using GameOfLife.Presentation;

namespace GameOfLife
{
    class Program
    {
        private const string ConfigFileName = "simulationConfig.json";
        
        static void Main(string[] args)
        {
            var configLoader = new JsonConfigurationLoader(ConfigFileName);

            var simulationConfig = configLoader.Load();
            var simulation = new Simulation(simulationConfig, new CommandLinePresenter(new Writer()), new Timer());
            simulation.Execute();
        }
    }
}