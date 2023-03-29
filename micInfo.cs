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
    public partial class micInfo : Form
    {
        string cur_ver;

        public micInfo(string ver)
        {
            InitializeComponent();
            cur_ver = ver;
        }

        private void micInfo_Load(object sender, EventArgs e)
        {
            lbVersion.Text = cur_ver;
        }

        private void micInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
