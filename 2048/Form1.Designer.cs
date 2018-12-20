namespace _2048
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemNewGame = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.labelScoreTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemNewGame);
            this.mainMenu1.MenuItems.Add(this.menuItem4);
            this.mainMenu1.MenuItems.Add(this.menuItemAbout);
            this.mainMenu1.MenuItems.Add(this.menuItem5);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItemNewGame
            // 
            this.menuItemNewGame.Text = "New Game";
            this.menuItemNewGame.Click += new System.EventHandler(this.menuItemNewGame_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Enabled = false;
            this.menuItem4.Text = "|";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Text = "About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Enabled = false;
            this.menuItem5.Text = "|";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // labelScoreTitle
            // 
            this.labelScoreTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelScoreTitle.Location = new System.Drawing.Point(18, 16);
            this.labelScoreTitle.Name = "labelScoreTitle";
            this.labelScoreTitle.Size = new System.Drawing.Size(87, 40);
            this.labelScoreTitle.Text = "Score:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(18, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 421);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // labelScore
            // 
            this.labelScore.Location = new System.Drawing.Point(111, 16);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(132, 40);
            this.labelScore.Text = "0";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 536);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelScoreTitle);
            this.Location = new System.Drawing.Point(0, 52);
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Text = "2048";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemNewGame;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Label labelScoreTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelScore;
    }
}

