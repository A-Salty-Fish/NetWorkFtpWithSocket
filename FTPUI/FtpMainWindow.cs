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
using CCWin.SkinControl;
using FTPCMD;

namespace FTPUI
{
    public partial class FtpMainWindow : Skin_DevExpress
    {

        public static MyFTP myFtp;
        private readonly Form LoginInWindow = new FtpLoginWindow();

        public string LocalPath;

        public FtpMainWindow()
        {
            myFtp = new MyFTP();
            InitializeComponent();
            LoginInWindow.ShowDialog();
            ShowExtendAttri();
            FreshFtpFile();
            ListBoxMessage.Items.Add("已连接");
            ListBoxMessage.Items.Add(myFtp.SetUTF8());
        }

        private void ButtonChoseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                LocalPath = fbd.SelectedPath;
                FreshLocalFile();
            }
        }

        private void ShowExtendAttri()
        {
            var message = myFtp.GetFtpExtAttr();
            TextBoxExtendAttr.Text = message;

        }

        private void FreshLocalFile()
        {
            if (LocalPath == null) return;
            ListBoxLocal.Items.Clear();
            List<string> localFileList = myFtp.GetLocalFileList(LocalPath);
            foreach (var fileName in localFileList)
            {
                ListBoxLocal.Items.Add(fileName);
            }
        }

        private void FreshFtpFile()
        {
            ListBoxFtp.Items.Clear();
            List<string> ftpFileList = myFtp.GetFtpFileList();
            foreach (var fileName in ftpFileList)
            {
                ListBoxFtp.Items.Add(fileName);
            }
        }

        private void ButtonFreshLocal_Click(object sender, EventArgs e)
        {
            FreshLocalFile();
        }

        private void ButtonFreshFtp_Click(object sender, EventArgs e)
        {
            FreshFtpFile();
        }

        private void FtpMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            myFtp.Close();
        }

        private void ButtonDownLoad_Click(object sender, EventArgs e)
        {

        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {

        }

    }
}
