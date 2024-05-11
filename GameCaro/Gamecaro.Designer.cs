namespace GameCaro
{
    partial class GameCaro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameCaro));
            this.pn_Info = new System.Windows.Forms.Panel();
            this.pgb_CountDown = new System.Windows.Forms.ProgressBar();
            this.btn_Play = new System.Windows.Forms.Button();
            this.lbl_PlayerName = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.tb_PlayerName = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viaLANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onSameComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_CountDown = new System.Windows.Forms.Timer(this.components);
            this.pn_GameBoard = new System.Windows.Forms.Panel();
            this.pn_Info.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Info
            // 
            this.pn_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Info.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pn_Info.Controls.Add(this.pgb_CountDown);
            this.pn_Info.Controls.Add(this.btn_Play);
            this.pn_Info.Controls.Add(this.lbl_PlayerName);
            this.pn_Info.Controls.Add(this.lbl_Port);
            this.pn_Info.Controls.Add(this.tb_Port);
            this.pn_Info.Controls.Add(this.tb_PlayerName);
            this.pn_Info.Location = new System.Drawing.Point(12, 32);
            this.pn_Info.Name = "pn_Info";
            this.pn_Info.Size = new System.Drawing.Size(940, 52);
            this.pn_Info.TabIndex = 0;
            // 
            // pgb_CountDown
            // 
            this.pgb_CountDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pgb_CountDown.Location = new System.Drawing.Point(276, 3);
            this.pgb_CountDown.Name = "pgb_CountDown";
            this.pgb_CountDown.Size = new System.Drawing.Size(304, 39);
            this.pgb_CountDown.TabIndex = 3;
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(205, 8);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(65, 35);
            this.btn_Play.TabIndex = 4;
            this.btn_Play.Text = "Play";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Visible = false;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // lbl_PlayerName
            // 
            this.lbl_PlayerName.AutoSize = true;
            this.lbl_PlayerName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_PlayerName.Location = new System.Drawing.Point(3, 17);
            this.lbl_PlayerName.Name = "lbl_PlayerName";
            this.lbl_PlayerName.Size = new System.Drawing.Size(34, 16);
            this.lbl_PlayerName.TabIndex = 2;
            this.lbl_PlayerName.Text = "Turn";
            // 
            // lbl_Port
            // 
            this.lbl_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Port.Location = new System.Drawing.Point(652, 17);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(44, 16);
            this.lbl_Port.TabIndex = 2;
            this.lbl_Port.Text = "Room";
            // 
            // tb_Port
            // 
            this.tb_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Port.Location = new System.Drawing.Point(702, 14);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.ReadOnly = true;
            this.tb_Port.Size = new System.Drawing.Size(75, 22);
            this.tb_Port.TabIndex = 1;
            // 
            // tb_PlayerName
            // 
            this.tb_PlayerName.Location = new System.Drawing.Point(53, 14);
            this.tb_PlayerName.Name = "tb_PlayerName";
            this.tb_PlayerName.ReadOnly = true;
            this.tb_PlayerName.Size = new System.Drawing.Size(146, 22);
            this.tb_PlayerName.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(964, 28);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.stmNewGame_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Visible = false;
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viaLANToolStripMenuItem,
            this.onSameComputerToolStripMenuItem});
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.playersToolStripMenuItem.Text = "2 players";
            // 
            // viaLANToolStripMenuItem
            // 
            this.viaLANToolStripMenuItem.Name = "viaLANToolStripMenuItem";
            this.viaLANToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.viaLANToolStripMenuItem.Text = "Via LAN";
            this.viaLANToolStripMenuItem.Click += new System.EventHandler(this.viaLANToolStripMenuItem_Click);
            // 
            // onSameComputerToolStripMenuItem
            // 
            this.onSameComputerToolStripMenuItem.Name = "onSameComputerToolStripMenuItem";
            this.onSameComputerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.onSameComputerToolStripMenuItem.Text = "On same computer";
            // 
            // tm_CountDown
            // 
            this.tm_CountDown.Tick += new System.EventHandler(this.Tm_CountDown_Tick);
            // 
            // pn_GameBoard
            // 
            this.pn_GameBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_GameBoard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pn_GameBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_GameBoard.Location = new System.Drawing.Point(12, 90);
            this.pn_GameBoard.Name = "pn_GameBoard";
            this.pn_GameBoard.Size = new System.Drawing.Size(940, 620);
            this.pn_GameBoard.TabIndex = 4;
            // 
            // GameCaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 722);
            this.Controls.Add(this.pn_GameBoard);
            this.Controls.Add(this.pn_Info);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GameCaro";
            this.Text = "Game Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameCaro_FormClosing);
            this.Shown += new System.EventHandler(this.GameCaro_Shown);
            this.pn_Info.ResumeLayout(false);
            this.pn_Info.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_Info;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viaLANToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onSameComputerToolStripMenuItem;
        private System.Windows.Forms.TextBox tb_PlayerName;
        private System.Windows.Forms.ProgressBar pgb_CountDown;
        private System.Windows.Forms.Timer tm_CountDown;
        private System.Windows.Forms.Panel pn_GameBoard;
        private System.Windows.Forms.Label lbl_PlayerName;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.Button btn_Play;
    }
}

