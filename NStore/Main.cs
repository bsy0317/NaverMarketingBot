using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NStore
{
    public partial class Main : Form
    {
        public static string[] userData;
        IP ipfrm;
        public Main(string[] userDataA)
        {
            InitializeComponent();
            userData = userDataA;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(userData[1] == "IP" || userData[1] == "SEARCH")
            {
                ipfrm = new IP(userData);
                ipfrm.TopLevel = false;
                ipfrm.MdiParent = this;
                ipfrm.Show();
            }
            if(userData[1] == "SEARCH")
            {

            }
            else if(userData[1] == "NONE")
            {
                Environment.Exit(-1);
            }
        }
        private void initialzedAdapter(bool Enable,bool wait)
        {
            Thread t3 = new Thread(delegate () {
                SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
                ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
                foreach (ManagementObject item in searchProcedure.Get())
                {
                    if (((string)item["Name"]) != "Remote NDIS based Internet Sharing Device")
                    {
                        Debug.WriteLine("활성 > " + (string)item["Name"]);
                        if (Enable == true)
                        {
                            item.InvokeMethod("Enable", null);
                        }
                        else if (Enable == false)
                        {
                            item.InvokeMethod("Disable", null);
                        }
                    }
                }
            });
            t3.Start();
            if (wait) t3.Join();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            ProgressBar pb = new ProgressBar();
            ipfrm.Close();
            pb.TopMost = true;
            pb.StartPosition = FormStartPosition.CenterScreen;
            pb.progressBar1.Visible = false;
            pb.Controls.Remove(pb.progressBar1);

            Label lb1 = new Label();
            lb1.BackColor = Color.White;
            lb1.ForeColor = Color.Red;
            lb1.Text = "잠시만 기다려주세요.";
            lb1.Name = "Notice";
            lb1.Font = new Font("맑은 고딕", 10,FontStyle.Bold);
            lb1.Location = new Point(12, 12);
            lb1.Size = new Size(309,23);
            lb1.TextAlign = ContentAlignment.MiddleCenter;
            pb.Controls.Add(lb1);

            pb.Show();
            pb.Refresh();
            initialzedAdapter(true, true);
            pb.Close();
            Environment.Exit(0);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
