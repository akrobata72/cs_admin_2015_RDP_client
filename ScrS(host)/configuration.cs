using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace ScrS_server_
{
    public partial class configuration : Form
    {
        public configuration()
        {
            InitializeComponent();
            //Properties.Settings.Default.sRDPfilePath = txtRDPFilePath.Text;
            txtRDPFilePath.Text = Properties.Settings.Default.sRDPInvitePath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"Firga","app.config");
            Configuration MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = path }, ConfigurationUserLevel.None);

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            Properties.Settings.Default.sRDPInvitePath = txtRDPFilePath.Text;
            //Properties.Settings.Default.Save();
            MyAppConfig.Save();
            
            ConfigurationManager.RefreshSection("MyAppConfig");
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
