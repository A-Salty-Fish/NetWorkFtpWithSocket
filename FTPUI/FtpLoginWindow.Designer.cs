namespace FTPUI
{
    partial class FtpLoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LabelIP = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.TextBoxIP = new CCWin.SkinControl.SkinChatRichTextBox();
            this.TextBoxUserName = new CCWin.SkinControl.SkinChatRichTextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.CheckBoxShowPwd = new CCWin.SkinControl.SkinCheckBox();
            this.ButtonLogin = new CCWin.SkinControl.SkinButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.25243F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.Controls.Add(this.LabelIP, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LabelPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LabelUserName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxIP, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxUserName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.TextBoxPassword, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.CheckBoxShowPwd, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(570, 278);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // LabelIP
            // 
            this.LabelIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelIP.AutoSize = true;
            this.LabelIP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelIP.Location = new System.Drawing.Point(90, 41);
            this.LabelIP.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.LabelIP.Name = "LabelIP";
            this.LabelIP.Size = new System.Drawing.Size(109, 65);
            this.LabelIP.TabIndex = 0;
            this.LabelIP.Text = "IP地址";
            this.LabelIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelPassword
            // 
            this.LabelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelPassword.Location = new System.Drawing.Point(90, 206);
            this.LabelPassword.Margin = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(109, 58);
            this.LabelPassword.TabIndex = 2;
            this.LabelPassword.Text = "密码";
            this.LabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelUserName
            // 
            this.LabelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LabelUserName.Location = new System.Drawing.Point(90, 126);
            this.LabelUserName.Margin = new System.Windows.Forms.Padding(5, 15, 5, 5);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(109, 60);
            this.LabelUserName.TabIndex = 3;
            this.LabelUserName.Text = "用户名";
            this.LabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxIP.Location = new System.Drawing.Point(214, 59);
            this.TextBoxIP.Margin = new System.Windows.Forms.Padding(10, 28, 10, 20);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.SelectControl = null;
            this.TextBoxIP.SelectControlIndex = 0;
            this.TextBoxIP.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.TextBoxIP.Size = new System.Drawing.Size(244, 32);
            this.TextBoxIP.TabIndex = 4;
            this.TextBoxIP.Text = "192.168.56.1";
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxUserName.Location = new System.Drawing.Point(214, 137);
            this.TextBoxUserName.Margin = new System.Windows.Forms.Padding(10, 26, 10, 20);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.SelectControl = null;
            this.TextBoxUserName.SelectControlIndex = 0;
            this.TextBoxUserName.SelectControlPoint = new System.Drawing.Point(0, 0);
            this.TextBoxUserName.Size = new System.Drawing.Size(244, 34);
            this.TextBoxUserName.TabIndex = 5;
            this.TextBoxUserName.Text = "dzy";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPassword.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxPassword.Location = new System.Drawing.Point(214, 217);
            this.TextBoxPassword.Margin = new System.Windows.Forms.Padding(10, 26, 10, 20);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.PasswordChar = '○';
            this.TextBoxPassword.Size = new System.Drawing.Size(244, 33);
            this.TextBoxPassword.TabIndex = 6;
            // 
            // CheckBoxShowPwd
            // 
            this.CheckBoxShowPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxShowPwd.AutoSize = true;
            this.CheckBoxShowPwd.BackColor = System.Drawing.Color.Transparent;
            this.CheckBoxShowPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.CheckBoxShowPwd.DownBack = null;
            this.CheckBoxShowPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckBoxShowPwd.Location = new System.Drawing.Point(482, 217);
            this.CheckBoxShowPwd.Margin = new System.Windows.Forms.Padding(14, 26, 14, 20);
            this.CheckBoxShowPwd.MouseBack = null;
            this.CheckBoxShowPwd.Name = "CheckBoxShowPwd";
            this.CheckBoxShowPwd.NormlBack = null;
            this.CheckBoxShowPwd.SelectedDownBack = null;
            this.CheckBoxShowPwd.SelectedMouseBack = null;
            this.CheckBoxShowPwd.SelectedNormlBack = null;
            this.CheckBoxShowPwd.Size = new System.Drawing.Size(74, 32);
            this.CheckBoxShowPwd.TabIndex = 7;
            this.CheckBoxShowPwd.Text = "显示";
            this.CheckBoxShowPwd.UseVisualStyleBackColor = false;
            this.CheckBoxShowPwd.CheckedChanged += new System.EventHandler(this.CheckBoxShowPwd_CheckedChanged);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.Transparent;
            this.ButtonLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ButtonLogin.DownBack = null;
            this.ButtonLogin.Location = new System.Drawing.Point(206, 331);
            this.ButtonLogin.MouseBack = null;
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.NormlBack = null;
            this.ButtonLogin.Size = new System.Drawing.Size(171, 36);
            this.ButtonLogin.TabIndex = 3;
            this.ButtonLogin.Text = "登录";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // FtpLoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(578, 394);
            this.ControlBox = false;
            this.Controls.Add(this.ButtonLogin);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FtpLoginWindow";
            this.Text = "登录";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label LabelIP;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.Label LabelUserName;
        private CCWin.SkinControl.SkinChatRichTextBox TextBoxIP;
        private CCWin.SkinControl.SkinChatRichTextBox TextBoxUserName;
        private CCWin.SkinControl.SkinButton ButtonLogin;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private CCWin.SkinControl.SkinCheckBox CheckBoxShowPwd;
    }
}