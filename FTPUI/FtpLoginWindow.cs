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
    public partial class FtpLoginWindow : Skin_DevExpress
    {
        public FtpLoginWindow()
        {
            InitializeComponent();
        }


        private void CheckBoxShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxShowPwd.Checked)
                TextBoxPassword.PasswordChar = '\0';
            else
                TextBoxPassword.PasswordChar = '○';
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (TextBoxIP.Text == "")
                MessageBox.Show("请输入IP");
            else
            {
                try
                {
                    FtpMainWindow.myFtp.Connect(TextBoxIP.Text);
                    if (FtpMainWindow.myFtp.GetRCode() != 220)
                        MessageBox.Show("IP错误或服务器未开启");
                    else
                    {
                        FtpMainWindow.myFtp.LoginIn(TextBoxUserName.Text, TextBoxPassword.Text);
                        if (FtpMainWindow.myFtp.GetRCode() != 230)
                            MessageBox.Show("请检查用户名和密码");
                        else
                        {
                            MessageBox.Show("登录成功");
                            this.Close();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    throw;
                }
            }
        }

        private void FtpLoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
