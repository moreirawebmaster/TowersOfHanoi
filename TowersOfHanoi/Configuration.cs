namespace TowersOfHanoi
{
    public class Configuration
    {
        public int StartPole {get; set;}
        public int EndPole { get; set; }
        public int AmountOfDisks { get; set; }

        public Configuration(int startPole, int endPole, int amountOfDisks)
        {
            StartPole = startPole;
            EndPole = endPole;
            AmountOfDisks = amountOfDisks;
        }
    }
}
