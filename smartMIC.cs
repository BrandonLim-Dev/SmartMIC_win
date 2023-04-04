using NAudio.CoreAudioApi;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using WebSocket = WebSocketSharp.WebSocket;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;

namespace SmartMIC
{
    /// <summary>
    /// Form delegate Area
    /// </summary>
    public delegate void sysSettingGetEventHandler(string ip, string port, string secureFlag, string id, string sampleRate, string logFlag, string version);

    public partial class smartMIC : Form
    {
        #region Global Variable
        /// <summary>
        /// Network Data
        /// </summary>
        private WebSocket ws;
        public MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
        public MMDevice micDevice;

        /// <summary>
        /// Inner Data
        /// </summary>
        private string macAddr;
        public string micVer, strSecFlag, strSamplerate, strLogFlag; 
        public static string muteStatus, wsURL, strMSG, msgID;
        public bool secFlag = false, logFlag = false;
        public int cntLoginReq = 0;

        /// <summary>
        /// Status Data
        /// </summary>
        public bool login_ing = false, logined = false;

        /// <summary>
        /// Form Class
        /// </summary>
        //micSetting setting;

        #endregion


        public smartMIC()
        {
            InitializeComponent();
            //setting.sysSettingGetEvent += new sysSettingGetEventHandler(this.Setting_Process);
        }

        #region Form Event
        /// <summary>
        /// 
        /// </summary>
        private void smartMIC_Load(object sender, EventArgs e)
        {
            ///<summary>
            /// set Default MIC Setting
            ///</summary>
            // 연결된 마이크 Loading 및 기본값 설정
            SelectMICList();
            if(cbMicList.Items.Count > 0)
                cbMicList.SelectedIndex = 0;
            // 기기 MAC Address 가져오기
            macAddr = GetMACAddress();
            // Websocket Data 통신 URL 생성
            //tbIPAddress.Text = "192.168.50.100";
            tbIPAddress.Text = "211.201.11.12";
            tbPortNumber.Text = "28083";
            if (secFlag)
            {
                wsURL = "wss://" + tbIPAddress.Text + ":" + tbPortNumber.Text + "/minutes";
                stSecureWeb.BackColor = Color.Lime;
                strSecFlag = "예";
            }
            else
            {
                wsURL = "ws://" + tbIPAddress.Text + ":" + tbPortNumber.Text + "/minutes";
                stSecureWeb.BackColor = Color.Red;
                strSecFlag = "아니오";
            }
            Console.WriteLine(wsURL);
            // Voice Samplerate
            strSamplerate = "8000";
            // Message Loging Flag
            strLogFlag = "아니오";
            // MIC Version
            micVer = "4.0.0";

            initWebsocket();
            ws.Connect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(login_ing == false && logined == false)
            {
                loginCtrlTimer.Enabled = true;
                login_ing = true;
                btnLogin.Text = "로그인 취소";
                AddMeetingEventLog("시스템", "로그인 요청");
            }
            else if(login_ing == true && logined == false)
            {
                loginCtrlTimer.Enabled = false;
                login_ing = false;
                btnLogin.Text = "로그인";
                AddMeetingEventLog("시스템", "로그인 취소");
            }
            else if(login_ing == false && logined == true)
            {
                logined = false;
                btnLogin.Text = "로그인";
                AddMeetingEventLog("시스템", "로그아웃");
            }
            else
            {

            }
        }

        private void btnMute_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// menu form Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 시스템설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login_ing == true || logined == true)
            {
                if (MessageBox.Show("현재 마이크 로그인 시도 또는 로그인 중으로 마이크 설정을 변경할 수 없습니다.", "알림",
               MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    // Nothing To Do
                }
            }
            else
            {
                micSetting setting = new micSetting(tbIPAddress.Text, tbPortNumber.Text, strSecFlag, macAddr, strSamplerate, strLogFlag, micVer);
                setting.Owner = this;
                setting.Show();
            }
        }

        private void 버전정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            micInfo micInfo = new micInfo(micVer);
            micInfo.Owner = this;
            micInfo.Show();
        }

        private void 시스템종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("smartMIC를 종료하시겠습니까?", "프로그램 종료",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Yes)
            {
                if(login_ing == true || logined == true)
                {
                    if (MessageBox.Show("현재 마이크 로그인 중으로 종료할 수 없습니다.", "알림",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        // Nothing To Do
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void smartMIC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (login_ing == true || logined == true)
            {
                if (MessageBox.Show("현재 마이크 로그인 중으로 종료할 수 없습니다.", "알림",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                {
                    // Cancel Closing
                    e.Cancel = true;
                }
            }
            else
            {
                // Nothing To Do
            }
        }
        #endregion


        #region Inner Function
        /// <summary>
        /// 
        /// </summary>
        private void SelectMICList()
        {
            try
            {
                MMDeviceCollection devices = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
                foreach (var device in devices)
                {
                    cbMicList.Items.Add(device.FriendlyName);
                }
            }
            catch (Exception e)
            {
                AddErrorLog(e.ToString());
            }
        }

        ///<summary>
        ///
        /// </summary>
        private string GetMACAddress()
        {
            macAddr = 
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();

            Console.WriteLine("macAddr : " + macAddr);
            tbMicID.Text = macAddr;
            return macAddr;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Setting_Process(string ip, string port, string secureFlag, string id, string sampleRate, string logFlag, string version)
        {
            Console.WriteLine("시스템 설정 ---------------------------");
            Console.WriteLine("△ 접속 주소 : " + ip);
            Console.WriteLine("△ 웹소켓 Port : " + port);
            Console.WriteLine("△ 웹소켓 Secure : " + secureFlag);
            Console.WriteLine("△ 단말 MAC 주소 : " + id);
            Console.WriteLine("△ 음성 SampleRate : " + sampleRate);
            Console.WriteLine("△ 메시지 Logging : " + logFlag);
            Console.WriteLine("△ 버전 : " + version);
            Console.WriteLine("---------------------------------------");

            tbIPAddress.Text = ip;
            tbPortNumber.Text = port;
            tbMicID.Text = id;
            if(secureFlag.Equals("예"))
            {
                secFlag = true;
                wsURL = "wss://" + tbIPAddress.Text + ":" + tbPortNumber.Text + "/minutes";
                stSecureWeb.BackColor = Color.Lime;
            }
            else
            {
                secFlag = false;
                wsURL = "ws://" + tbIPAddress.Text + ":" + tbPortNumber.Text + "/minutes";
                stSecureWeb.BackColor = Color.Red;
            }
            micVer = version;
        }
        #endregion


        #region Network
        /// <summary>
        /// Network for Data Communication between smartMIC and Server/Web
        /// using] Websocket (TCP/IP) for sending & receiving voice/data
        /// </summary>
        private void initWebsocket()
        {         
            try
            {
                //ws = new WebSocketSharp.WebSocket(wsURL);
                ws = new WebSocketSharp.WebSocket("ws://211.201.11.12:28083/minutes");

                Console.WriteLine("ReadyState = " + ws.ReadyState.ToString());
            
                ws.OnOpen += (sender, e) =>
                {
                    Console.WriteLine("[Websocket] OnOpen():: ");
                    Console.WriteLine("ReadyState = " + ws.ReadyState.ToString());

                };
            
                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("[Websocket] OnClose():: ");
                    loginCtrlTimer.Enabled = false;
                };
                ws.OnMessage += (sender, e) =>
                {
                    //cntLoginReq = 0;
                    strMSG = e.Data.ToString();
                    msgID = getMsgID(strMSG);
                    Console.WriteLine("[Websocket] OnMessage():: msgID : " + msgID);

                    switch (msgID)
                    {
                        case "RES_MIC_LOGIN":
                            break;

                        case "ERR_MIC_LOGIN":
                            loginControl003(strMSG);
                            break;

                        default:
                            break;
                    }
                };

                ws.OnError += (sender, e) =>
                {
                    Console.WriteLine("[Websocket] OnError():: ");
                };
            }
            catch (Exception e)
            {
                Console.WriteLine("[Websocket] Exception :: " + e.ToString());
            }
        }
        #endregion


        #region Timer
        private void loginCtrlTimer_Tick(object sender, EventArgs e)
        {
            string jsonLoginReq = loginControl001();
            Console.WriteLine("[JSON] \n" + jsonLoginReq);
            ws.Send(jsonLoginReq);
            cntLoginReq++;
            //Console.WriteLine("cntLoginReq : " + cntLoginReq);
            //if(cntLoginReq == 3)
            //{
            //    loginCtrlTimer.Enabled = false;
            //}
        }
        #endregion

        #region Self Library
        private void AddErrorLog(String ErrMessage)
        {
            String strMsg = "--- [ERROR]:" + ErrMessage;
            lbConversationList.Items.Add(strMsg);
        }

        private void AddTextResult(String Talker, String Text)
        {
            String strMsg = "[" + Talker + "] : " + Text;
            lbConversationList.Items.Add(strMsg);
        }
        private void AddMeetingEventLog(String Talker, String Message)
        {
            String strMsg = "------------------ [ " + Talker + " ] " + Message + "------------------";
            //lbConversationList.Items.Add(strMsg);
            lbConversationList.Invoke(new MethodInvoker(delegate { lbConversationList.Items.Add(strMsg); }));
        }

        #endregion

        #region JSON for Interface
        ///<summary>
        /// for Common Parse [ msg_header ]
        ///  > input : json string
        ///  > return : string
        ///</summary>
        private string getMsgID(string jsonString)
        {
            string msgID;

            JObject jObject = JObject.Parse(jsonString);
            msgID = jObject["msg_header"]["msg_id"].ToString();

            return msgID;
        }

        ///<summary>
        /// LOGINCONTROL-001 > 마이크 로그인 요청 메시지 (Send)
        ///  > input : N/A
        ///  > return : json string
        ///</summary>
        private string loginControl001()
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "REQ_MIC_LOGIN")
                );
            JObject msg_body = new JObject(
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("MIC_NAME", null),
                    new JProperty("CHARACTER", null),
                    new JProperty("VERSION", micVer)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// LOGINCONTROL-002 > 마이크 로그인 응답 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string loginControl002(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// LOGINCONTROL-003 > 마이크 로그인 에러 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string loginControl003(string jsonString)
        {
            string errCode, errMsg;

            JObject jObject = JObject.Parse(jsonString);
            
            errCode = jObject["msg_body"]["ERROR_CODE"].ToString();
            errMsg = jObject["msg_body"]["ERROR_REASON"].ToString();
            Console.WriteLine("loginControl003() :: " + errMsg + "(" + errCode + ")");
            if(errCode.Equals("1001"))
            {
                AddMeetingEventLog("시스템", "로그인 실패 - APP 버전 불일치");
            }

            return null;
        }

        ///<summary>
        /// LOGINCONTROL-004 > 마이크 HB 요청 메시지 (Send)
        ///  > input : N/A
        ///  > return : json string
        ///</summary>
        private string loginControl004()
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "REQ_HB")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("IP", tbIPAddress.Text),
                    new JProperty("PORT", tbPortNumber.Text),
                    new JProperty("MINUTES_JOINED_CNT", "")
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// LOGINCONTROL-005 > 마이크 HB 응답 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string loginControl005(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MINUTES-001 > 실시간 회의 시작 알림 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string minutes001(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MINUTES-002 > 실시간 회의 변환 텍스트 전송 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string minutes002(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MINUTES-003 > 실시간 회의 종료 알림 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string minutes003(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MINUTES-004 > 실시간 회의 Text 수정 전송 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string minutes004(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MINUTES-005 > 실시간 회의 마이크 추가/삭제 알림 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string minutes005(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MICCONTROL-001 > 실시간 회의 마이크 Mute 조작 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string micControl001(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MICCONTROL-001 > 실시간 회의 마이크 Mute 변경 알림 메시지 (Send)
        ///  > input : string
        ///  > return : json string
        ///</summary>
        private string micControl002(string status)
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "MIC_EVENT")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("TYPE", status),
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("CONTAINER", null)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// MICCONTROL-003 > 실시간 회의 마이크 상태 확인 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string micControl003(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MICCONTROL-004 > 실시간 회의 마이크 상태 전달 (Send)
        ///  > input : string
        ///  > return : json string
        ///</summary>
        private string micControl004(string status)
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "MIC_STATUS_RES")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("TYPE", "MUTE_STATUS"),
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("MUTE_STATUS", status),
                    new JProperty("CONTAINER", null)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// MICCONTROL-005 > 실시간 회의 마이크 상태 전달 (Send)
        ///  > input : N/A
        ///  > return : json string
        ///</summary>
        private string micControl005()
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "MIC_EVENT")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("TYPE", "#MIC_ATTACH#"),
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("CONTAINER", null)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// MICCONTROL-006 > 실시간 회의 마이크 상태 전달 (Send)
        ///  > input : N/A
        ///  > return : json string
        ///</summary>
        private string micControl006()
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "MIC_EVENT")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("TYPE", "#MIC_DETACH#"),
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("CONTAINER", null)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// MICCONTROL-007 > 
        ///  > input : 
        ///  > return : 
        ///</summary>

        ///<summary>
        /// MICCONTROL-008 > 
        ///  > input : 
        ///  > return : 
        ///</summary>

        ///<summary>
        /// MICCONTROL-009 > 실시간 회의 마이크 연동 수신 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string micControl009(string jsonString)
        {
            return null;
        }


        ///<summary>
        /// MICCONTROL-010 > 실시간 회의 마이크 연동 알림 메시지 (Send)
        ///  > input : N/A
        ///  > return : json string
        ///</summary>
        private string micControl010()
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "MIC_STATUS_RES")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("TYPE", "#REALTIME_HB#"),
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("CONTAINER", null)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        ///<summary>
        /// MICCONTROL-011 > 실시간 회의 마이크 추가/삭제 알림 메시지 (Receive)
        ///  > input : json string
        ///  > return : parsed data object
        ///</summary>
        private string micControl011(string jsonString)
        {
            return null;
        }

        ///<summary>
        /// MICCONTROL-012 > 실시간 회의 마이크 화면 표시 상태 전송
        ///  > input : 
        ///  > return : 
        ///</summary>

        ///<summary>
        /// SESSION_INIT-001 > 실시간 회의 세션 초기화 메시지 (Send)
        ///  > input : N/A
        ///  > return : json string
        ///</summary>
        private string sessionInit001()
        {
            JObject msg_header = new JObject(
                    new JProperty("msg_id", "SESSION_INIT")
                );
            JObject msg_body = new JObject(
                    new JProperty("CALL_ID", ""),
                    new JProperty("TYPE", "Mic"),
                    new JProperty("MIC_ID", tbMicID.Text),
                    new JProperty("TMP_MIC_NAME", ""),
                    new JProperty("MIC_IP", tbIPAddress.Text),
                    new JProperty("MIC_PORT", tbPortNumber)
                );

            JObject jsonMsg = new JObject(
                    new JProperty("msg_header", msg_header),
                    new JProperty("msg_body", msg_body)
                );

            return jsonMsg.ToString();
        }

        #endregion

    }
}
