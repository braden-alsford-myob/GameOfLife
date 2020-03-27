using System;

namespace GameOfLife.Business.Exceptions
{
    public class RequirementInvalidException : Exception
    {
        public RequirementInvalidException(string message, object invalidPart) : base(FormatMessage(message, invalidPart))
        {
            
        }
        
        private static string FormatMessage(string message, object invalidPart)
        {
            return $"This requirement is not valid and cannot be initialized. Specifically: {invalidPart} \n{message}";
        }
    }
}