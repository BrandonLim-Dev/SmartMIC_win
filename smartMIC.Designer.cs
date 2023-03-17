
namespace SmartMIC
{
    partial class smartMIC
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbMinutesStarttime = new System.Windows.Forms.TextBox();
            this.tbMinutesMeetingRoom = new System.Windows.Forms.TextBox();
            this.tbMinutesJoinedMem = new System.Windows.Forms.TextBox();
            this.tbMinutesTopic = new System.Windows.Forms.TextBox();
            this.tbMinutesName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbMicID = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbPortNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbMicName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMute = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시스템설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.버전정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시스템종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.stSecureWeb = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.stRealtimeConn = new System.Windows.Forms.Label();
            this.stSeverConn = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbMicList = new System.Windows.Forms.ComboBox();
            this.lbConversationList = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMinutesStarttime);
            this.groupBox1.Controls.Add(this.tbMinutesMeetingRoom);
            this.groupBox1.Controls.Add(this.tbMinutesJoinedMem);
            this.groupBox1.Controls.Add(this.tbMinutesTopic);
            this.groupBox1.Controls.Add(this.tbMinutesName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(205, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "회의 정보";
            // 
            // tbMinutesStarttime
            // 
            this.tbMinutesStarttime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMinutesStarttime.Location = new System.Drawing.Point(444, 46);
            this.tbMinutesStarttime.Name = "tbMinutesStarttime";
            this.tbMinutesStarttime.ReadOnly = true;
            this.tbMinutesStarttime.Size = new System.Drawing.Size(221, 21);
            this.tbMinutesStarttime.TabIndex = 9;
            // 
            // tbMinutesMeetingRoom
            // 
            this.tbMinutesMeetingRoom.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMinutesMeetingRoom.Location = new System.Drawing.Point(444, 20);
            this.tbMinutesMeetingRoom.Name = "tbMinutesMeetingRoom";
            this.tbMinutesMeetingRoom.ReadOnly = true;
            this.tbMinutesMeetingRoom.Size = new System.Drawing.Size(221, 21);
            this.tbMinutesMeetingRoom.TabIndex = 8;
            // 
            // tbMinutesJoinedMem
            // 
            this.tbMinutesJoinedMem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMinutesJoinedMem.Location = new System.Drawing.Point(66, 72);
            this.tbMinutesJoinedMem.Name = "tbMinutesJoinedMem";
            this.tbMinutesJoinedMem.ReadOnly = true;
            this.tbMinutesJoinedMem.Size = new System.Drawing.Size(599, 21);
            this.tbMinutesJoinedMem.TabIndex = 7;
            // 
            // tbMinutesTopic
            // 
            this.tbMinutesTopic.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMinutesTopic.Location = new System.Drawing.Point(66, 46);
            this.tbMinutesTopic.Name = "tbMinutesTopic";
            this.tbMinutesTopic.ReadOnly = true;
            this.tbMinutesTopic.Size = new System.Drawing.Size(308, 21);
            this.tbMinutesTopic.TabIndex = 6;
            // 
            // tbMinutesName
            // 
            this.tbMinutesName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMinutesName.Location = new System.Drawing.Point(66, 19);
            this.tbMinutesName.Name = "tbMinutesName";
            this.tbMinutesName.ReadOnly = true;
            this.tbMinutesName.Size = new System.Drawing.Size(308, 21);
            this.tbMinutesName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "참석인";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "회의 일시";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "안건";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "회의실";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "회의명";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbConversationList);
            this.groupBox2.Location = new System.Drawing.Point(205, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(675, 318);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "회의 내용";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbMicID);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tbPortNumber);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.tbIPAddress);
            this.groupBox3.Controls.Add(this.tbUserName);
            this.groupBox3.Controls.Add(this.tbMicName);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(12, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 157);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "마이크 정보";
            // 
            // tbMicID
            // 
            this.tbMicID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMicID.Location = new System.Drawing.Point(72, 126);
            this.tbMicID.Name = "tbMicID";
            this.tbMicID.ReadOnly = true;
            this.tbMicID.Size = new System.Drawing.Size(109, 21);
            this.tbMicID.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "단말 ID";
            // 
            // tbPortNumber
            // 
            this.tbPortNumber.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbPortNumber.Location = new System.Drawing.Point(72, 99);
            this.tbPortNumber.Name = "tbPortNumber";
            this.tbPortNumber.ReadOnly = true;
            this.tbPortNumber.Size = new System.Drawing.Size(109, 21);
            this.tbPortNumber.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "통신 포트";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbIPAddress.Location = new System.Drawing.Point(72, 72);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.ReadOnly = true;
            this.tbIPAddress.Size = new System.Drawing.Size(109, 21);
            this.tbIPAddress.TabIndex = 18;
            // 
            // tbUserName
            // 
            this.tbUserName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbUserName.Location = new System.Drawing.Point(72, 46);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.ReadOnly = true;
            this.tbUserName.Size = new System.Drawing.Size(109, 21);
            this.tbUserName.TabIndex = 17;
            // 
            // tbMicName
            // 
            this.tbMicName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMicName.Location = new System.Drawing.Point(72, 19);
            this.tbMicName.Name = "tbMicName";
            this.tbMicName.ReadOnly = true;
            this.tbMicName.Size = new System.Drawing.Size(109, 21);
            this.tbMicName.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "접속 주소";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "사용자 명";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "마이크 명";
            // 
            // btnMute
            // 
            this.btnMute.BackColor = System.Drawing.Color.Red;
            this.btnMute.Location = new System.Drawing.Point(12, 408);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(187, 49);
            this.btnMute.TabIndex = 3;
            this.btnMute.Text = "마이크 켜기";
            this.btnMute.UseVisualStyleBackColor = false;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설정ToolStripMenuItem,
            this.도움말ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(890, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.시스템설정ToolStripMenuItem,
            this.버전정보ToolStripMenuItem,
            this.시스템종료ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.설정ToolStripMenuItem.Text = "설정";
            // 
            // 시스템설정ToolStripMenuItem
            // 
            this.시스템설정ToolStripMenuItem.Name = "시스템설정ToolStripMenuItem";
            this.시스템설정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.시스템설정ToolStripMenuItem.Text = "시스템 설정";
            // 
            // 버전정보ToolStripMenuItem
            // 
            this.버전정보ToolStripMenuItem.Name = "버전정보ToolStripMenuItem";
            this.버전정보ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.버전정보ToolStripMenuItem.Text = "버전 정보";
            // 
            // 시스템종료ToolStripMenuItem
            // 
            this.시스템종료ToolStripMenuItem.Name = "시스템종료ToolStripMenuItem";
            this.시스템종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.시스템종료ToolStripMenuItem.Text = "시스템 종료";
            // 
            // 도움말ToolStripMenuItem
            // 
            this.도움말ToolStripMenuItem.Name = "도움말ToolStripMenuItem";
            this.도움말ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.도움말ToolStripMenuItem.Text = "도움말";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 347);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(187, 55);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.stSecureWeb);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.stRealtimeConn);
            this.groupBox4.Controls.Add(this.stSeverConn);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 250);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(187, 91);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "상태 표시";
            // 
            // stSecureWeb
            // 
            this.stSecureWeb.BackColor = System.Drawing.Color.Red;
            this.stSecureWeb.Location = new System.Drawing.Point(159, 67);
            this.stSecureWeb.Name = "stSecureWeb";
            this.stSecureWeb.Size = new System.Drawing.Size(11, 12);
            this.stSecureWeb.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 12);
            this.label15.TabIndex = 14;
            this.label15.Text = "보안 모드";
            // 
            // stRealtimeConn
            // 
            this.stRealtimeConn.BackColor = System.Drawing.Color.Red;
            this.stRealtimeConn.Location = new System.Drawing.Point(159, 43);
            this.stRealtimeConn.Name = "stRealtimeConn";
            this.stRealtimeConn.Size = new System.Drawing.Size(11, 12);
            this.stRealtimeConn.TabIndex = 13;
            // 
            // stSeverConn
            // 
            this.stSeverConn.BackColor = System.Drawing.Color.Red;
            this.stSeverConn.Location = new System.Drawing.Point(159, 19);
            this.stSeverConn.Name = "stSeverConn";
            this.stSeverConn.Size = new System.Drawing.Size(11, 12);
            this.stSeverConn.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "실시간 회의 연결 상태";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "서버 연결 상태";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbMicList);
            this.groupBox5.Location = new System.Drawing.Point(12, 196);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(187, 48);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "마이크 선택";
            // 
            // cbMicList
            // 
            this.cbMicList.FormattingEnabled = true;
            this.cbMicList.Location = new System.Drawing.Point(6, 17);
            this.cbMicList.Name = "cbMicList";
            this.cbMicList.Size = new System.Drawing.Size(175, 20);
            this.cbMicList.TabIndex = 0;
            // 
            // lbConversationList
            // 
            this.lbConversationList.FormattingEnabled = true;
            this.lbConversationList.ItemHeight = 12;
            this.lbConversationList.Location = new System.Drawing.Point(6, 17);
            this.lbConversationList.Name = "lbConversationList";
            this.lbConversationList.Size = new System.Drawing.Size(663, 292);
            this.lbConversationList.TabIndex = 0;
            // 
            // smartMIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 468);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "smartMIC";
            this.Text = "smartMIC - windows ver.";
            this.Load += new System.EventHandler(this.smartMIC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시스템설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 버전정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시스템종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말ToolStripMenuItem;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMinutesStarttime;
        private System.Windows.Forms.TextBox tbMinutesMeetingRoom;
        private System.Windows.Forms.TextBox tbMinutesJoinedMem;
        private System.Windows.Forms.TextBox tbMinutesTopic;
        private System.Windows.Forms.TextBox tbMinutesName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label stRealtimeConn;
        private System.Windows.Forms.Label stSeverConn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbMicList;
        private System.Windows.Forms.TextBox tbPortNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbMicName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label stSecureWeb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMicID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lbConversationList;
    }
}

