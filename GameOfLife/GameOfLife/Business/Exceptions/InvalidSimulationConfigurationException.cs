using System;

namespace GameOfLife.Business.Exceptions
{
    public class InvalidSimulationConfigurationException : Exception
    {
        public InvalidSimulationConfigurationException(string message) : base(FormatMessage(message))
        {
            
        }
        
        private static string FormatMessage(string message)
        {
            return $"The simulation configuration is not valid. \n{message}";
        }
    }
}