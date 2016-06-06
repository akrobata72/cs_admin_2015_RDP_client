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
using System.Threading;

namespace RAInvite_Admin_Toolroom
{
    public partial class Form1 : Form
    {
        RDPSession x = new RDPSession();
        
        public Form1()
        {
            InitializeComponent();
            //this.LostFocus += new System.EventHandler(this.Form1_LostFocus);
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_LostFocus(Object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["configuration"];
            Form fa = Application.OpenForms["frmAbout"];
            if (fc == null && fa==null)
            
            this.WindowState = FormWindowState.Minimized;

        }


        private void Incoming(object Guest)
        {
            IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest;//???
            MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_MAX;
            IRDPSRAPISharingSession ses = (IRDPSRAPISharingSession)Guest;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            x.OnAttendeeConnected += Incoming;
            x.colordepth = 8;
            x.Open();
            
            

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Firga", "app.config");
            Configuration MyAppConfig = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap { ExeConfigFilename = path }, ConfigurationUserLevel.None);

            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Igor", "WORKGROUP", "", 10);
            string file = MyAppConfig.AppSettings.Settings["sRDPInvitePath"].Value;
            FileInfo fi = new FileInfo(@"\\" + file );
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.Write(Invitation.ConnectionString);
                label1.ForeColor = Color.DarkGreen;
                label1.Text = "Connected!";
                //WindowState = FormWindowState.Minimized;

            }

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            x.Close();
            x = null;
            label1.ForeColor = Color.Red;
            label1.Text = "Disconnected";
            Application.Restart();
            
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f2 = new frmAbout();
            f2.ShowDialog();

        }
    }
}
