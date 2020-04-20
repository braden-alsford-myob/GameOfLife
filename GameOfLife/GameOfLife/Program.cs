﻿using GameOfLife.Business;
using GameOfLife.DataAccess;
using GameOfLife.Presentation;

namespace GameOfLife
{
    class Program
    {
        private const string ConfigFileName = "simulationConfig.json";
        
        static void Main(string[] args)
        {
            var simulationConfig = ConfigurationLoader.LoadSimulationConfiguration(ConfigFileName);
            var simulation = new Simulation(simulationConfig, new CommandLinePresenter(new Writer()));
            simulation.Execute();
        }
    }
}