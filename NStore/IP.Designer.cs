
namespace NStore
{
    partial class IP
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_nowIP = new System.Windows.Forms.Label();
            this.label_prevIP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.changetime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtn_autosync = new System.Windows.Forms.RadioButton();
            this.rbtn_autotime = new System.Windows.Forms.RadioButton();
            this.rbtn_manual = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_off = new System.Windows.Forms.Button();
            this.btn_on = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changetime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_nowIP);
            this.groupBox1.Controls.Add(this.label_prevIP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(321, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // label_nowIP
            // 
            this.label_nowIP.AutoSize = true;
            this.label_nowIP.Location = new System.Drawing.Point(68, 48);
            this.label_nowIP.Name = "label_nowIP";
            this.label_nowIP.Size = new System.Drawing.Size(58, 15);
            this.label_nowIP.TabIndex = 3;
            this.label_nowIP.Text = "127.0.0.1";
            // 
            // label_prevIP
            // 
            this.label_prevIP.AutoSize = true;
            this.label_prevIP.Location = new System.Drawing.Point(68, 26);
            this.label_prevIP.Name = "label_prevIP";
            this.label_prevIP.Size = new System.Drawing.Size(58, 15);
            this.label_prevIP.TabIndex = 2;
            this.label_prevIP.Text = "127.0.0.1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "현재 IP :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "이전 IP :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.changetime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rbtn_autosync);
            this.groupBox2.Controls.Add(this.rbtn_autotime);
            this.groupBox2.Controls.Add(this.rbtn_manual);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_off);
            this.groupBox2.Controls.Add(this.btn_on);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "NEW IP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(150, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "분 주기로 변경";
            // 
            // changetime
            // 
            this.changetime.Enabled = false;
            this.changetime.Location = new System.Drawing.Point(77, 66);
            this.changetime.Name = "changetime";
            this.changetime.Size = new System.Drawing.Size(72, 23);
            this.changetime.TabIndex = 8;
            this.changetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "시간설정 : ";
            // 
            // rbtn_autosync
            // 
            this.rbtn_autosync.AutoSize = true;
            this.rbtn_autosync.Location = new System.Drawing.Point(203, 45);
            this.rbtn_autosync.Name = "rbtn_autosync";
            this.rbtn_autosync.Size = new System.Drawing.Size(81, 19);
            this.rbtn_autosync.TabIndex = 6;
            this.rbtn_autosync.Text = "자동(연동)";
            this.rbtn_autosync.UseVisualStyleBackColor = true;
            this.rbtn_autosync.CheckedChanged += new System.EventHandler(this.rbtn_autosync_CheckedChanged);
            // 
            // rbtn_autotime
            // 
            this.rbtn_autotime.AutoSize = true;
            this.rbtn_autotime.Location = new System.Drawing.Point(124, 45);
            this.rbtn_autotime.Name = "rbtn_autotime";
            this.rbtn_autotime.Size = new System.Drawing.Size(81, 19);
            this.rbtn_autotime.TabIndex = 5;
            this.rbtn_autotime.Text = "자동(시간)";
            this.rbtn_autotime.UseVisualStyleBackColor = true;
            this.rbtn_autotime.CheckedChanged += new System.EventHandler(this.rbtn_autotime_CheckedChanged);
            // 
            // rbtn_manual
            // 
            this.rbtn_manual.AutoSize = true;
            this.rbtn_manual.Checked = true;
            this.rbtn_manual.Location = new System.Drawing.Point(77, 45);
            this.rbtn_manual.Name = "rbtn_manual";
            this.rbtn_manual.Size = new System.Drawing.Size(49, 19);
            this.rbtn_manual.TabIndex = 4;
            this.rbtn_manual.TabStop = true;
            this.rbtn_manual.Text = "수동";
            this.rbtn_manual.UseVisualStyleBackColor = true;
            this.rbtn_manual.CheckedChanged += new System.EventHandler(this.rbtn_manual_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "변경방식 : ";
            // 
            // btn_off
            // 
            this.btn_off.Enabled = false;
            this.btn_off.Location = new System.Drawing.Point(155, 15);
            this.btn_off.Name = "btn_off";
            this.btn_off.Size = new System.Drawing.Size(75, 23);
            this.btn_off.TabIndex = 2;
            this.btn_off.Text = "OFF";
            this.btn_off.UseVisualStyleBackColor = true;
            this.btn_off.Click += new System.EventHandler(this.btn_off_Click);
            // 
            // btn_on
            // 
            this.btn_on.Enabled = false;
            this.btn_on.Location = new System.Drawing.Point(74, 15);
            this.btn_on.Name = "btn_on";
            this.btn_on.Size = new System.Drawing.Size(75, 23);
            this.btn_on.TabIndex = 1;
            this.btn_on.Text = "ON";
            this.btn_on.UseVisualStyleBackColor = true;
            this.btn_on.Click += new System.EventHandler(this.btn_on_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ON/OFF : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.logBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(533, 185);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LOG";
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.Window;
            this.logBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.logBox.Location = new System.Drawing.Point(9, 23);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(518, 156);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // IP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 310);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "IP";
            this.Text = "IP";
            this.Load += new System.EventHandler(this.IP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changetime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_autosync;
        private System.Windows.Forms.RadioButton rbtn_autotime;
        private System.Windows.Forms.RadioButton rbtn_manual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_off;
        private System.Windows.Forms.Button btn_on;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown changetime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_nowIP;
        private System.Windows.Forms.Label label_prevIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button button1;
    }
}