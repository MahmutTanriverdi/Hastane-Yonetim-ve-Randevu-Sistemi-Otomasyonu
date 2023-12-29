namespace WindowsFormsApp4
{
    partial class FrmAnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaForm));
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSekreterGirisi = new System.Windows.Forms.Button();
            this.btnDoktorGirisi = new System.Windows.Forms.Button();
            this.btnHastaGirisi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 22.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(602, 98);
            this.label4.TabIndex = 15;
            this.label4.Text = "SeaGreen Hospital";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(770, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 340);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(966, 701);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 39);
            this.label3.TabIndex = 13;
            this.label3.Text = "Sekreter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(584, 701);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 39);
            this.label2.TabIndex = 12;
            this.label2.Text = "Doktor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 701);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Hasta";
            // 
            // btnSekreterGirisi
            // 
            this.btnSekreterGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSekreterGirisi.BackgroundImage")));
            this.btnSekreterGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSekreterGirisi.Location = new System.Drawing.Point(881, 416);
            this.btnSekreterGirisi.Name = "btnSekreterGirisi";
            this.btnSekreterGirisi.Size = new System.Drawing.Size(319, 258);
            this.btnSekreterGirisi.TabIndex = 10;
            this.btnSekreterGirisi.UseVisualStyleBackColor = true;
            this.btnSekreterGirisi.Click += new System.EventHandler(this.btnSekreterGirisi_Click);
            // 
            // btnDoktorGirisi
            // 
            this.btnDoktorGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoktorGirisi.BackgroundImage")));
            this.btnDoktorGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoktorGirisi.Location = new System.Drawing.Point(474, 416);
            this.btnDoktorGirisi.Name = "btnDoktorGirisi";
            this.btnDoktorGirisi.Size = new System.Drawing.Size(319, 258);
            this.btnDoktorGirisi.TabIndex = 9;
            this.btnDoktorGirisi.UseVisualStyleBackColor = true;
            this.btnDoktorGirisi.Click += new System.EventHandler(this.btnDoktorGirisi_Click);
            // 
            // btnHastaGirisi
            // 
            this.btnHastaGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHastaGirisi.BackgroundImage")));
            this.btnHastaGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHastaGirisi.Location = new System.Drawing.Point(40, 416);
            this.btnHastaGirisi.Name = "btnHastaGirisi";
            this.btnHastaGirisi.Size = new System.Drawing.Size(306, 258);
            this.btnHastaGirisi.TabIndex = 8;
            this.btnHastaGirisi.UseVisualStyleBackColor = true;
            this.btnHastaGirisi.Click += new System.EventHandler(this.btnHastaGirisi_Click);
            // 
            // FrmAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1231, 785);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSekreterGirisi);
            this.Controls.Add(this.btnDoktorGirisi);
            this.Controls.Add(this.btnHastaGirisi);
            this.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FrmAnaForm";
            this.Text = "SeaGreen Hospital Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSekreterGirisi;
        private System.Windows.Forms.Button btnDoktorGirisi;
        private System.Windows.Forms.Button btnHastaGirisi;
    }
}