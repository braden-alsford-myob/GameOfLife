namespace GameOfLife.Business.Grid
{
    public static class GridTemplates
    {
        public const string Glider = "00000\n" +
                                      "00100\n" +
                                      "00010\n" +
                                      "01110\n" +
                                      "00000";

        public const string Tumbler = "000000000\n" +
                                      "001101100\n" +
                                      "001101100\n" +
                                      "000101000\n" +
                                      "010101010\n" +
                                      "010101010\n" +
                                      "011000110\n" +
                                      "000000000";

        public const string JohnConway = "000000000\n" +
                                         "000111000\n" +
                                         "000101000\n" +
                                         "000101000\n" +
                                         "000010000\n" +
                                         "010111000\n" +
                                         "001010100\n" +
                                         "000010010\n" +
                                         "000101000\n" +
                                         "000101000\n" +
                                         "000000000";
    }
}