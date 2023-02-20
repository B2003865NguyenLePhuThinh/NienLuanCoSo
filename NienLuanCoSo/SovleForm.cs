using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;


namespace NienLuanCoSo
{
    public partial class SovleForm : Form
    {
        private Color color;
        private int size, blocks;
        private Panel panelContainer;
        Board board;
        private SovleKenKen sovleKenKen;

        #region property
        public Color Color { get => color; set => color = value; }
        public int Blocks { get => blocks; set => blocks = value; }
        public int Size1 { get => size; set => size = value; }
        public Board Board { get => board; set => board = value; }
        public Panel PanelContainer { get => panelContainer; set => panelContainer = value; }

        public SovleKenKen SovleKenKen { get => sovleKenKen; set => sovleKenKen = value; }
        #endregion
        public SovleForm()
        {
            InitializeComponent();
            this.Color = new Color();
            this.Color = Color.Aqua;
            LoadForm();
        }

        public void LoadForm()
        {
            this.Size1 = Convert.ToInt32(this.numericUpDown1.Value);
            this.Blocks = Convert.ToInt32(this.numericUpDown2.Value);

            Board = new Board(this.panel1, this.Size1, this.Size1);
            CreateBlocks(this.Blocks);
            this.Board.Click += Board_Click;
        }

        private void Board_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = this.Color;
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
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            //pictureBox.BorderStyle = BorderStyle.Fixed3D;
            this.Color = pictureBox.BackColor;
        }
        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.BackColor = colorDialog.Color;
                this.Color = colorDialog.Color;
            }
        }
        #endregion
        /// <summary>
        /// Handling size of Kenken map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NumericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.Size1 != Convert.ToInt32(this.numericUpDown1.Value))
                {
                    this.Size1 = Convert.ToInt32(this.numericUpDown1.Value);
                    this.Board.clear(this.panel1);
                    this.Board.initBoard(this.panel1, this.size, this.size);
                }

            }

        }
        /// <summary>
        /// Creating blocks setting 
        /// </summary>
        /// <param name="n"></param>
        public void CreateBlocks(int n)
        {
      
            for (int i = 0; i < n; i++)
            {
                Panel panel = new Panel();
                panel.Size = new System.Drawing.Size(350, 27);
                // pictureBox1
                // 
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new System.Drawing.Point(0, 0);
                pictureBox1.Margin = new System.Windows.Forms.Padding(0);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(43, 27);
                pictureBox1.TabIndex = 0;
                pictureBox1.TabStop = false;
                pictureBox1.BackColor = Color.Aqua;
                pictureBox1.Click += PictureBox1_Click;
                pictureBox1.DoubleClick += PictureBox1_DoubleClick;
                // 
                ComboBox comboBox1 = new ComboBox();
                comboBox1.FormattingEnabled = true;
                comboBox1.Items.AddRange(new object[] {
                    "Cộng",
                    "Trừ ",
                    "Nhân",
                    "Chia",
                    "Không"});
                comboBox1.Location = new System.Drawing.Point(50, 0);
                comboBox1.Margin = new System.Windows.Forms.Padding(0);
                comboBox1.Name = "comboBox1";
                comboBox1.Size = new System.Drawing.Size(91, 27);
                comboBox1.TabIndex = 1;
                comboBox1.SelectedIndex = 0;
                // numericUpDown3
                // 
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                numericUpDown.Location = new System.Drawing.Point(147, 0);
                numericUpDown.Margin = new System.Windows.Forms.Padding(0);
                numericUpDown.Name = "numericUpDown";
                numericUpDown.Size = new System.Drawing.Size(76, 27);
                numericUpDown.TabIndex = 2;
                numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                numericUpDown.Maximum = new decimal(new int[] {
                    Int32.MaxValue,
                    0,
                    0,
                    0});
                // textBox1
                // 
                TextBox textBox1 = new TextBox();
                textBox1.Location = new System.Drawing.Point(228, 3);
                textBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox1.Margin = new System.Windows.Forms.Padding(0);
                textBox1.Name = "textBox1";
                textBox1.Size = new System.Drawing.Size(100, 27);
                textBox1.TabIndex = 3;
                textBox1.Text = "Block " + (i + 1).ToString();
                textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                textBox1.Multiline = true;
                textBox1.TextAlign = HorizontalAlignment.Center;
                textBox1.Enabled = false;
                textBox1.BackColor = SystemColors.Control;

                panel.Controls.Add(numericUpDown);
                panel.Controls.Add(pictureBox1);
                panel.Controls.Add(comboBox1);
                panel.Controls.Add(textBox1);

                this.flowLayoutPanel1.Controls.Add(panel);
            }
        }

        

        /// <summary>
        /// Handing how many blocks of Kenken map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NumericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.Blocks != Convert.ToInt32(this.numericUpDown2.Value))
                {
                    this.Blocks = Convert.ToInt32(this.numericUpDown2.Value);
                    this.flowLayoutPanel1.Controls.Clear();
                    CreateBlocks(this.Blocks);
                }

            }
        }
        public void SovleBtn_Click(object sender, System.EventArgs e)
        {
            //this.panel1.Enabled = false;
            int size = this.Size1;
            int[,] mapBlock = new int[size, size];
            int[] operators = new int[this.Blocks];
            int[] results = new int[this.Blocks];
            int len = this.flowLayoutPanel1.Controls.Count;
            int index1 = 0, index2 = 0;
            foreach(Panel panel in this.flowLayoutPanel1.Controls.OfType<Panel>())
            {
                NumericUpDown numericUpDown = new NumericUpDown();
                ComboBox comboBox = new ComboBox();
                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i].GetType() == numericUpDown.GetType())
                    {
                        numericUpDown = panel.Controls[i] as NumericUpDown;
                        results[index1++] = Convert.ToInt32(numericUpDown.Value);
                    }
                    if(panel.Controls[i].GetType() == comboBox.GetType())
                    {
                        comboBox = panel.Controls[i] as ComboBox;
                        operators[index2 ++] = Convert.ToInt32(comboBox.SelectedIndex); 
                    }
                }
            }

            InitMapBlock(mapBlock, size);
            MessageBox.Show("jgdfkjabf");
            this.SovleKenKen = new SovleKenKen(this.Size1, results, operators, mapBlock);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    this.Board.Buttons[i, j].Text = this.SovleKenKen.ResultMap[i,j].ToString();
                }



        }
        public void InitMapBlock(int[,] mapBlock, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    mapBlock[i, j] = -1;
                }
            int k = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (mapBlock[i, j] == -1)
                    {
                        ConvertMapBlocks(mapBlock, i, j, k, this.Board.Buttons[i, j].BackColor);
                        k++;
                    }
                }

            if (k == this.Blocks)
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        this.Board.Buttons[i, j].Text = mapBlock[i, j].ToString();
                    }
            }
            else
            {
                MessageBox.Show("Số lượng Block không đúng với khai báo", "Lỗi");
                this.panel1.Enabled = true;
            }
        }
        public void ConvertMapBlocks(int[,] mapBlock, int r, int c, int k, Color color)
        {
            if (mapBlock[r, c] != -1)
                return;
            mapBlock[r, c] = k;
            int[] row = new int[4] { -1, 0, 0,1 };
            int[] col = new int[4] {0, -1, 1, 0 };
            for (int i = 0; i < 4; i++)
            {
                int rr = r + row[i];
                int cc = c + col[i];
                if (rr >= 0 && cc >= 0 && rr < this.Size1 && cc < this.Size1 && this.Board.Buttons[rr, cc].BackColor == color)
                {
                    ConvertMapBlocks(mapBlock, rr, cc, k, color);
                }

            }
        }
    }
}
