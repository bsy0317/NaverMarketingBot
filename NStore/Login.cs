using DeviceId;
using DeviceId.Encoders;
using DeviceId.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinHttp;

namespace NStore
{
    public partial class Login : Form
    {
        public static string uniqueID = "";
        public static string[] userData;

        public Login()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string deviceId = new DeviceIdBuilder()
                .AddProcessorId()
                .AddMotherboardSerialNumber()
                .AddSystemDriveSerialNumber()
                .AddSystemUUID()
                .UseFormatter(new HashDeviceIdFormatter(() => MD5.Create(), new Base64UrlByteArrayEncoder()))
                .ToString().ToUpper();
            toolStripStatusLabel1.Text = InsertCharAtDividedPosition(deviceId, 6, "-");
            uniqueID = InsertCharAtDividedPosition(deviceId, 6, "-");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("아이디 또는 비밀번호가 입력되지 않았습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Thread th = new Thread(login);
                th.Start();
            }
        }
        private void login()
        {
            string ID = textBox1.Text;
            string PW = textBox2.Text;
            WinHttpRequest wt = new WinHttpRequest();
            wt.Open("GET", "http://auth.krr.kr/index.php?ID=" + ID + "&PW=" + PW);
            wt.Send();
            Debug.WriteLine(wt.ResponseText);
            string[] Data = Decrypt(wt.ResponseText).Split('|');
            userData = Data;
            if (Data[0] == "FAIL")
            {
                MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Data[1] == "NULL")
            {
                MessageBox.Show("등록된 라이선스가 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Data[2] != uniqueID)
            {
                MessageBox.Show("사용이 허가된 PC가 아닙니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DateTime.Parse(Data[3]).Subtract(DateTime.Parse(Data[4])).Days <= 0)
            {
                MessageBox.Show("사용기한이 만료되었습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string sub = DateTime.Parse(Data[3]).Subtract(DateTime.Parse(Data[4])).Days.ToString();
                MessageBox.Show("로그인 성공\n사용기한 " + sub + "일 남음.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Main frm1 = new Main(userData);
                frm1.ShowDialog();
            }

        }
        public static string Decrypt(string cipherData)
        {

            byte[] ivString = new byte[16];
            string key_string = SHA256Hash(DateTime.Now.ToString("yyyyMMdd")).Substring(0, 32);
            Debug.WriteLine(key_string);
            byte[] key = Encoding.UTF8.GetBytes(key_string);
            byte[] iv = ivString;
            try
            {
                using RijndaelManaged rijndaelManaged = new RijndaelManaged
                {
                    Key = key,
                    IV = iv,
                    Mode = CipherMode.CBC
                };
                using MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherData));
                using CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                return new StreamReader(cryptoStream).ReadToEnd();
            }
            catch (CryptographicException e)
            {
                Debug.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }
        private static string SHA256Hash(string data)
        {
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = hash;
            foreach (byte b in array)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        public static string InsertCharAtDividedPosition(string str, int count, string character)
        {
            int i = 0;
            while (++i * count + (i - 1) < str.Length)
            {
                str = str.Insert(i * count + (i - 1), character);
            }
            return str;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Clipboard.SetText(uniqueID);
            toolStripStatusLabel1.Text = "복사완료!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text.IndexOf("내 PC 고유번호") != -1)
            {
                toolStripStatusLabel1.Text = "이곳을 클릭하면 복사됩니다.";
            }
            else
            {
                toolStripStatusLabel1.Text = "내 PC 고유번호 = " + uniqueID;
            }
        }
    }
}
