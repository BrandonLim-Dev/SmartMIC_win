using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMIC
{
    public partial class micSetting : Form
    {
        /// <summary>
        /// Global Variable
        /// </summary>
        #region Global Variable
        public sysSettingGetEventHandler sysSettingGetEvent;
        #endregion

        public micSetting()
        {
            InitializeComponent();
        }

        private void micSetting_Load(object sender, EventArgs e)
        {
            tbIPAddress.Text = "192.168.50.100";
            tbPort.Text = "28083";
            cbSercureFlag.Text = "예";
            tbIPAddress.Text = "";
            cbSamplerate.Text = "8000";
            cbLogFlag.Text = "아니오";
            tbVersion.Text = "";   
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

        }
    }
}
