using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.WebSockets;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;
using ErrorEventArgs = WebSocketSharp.ErrorEventArgs;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        /// Network Global
        /// </summary>
        private WebSocket ws;
        public MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
        public MMDevice micDevice;

        private string macAddr;
        public string micVer, muteStatus;

        /// <summary>
        /// Form Class
        /// </summary>
        micSetting setting = new micSetting();

        #endregion


        public smartMIC()
        {
            InitializeComponent();
            setting.sysSettingGetEvent += new sysSettingGetEventHandler(this.Setting_Process);
        }

        #region Form Event
        /// <summary>
        /// 
        /// </summary>
        private void smartMIC_Load(object sender, EventArgs e)
        {
            SelectMICList();
            cbMicList.SelectedIndex = 0;
            GetMACAddress();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string jsonLoginReq = loginControl001();
            Console.WriteLine("[JSON] \n" + jsonLoginReq);
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
            setting.Show();
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
                this.Close();
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
        private void GetMACAddress()
        {
            macAddr = 
                (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                ).FirstOrDefault();

            Console.WriteLine("macAddr : " + macAddr);
            tbMicID.Text = macAddr;
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
                stSecureWeb.BackColor = Color.Lime;
            }
            else
            {
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
            //try
            //{
            //    ws = new WebSocketSharp.WebSocket();
            //    ws.OnMessage += WebSocket_OnMessage;
            //
            //    ws.OnOpen += (sender, e) =>
            //    {
            //
            //    };
            //
            //    ws.OnClose += (sender, e) =>
            //    {
            //
            //    };
            //
            //    ws.OnError += (sender, e) =>
            //    {
            //
            //    };
            //}
            //catch (Exception e)
            //{
            //
            //}
        }

        private void WebSocket_OnMessage(object sender, MessageEventArgs e)
        {

        }
        #endregion


        #region Timer
        #endregion

        #region Self Library
        private void AddErrorLog(String ErrMessage)
        {
            String strMsg = "---[ERROR]:" + ErrMessage;
            lbConversationList.Items.Add(strMsg);
        }

        private void AddTextResult(String Talker, String Text)
        {
            String strMsg = "[" + Talker + "] : " + Text;
            lbConversationList.Items.Add(strMsg);
        }
        private void AddMeetingEventLog(String Talker, String Message)
        {
            String strMsg = "------------------[" + Talker + "]" + Message + "------------------";
            lbConversationList.Items.Add(strMsg);
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
            string msgID = null;

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
