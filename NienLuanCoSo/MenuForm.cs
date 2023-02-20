using System;
using System.Media;
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
    public partial class MenuForm : Form
    {
        public SoundPlayer BackgroundMucsic; 
        public MenuForm()
        {
            InitializeComponent();
            this.BackgroundMucsic = new SoundPlayer();
            this.BackgroundMucsic.SoundLocation = "music.wav";
            this.BackgroundMucsic.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new MapGame();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new SovleForm();
            form.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
