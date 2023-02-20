using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NienLuanCoSo
{
    public partial class OptionNumberForm : Form
    {
        private int value;
        public OptionNumberForm(int size)
        {
            InitializeComponent();
            LoadForm(size);
        }

        public int Value { get => value; set => this.value = value; }

        public void LoadForm(int size)
        {
            for(int i = 0; i < size; i++)
            {
                Button ptb = new Button();
                ptb.Text = (i+1).ToString();
                ptb.Width = NumPnl.Width / size;
                ptb.Height = NumPnl.Height*6/10;
                ptb.ForeColor = Color.Black;
                ptb.Location = new System.Drawing.Point((NumPnl.Width / size) * i , 0);
                ptb.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ptb.Margin = new System.Windows.Forms.Padding(0);
                ptb.Padding = new System.Windows.Forms.Padding(0);
                ptb.Click += Ptb_Click; ;
                this.NumPnl.Controls.Add(ptb);
                
            }
        }

        private void Ptb_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Value = Convert.ToInt32(button.Text);
            this.Close();
        }

        
    }
}
