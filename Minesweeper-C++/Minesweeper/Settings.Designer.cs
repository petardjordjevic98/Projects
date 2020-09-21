namespace Minesweeper
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numdim = new System.Windows.Forms.NumericUpDown();
            this.nummin = new System.Windows.Forms.NumericUpDown();
            this.btnok = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numdim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nummin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dimenzija polja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Broj mina";
            // 
            // numdim
            // 
            this.numdim.Location = new System.Drawing.Point(266, 21);
            this.numdim.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numdim.Name = "numdim";
            this.numdim.Size = new System.Drawing.Size(270, 20);
            this.numdim.TabIndex = 2;
            this.numdim.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // nummin
            // 
            this.nummin.Location = new System.Drawing.Point(266, 193);
            this.nummin.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nummin.Name = "nummin";
            this.nummin.Size = new System.Drawing.Size(270, 20);
            this.nummin.TabIndex = 3;
            this.nummin.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(98, 230);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(231, 70);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "U redu";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 70);
            this.button1.TabIndex = 5;
            this.button1.Text = "Otkazi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.nummin);
            this.Controls.Add(this.numdim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numdim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nummin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numdim;
        private System.Windows.Forms.NumericUpDown nummin;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button button1;
    }
}