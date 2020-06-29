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
        private List<string> ftpFileList;
        private List<string> localFileList;
        public string LocalPath;

        public FtpMainWindow()
        {
            myFtp = new MyFTP();
            InitializeComponent();
            LoginInWindow.ShowDialog();
            if (myFtp.GetRCode() != 230) { System.Environment.Exit(0);}
            ListBoxMessage.Items.Add("已连接");
            FreshFtpFile();
        }

        private void ButtonChoseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                LocalPath = fbd.SelectedPath;
                FreshLocalFile();
                ListBoxMessage.Items.Add("选择目录：" + LocalPath);
            }
        }

        private void ShowExtendAttri()
        {
            string message = myFtp.GetFtpExtAttr();
            TextBoxExtendAttr.Text = message;
            ListBoxMessage.Items.Add("成功获取服务器拓展");
        }

        private void FreshLocalFile()
        {
            if (LocalPath == null) return;
            ListBoxLocal.Items.Clear();
            localFileList = myFtp.GetLocalFileList(LocalPath);
            if (CheckBoxShowFileSize.Checked)
                foreach (var fileName in localFileList)
                {
                    string filePath = LocalPath + "\\" + fileName;
                    ListBoxLocal.Items.Add(fileName + " 大小: " + myFtp.GetLocalFileSize(filePath) + "B");
                }
            else
                foreach (var fileName in localFileList)
                {
                    ListBoxLocal.Items.Add(fileName);
                }

            ListBoxMessage.Items.Add("成功刷新本地文件列表");
        }

        private void FreshFtpFile()
        {
            ListBoxMessage.Items.Add(myFtp.SetUTF8(false));
            ListBoxFtp.Items.Clear();
            ftpFileList = myFtp.GetFtpFileList();
            foreach (var fileName in ftpFileList)
            {
                ListBoxFtp.Items.Add(fileName);
            }
            ListBoxMessage.Items.Add("成功刷新服务器文件列表");
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
            if (LocalPath == null)
            {
                MessageBox.Show("请选择路径");
                return;
            }
            else if (ListBoxFtp.SelectedIndex < 0)
            {
                MessageBox.Show("请选择文件");
                return;
            }
            ListBoxMessage.Items.Add(myFtp.SetUTF8(true));
            string fileName = ListBoxFtp.Items[ListBoxFtp.SelectedIndex].ToString();
            fileName = fileName.Substring(0, fileName.Length - 1);
            string filePath = LocalPath + "\\" + fileName;
            ListBoxMessage.Items.Add("准备下载:" + fileName);
            myFtp.DownLoadFile(fileName, filePath);
            ListBoxMessage.Items.Add("下载完成:" + fileName);
        }

        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (LocalPath == null || ListBoxLocal.SelectedIndex < 0)
            {
                MessageBox.Show("请选择上传的文件");
                return;
            }
            ListBoxMessage.Items.Add(myFtp.SetUTF8(true));
            string fileName = ListBoxLocal.Items[ListBoxLocal.SelectedIndex].ToString();
            string filePath = LocalPath + "\\" + fileName;
            ListBoxMessage.Items.Add("准备上传:" + fileName);
            myFtp.UpLoadFile(fileName,filePath);
            ListBoxMessage.Items.Add("上传完成:" + fileName);
        }

        private void ButtonExtAttri_Click(object sender, EventArgs e)
        {
            ShowExtendAttri();
        }

        private void CheckBoxShowFileSize_CheckedChanged(object sender, EventArgs e)
        {
            FreshFtpFile();
            FreshLocalFile();
            ListBoxMessage.Items.Add(myFtp.SetUTF8(true));

            if (CheckBoxShowFileSize.Checked)
            {
                ListBoxMessage.Items.Add("显示文件大小");
                ListBoxFtp.Items.Clear();
                foreach (var fileName in ftpFileList)
                {
                    ListBoxFtp.Items.Add(fileName + "  大小: " + myFtp.GetFtpFileSize(fileName) + "B");
                }
                ListBoxLocal.Items.Clear();
                if (localFileList!=null)
                    foreach (var fileName in localFileList)
                    {
                        string filePath = LocalPath + "\\" + fileName;
                        ListBoxLocal.Items.Add(fileName + " 大小: " + myFtp.GetLocalFileSize(filePath) + "B");
                    }
            }
            else
            {
                ListBoxMessage.Items.Add("取消显示文件大小");
                return;
            }
        }

    }
}
