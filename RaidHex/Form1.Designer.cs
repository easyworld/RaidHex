namespace RaidHex
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.denIdComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WriteDataButton = new System.Windows.Forms.Button();
            this.ReadDataButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.starDisplayComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flagsTextBox = new System.Windows.Forms.TextBox();
            this.randRollTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.seedTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(53, 10);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(114, 21);
            this.ipTextBox.TabIndex = 1;
            this.ipTextBox.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(53, 37);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(45, 21);
            this.portTextBox.TabIndex = 3;
            this.portTextBox.Text = "6000";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(104, 35);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(63, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.denIdComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WriteDataButton);
            this.groupBox1.Controls.Add(this.ReadDataButton);
            this.groupBox1.Location = new System.Drawing.Point(14, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raid Editor";
            // 
            // denIdComboBox
            // 
            this.denIdComboBox.FormattingEnabled = true;
            this.denIdComboBox.Location = new System.Drawing.Point(39, 78);
            this.denIdComboBox.Name = "denIdComboBox";
            this.denIdComboBox.Size = new System.Drawing.Size(107, 20);
            this.denIdComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Raid";
            // 
            // WriteDataButton
            // 
            this.WriteDataButton.Location = new System.Drawing.Point(7, 49);
            this.WriteDataButton.Name = "WriteDataButton";
            this.WriteDataButton.Size = new System.Drawing.Size(140, 23);
            this.WriteDataButton.TabIndex = 1;
            this.WriteDataButton.Text = "Write to Raid";
            this.WriteDataButton.UseVisualStyleBackColor = true;
            this.WriteDataButton.Click += new System.EventHandler(this.WriteDataButton_Click);
            // 
            // ReadDataButton
            // 
            this.ReadDataButton.Location = new System.Drawing.Point(6, 20);
            this.ReadDataButton.Name = "ReadDataButton";
            this.ReadDataButton.Size = new System.Drawing.Size(141, 22);
            this.ReadDataButton.TabIndex = 0;
            this.ReadDataButton.Text = "Read from Raid";
            this.ReadDataButton.UseVisualStyleBackColor = true;
            this.ReadDataButton.Click += new System.EventHandler(this.ReadDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.typeComboBox);
            this.groupBox2.Controls.Add(this.starDisplayComboBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.flagsTextBox);
            this.groupBox2.Controls.Add(this.randRollTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.seedTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(173, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 168);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editor";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(62, 100);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(112, 20);
            this.typeComboBox.TabIndex = 22;
            // 
            // starDisplayComboBox
            // 
            this.starDisplayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.starDisplayComboBox.FormattingEnabled = true;
            this.starDisplayComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.starDisplayComboBox.Location = new System.Drawing.Point(62, 46);
            this.starDisplayComboBox.Name = "starDisplayComboBox";
            this.starDisplayComboBox.Size = new System.Drawing.Size(112, 20);
            this.starDisplayComboBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "Flags";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "DenType";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "RandRoll";
            // 
            // flagsTextBox
            // 
            this.flagsTextBox.Location = new System.Drawing.Point(62, 126);
            this.flagsTextBox.Name = "flagsTextBox";
            this.flagsTextBox.Size = new System.Drawing.Size(112, 21);
            this.flagsTextBox.TabIndex = 6;
            // 
            // randRollTextBox
            // 
            this.randRollTextBox.Location = new System.Drawing.Point(62, 72);
            this.randRollTextBox.Name = "randRollTextBox";
            this.randRollTextBox.Size = new System.Drawing.Size(112, 21);
            this.randRollTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Stars";
            // 
            // seedTextBox
            // 
            this.seedTextBox.Location = new System.Drawing.Point(62, 18);
            this.seedTextBox.Name = "seedTextBox";
            this.seedTextBox.Size = new System.Drawing.Size(112, 21);
            this.seedTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Seed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 190);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "RaidHexFor1.3.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WriteDataButton;
        private System.Windows.Forms.Button ReadDataButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox flagsTextBox;
        private System.Windows.Forms.TextBox randRollTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox seedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox denIdComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox starDisplayComboBox;
    }
}

