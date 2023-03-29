
namespace SmartMIC
{
    partial class micSetting
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSercureFlag = new System.Windows.Forms.ComboBox();
            this.tbIdentity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSamplerate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLogFlag = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "접속 주소";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(56, 215);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "적용";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(146, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(141, 10);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(120, 21);
            this.tbIPAddress.TabIndex = 4;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(141, 39);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(120, 21);
            this.tbPort.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "웹소켓 Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "웹소켓 Secure";
            // 
            // cbSercureFlag
            // 
            this.cbSercureFlag.FormattingEnabled = true;
            this.cbSercureFlag.Items.AddRange(new object[] {
            "예",
            "아니오"});
            this.cbSercureFlag.Location = new System.Drawing.Point(141, 71);
            this.cbSercureFlag.Name = "cbSercureFlag";
            this.cbSercureFlag.Size = new System.Drawing.Size(120, 20);
            this.cbSercureFlag.TabIndex = 8;
            // 
            // tbIdentity
            // 
            this.tbIdentity.Location = new System.Drawing.Point(141, 97);
            this.tbIdentity.Name = "tbIdentity";
            this.tbIdentity.Size = new System.Drawing.Size(120, 21);
            this.tbIdentity.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "단말 MAC 주소";
            // 
            // cbSamplerate
            // 
            this.cbSamplerate.FormattingEnabled = true;
            this.cbSamplerate.Items.AddRange(new object[] {
            "8000",
            "16000"});
            this.cbSamplerate.Location = new System.Drawing.Point(140, 128);
            this.cbSamplerate.Name = "cbSamplerate";
            this.cbSamplerate.Size = new System.Drawing.Size(120, 20);
            this.cbSamplerate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "음성 SampleRate";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(140, 182);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(120, 21);
            this.tbVersion.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "버전";
            // 
            // cbLogFlag
            // 
            this.cbLogFlag.FormattingEnabled = true;
            this.cbLogFlag.Items.AddRange(new object[] {
            "예",
            "아니오"});
            this.cbLogFlag.Location = new System.Drawing.Point(140, 156);
            this.cbLogFlag.Name = "cbLogFlag";
            this.cbLogFlag.Size = new System.Drawing.Size(120, 20);
            this.cbLogFlag.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "메시지 Logging";
            // 
            // micSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 247);
            this.Controls.Add(this.tbVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbLogFlag);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSamplerate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbIdentity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSercureFlag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Name = "micSetting";
            this.Text = "마이크 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.micSetting_FormClosing);
            this.Load += new System.EventHandler(this.micSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSercureFlag;
        private System.Windows.Forms.TextBox tbIdentity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSamplerate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLogFlag;
        private System.Windows.Forms.Label label7;
    }
}