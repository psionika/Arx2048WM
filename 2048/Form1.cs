using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace _2048
{
    public delegate void DeShow(int x, int y, int score);
    public delegate void ShowStat(int balls);

    public partial class FormMain : Form
    {
        private const int size = 4;

        Label[,] labels;

        Dictionary<int, Color> backColors;

        Logic logic;

        public FormMain()
        {
            InitializeComponent();

            InitBackColors();
            InitLabels();
            logic = new Logic(size, Show, ShowStat);
            logic.InitGame();
        }

        private void menuItemNewGame_Click(object sender, EventArgs e)
        {
            logic.InitGame();
            labelScore.Text = "0";    
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2048 is played on a gray 4×4 grid, with numbered tiles that slide smoothly when"+
                            " a player moves them using the four arrow keys. Every turn, a new tile will randomly"+
                            " appear in an empty spot on the board with a value of either 2 or 4"
                            + "\n\nDev: Ivan Lezhnev \nContact: arxont@itchita.ru", 
                            "Rules", 
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question, 
                            MessageBoxDefaultButton.Button1);

        }

        private static Color Hex2Color(string hex)
        {
            int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

            return Color.FromArgb( r, g, b);
        }

        private void InitBackColors() 
        {
            backColors = new Dictionary<int, Color>();
            backColors.Add(0, Hex2Color("eee4da"));
            backColors.Add(2, Hex2Color("ede0c8"));
            backColors.Add(4, Hex2Color("f2b179"));
            backColors.Add(8, Hex2Color("f59563"));
            backColors.Add(16, Hex2Color("f67c5f"));
            backColors.Add(32, Hex2Color("f65e3b"));
            backColors.Add(64, Hex2Color("edcf72"));
            backColors.Add(128, Hex2Color("edcc61"));
            backColors.Add(256, Hex2Color("edc850"));
            backColors.Add(512, Hex2Color("edc53f"));
            backColors.Add(1024, Hex2Color("edc22e"));
            backColors.Add(2048, Hex2Color("3c3a32"));
            backColors.Add(4096, Color.FromArgb(242, 181, 233));
            backColors.Add(8192, Color.FromArgb(242, 181, 233));
            backColors.Add(16384, Color.FromArgb(242, 181, 233));
            backColors.Add(32768, Color.FromArgb(242, 181, 233));
            backColors.Add(65536, Color.FromArgb(242, 181, 233));
        }

        private void InitLabels()
        {
            int w = panel1.Width / size;
            int h = panel1.Height / size;
            labels = new Label[size, size];
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    labels[x, y] = CreateLabel();
                    labels[x, y].Size = new Size(w - 10, h - 10);
                    labels[x, y].Location = new Point(x * w + 10, y * h + 10);
                    panel1.Controls.Add(labels[x, y]);
                }
            }
        }

        private Label CreateLabel() 
        {
            Label label = new Label();
            label.BackColor = Color.LightCoral;
            label.Location = new Point(0, 0);
            label.Text = "-";
            label.TextAlign = ContentAlignment.TopCenter;
            return label;
        }

        public void Show(int x, int y, int score)
        {
            string str = score == 0 ? "" : score.ToString(CultureInfo.InvariantCulture);

            labels[x, y].Text = "\n" + str;

            labels[x, y].BackColor = backColors[score];
        }

        private void ShowStat(int balls) 
        {
            try
            {
                int score = Convert.ToInt32(labelScore.Text);
                string str = Convert.ToString(score + balls);
                labelScore.Text = str;
            }
            catch (Exception)
            {
                MessageBox.Show("Error convert score", "Error!");
            }
        }

        private void HandlingFinishInfo() 
        {
            DialogResult result = 
                MessageBox.Show("GAME OVER :(\nYour result " + labelScore.Text + "." 
                                  + "\n\nDo you have game again?",
                                "End game",
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question, 
                                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                logic.InitGame();
                labelScore.Text = "0";    
            }
            
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: logic.ShiftLeft(); break;
                case Keys.Right: logic.ShiftRight(); break;
                case Keys.Up: logic.ShiftUp(); break;
                case Keys.Down: logic.ShiftDown(); break;
                case Keys.Escape: logic.InitGame(); break;
                default: break;
            }
            if (logic.GameOver())
            {
                HandlingFinishInfo();
            }
        }

        #region Convert stylus move to keyPress
        private Point previousLocation;

        private void panel1_MouseMove(object sender, MouseEventArgs mea)
        {
            int factor = 80;

            int differenceX = mea.X - previousLocation.X;
            int differenceY = mea.Y - previousLocation.Y;

            if (Math.Abs(differenceX) < factor && Math.Abs(differenceY) < factor){ return; }

            if (Math.Abs(differenceY) >= factor && Math.Abs(differenceX) < factor)
            {
                if ((mea.Y - previousLocation.Y) >= factor)
                {
                    logic.ShiftDown();
                }
                if ((mea.Y - previousLocation.Y) <= -factor)
                {
                    logic.ShiftUp();
                }
            }

            if (Math.Abs(differenceY) < factor && Math.Abs(differenceX) >= factor)
            {
                if ((mea.X - previousLocation.X) >= factor)
                {
                    logic.ShiftRight();
                }
                if ((mea.X - previousLocation.X) <= -factor)
                {
                    logic.ShiftLeft();
                }
            }
                
            if (logic.GameOver())
            {
                HandlingFinishInfo();
            }

            base.OnMouseMove(mea);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs mea)
        {
            previousLocation = new Point(mea.X, mea.Y);

            base.OnMouseDown(mea);
        }
        #endregion

    }
}