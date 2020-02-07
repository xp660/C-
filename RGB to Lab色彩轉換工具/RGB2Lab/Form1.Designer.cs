namespace RGB2Lab
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPick = new System.Windows.Forms.Button();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.clrPicker = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.txtL = new System.Windows.Forms.TextBox();
            this.txta = new System.Windows.Forms.TextBox();
            this.txtb = new System.Windows.Forms.TextBox();
            this.txtHex = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(181, 99);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 0;
            this.btnPick.Text = "button1";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // picColor
            // 
            this.picColor.Location = new System.Drawing.Point(156, 147);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(345, 50);
            this.picColor.TabIndex = 1;
            this.picColor.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(117, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hex Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "L";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "a";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "b";
            // 
            // numericUpDownR
            // 
            this.numericUpDownR.Location = new System.Drawing.Point(166, 295);
            this.numericUpDownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownR.Name = "numericUpDownR";
            this.numericUpDownR.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownR.TabIndex = 9;
            this.numericUpDownR.ValueChanged += new System.EventHandler(this.numericUpDownR_ValueChanged);
            // 
            // numericUpDownG
            // 
            this.numericUpDownG.Location = new System.Drawing.Point(166, 331);
            this.numericUpDownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownG.Name = "numericUpDownG";
            this.numericUpDownG.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownG.TabIndex = 10;
            this.numericUpDownG.ValueChanged += new System.EventHandler(this.numericUpDownG_ValueChanged);
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.Location = new System.Drawing.Point(166, 364);
            this.numericUpDownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownB.TabIndex = 11;
            this.numericUpDownB.ValueChanged += new System.EventHandler(this.numericUpDownB_ValueChanged);
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(365, 287);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(100, 22);
            this.txtL.TabIndex = 12;
            // 
            // txta
            // 
            this.txta.Location = new System.Drawing.Point(365, 321);
            this.txta.Name = "txta";
            this.txta.Size = new System.Drawing.Size(100, 22);
            this.txta.TabIndex = 13;
            // 
            // txtb
            // 
            this.txtb.Location = new System.Drawing.Point(365, 364);
            this.txtb.Name = "txtb";
            this.txtb.Size = new System.Drawing.Size(100, 22);
            this.txtb.TabIndex = 14;
            // 
            // txtHex
            // 
            this.txtHex.Location = new System.Drawing.Point(293, 245);
            this.txtHex.Name = "txtHex";
            this.txtHex.Size = new System.Drawing.Size(100, 22);
            this.txtHex.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtHex);
            this.Controls.Add(this.txtb);
            this.Controls.Add(this.txta);
            this.Controls.Add(this.txtL);
            this.Controls.Add(this.numericUpDownB);
            this.Controls.Add(this.numericUpDownG);
            this.Controls.Add(this.numericUpDownR);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.btnPick);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.ColorDialog clrPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownR;
        private System.Windows.Forms.NumericUpDown numericUpDownG;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.TextBox txta;
        private System.Windows.Forms.TextBox txtb;
        private System.Windows.Forms.TextBox txtHex;
    }
}

