using System;
using System.Drawing;
using System.Windows.Forms;

namespace TowersOfHanoi
{
    public sealed partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
            AllowDrop = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void ThisBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ThisBox_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            var disk = (Disk)sender;
            var pointX = Cursor.Position.X - Location.X - (disk.Size.Height / 2);
            var pointY = Cursor.Position.Y - Location.Y - (disk.Size.Width / 2);
            disk.Location = new Point(pointX, pointY);

            if (e.Action == DragAction.Drop)
            {
                var destinationPoleNumber = DeterminePoleFromCursorPosition();
                var currentPole = GameState.FindDisk(disk);
                var move = new Move(currentPole, GameState.Poles[destinationPoleNumber]);

                if (move.IsValid())
                {
                    MakeMove(move);
                }
                else
                {
                    var moveBack = new Move(currentPole, currentPole);
                    GameState.MakeMove(moveBack);
                }
            }
        }

        private void MakeMove(Move move)
        {
            var moveCount = GameState.MakeMove(move);
            moveCounter.Text = moveCount.ToString();
            if (GameState.IsSolved())
            {
                possibleToSolve.Text = "Solved :) ";
            }
        }

        private void disk_MouseDown(object sender, MouseEventArgs e)
        {
            var disk = sender as Disk;
            var pole = GameState.FindDisk(disk);

            if (!pole.GetTopDisk().Equals(disk))
            {
                return;
            }

            disk?.DoDragDrop(disk, DragDropEffects.All);
        }

        private Point GetMousePosition()
        {
            return new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
        }

        private int DeterminePoleFromCursorPosition()
        {
            var mousePosition = GetMousePosition();
            if (mousePosition.X < GameState.Poles[0].Location.X)
                return 0;
            if (mousePosition.X > GameState.Poles[1].Location.X - 60 && mousePosition.X < GameState.Poles[2].Location.X - 60)
                return 1;
            if (mousePosition.X > GameState.Poles[2].Location.X - 60 && mousePosition.X < GameState.Poles[2].Location.X + GameConstants.SpaceBetweenPoles)
                return 2;

            return 0;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripDropDownItem;
            RestartGame(Convert.ToInt16(item?.Text));
        }

        private void Form2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void ShowMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
            SolveGame();
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void SolveGame()
        {
            Enabled = false;
            var moves = MoveCalculator.GetMoves(GameState.NumberOfDisks);
            hints.Visible = true;
            hints.Text = string.Empty;
            hints.Text = Properties.Resources.HintCaption;
            moves.ForEach(move =>
            {
                hints.Text += move.ToString();
                MakeMove(move);
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
            });
            Enabled = true;
        }

        private void RestartGame(int numberOfDisks)
        {
            GameState.NumberOfDisks = numberOfDisks;
            RestartGame();
        }

        private void RestartGame()
        {
            RemoveAllDisks();
            GameState.RestartGame();
            AddComponents();
            hints.Text = "";
            hints.Visible = false;
            moveCounter.Text = GameState.MoveCount.ToString();
            possibleToSolve.Text = $@"It is possible to solve this puzzle in {MoveCalculator.GetMoveCount(GameState.NumberOfDisks)} moves.";
        }

        private void RemoveAllDisks()
        {
            GameState.Poles.ForEach(pole =>
            {
                foreach (var disk in pole.Disks.Values)
                    Controls.Remove(disk);
            });
        }

        private void AddComponents()
        {
            var _base = new PictureBox
            {
                Image = Properties.Resources._base,
                Size = Properties.Resources._base.Size,
                BackColor = SystemColors.ControlDarkDark,
                Location = new Point(GameConstants.BaseStartPositionX, GameConstants.BaseStartPositionY)
            };

            Controls.Add(_base);

            moveCounter.Text = GameState.MoveCount.ToString();

            GameState.Poles.ForEach(pole =>
            {
                InitPole(pole);
                foreach (var disk in pole.Disks.Values)
                    InitDisk(disk);
            });
        }

        private void InitPole(Pole pole)
        {
            if (!Controls.Contains(pole))
            {
                Controls.Add(pole);
            }
        }

        private void InitDisk(Control disk)
        {
            if (!Controls.Contains(disk))
            {
                disk.MouseDown += disk_MouseDown;
                disk.QueryContinueDrag += ThisBox_QueryContinueDrag;
                disk.DragOver += ThisBox_DragOver;
                Controls.Add(disk);
                Controls.SetChildIndex(disk, 0);
            }
        }

        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            usernameTextbox.Text = "";
        }
    }
}