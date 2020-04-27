using System;

namespace GameOfLife.Business.GridObjects
{
    public class GridFactory
    {
        public Grid Create(GridType type, int height, int width)
        {
            var template = GetTemplate(type);

            var grid = new Grid(height, width);
            grid.AddTemplateToCenter(template);

            return grid;
        }

        private Grid GetTemplate(GridType type)
        { 
            return type switch
            {
                GridType.Glider => StringTemplateToGridConverter.Convert(GridTemplates.Glider),
                GridType.Tumbler => StringTemplateToGridConverter.Convert(GridTemplates.Tumbler),
                GridType.JohnConway => StringTemplateToGridConverter.Convert(GridTemplates.JohnConway),
                _ => throw new Exception("Invalid template enum")
            };
        }
    }
}