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

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Firga", "app.config");

            Configuration MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = path }, ConfigurationUserLevel.None);

            txtRDPFilePath.Text = MyAppConfig.AppSettings.Settings["sRDPInvitePath"].Value;

        }

        

        public void btnSave_Click(object sender, EventArgs e)
        {
            
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Firga", "app.config");

            Configuration MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = path }, ConfigurationUserLevel.None);
            AppSettingsSection section = MyAppConfig.AppSettings;
            section.Settings.Remove("sRDPInvitePath");
            section.Settings.Add("sRDPInvitePath",txtRDPFilePath.Text);

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
