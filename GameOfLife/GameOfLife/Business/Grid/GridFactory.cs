using System;

namespace GameOfLife.Business.Grid
{
    public class GridFactory
    {
        public Grid Create(GridType type, int height, int width)
        {
            var template = type switch
            {
                GridType.Glider => StringTemplateToGridConverter.Convert(GridTemplates.Glider),
                GridType.Tumbler => StringTemplateToGridConverter.Convert(GridTemplates.Tumbler),
                GridType.JohnConway => StringTemplateToGridConverter.Convert(GridTemplates.JohnConway),
                _ => throw new Exception()
            };

            var grid = new Grid(height, width);
            grid.AddTemplateToCenter(template);

            return grid;
        }
    }
}