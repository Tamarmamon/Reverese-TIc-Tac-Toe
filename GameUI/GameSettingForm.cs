using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameUI
{
    public class GameSettingForm : Form
    {
        private Label PlayersHeaderStr;
        private Label Player1;
        public TextBox player1Name;
        public CheckBox player2Choice;
        public TextBox player2Name;
        private Label BoarsSizeStr;
        public NumericUpDown numericUpDownRows;
        public NumericUpDown NumberCols;
        private Label RowsStr;
        private Button StartButton;
        private Label ColsStr;

        public GameSettingForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.PlayersHeaderStr = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.player1Name = new System.Windows.Forms.TextBox();
            this.player2Choice = new System.Windows.Forms.CheckBox();
            this.player2Name = new System.Windows.Forms.TextBox();
            this.BoarsSizeStr = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.NumberCols = new System.Windows.Forms.NumericUpDown();
            this.RowsStr = new System.Windows.Forms.Label();
            this.ColsStr = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberCols)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayersHeaderStr
            // 
            this.PlayersHeaderStr.AutoSize = true;
            this.PlayersHeaderStr.Location = new System.Drawing.Point(12, 9);
            this.PlayersHeaderStr.Name = "PlayersHeaderStr";
            this.PlayersHeaderStr.Size = new System.Drawing.Size(64, 20);
            this.PlayersHeaderStr.TabIndex = 0;
            this.PlayersHeaderStr.Text = "Players:";
            this.PlayersHeaderStr.Click += new System.EventHandler(this.Player1_Click);
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(33, 47);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(69, 20);
            this.Player1.TabIndex = 1;
            this.Player1.Text = "Player 1:";
            this.Player1.Click += new System.EventHandler(this.label2_Click);
            // 
            // player1Name
            // 
            this.player1Name.Location = new System.Drawing.Point(139, 47);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(116, 26);
            this.player1Name.TabIndex = 2;
            // 
            // player2Choice
            // 
            this.player2Choice.AutoSize = true;
            this.player2Choice.Location = new System.Drawing.Point(27, 93);
            this.player2Choice.Name = "player2Choice";
            this.player2Choice.Size = new System.Drawing.Size(95, 24);
            this.player2Choice.TabIndex = 3;
            this.player2Choice.Text = "Player 2:";
            this.player2Choice.UseVisualStyleBackColor = true;
            this.player2Choice.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // player2Name
            // 
            this.player2Name.BackColor = System.Drawing.SystemColors.MenuBar;
            this.player2Name.Enabled = false;
            this.player2Name.Location = new System.Drawing.Point(139, 93);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(116, 26);
            this.player2Name.TabIndex = 4;
            this.player2Name.Text = "Computer";
            // 
            // BoarsSizeStr
            // 
            this.BoarsSizeStr.AutoSize = true;
            this.BoarsSizeStr.Location = new System.Drawing.Point(12, 148);
            this.BoarsSizeStr.Name = "BoarsSizeStr";
            this.BoarsSizeStr.Size = new System.Drawing.Size(91, 20);
            this.BoarsSizeStr.TabIndex = 5;
            this.BoarsSizeStr.Text = "Board Size:";
            this.BoarsSizeStr.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDownRows.Location = new System.Drawing.Point(68, 174);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(54, 26);
            this.numericUpDownRows.TabIndex = 6;
            this.numericUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // NumberCols
            // 
            this.NumberCols.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.NumberCols.Location = new System.Drawing.Point(204, 173);
            this.NumberCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumberCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumberCols.Name = "NumberCols";
            this.NumberCols.Size = new System.Drawing.Size(51, 26);
            this.NumberCols.TabIndex = 7;
            this.NumberCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumberCols.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // RowsStr
            // 
            this.RowsStr.AutoSize = true;
            this.RowsStr.Location = new System.Drawing.Point(12, 175);
            this.RowsStr.Name = "RowsStr";
            this.RowsStr.Size = new System.Drawing.Size(53, 20);
            this.RowsStr.TabIndex = 8;
            this.RowsStr.Text = "Rows:";
            this.RowsStr.Click += new System.EventHandler(this.label4_Click);
            // 
            // ColsStr
            // 
            this.ColsStr.AutoSize = true;
            this.ColsStr.Location = new System.Drawing.Point(154, 175);
            this.ColsStr.Name = "ColsStr";
            this.ColsStr.Size = new System.Drawing.Size(44, 20);
            this.ColsStr.TabIndex = 9;
            this.ColsStr.Text = "Cols:";
            this.ColsStr.Click += new System.EventHandler(this.label5_Click);
            // 
            // StartButton
            // 
            this.StartButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartButton.Location = new System.Drawing.Point(85, 212);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(127, 26);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameSettingForm
            // 
            this.ClientSize = new System.Drawing.Size(306, 264);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ColsStr);
            this.Controls.Add(this.RowsStr);
            this.Controls.Add(this.NumberCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.BoarsSizeStr);
            this.Controls.Add(this.player2Name);
            this.Controls.Add(this.player2Choice);
            this.Controls.Add(this.player1Name);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.PlayersHeaderStr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettingForm";
            this.Text = "Game Setting";
            this.Load += new System.EventHandler(this.GameSettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(player2Choice.Checked == true)
            {
                player2Name.Enabled = true;
                player2Name.Text = null;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = NumberCols.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            NumberCols.Value = numericUpDownRows.Value;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GameSettingForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Player1_Click(object sender, EventArgs e)
        {

        }
    }
}
