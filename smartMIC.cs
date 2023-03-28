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
            GetMACAddress();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

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

        }

        private void 시스템종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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


    }
}
