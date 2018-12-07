using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TowersOfHanoi
{
    public class Pole : PictureBox
    {
        public SortedList<int, Disk> Disks { get; set; }
        public int Number { get; set; }

        public Pole(int number)
        {
            Disks = new SortedList<int, Disk>();
            Number = number;
            Image = Properties.Resources.pole;
            Size = Properties.Resources.pole.Size;
            var xPosition = GameConstants.BaseStartPositionX + ((number + 1) * GameConstants.SpaceBetweenPoles);
            var yPosition = GameConstants.BaseStartPositionY + Properties.Resources._base.Size.Height - Size.Height;
            Location = new Point(xPosition, yPosition);
        }

        public bool IsEmpty() => Disks.Count == 0;
        
        public bool AllowDisk(Disk disk)
        {
            if (disk == null)
            {
                return false;
            }
            if (Disks.Count == 0)
            {
                return true;
            }
            return GetTopDisk().Number > disk.Number;
        }

        public Disk GetTopDisk()
        {
            if (Disks.Count > 0)
            {
                return Disks.First().Value;
            }
            return null;
        }

        public void RemoveDisk() => Disks.Remove(Disks.First().Key);
        
        public void AddDisk(Disk disk)
        {
            if (disk == null)
                return;
            
            if (AllowDisk(disk))
            {
                disk.MoveToPole(this);
                Disks.Add(disk.Number, disk);
            }
        }

        public override string ToString() => Convert.ToString(Number);

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Pole pole))
                return false;
            return pole.Number == Number;
        }
    }
}

