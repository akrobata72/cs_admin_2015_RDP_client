using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ScrS_server_
{
    public partial class configuration : Form
    {
        public configuration()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            Properties.Settings.Default.sRDPfilePath = txtRDPFilePath.Text;
            
            Properties.Settings.Default.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void btnRDPInvitationFile_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                txtRDPFilePath.Text = path.ToString();
            }
        }
    }
}
