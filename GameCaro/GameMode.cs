﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class GameMode : Form
    {
        public GameMode()
        {
            InitializeComponent();
        }

        private void btn_2Player_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (tb_Name.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên", "Thông báo");
                    return;
                }
                if (tb_Room.Text == "" || !Int32.TryParse(tb_Room.Text, out int tryInt))
                {
                    MessageBox.Show("Phòng không hợp lệ !", "Thông báo");
                    return;
                }
                GameCaro gameCaro = new GameCaro();
                gameCaro.GameMode = 1;
                gameCaro.Room = int.Parse(tb_Room.Text);
                gameCaro.GetName = tb_Name.Text;
                gameCaro.Text = $"GameCaro (Name: {tb_Name.Text}, Room: {tb_Room.Text})";
                gameCaro.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Thông báo");
            }
        }
        

        
    }
}
