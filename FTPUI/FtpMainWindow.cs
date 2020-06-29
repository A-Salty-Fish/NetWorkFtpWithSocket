using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using FTPCMD;

namespace FTPUI
{
    public partial class FtpMainWindow : Skin_DevExpress
    {
        public static MyFTP myFtp;
        private readonly Form LoginInWindow = new FtpLoginWindow();
        public FtpMainWindow()
        {
            myFtp = new MyFTP();
            InitializeComponent();
            LoginInWindow.ShowDialog();
        }
    }
}
