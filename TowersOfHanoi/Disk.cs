using System.Drawing;
using System.Windows.Forms;

namespace TowersOfHanoi
{
    public class Disk : PictureBox
    {
        public int Number { get; set; }

        public Disk(int number) : base()
        {
            Number = number;
            Image = GameState.ImageList[Number];
            Size = Image.Size;
        }

        public void MoveToPole(Pole destinationPole)
        {
            if (destinationPole?.Disks == null)
                return;
            
            var numberOfRungsOnSelectedPole = destinationPole.Disks.Count;         
            var x = (destinationPole.Location.X + destinationPole.Width) - (destinationPole.Width / 2)  - (this.Size.Width / 2);
            var y = destinationPole.Location.Y + destinationPole.Size.Height - ((numberOfRungsOnSelectedPole + 1) * this.Size.Height) - Properties.Resources._base.Size.Height;
            Location = new Point(x, y);
        }

        public override string ToString()
        {
            return Number.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Disk disk))
                return false;
            
            return disk.Number == Number;
        }
    }
}

