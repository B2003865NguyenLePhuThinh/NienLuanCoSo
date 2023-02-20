using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NienLuanCoSo
{
    public class Board
    {
        #region field
        private Button[,] buttons;

        public Button[,] Buttons { get => buttons; set => buttons = value; }
        #endregion

        public Board(Panel pnl, int col, int row)
        {
            initBoard(pnl,col, row);
        }
        public void initBoard(Panel pnl, int col, int row)
        {
            buttons = new Button[row, col];
            for (int y = 0; y < row; y++)
            {
                for (int x = 0; x < col; x++)
                {
                    Button ptb = new Button();
                    ptb.Width = pnl.Width / col;
                    ptb.Height = pnl.Height / row;
                    ptb.ForeColor = Color.Black;
                    ptb.Text = "";
                    ptb.Location = new System.Drawing.Point((pnl.Width / col) * x, (pnl.Height / row) * y);
                    ptb.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ptb.Margin = new System.Windows.Forms.Padding(0);
                    ptb.Padding = new System.Windows.Forms.Padding(0);
                    ptb.Click += Ptb_Click;
                    pnl.Controls.Add(ptb);
                    Buttons[y, x] = ptb;
                }
            }
        }
        public void clear(Panel pnl)
        {
            pnl.Controls.Clear();
        }
        #region click event
        private event EventHandler click;
        public event EventHandler Click
        {
            add
            {
                click += value;
            }
            remove
            {
                click -= value;
            }
        }
        public void On_Click(object sender)
        {
            if (click != null)
                click(sender, new EventArgs());
        }
        private void Ptb_Click(object sender, EventArgs e)
        {
            On_Click(sender);
        }
        #endregion
    }
}
