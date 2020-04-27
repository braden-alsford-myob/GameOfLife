namespace GameOfLife.Business.NeighbourFinderObjects
 {
     public class IndexSet
     {
         public IndexSet(int aboveRowIndex, int currentRowIndex, int belowRowIndex, int leftColumnIndex, int currentColumnIndex, int rightColumnIndex)
         {
             AboveRowIndex = aboveRowIndex;
             CurrentRowIndex = currentRowIndex;
             BelowRowIndex = belowRowIndex;
             LeftColumnIndex = leftColumnIndex;
             CurrentColumnIndex = currentColumnIndex;
             RightColumnIndex = rightColumnIndex;
         }
 
         public int AboveRowIndex { get; } 
         public int CurrentRowIndex { get; } 
         public int BelowRowIndex { get; } 
         public int LeftColumnIndex { get; } 
         public int CurrentColumnIndex { get; } 
         public int RightColumnIndex { get; } 
     }
 }