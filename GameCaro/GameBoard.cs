using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameCaro
{
    internal class GameBoard
    {
        private Panel board;

        private int currentPlayer;
        private TextBox playerName;

        private List<Player> listPlayers;
        private List<List<Button>> matrixPositions;

        private event EventHandler<BtnClickEvent> playerClicked;
        private event EventHandler gameOver;

        private Stack<PlayInfo> stkUndoStep;
        private Stack<PlayInfo> stkRedoStep;

        private int playMode = 0;
        private bool IsAI = false;

        public Panel Board
        {
            get { return board; }
            set { board = value; }
        }

        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public List<Player> ListPlayers
        {
            get { return listPlayers; }
            set { listPlayers = value; }
        }

        public List<List<Button>> MatrixPositions
        {
            get { return matrixPositions; }
            set { matrixPositions = value; }
        }

        public event EventHandler<BtnClickEvent> PlayerClicked
        {
            add { playerClicked += value; }
            remove { playerClicked -= value; }
        }

        public event EventHandler GameOver
        {
            add { gameOver += value; }
            remove { gameOver -= value; }
        }

        public Stack<PlayInfo> StkUndoStep
        {
            get { return stkUndoStep; }
            set { stkUndoStep = value; }
        }

        public Stack<PlayInfo> StkRedoStep
        {
            get { return stkRedoStep; }
            set { stkRedoStep = value; }
        }

        public int PlayMode
        {
            get { return playMode; }
            set { playMode = value; }
        }

        public GameBoard(Panel board, TextBox PlayerName)
        {
            this.Board = board;
            this.PlayerName = PlayerName;

            this.CurrentPlayer = 0;
            this.ListPlayers = new List<Player>()
            {
                new Player("Player1",Image.FromFile(Application.StartupPath + "\\Resources\\X.png")),

                new Player("PLayer2", Image.FromFile(Application.StartupPath + "\\Resources\\O.png"))
            };
        }
   
        public void DrawGameBoard()
        {
            board.Enabled = true;
            board.Controls.Clear();

            StkUndoStep = new Stack<PlayInfo>();
            StkRedoStep = new Stack<PlayInfo>();

            this.CurrentPlayer = 0;
            ChangePlayer();

            int LocX, LocY;
            int nRows = InitValue.nRows;
            int nCols = InitValue.nCols;

            Button OldButton = new Button();
            OldButton.Width = OldButton.Height = 0;
            OldButton.Location = new Point(0, 0);

            MatrixPositions = new List<List<Button>>();

            for (int i = 0; i < nRows; i++)
            {
                MatrixPositions.Add(new List<Button>());

                for (int j = 0; j < nCols; j++)
                {
                    LocX = OldButton.Location.X + OldButton.Width;
                    LocY = OldButton.Location.Y;

                    Button btn = new Button()
                    {
                        Width = InitValue.CellWidth,
                        Height = InitValue.CellHeight,

                        Location = new Point(LocX, LocY),
                        Tag = i.ToString(), // Để xác định button đang ở hàng nào

                        BackColor = Color.Lavender,
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    btn.Click += btn_Click;
                    MatrixPositions[i].Add(btn);

                    Board.Controls.Add(btn);
                    OldButton = btn;
                }

                OldButton.Location = new Point(0, OldButton.Location.Y + InitValue.CellHeight);
                OldButton.Width = OldButton.Height = 0;
            }
        }
        private Point GetButtonCoordinate(Button btn)
        {
            int Vertical = Convert.ToInt32(btn.Tag);
            int Horizontal = MatrixPositions[Vertical].IndexOf(btn);

            Point Coordinate = new Point(Horizontal, Vertical);
            return Coordinate;
        }

        

        private bool CheckHorizontal(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow > InitValue.nCols - 5)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrCol == 0 || CurrCol + Count == InitValue.nCols)
                return true;

            if (MatrixPositions[CurrRow][CurrCol - 1].BackgroundImage == null || MatrixPositions[CurrRow][CurrCol + Count].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow][CurrCol + Count].BackColor = Color.Lime;
                return true;
            }

            return false;
        }

        private bool CheckVertical(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow > InitValue.nRows - 5)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrRow == 0 || CurrRow + Count == InitValue.nRows)
                return true;

            if (MatrixPositions[CurrRow - 1][CurrCol].BackgroundImage == null || MatrixPositions[CurrRow + Count][CurrCol].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow + Count][CurrCol].BackColor = Color.Lime;
                return true;
            }

            return false;
        }

        private bool CheckMainDiag(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow > InitValue.nRows - 5 || CurrCol > InitValue.nCols - 5)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrRow == 0 || CurrRow + Count == InitValue.nRows || CurrCol == 0 || CurrCol + Count == InitValue.nCols)
                return true;

            if (MatrixPositions[CurrRow - 1][CurrCol - 1].BackgroundImage == null || MatrixPositions[CurrRow + Count][CurrCol + Count].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow + Count][CurrCol + Count].BackColor = Color.Lime;
                return true;
            }

            return false;
        }

        private bool CheckExtraDiag(int CurrRow, int CurrCol, Image PlayerSymbol)
        {
            int NumCellsToWin = 5;
            int Count;

            if (CurrRow < NumCellsToWin - 1 || CurrCol > InitValue.nCols - NumCellsToWin)
                return false;

            for (Count = 1; Count < NumCellsToWin; Count++)
                if (MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage != PlayerSymbol)
                    return false;

            // Xét chặn 2 đầu
            if (CurrRow == 4 || CurrRow == InitValue.nRows - 1 || CurrRow == 0 || CurrRow + Count == InitValue.nRows)
                return true;

            if (MatrixPositions[CurrRow + 1][CurrCol - 1].BackgroundImage == null || MatrixPositions[CurrRow - Count][CurrCol + Count].BackgroundImage == null)
            {
                for (Count = 0; Count < NumCellsToWin; Count++)
                    MatrixPositions[CurrRow - Count][CurrCol + Count].BackColor = Color.Lime;
                return true;
            }

            return false;
        }

        private bool IsEndGame()
        {
            if (StkUndoStep.Count == InitValue.nRows * InitValue.nCols)
            {
                MessageBox.Show("Hòa cờ !!!");
                return true;
            }

            bool IsWin = false;

            foreach (PlayInfo btn in StkUndoStep)
            {
                if (CheckHorizontal(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;

                if (CheckVertical(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;

                if (CheckMainDiag(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;

                if (CheckExtraDiag(btn.Point.Y, btn.Point.X, btn.Symbol))
                    IsWin = true;
            }

            if (IsWin)
                return IsWin;
            return false;
        }

        public void EndGame()
        {
            if (gameOver != null)
                gameOver(this, new EventArgs());
        }

        private void ChangePlayer()
        {
            PlayerName.Text = ListPlayers[CurrentPlayer].Name;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return; // Nếu ô đã được đánh thì ko cho đánh lại

            btn.BackgroundImage = ListPlayers[CurrentPlayer].Symbol;

            StkUndoStep.Push(new PlayInfo(GetButtonCoordinate(btn), CurrentPlayer, btn.BackgroundImage));
            StkRedoStep.Clear();

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if (playerClicked != null)
                playerClicked(this, new BtnClickEvent(GetButtonCoordinate(btn)));

            if (IsEndGame())
                EndGame();


        }

        public void OtherPlayerClicked(Point point)
        {
            Button btn = MatrixPositions[point.Y][point.X];

            if (btn.BackgroundImage != null)
                return; // Nếu ô đã được đánh thì ko cho đánh lại

            btn.BackgroundImage = ListPlayers[CurrentPlayer].Symbol;

            StkUndoStep.Push(new PlayInfo(GetButtonCoordinate(btn), CurrentPlayer, btn.BackgroundImage));
            StkRedoStep.Clear();

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if (IsEndGame())
                EndGame();
        }


        

    }
}
