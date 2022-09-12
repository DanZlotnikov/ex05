namespace GameUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.lblPlayerName1 = new System.Windows.Forms.Label();
            this.lblPlayerName2 = new System.Windows.Forms.Label();
            this.PlayerName1 = new System.Windows.Forms.TextBox();
            this.PlayerName2 = new System.Windows.Forms.TextBox();
            this.lblBoardSize = new System.Windows.Forms.Label();
            this.againstFriendComputerButton = new System.Windows.Forms.Button();
            this.boardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.startButton.Location = new System.Drawing.Point(526, 248);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(116, 29);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPlayerName1
            // 
            this.lblPlayerName1.AutoSize = true;
            this.lblPlayerName1.Location = new System.Drawing.Point(51, 45);
            this.lblPlayerName1.Name = "lblPlayerName1";
            this.lblPlayerName1.Size = new System.Drawing.Size(99, 15);
            this.lblPlayerName1.TabIndex = 1;
            this.lblPlayerName1.Text = "First Player Name";
            // 
            // lblPlayerName2
            // 
            this.lblPlayerName2.AutoSize = true;
            this.lblPlayerName2.Location = new System.Drawing.Point(51, 91);
            this.lblPlayerName2.Name = "lblPlayerName2";
            this.lblPlayerName2.Size = new System.Drawing.Size(116, 15);
            this.lblPlayerName2.TabIndex = 2;
            this.lblPlayerName2.Text = "Second Player Name";
            // 
            // PlayerName1
            // 
            this.PlayerName1.Location = new System.Drawing.Point(211, 37);
            this.PlayerName1.Name = "PlayerName1";
            this.PlayerName1.Size = new System.Drawing.Size(201, 23);
            this.PlayerName1.TabIndex = 3;
            // 
            // PlayerName2
            // 
            this.PlayerName2.Location = new System.Drawing.Point(211, 83);
            this.PlayerName2.Name = "PlayerName2";
            this.PlayerName2.ReadOnly = true;
            this.PlayerName2.Size = new System.Drawing.Size(201, 23);
            this.PlayerName2.TabIndex = 4;
            this.PlayerName2.Text = "- computer -";
            // 
            // lblBoardSize
            // 
            this.lblBoardSize.AutoSize = true;
            this.lblBoardSize.Location = new System.Drawing.Point(51, 158);
            this.lblBoardSize.Name = "lblBoardSize";
            this.lblBoardSize.Size = new System.Drawing.Size(64, 15);
            this.lblBoardSize.TabIndex = 5;
            this.lblBoardSize.Text = "Board Size:";
            // 
            // againstFriendComputerButton
            // 
            this.againstFriendComputerButton.Location = new System.Drawing.Point(430, 82);
            this.againstFriendComputerButton.Name = "againstFriendComputerButton";
            this.againstFriendComputerButton.Size = new System.Drawing.Size(212, 24);
            this.againstFriendComputerButton.TabIndex = 7;
            this.againstFriendComputerButton.Text = "Against a Friend";
            this.againstFriendComputerButton.UseVisualStyleBackColor = true;
            this.againstFriendComputerButton.Click += new System.EventHandler(this.againstFriendComputerButton_Click);
            // 
            // boardSizeButton
            // 
            this.boardSizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.boardSizeButton.Location = new System.Drawing.Point(51, 186);
            this.boardSizeButton.Name = "boardSizeButton";
            this.boardSizeButton.Size = new System.Drawing.Size(149, 91);
            this.boardSizeButton.TabIndex = 8;
            this.boardSizeButton.Text = "4 x 4";
            this.boardSizeButton.UseVisualStyleBackColor = false;
            this.boardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.boardSizeButton);
            this.Controls.Add(this.againstFriendComputerButton);
            this.Controls.Add(this.lblBoardSize);
            this.Controls.Add(this.PlayerName2);
            this.Controls.Add(this.PlayerName1);
            this.Controls.Add(this.lblPlayerName2);
            this.Controls.Add(this.lblPlayerName1);
            this.Controls.Add(this.startButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startButton;
        private Label lblPlayerName1;
        private Label lblPlayerName2;
        private TextBox PlayerName1;
        private TextBox PlayerName2;
        private Label lblBoardSize;
        private Button againstFriendComputerButton;
        private Button boardSizeButton;
    }
}