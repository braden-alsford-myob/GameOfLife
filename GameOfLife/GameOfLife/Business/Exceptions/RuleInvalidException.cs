using System;

namespace GameOfLife.Business.Exceptions
{
    public class RuleInvalidException : Exception
    {
        public RuleInvalidException(object invalidPart) : base(FormatMessage(invalidPart))
        {
            
        }
        
        private static string FormatMessage(object invalidPart)
        {
            return $"This rule is not valid so cannot be initialized. Specifically, this part: {invalidPart}";
        }
    }
}