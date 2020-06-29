namespace FTPUI
{
    partial class FtpMainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonUpload = new CCWin.SkinControl.SkinButton();
            this.ButtonFreshLocal = new CCWin.SkinControl.SkinButton();
            this.ButtonChoseDir = new CCWin.SkinControl.SkinButton();
            this.ButtonDownLoad = new CCWin.SkinControl.SkinButton();
            this.ButtonFreshFtp = new CCWin.SkinControl.SkinButton();
            this.ListBoxLocal = new System.Windows.Forms.ListBox();
            this.ListBoxFtp = new System.Windows.Forms.ListBox();
            this.ListBoxMessage = new System.Windows.Forms.ListBox();
            this.TextBoxExtendAttr = new CCWin.SkinControl.SkinTextBox();
            this.SuspendLayout();
            // 
            // ButtonUpload
            // 
            this.ButtonUpload.BackColor = System.Drawing.Color.Transparent;
            this.ButtonUpload.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ButtonUpload.DownBack = null;
            this.ButtonUpload.Location = new System.Drawing.Point(149, 308);
            this.ButtonUpload.MouseBack = null;
            this.ButtonUpload.Name = "ButtonUpload";
            this.ButtonUpload.NormlBack = null;
            this.ButtonUpload.Size = new System.Drawing.Size(81, 30);
            this.ButtonUpload.TabIndex = 0;
            this.ButtonUpload.Text = "上传";
            this.ButtonUpload.UseVisualStyleBackColor = false;
            this.ButtonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // ButtonFreshLocal
            // 
            this.ButtonFreshLocal.BackColor = System.Drawing.Color.Transparent;
            this.ButtonFreshLocal.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ButtonFreshLocal.DownBack = null;
            this.ButtonFreshLocal.Location = new System.Drawing.Point(289, 308);
            this.ButtonFreshLocal.MouseBack = null;
            this.ButtonFreshLocal.Name = "ButtonFreshLocal";
            this.ButtonFreshLocal.NormlBack = null;
            this.ButtonFreshLocal.Size = new System.Drawing.Size(81, 30);
            this.ButtonFreshLocal.TabIndex = 1;
            this.ButtonFreshLocal.Text = "刷新";
            this.ButtonFreshLocal.UseVisualStyleBackColor = false;
            this.ButtonFreshLocal.Click += new System.EventHandler(this.ButtonFreshLocal_Click);
            // 
            // ButtonChoseDir
            // 
            this.ButtonChoseDir.BackColor = System.Drawing.Color.Transparent;
            this.ButtonChoseDir.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ButtonChoseDir.DownBack = null;
            this.ButtonChoseDir.Location = new System.Drawing.Point(7, 308);
            this.ButtonChoseDir.MouseBack = null;
            this.ButtonChoseDir.Name = "ButtonChoseDir";
            this.ButtonChoseDir.NormlBack = null;
            this.ButtonChoseDir.Size = new System.Drawing.Size(81, 30);
            this.ButtonChoseDir.TabIndex = 2;
            this.ButtonChoseDir.Text = "目录";
            this.ButtonChoseDir.UseVisualStyleBackColor = false;
            this.ButtonChoseDir.Click += new System.EventHandler(this.ButtonChoseDir_Click);
            // 
            // ButtonDownLoad
            // 
            this.ButtonDownLoad.BackColor = System.Drawing.Color.Transparent;
            this.ButtonDownLoad.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ButtonDownLoad.DownBack = null;
            this.ButtonDownLoad.Location = new System.Drawing.Point(490, 308);
            this.ButtonDownLoad.MouseBack = null;
            this.ButtonDownLoad.Name = "ButtonDownLoad";
            this.ButtonDownLoad.NormlBack = null;
            this.ButtonDownLoad.Size = new System.Drawing.Size(81, 30);
            this.ButtonDownLoad.TabIndex = 3;
            this.ButtonDownLoad.Text = "下载";
            this.ButtonDownLoad.UseVisualStyleBackColor = false;
            this.ButtonDownLoad.Click += new System.EventHandler(this.ButtonDownLoad_Click);
            // 
            // ButtonFreshFtp
            // 
            this.ButtonFreshFtp.BackColor = System.Drawing.Color.Transparent;
            this.ButtonFreshFtp.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.ButtonFreshFtp.DownBack = null;
            this.ButtonFreshFtp.Location = new System.Drawing.Point(675, 308);
            this.ButtonFreshFtp.MouseBack = null;
            this.ButtonFreshFtp.Name = "ButtonFreshFtp";
            this.ButtonFreshFtp.NormlBack = null;
            this.ButtonFreshFtp.Size = new System.Drawing.Size(81, 30);
            this.ButtonFreshFtp.TabIndex = 4;
            this.ButtonFreshFtp.Text = "刷新";
            this.ButtonFreshFtp.UseVisualStyleBackColor = false;
            this.ButtonFreshFtp.Click += new System.EventHandler(this.ButtonFreshFtp_Click);
            // 
            // ListBoxLocal
            // 
            this.ListBoxLocal.FormattingEnabled = true;
            this.ListBoxLocal.ItemHeight = 18;
            this.ListBoxLocal.Location = new System.Drawing.Point(7, 37);
            this.ListBoxLocal.Name = "ListBoxLocal";
            this.ListBoxLocal.Size = new System.Drawing.Size(363, 256);
            this.ListBoxLocal.TabIndex = 8;
            // 
            // ListBoxFtp
            // 
            this.ListBoxFtp.FormattingEnabled = true;
            this.ListBoxFtp.ItemHeight = 18;
            this.ListBoxFtp.Location = new System.Drawing.Point(430, 37);
            this.ListBoxFtp.Name = "ListBoxFtp";
            this.ListBoxFtp.Size = new System.Drawing.Size(363, 256);
            this.ListBoxFtp.TabIndex = 9;
            // 
            // ListBoxMessage
            // 
            this.ListBoxMessage.FormattingEnabled = true;
            this.ListBoxMessage.ItemHeight = 18;
            this.ListBoxMessage.Location = new System.Drawing.Point(430, 347);
            this.ListBoxMessage.Name = "ListBoxMessage";
            this.ListBoxMessage.Size = new System.Drawing.Size(363, 166);
            this.ListBoxMessage.TabIndex = 10;
            // 
            // TextBoxExtendAttr
            // 
            this.TextBoxExtendAttr.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxExtendAttr.DownBack = null;
            this.TextBoxExtendAttr.Icon = null;
            this.TextBoxExtendAttr.IconIsButton = false;
            this.TextBoxExtendAttr.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextBoxExtendAttr.IsPasswordChat = '\0';
            this.TextBoxExtendAttr.IsSystemPasswordChar = false;
            this.TextBoxExtendAttr.Lines = new string[0];
            this.TextBoxExtendAttr.Location = new System.Drawing.Point(8, 347);
            this.TextBoxExtendAttr.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxExtendAttr.MaxLength = 32767;
            this.TextBoxExtendAttr.MinimumSize = new System.Drawing.Size(28, 28);
            this.TextBoxExtendAttr.MouseBack = null;
            this.TextBoxExtendAttr.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TextBoxExtendAttr.Multiline = true;
            this.TextBoxExtendAttr.Name = "TextBoxExtendAttr";
            this.TextBoxExtendAttr.NormlBack = null;
            this.TextBoxExtendAttr.Padding = new System.Windows.Forms.Padding(5);
            this.TextBoxExtendAttr.ReadOnly = true;
            this.TextBoxExtendAttr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxExtendAttr.Size = new System.Drawing.Size(362, 166);
            // 
            // 
            // 
            this.TextBoxExtendAttr.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxExtendAttr.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxExtendAttr.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TextBoxExtendAttr.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TextBoxExtendAttr.SkinTxt.Multiline = true;
            this.TextBoxExtendAttr.SkinTxt.Name = "BaseText";
            this.TextBoxExtendAttr.SkinTxt.ReadOnly = true;
            this.TextBoxExtendAttr.SkinTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxExtendAttr.SkinTxt.Size = new System.Drawing.Size(352, 156);
            this.TextBoxExtendAttr.SkinTxt.TabIndex = 0;
            this.TextBoxExtendAttr.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextBoxExtendAttr.SkinTxt.WaterText = "";
            this.TextBoxExtendAttr.TabIndex = 11;
            this.TextBoxExtendAttr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextBoxExtendAttr.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TextBoxExtendAttr.WaterText = "";
            this.TextBoxExtendAttr.WordWrap = true;
            // 
            // FtpMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.TextBoxExtendAttr);
            this.Controls.Add(this.ListBoxMessage);
            this.Controls.Add(this.ListBoxFtp);
            this.Controls.Add(this.ListBoxLocal);
            this.Controls.Add(this.ButtonFreshFtp);
            this.Controls.Add(this.ButtonDownLoad);
            this.Controls.Add(this.ButtonChoseDir);
            this.Controls.Add(this.ButtonFreshLocal);
            this.Controls.Add(this.ButtonUpload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FtpMainWindow";
            this.Text = "Ftp客户端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FtpMainWindow_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton ButtonUpload;
        private CCWin.SkinControl.SkinButton ButtonFreshLocal;
        private CCWin.SkinControl.SkinButton ButtonChoseDir;
        private CCWin.SkinControl.SkinButton ButtonDownLoad;
        private CCWin.SkinControl.SkinButton ButtonFreshFtp;
        private System.Windows.Forms.ListBox ListBoxLocal;
        private System.Windows.Forms.ListBox ListBoxFtp;
        private System.Windows.Forms.ListBox ListBoxMessage;
        private CCWin.SkinControl.SkinTextBox TextBoxExtendAttr;
    }
}

