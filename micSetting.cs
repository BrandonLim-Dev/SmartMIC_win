using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace SmartMIC
{
    public partial class micSetting : Form
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        #region Global Variable
        public sysSettingGetEventHandler sysSettingGetEvent;
        private string macAddr;
        #endregion

        public micSetting(string ipAddr, string portNum, string secure, string id, string sampleRate, string logFlag, string ver)
        {
            InitializeComponent();

            tbIPAddress.Text = ipAddr;
            tbPort.Text = portNum;
            cbSercureFlag.Text = secure;
            tbIdentity.Text = id;
            cbSamplerate.Text = sampleRate;
            cbLogFlag.Text = logFlag;
            tbVersion.Text = ver;
        }

        private void micSetting_Load(object sender, EventArgs e)
        {
            //tbIPAddress.Text = "192.168.50.100";
            //tbPort.Text = "28083";
            //cbSercureFlag.Text = "예";
            //tbIdentity.Text = "";
            //cbSamplerate.Text = "8000";
            //cbLogFlag.Text = "아니오";
            //tbVersion.Text = "";
            //
            //GetMACAddress();
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
            tbIdentity.Text = macAddr;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ///<summary>
            ///sysSettingGetEvent(접속주소, 웹소켓 Port, 웹소켓 Secure, 단말 MAC 주소, 음성 SampleRate, 메시지 Logging, 버전)
            ///</summary>
            sysSettingGetEvent(tbIPAddress.Text, tbPort.Text, cbSercureFlag.Text, tbIdentity.Text, cbSamplerate.Text, cbLogFlag.Text, tbVersion.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void micSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
