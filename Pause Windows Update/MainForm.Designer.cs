namespace Pause_Windows_Update
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            NumericUpDown_Day = new NumericUpDown();
            label2 = new Label();
            Label_Day = new Label();
            Button_Apply = new Button();
            groupBox1 = new GroupBox();
            Button_Cancel = new Button();
            Button_About = new Button();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown_Day).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 5);
            label1.Margin = new Padding(3, 5, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 0;
            label1.Text = "自定义暂停：";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(NumericUpDown_Day);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(Label_Day);
            flowLayoutPanel1.Location = new Point(8, 26);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(300, 68);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // NumericUpDown_Day
            // 
            NumericUpDown_Day.Location = new Point(86, 3);
            NumericUpDown_Day.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            NumericUpDown_Day.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown_Day.Name = "NumericUpDown_Day";
            NumericUpDown_Day.Size = new Size(120, 23);
            NumericUpDown_Day.TabIndex = 1;
            NumericUpDown_Day.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown_Day.ValueChanged += NumericUpDown_Week_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 5);
            label2.Margin = new Padding(0, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 17);
            label2.TabIndex = 2;
            label2.Text = "天";
            // 
            // Label_Day
            // 
            Label_Day.AutoSize = true;
            Label_Day.ForeColor = Color.Gray;
            Label_Day.Location = new Point(3, 34);
            Label_Day.Margin = new Padding(3, 5, 0, 0);
            Label_Day.Name = "Label_Day";
            Label_Day.Size = new Size(80, 17);
            Label_Day.TabIndex = 4;
            Label_Day.Text = "预计禁用至：";
            // 
            // Button_Apply
            // 
            Button_Apply.FlatStyle = FlatStyle.System;
            Button_Apply.Location = new Point(11, 112);
            Button_Apply.Name = "Button_Apply";
            Button_Apply.Size = new Size(168, 36);
            Button_Apply.TabIndex = 2;
            Button_Apply.Text = "应用暂停";
            Button_Apply.UseVisualStyleBackColor = true;
            Button_Apply.Click += Button_Apply_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flowLayoutPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(330, 94);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "适用于 Win10/11 ：自定义暂停天数";
            // 
            // Button_Cancel
            // 
            Button_Cancel.FlatStyle = FlatStyle.System;
            Button_Cancel.Location = new Point(185, 112);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new Size(86, 36);
            Button_Cancel.TabIndex = 4;
            Button_Cancel.Text = "取消暂停";
            Button_Cancel.UseVisualStyleBackColor = true;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // Button_About
            // 
            Button_About.FlatStyle = FlatStyle.System;
            Button_About.Location = new Point(277, 112);
            Button_About.Name = "Button_About";
            Button_About.Size = new Size(66, 36);
            Button_About.TabIndex = 5;
            Button_About.Text = "关于";
            Button_About.UseVisualStyleBackColor = true;
            Button_About.Click += Button_About_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 160);
            Controls.Add(Button_About);
            Controls.Add(Button_Cancel);
            Controls.Add(groupBox1);
            Controls.Add(Button_Apply);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += MainForm_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown_Day).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private NumericUpDown NumericUpDown_Day;
        private Label label2;
        private Button Button_Apply;
        private GroupBox groupBox1;
        private Label Label_Day;
        private Button Button_Cancel;
        private Button Button_About;
    }
}
