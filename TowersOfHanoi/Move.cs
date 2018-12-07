namespace TowersOfHanoi
{
    public class Move
    {
        public Pole FromPole { get; set; }
        public Pole ToPole { get; set; }

        public Move(Pole fromPole, Pole toPole)
        {
            FromPole = fromPole;
            ToPole = toPole;
        }

        public bool AffectCount()
        {
            //If the poles dont change the move should not be counted
            if (ToPole.Equals(FromPole))
            {
                return false;
            }
            return IsValid();
        }            

        public bool IsValid()
        {
            if (ToPole.Equals(FromPole))
            {
                return true;
            }
            return ToPole.AllowDisk(FromPole.GetTopDisk());
        }

        public Move(int fromPoleNumber, int toPoleNumber)
        {
            FromPole = GameState.Poles[fromPoleNumber];
            ToPole = GameState.Poles[toPoleNumber];
        }

        public override string ToString()
        {
            if (FromPole == null || ToPole == null)
            {
                return "Missing poles";
            }
            return $"Move the top disk from{FromPole} to {ToPole} \n";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Move move))
                return false;
            
            return move.FromPole.Number == FromPole.Number;
        }
    }
}