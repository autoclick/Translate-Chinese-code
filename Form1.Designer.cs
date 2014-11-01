namespace TranslateChineseByStep
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.nmFileIndex = new System.Windows.Forms.NumericUpDown();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtPatternFileLoad = new System.Windows.Forms.TextBox();
            this.lblCountFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richText_En = new System.Windows.Forms.RichTextBox();
            this.richText_Vi = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbChines = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSelectVi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectEN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelectCN = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFileIndex)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.nmFileIndex);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.txtPatternFileLoad);
            this.panel1.Controls.Add(this.lblCountFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 100);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(391, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Translate per word";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(538, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 37);
            this.button2.TabIndex = 11;
            this.button2.Text = "2b. Translate All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "files";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(538, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Primary language:";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(775, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 37);
            this.button3.TabIndex = 7;
            this.button3.Text = "3. Save All Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nmFileIndex
            // 
            this.nmFileIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmFileIndex.Location = new System.Drawing.Point(293, 13);
            this.nmFileIndex.Name = "nmFileIndex";
            this.nmFileIndex.Size = new System.Drawing.Size(58, 20);
            this.nmFileIndex.TabIndex = 6;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(360, 46);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(172, 37);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "2a. Next [Enter]";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtPatternFileLoad
            // 
            this.txtPatternFileLoad.Location = new System.Drawing.Point(13, 14);
            this.txtPatternFileLoad.Name = "txtPatternFileLoad";
            this.txtPatternFileLoad.Size = new System.Drawing.Size(162, 20);
            this.txtPatternFileLoad.TabIndex = 4;
            this.txtPatternFileLoad.Text = "*.html|*.js";
            // 
            // lblCountFile
            // 
            this.lblCountFile.AutoSize = true;
            this.lblCountFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountFile.Location = new System.Drawing.Point(357, 11);
            this.lblCountFile.Name = "lblCountFile";
            this.lblCountFile.Size = new System.Drawing.Size(44, 20);
            this.lblCountFile.TabIndex = 3;
            this.lblCountFile.Text = "/100";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 60);
            this.label1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(185, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "1. Select\r\n Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richText_En);
            this.panel2.Controls.Add(this.richText_Vi);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(855, 501);
            this.panel2.TabIndex = 2;
            // 
            // richText_En
            // 
            this.richText_En.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richText_En.Location = new System.Drawing.Point(421, 0);
            this.richText_En.Name = "richText_En";
            this.richText_En.Size = new System.Drawing.Size(434, 501);
            this.richText_En.TabIndex = 1;
            this.richText_En.Text = "";
            // 
            // richText_Vi
            // 
            this.richText_Vi.Dock = System.Windows.Forms.DockStyle.Left;
            this.richText_Vi.Location = new System.Drawing.Point(0, 0);
            this.richText_Vi.Name = "richText_Vi";
            this.richText_Vi.Size = new System.Drawing.Size(421, 501);
            this.richText_Vi.TabIndex = 0;
            this.richText_Vi.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.cbChines);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtSelectVi);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtSelectEN);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtSelectCN);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(861, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(314, 501);
            this.panel3.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(165, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Translate from English";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 199);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Translate from Chinese";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbChines
            // 
            this.cbChines.FormattingEnabled = true;
            this.cbChines.Location = new System.Drawing.Point(101, 105);
            this.cbChines.Name = "cbChines";
            this.cbChines.Size = new System.Drawing.Size(204, 21);
            this.cbChines.TabIndex = 8;
            this.cbChines.SelectedIndexChanged += new System.EventHandler(this.cbChines_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "English List:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Primary Value:";
            // 
            // txtSelectVi
            // 
            this.txtSelectVi.Location = new System.Drawing.Point(101, 154);
            this.txtSelectVi.Name = "txtSelectVi";
            this.txtSelectVi.Size = new System.Drawing.Size(204, 20);
            this.txtSelectVi.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "English Value:";
            // 
            // txtSelectEN
            // 
            this.txtSelectEN.Location = new System.Drawing.Point(101, 56);
            this.txtSelectEN.Name = "txtSelectEN";
            this.txtSelectEN.Size = new System.Drawing.Size(204, 20);
            this.txtSelectEN.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selected Value:";
            // 
            // txtSelectCN
            // 
            this.txtSelectCN.Location = new System.Drawing.Point(101, 9);
            this.txtSelectCN.Name = "txtSelectCN";
            this.txtSelectCN.Size = new System.Drawing.Size(204, 20);
            this.txtSelectCN.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(546, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Close app to STOP";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 601);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Translate Chinese - Powered by Google Translate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmFileIndex)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richText_Vi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPatternFileLoad;
        private System.Windows.Forms.Label lblCountFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.NumericUpDown nmFileIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSelectVi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelectEN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectCN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbChines;
        private System.Windows.Forms.RichTextBox richText_En;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label9;
    }
}

