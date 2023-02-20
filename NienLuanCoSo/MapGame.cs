using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NienLuanCoSo
{
    public partial class MapGame : Form
    {
        private int size;
        private Board board;
        private KenKenGame kenKenGame;
        List<Color> colorList = new List<Color>()
            {
                Color.AliceBlue,
                Color.AntiqueWhite,
                Color.Aqua,
                Color.Aquamarine,
                Color.CornflowerBlue,
                Color.GreenYellow,
                Color.LightGreen
            };
        #region Property
        public int Size { get => size; set => size = value; }
        public KenKenGame KenKenGame { get => kenKenGame; set => kenKenGame = value; }
        public Board Board { get => board; set => board = value; }

        #endregion
        public MapGame()
        {
            InitializeComponent();
            this.Size = Convert.ToInt32(this.numericUpDown1.Value);
        }
        public void LoadForm()
        {
            InitBoard();
        }

        public void InitBoard()
        {
            if (this.Board != null)
            {
                this.Board.clear(this.MapGamePnl);
                this.Board.initBoard(this.MapGamePnl, this.Size, this.Size);
            }
            else
            {
                this.Board = new Board(this.MapGamePnl, this.Size, this.Size);
                this.Board.Click += Board_Click;
            }
            this.KenKenGame = new KenKenGame(this.Size);
            SetOperatorLabel();
            SetColorBlock();
        }
        public bool IsTrueColor(Color color, int blockIndex)
        {
            int[] deltaX = { 0, -1, 0, 1 };
            int[] deltaY = { -1, 0, 0, 1 };
            List<Point> points = this.KenKenGame.BlocksList[blockIndex] as List<Point>;
            foreach (Point point in points)
            {
                int row = point.Y, col = point.X;
                for (int i = 0; i < 3; i++)
                {
                    if (row + deltaY[i] < 0 || row + deltaY[i] == this.Size || col + deltaX[i] < 0 || col + deltaX[i] == this.Size)
                        continue;
                    if (this.KenKenGame.MapBlock[row, col] != this.KenKenGame.MapBlock[row + deltaY[i], col + deltaX[i]]
                        && color == this.Board.Buttons[row + deltaY[i], col + deltaX[i]].BackColor)
                        return false;
                }
            }

            return true;
        }
        public void SetColorBlock()
        {

            Random rand = new Random();

            for (int i = 0; i < this.KenKenGame.BlocksList.Count; i++)
            {
                List<Point> pointList = this.KenKenGame.BlocksList[i] as List<Point>;
                Color color;
                do
                {
                    color = colorList[rand.Next(0, colorList.Count)];
                } while (!IsTrueColor(color, i));
                foreach (Point point in pointList)
                {
                    this.Board.Buttons[point.Y, point.X].BackColor = color;
                }
            }
        }

        public void SetOperatorLabel()
        {
            for (int i = 0; i < this.KenKenGame.BlocksList.Count; i++)
            {
                List<Point> point = this.KenKenGame.BlocksList[i] as List<Point>;
                Label label = new Label();
                label.AutoSize = true;
                label.BackColor = System.Drawing.SystemColors.Control;
                label.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label.Location = new System.Drawing.Point(5, 5);
                label.Margin = new System.Windows.Forms.Padding(0);
                int labelSize = Board.Buttons[0, 0].Height;
                label.Size = new System.Drawing.Size(20, labelSize / 4);
                label.TabIndex = 0;
                String temp = this.KenKenGame.Operators[i] == '!' ? "" : this.KenKenGame.Operators[i].ToString();
                label.Text = this.KenKenGame.Results[i].ToString() + " " + temp;
                this.Board.Buttons[point[0].Y, point[0].X].Controls.Add(label);

                //foreach (Point p in point)
                //{
                //    this.Board.Buttons[p.Y, p.X].Text = (i + 1).ToString();
                //}
            }
        }
        #region Event Handle
        public void NumericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.Size != Convert.ToInt32(this.numericUpDown1.Value))
                {
                    this.Size = Convert.ToInt32(this.numericUpDown1.Value);
                }

            }

        }
        private void Board_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            OptionNumberForm temp = new OptionNumberForm(this.Size);
            temp.ShowDialog();
            btn.Text = temp.Value.ToString();
        }




        #endregion

        private void CreateGameBtn_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            if (this.Board != null)
            {
                this.Board.clear(this.MapGamePnl);
                this.Board.initBoard(this.MapGamePnl, this.Size, this.Size);
                this.KenKenGame = new KenKenGame(this.Size);
                SetOperatorLabel();
                SetColorBlock();
            }
            else LoadForm();
        }

        private void showGameBtn_Click(object sender, EventArgs e)
        {

            if (this.Board != null)
            {
                for (int i = 0; i < this.Size; i++)
                {
                    for (int j = 0; j < this.Size; j++)
                    {
                        this.Board.Buttons[i, j].Text = this.KenKenGame.Map[i, j].ToString();

                    }

                }
            }



        }

        private void checkGameBtn_Click(object sender, EventArgs e)
        {
            if (this.Board != null)
            {
                int cnt = 0;
                for (int i = 0; i < this.Size; i++)
                {
                    for (int j = 0; j < this.Size; j++)
                    {
                        if (this.Board.Buttons[i, j].Text.Equals(this.KenKenGame.Map[i, j].ToString()))
                        {
                            this.Board.Buttons[i, j].ForeColor = Color.DarkBlue;
                            cnt++;
                        }

                    }
                    if(cnt == this.Size * this.Size)
                    {
                        MessageBox.Show("Chúc mừng bạn đã giải mã thành công câu đố", "Thông báo");
                        
                    }
                }
            }
        }

        private void revealBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
