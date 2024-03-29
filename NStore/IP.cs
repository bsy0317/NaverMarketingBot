﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHttp;

namespace NStore
{
    public partial class IP : Form
    {
        ProgressBar pb;
        public static string[] userData;
        private static bool autoOn = false;
        bool timeLoop_Status = false;
        Thread timeLoop;
        public IP(string[] userDataA)
        {
            userData = userDataA;
            InitializeComponent();
        }

        private void IP_Load(object sender, EventArgs e)
        {
            btn_off.Enabled = false;
            if(userData[1] != "SEARCH")
            {
                rbtn_autosync.Enabled = false;
            }
            if (File.Exists(Environment.CurrentDirectory + @"\adb\adb.exe") == false)
            {
                pb = new ProgressBar();
                pb.TopMost = false;
                pb.MdiParent = ((Main)MdiParent);
                pb.StartPosition = FormStartPosition.Manual;
                pb.Location = new Point(this.Location.X+this.Size.Width+20, this.Location.Y+this.Size.Height+20);
                pb.Show();
                MessageBox.Show("필수 바이너리 파일 다운로드를 시작합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread th = new Thread(binaryDownload);
                th.Start();
            }
            else
            {
                //ADB 바이너리가 있는경우에만 어댑터 비활성화
                //initialzedAdapter(false);
            }
        }
        private void initialzedAdapter(bool Enable=false)
        {
            Thread t3 = new Thread(delegate () {
                logBox.AppendText("[Wait] 서비스 실행 시작중...\n", Color.DarkOrange);
                SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
                ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
                foreach (ManagementObject item in searchProcedure.Get())
                {
                    if (((string)item["Name"]).IndexOf("Remote NDIS") == -1)
                    {
                        Debug.WriteLine("비활성 > " + (string)item["Name"]);
                        if (Enable == true)
                        {
                            item.InvokeMethod("Enable", null);
                        }
                        else if (Enable == false)
                        {
                            item.InvokeMethod("Disable", null);
                        }
                    }
                    else if (((string)item["Name"]).IndexOf("Remote NDIS") != -1)
                    {
                        Debug.WriteLine("활성 > " + (string)item["Name"]);
                        item.InvokeMethod("Enable", null);
                    }
                }
                logBox.AppendText("[OK] 테더링 네트워크를 제외한 다른 네트워크 사용을 중지했습니다.\n", Color.Green);
            });
            t3.Start();
        }
        private void ipChange()
        {
            Thread t3 = new Thread(delegate ()
            {
                logBox.AppendText("[Wait] 새로운 IP주소를 받아옵니다.\n", Color.Green);
                string ipAPI = "http://auth.krr.kr/getIP.php";
                WinHttpRequest wt = new WinHttpRequest();
                wt.Open("GET", ipAPI);
                wt.Send();
                string prevIP = wt.ResponseText;
                ProcessStartInfo proc_info = new ProcessStartInfo();
                Process proc = new Process();
                proc_info.FileName = Environment.CurrentDirectory + @"\adb\adb.exe";
                proc_info.UseShellExecute = false;
                proc_info.CreateNoWindow = true;
                proc_info.RedirectStandardOutput = true;
                proc_info.RedirectStandardError = true;
                proc_info.RedirectStandardInput = true;
                string[] arg_list = { "shell svc data disable" , "shell settings put global airplane_mode_on 1" ,
                "shell svc data enable","shell settings put global airplane_mode_on 0"};

                foreach (string arg_ in arg_list)
                {
                    proc_info.Arguments = arg_;
                    proc.StartInfo = proc_info;
                    proc.Start();
                    string result = proc.StandardOutput.ReadToEnd();
                    Debug.WriteLine(result + "OK");
                    proc.WaitForExit();
                    proc.Close();
                }
                logBox.AppendText("[Wait] IP정보 갱신대기중.\n", Color.DarkOrange);
                Thread.Sleep(1000);
                wt.Send();
                string newIP = wt.ResponseText;
                label_prevIP.Text = prevIP;
                label_nowIP.Text = newIP;
                logBox.AppendText("[OK] IP정보 갱신완료.\n", Color.Green);
            });
            t3.Start();
        }
        private void timeChangeIP()
        {
            try
            {
                timeLoop_Status = true;
                timeLoop = new Thread(delegate ()
                {
                    while (timeLoop_Status)
                    {
                        for (int i = (int)changetime.Value; i > 0; i--)
                        {
                            logBox.AppendText("[Time] " + i.ToString() + "분 후 IP가 변경됩니다.\n", Color.Red);
                            Thread.Sleep(1000 * 60);
                            if (!timeLoop_Status)
                            {
                                logBox.AppendText("[Alert] IP 자동변경 중지 완료.\n", Color.Red);
                                break;
                            }
                        }
                        if(timeLoop_Status) ipChange();
                    }
                });
                timeLoop.IsBackground = true;
                timeLoop.Start();
            }
            catch{  }
        }
        private void binaryDownload()
        {
            //Last SDK Update Link
            string SDK_DOWN_URL = "https://dl.google.com/android/repository/platform-tools-latest-windows.zip?hl=ko";
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wcProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCallback2);
            wc.DownloadFileAsync(new Uri(SDK_DOWN_URL), Environment.CurrentDirectory + @"\platform-tools-latest-windows.zip");
        }
        private void DownloadFileCallback2(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                ZipFile.ExtractToDirectory(Environment.CurrentDirectory + @"\platform-tools-latest-windows.zip", Environment.CurrentDirectory);
                Directory.Move(Environment.CurrentDirectory + @"\platform-tools", Environment.CurrentDirectory + @"\adb");
                File.Delete(Environment.CurrentDirectory + @"\platform-tools-latest-windows.zip");
                logBox.AppendText("[OK] ADB Binary 다운로드를 완료했습니다.\n", Color.Green);
                initialzedAdapter(false);
            }
            catch(Exception ex)
            {
                MessageBox.Show("ADB Binary 다운로드에 실패하였습니다.\n프로그램을 재시작 해 주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.Message);
                Environment.Exit(-1);
            }
        }
        void wcProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pb.progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100) pb.Close();
        }

        private void rbtn_autotime_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn_autotime.Checked == true)
            {
                btn_off.Enabled=btn_on.Enabled = true;
                btn_off.Enabled = autoOn;
                btn_on.Enabled = !autoOn;
                changetime.Enabled = true;
            }
        }

        private void rbtn_autosync_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_autosync.Checked == true)
            {
                changetime.Enabled = false;
                btn_off.Enabled = btn_on.Enabled = true;
                btn_off.Enabled = autoOn;
                btn_on.Enabled = !autoOn;
            }
        }

        private void rbtn_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_manual.Checked == true)
            {
                btn_off.Enabled = btn_on.Enabled = false;
                changetime.Enabled = false;
            }
            else
            {
                changetime.Enabled = true;
            }
        }

        private void btn_on_Click(object sender, EventArgs e)
        {
            autoOn = true;
            btn_on.Enabled = false;
            btn_off.Enabled = true;
            timeChangeIP();
        }

        private void btn_off_Click(object sender, EventArgs e)
        {
            autoOn = false;
            btn_on.Enabled = true;
            btn_off.Enabled = false;
            logBox.AppendText("[Alert] IP 자동변경 중지 요청 전송.\n", Color.Red);
            timeLoop_Status = false; //Loop 순환 종료
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ipChange();
        }
    }
    public static class RichTextBoxExtensions{
        public static void AppendText(this RichTextBox box, string text, Color color){
            text = "["+DateTime.Now.ToString("T")+"] " + text;
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;

            box.ScrollToCaret(); //Auto Scroll
        }
    }
}
