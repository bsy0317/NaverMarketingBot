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
        public Main(string[] userDataA)
        {
            InitializeComponent();
            userData = userDataA;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(userData[1] == "IP" || userData[1] == "SEARCH")
            {
                IP ipfrm = new IP(userData);
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
            initialzedAdapter(true,true);
            Environment.Exit(0);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
