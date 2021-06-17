using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NStore
{
    public partial class Search : Form
    {
        string[] userData;
        public Search(string[] userDataA)
        {
            InitializeComponent();
            userData = userDataA;
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
