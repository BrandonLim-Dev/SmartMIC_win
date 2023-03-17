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


namespace SmartMIC
{
    public partial class smartMIC : Form
    {
        #region Global Variable
        private WebSocket ws;
        public MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
        public MMDevice micDevice;
        #endregion


        public smartMIC()
        {
            InitializeComponent();
        }

        #region Form Event
        /// <summary>
        /// 
        /// </summary>
        private void smartMIC_Load(object sender, EventArgs e)
        {
            SelectMICList();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnMute_Click(object sender, EventArgs e)
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
