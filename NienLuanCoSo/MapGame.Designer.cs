namespace NienLuanCoSo
{
    partial class MapGame
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
            this.MapGamePnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.revealBtn = new System.Windows.Forms.Button();
            this.showGameBtn = new System.Windows.Forms.Button();
            this.checkGameBtn = new System.Windows.Forms.Button();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.CreateGameBtn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.KichThuoc = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // MapGamePnl
            // 
            this.MapGamePnl.Location = new System.Drawing.Point(415, 30);
            this.MapGamePnl.Margin = new System.Windows.Forms.Padding(0);
            this.MapGamePnl.Name = "MapGamePnl";
            this.MapGamePnl.Size = new System.Drawing.Size(750, 750);
            this.MapGamePnl.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.revealBtn);
            this.panel2.Controls.Add(this.showGameBtn);
            this.panel2.Controls.Add(this.checkGameBtn);
            this.panel2.Controls.Add(this.newGameBtn);
            this.panel2.Controls.Add(this.CreateGameBtn);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.KichThuoc);
            this.panel2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(20, 30);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 700);
            this.panel2.TabIndex = 4;
            // 
            // revealBtn
            // 
            this.revealBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.revealBtn.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.revealBtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.revealBtn.Location = new System.Drawing.Point(38, 345);
            this.revealBtn.Name = "revealBtn";
            this.revealBtn.Size = new System.Drawing.Size(240, 51);
            this.revealBtn.TabIndex = 17;
            this.revealBtn.Text = "Reveal";
            this.revealBtn.UseVisualStyleBackColor = false;
            this.revealBtn.Click += new System.EventHandler(this.revealBtn_Click);
            // 
            // showGameBtn
            // 
            this.showGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.showGameBtn.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.showGameBtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.showGameBtn.Location = new System.Drawing.Point(38, 182);
            this.showGameBtn.Name = "showGameBtn";
            this.showGameBtn.Size = new System.Drawing.Size(240, 51);
            this.showGameBtn.TabIndex = 16;
            this.showGameBtn.Text = "Sovle";
            this.showGameBtn.UseVisualStyleBackColor = false;
            this.showGameBtn.Click += new System.EventHandler(this.showGameBtn_Click);
            // 
            // checkGameBtn
            // 
            this.checkGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.checkGameBtn.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.checkGameBtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.checkGameBtn.Location = new System.Drawing.Point(38, 265);
            this.checkGameBtn.Name = "checkGameBtn";
            this.checkGameBtn.Size = new System.Drawing.Size(240, 51);
            this.checkGameBtn.TabIndex = 15;
            this.checkGameBtn.Text = "Check";
            this.checkGameBtn.UseVisualStyleBackColor = false;
            this.checkGameBtn.Click += new System.EventHandler(this.checkGameBtn_Click);
            // 
            // newGameBtn
            // 
            this.newGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.newGameBtn.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.newGameBtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.newGameBtn.Location = new System.Drawing.Point(38, 103);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(240, 51);
            this.newGameBtn.TabIndex = 10;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = false;
            this.newGameBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // CreateGameBtn
            // 
            this.CreateGameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CreateGameBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CreateGameBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CreateGameBtn.Font = new System.Drawing.Font("Arial Black", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateGameBtn.ForeColor = System.Drawing.Color.DarkBlue;
            this.CreateGameBtn.Location = new System.Drawing.Point(38, 459);
            this.CreateGameBtn.Name = "CreateGameBtn";
            this.CreateGameBtn.Size = new System.Drawing.Size(240, 65);
            this.CreateGameBtn.TabIndex = 9;
            this.CreateGameBtn.Text = "Play";
            this.CreateGameBtn.UseVisualStyleBackColor = false;
            this.CreateGameBtn.Click += new System.EventHandler(this.CreateGameBtn_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.numericUpDown1.Location = new System.Drawing.Point(38, 44);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(240, 36);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // KichThuoc
            // 
            this.KichThuoc.AutoSize = true;
            this.KichThuoc.BackColor = System.Drawing.SystemColors.Control;
            this.KichThuoc.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KichThuoc.Location = new System.Drawing.Point(34, 11);
            this.KichThuoc.Margin = new System.Windows.Forms.Padding(0);
            this.KichThuoc.Name = "KichThuoc";
            this.KichThuoc.Size = new System.Drawing.Size(152, 19);
            this.KichThuoc.TabIndex = 0;
            this.KichThuoc.Text = "Select Puzzle Size";
            // 
            // MapGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 806);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MapGamePnl);
            this.Name = "MapGame";
            this.Text = "MapGame";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

       



        #endregion
        private System.Windows.Forms.Panel MapGamePnl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button revealBtn;
        private System.Windows.Forms.Button showGameBtn;
        private System.Windows.Forms.Button checkGameBtn;
        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.Button CreateGameBtn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label KichThuoc;
    }
}