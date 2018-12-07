namespace TowersOfHanoi.Application.Game.NewGame
{
    public class PlayRequestDto
    {
        public int UserId { get; set; }
        public int TotalDisk { get; set; }
    }

    public class Peg
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}
