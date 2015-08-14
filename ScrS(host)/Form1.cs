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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x.OnAttendeeConnected += Incoming;
            x.Open();

            IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
            string file = Properties.Settings.Default.sRDPInvitePath;
            FileInfo fi = new FileInfo(@"\\" + file );
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.Write(Invitation.ConnectionString);
                label1.Text = "OK!";
            }
           // textBox1.Text = Invitation.ConnectionString;

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
                // Console app
                System.Environment.Exit(1);
            }
        }
    }
}
