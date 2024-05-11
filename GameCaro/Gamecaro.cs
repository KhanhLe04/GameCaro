using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GameCaro
{
    public partial class GameCaro : Form
    {
        GameBoard board;
        SocketManager socket;
        string PlayerName;
        int room;
        int gameMode;
        string getName;

        public int Room { get => room; set => room = value; }
        public int GameMode { get => gameMode; set => gameMode = value; }
        internal SocketManager Socket { get => socket; set => socket = value; }
        public string GetName { get => getName; set => getName = value; }

        public GameCaro()
        {
            InitializeComponent();

            board = new GameBoard(pn_GameBoard, tb_PlayerName);
            //Vẽ bàn cờ
            board.PlayerClicked += Board_PlayerClicked;
            //Thêm event click bàn cờ
            board.GameOver += Board_GameOver;
            //Thêm event khi kết thúc game
            pgb_CountDown.Step = InitValue.CountDownStep;
            pgb_CountDown.Maximum = InitValue.CountDownTime;
            tm_CountDown.Interval = InitValue.CountDownInterval;

            Socket = new SocketManager();


            NewGame();
        }

        void NewGame()
        {
            pgb_CountDown.Value = 0;
            tm_CountDown.Stop();




            board.DrawGameBoard();
        }

        void EndGame()
        {


            tm_CountDown.Stop();
            pn_GameBoard.Enabled = false;
        }

        private void GameCaro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
            else
            {
                try
                {
                    Socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }
        }


        //Event đánh caro
        private void Board_PlayerClicked(object sender, BtnClickEvent e)
        {
            // bắt đầu đếm giờ
            tm_CountDown.Start();
            // đặt thời gian countdown = 0
            pgb_CountDown.Value = 0;
            try
            {
                pn_GameBoard.Enabled = false;
                Socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));
                //Sẽ gửi nước cờ đến người chơi khác


                Listen();//Và tiếp tục lắng nghe
            }
            catch
            {
                EndGame();
                MessageBox.Show("Không có kết nối nào tới máy đối thủ", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void Board_GameOver(object sender, EventArgs e)
        {//Hàm sẽ được gọi khi có người chơi thắng
            EndGame();
            //Gửi thông điệp chiến thắng đến người chơi khác
            Socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
            
        }

        private void Tm_CountDown_Tick(object sender, EventArgs e)
        {
            pgb_CountDown.PerformStep();

            if (pgb_CountDown.Value >= pgb_CountDown.Maximum)
            {
                EndGame();

                if (board.PlayMode == 1)
                    Socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));
            }
        }




        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Khi form 
        private void viaLANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board.PlayMode = 1;
            NewGame();

            Socket.IP = "127.0.0.1";

            if (!Socket.ConnectServer()) // Kết nối thử đến server xem đã có chưa
            {//Nếu chưa form này sẽ được xem như là server
                Socket.IsServer = true;
                pn_GameBoard.Enabled = false;
                Socket.CreateServer();
                //Tạo server
                Player player = new Player(getName, Image.FromFile(Application.StartupPath + "\\Resources\\X.png"));
                board.ListPlayers[0] = player;
                tb_PlayerName.Text = player.Name;
                btn_Play.Visible = true;
                MessageBox.Show("Bạn đã tạo phòng " + room.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {//Ngược lại form này sẽ được xem như là client
                Socket.IsServer = false;
                pn_GameBoard.Enabled = false;
                tb_PlayerName.Text = "";
                Listen();
                //Client bắt đầu lắng nghe từ server 
                Socket.Send(new SocketData((int)SocketCommand.SEND_NAME, getName, new Point()));
                //Gửi tên đến server
                Player player = new Player(getName, Image.FromFile(Application.StartupPath + "\\Resources\\O.png"));
                board.ListPlayers[1] = player;
                MessageBox.Show("Bạn đã tham gia phòng " + room.ToString() + "\nVui lòng chờ đối thủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        
        private void btn_Play_Click(object sender, EventArgs e)
        {
            Listen();//Server sẽ bắt đầu lắng nghe từ client
        }




        //Khi form khởi động sẽ gọi đến hàm GameCaro_Shown để vào kiểu chơi đã chọn trước
        private void GameCaro_Shown(object sender, EventArgs e)
        {
            tb_Port.Visible = false;
            lbl_Port.Visible = false;
            tb_Port.Visible = true;
            lbl_Port.Visible = true;
            Socket.Port = room;
            tb_Port.Text = Socket.Port.ToString();
            viaLANToolStripMenuItem.PerformClick();
        }

        private void Listen()
        {
            Thread ListenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)Socket.Receive();
                    //Nhận dữ liệu và xử lý sau khi nhận
                    //Kiểu dữ liệu nhận được là SocketData đã được tạo
                    ProcessData(data);
                }
                catch { }
            });

            ListenThread.IsBackground = true;
            ListenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            PlayerName = board.ListPlayers[board.CurrentPlayer == 1 ? 0 : 1].Name;

            switch (data.Command)
            {
                case (int)SocketCommand.SEND_POINT: //Trường hợp gửi điểm vừa đánh cờ
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //Hàm OtherPlayerClicked sẽ được gọi để hiển thị cờ mà đối thủ vừa đánh
                        board.OtherPlayerClicked(data.Point);
                        
                        pn_GameBoard.Enabled = true;

                        pgb_CountDown.Value = 0;
                        tm_CountDown.Start();


                    }));
                    break;

                
                case (int)SocketCommand.NEW_GAME://Trường hợp tạo game mới
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pn_GameBoard.Enabled = false;
                    }));
                    break;

                

                case (int)SocketCommand.END_GAME://Trường hợp kết thúc game
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (tb_PlayerName.Text == board.ListPlayers[0].Name)
                            tb_PlayerName.Text = board.ListPlayers[1].Name;
                        else
                            tb_PlayerName.Text = board.ListPlayers[0].Name;
                        //Kiểm tra xem ai là người chiến thắng
                        EndGame();
                        MessageBox.Show(tb_PlayerName.Text + " đã chiến thắng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    break;

                case (int)SocketCommand.TIME_OUT://Trường hợp hết giừo
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (tb_PlayerName.Text == board.ListPlayers[0].Name)
                            tb_PlayerName.Text = board.ListPlayers[1].Name;
                        else
                            tb_PlayerName.Text = board.ListPlayers[0].Name;
                        //Kiểm tra xem ai là người chiến thắng
                        EndGame();
                        MessageBox.Show("Đã hết giờ, xử thua !\n" + tb_PlayerName.Text + " đã chiến thắng!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    break;

                case (int)SocketCommand.QUIT://Khi đối thủ thoát khỏi room
                    this.Invoke((MethodInvoker)(() =>
                    {
                        tm_CountDown.Stop();
                        EndGame();
                        board.PlayMode = 2;
                        Socket.CloseConnect();
                        //Kết thúc khỏi ván cờ và ngắt kết nối
                        MessageBox.Show("Đối thủ đã thoát phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                    break;
                case (int)SocketCommand.SEND_NAME://Gửi thông tin tên người dùng
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (Socket.IsServer)
                        {
                            pn_GameBoard.Enabled = true;
                            Player player = new Player(data.Message, Image.FromFile(Application.StartupPath + "\\Resources\\O.png"));
                            board.ListPlayers[1] = player;//Đổi tên người chơi
                            btn_Play.Enabled = false;
                            btn_Play.Visible = false;
                            Socket.Send(new SocketData((int)SocketCommand.SEND_NAME, getName, new Point()));
                        }
                        else
                        {
                            Player player = new Player(data.Message, Image.FromFile(Application.StartupPath + "\\Resources\\X.png"));
                            board.ListPlayers[0] = player;
                            tb_PlayerName.Text = player.Name;
                        }
                        Listen();
                    }));
                    break;

                default:
                    break;
            }

            //Sau khi xử lý trường hợp, tiếp tục lắng nghe
            Listen();
        }


        private void stmNewGame_Click(object sender, EventArgs e)
        {
            NewGame();

            if (board.PlayMode == 1)
            {
                try
                {
                    Socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
                }
                catch { }
            }

            pn_GameBoard.Enabled = true;
        }
    }
}
