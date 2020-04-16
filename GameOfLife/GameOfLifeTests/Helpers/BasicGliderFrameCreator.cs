using System;
using System.Collections.Generic;
using GameOfLife.Business.Cell;

namespace GameOfLifeTests.Helpers
{
    public static class BasicGliderFrameCreator
    {
        public static List<List<Cell>> GetFrame(int frameNumber)
        {
            return frameNumber switch
            {
                1 => GetFrameOne(),
                2 => GetFrameTwo(),
                3 => GetFrameThree(),
                4 => GetFrameFour(),
                5 => GetFrameFive(),
                _ => throw new Exception()
            };
        }

        private static List<List<Cell>> GetFrameOne()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };
            
            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive
            };
        }

        private static List<List<Cell>> GetFrameTwo()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive
            };
        }

        private static List<List<Cell>> GetFrameThree()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };
            
            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive
            };
        }

        private static List<List<Cell>> GetFrameFour()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };
            
            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive
            };
        }

        private static List<List<Cell>> GetFrameFive()
        {
            var rowOne = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowTwo = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead)
            };

            var rowThree = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Dead)
            };

            var rowFour = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive)
            };

            var rowFive = new List<Cell>
            {
                new Cell(CellState.Dead),
                new Cell(CellState.Dead),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive),
                new Cell(CellState.Alive)
            };
            
            return new List<List<Cell>>
            {
                rowOne,
                rowTwo,
                rowThree,
                rowFour,
                rowFive
            };
        }
    }
}