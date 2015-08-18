using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using RDPCOMAPILib;
using System.IO;
using System.Configuration;

namespace ScrS_server_
{
    public partial class Form1 : Form
    {
        RDPSession x = new RDPSession();
        public Form1()
        {
            InitializeComponent();



        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
            IRDPSRAPISharingSession ses = (IRDPSRAPISharingSession)Guest;
            ses.colordepth = 16;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x.OnAttendeeConnected += Incoming;
            x.Open();

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Firga", "app.config");
            Configuration MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = path }, ConfigurationUserLevel.None);

            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            string file = MyAppConfig.AppSettings.Settings["sRDPInvitePath"].Value;
            FileInfo fi = new FileInfo(@"\\" + file );
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.Write(Invitation.ConnectionString);
                label1.Text = "OK!";
            }

        }

      private void button3_Click(object sender, EventArgs e)
        {
            x.Close();
            x = null;

        }

        private void opcijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuration f1 = new configuration();
            f1.ShowDialog();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                 System.Environment.Exit(1);
            }
        }
    }
}
