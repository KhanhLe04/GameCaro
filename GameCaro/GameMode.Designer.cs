namespace GameCaro
{
    partial class GameMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameMode));
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tb_Room = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Room = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(122, 104);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(193, 22);
            this.tb_Name.TabIndex = 0;
            // 
            // tb_Room
            // 
            this.tb_Room.Location = new System.Drawing.Point(122, 145);
            this.tb_Room.Name = "tb_Room";
            this.tb_Room.Size = new System.Drawing.Size(193, 22);
            this.tb_Room.TabIndex = 1;
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(59, 107);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(44, 16);
            this.lbl_Name.TabIndex = 2;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_Room
            // 
            this.lbl_Room.AutoSize = true;
            this.lbl_Room.Location = new System.Drawing.Point(59, 148);
            this.lbl_Room.Name = "lbl_Room";
            this.lbl_Room.Size = new System.Drawing.Size(44, 16);
            this.lbl_Room.TabIndex = 3;
            this.lbl_Room.Text = "Room";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(122, 37);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(193, 36);
            this.btn_Start.TabIndex = 4;
            this.btn_Start.Text = "BẮT ĐẦU";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_2Player_Click);
            // 
            // GameMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(406, 185);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lbl_Room);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.tb_Room);
            this.Controls.Add(this.tb_Name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameMode";
            this.Text = "Game Caro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_Room;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Room;
        private System.Windows.Forms.Button btn_Start;
    }
}