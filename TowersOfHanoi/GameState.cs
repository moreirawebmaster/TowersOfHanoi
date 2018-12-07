using System.Collections.Generic;
using System.Drawing;

namespace TowersOfHanoi
{
    public static class GameState
    {
        public static List<Pole> Poles = new List<Pole>();
        public static List<Bitmap> ImageList = new List<Bitmap>();
        public static int MoveCount = 0;
        public static int NumberOfDisks = 0;
        
        // Start the game
        static GameState()
        {
            LoadImagesFromFile();
            RestartGame(3);
        }

        public static int MakeMove(Move move)
        {
            if (move == null || move.FromPole == null || move.ToPole == null)
            {
                return -1;
            }
            if (move.AffectCount())
            {
                MoveCount++;
            }
            
            if (move.IsValid())
            {
                Disk disk = move.FromPole.GetTopDisk();
                Poles[move.FromPole.Number].RemoveDisk();
                Poles[move.ToPole.Number].AddDisk(disk);
                return MoveCount;
            }

            else //Invalid move
            {
                return -1;
            }
        }

        public static bool IsSolved()
        {
            return (Poles[Properties.Settings.Default.EndPole].Disks.Count == NumberOfDisks);
        }

        public static Pole FindDisk(Disk diskToFind)
        {
            foreach (Pole pole in Poles)
            {
                if (pole.Disks.ContainsValue(diskToFind))
                {
                    return pole;
                }
            }
            return null;
        }

        public static void RestartGame()
        {
            MoveCount = 0;
            Poles = new List<Pole>();
            Poles.Add(new Pole(0));
            Poles.Add(new Pole(1));
            Poles.Add(new Pole(2));

            for (int i = NumberOfDisks - 1; i >= 0; i--)
            {
                Disk disk = new Disk(i);
                Poles[0].AddDisk(disk);
            }
        }

        public static void RestartGame(int numberOfDisks)
        {
            NumberOfDisks = numberOfDisks;
            RestartGame();
        }
        
        private static void LoadImagesFromFile()
        {
            ImageList.Add(TowersOfHanoi.Properties.Resources.disk1);
            ImageList.Add(TowersOfHanoi.Properties.Resources.disk2);
            ImageList.Add(TowersOfHanoi.Properties.Resources.disk3);
            ImageList.Add(TowersOfHanoi.Properties.Resources.disk4);
            ImageList.Add(TowersOfHanoi.Properties.Resources.disk5);
            ImageList.Add(TowersOfHanoi.Properties.Resources.disk6);
        }
    }
}

