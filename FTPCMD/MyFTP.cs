using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace FTPCMD
{
    public class MyFTP
    {
        #region 连接相关常量
        /// <summary>每个命令的结束符号</summary>
        private string CRLF = "\r\n";
        /// <summary>命令端口，默认为21</summary>
        private int CmdPort = 21;
        /// <summary>套接字缓冲区大小 默认1024B</summary>
        private int BufferSize = 1024;
        /// <summary>比特数组大小 默认1030B</summary>
        private int ByteArraySize = 1030;
        #endregion

        #region 连接相关参数
        /// <summary>Ftp服务器IP地址</summary>
        private string FtpIP;
        /// <summary>数据端口</summary>
        private int DataPort;
        /// <summary>用户名</summary>
        public string UserName;
        /// <summary>密码</summary>
        public string PassWord;
        /// <summary>客户端命令端口返回的最后一条消息</summary>
        public string LastMessage;
        #endregion

        #region 套接字
        /// <summary>命令套接字</summary>
        private Socket cmdSocket;
        /// <summary>数据套接字</summary>
        private Socket dataSocket;
        #endregion

        #region 获取\设置服务器相关信息
        /// <summary>获取FTP服务器控制端口返回的消息</summary>
        /// <returns>消息内容</returns>
        private string GetCmdMessage()
        {
            byte[] data = new byte[BufferSize];//新建一个byte数组，用来接收数据
            int length = cmdSocket.Receive(data); //length返回值表示接收了多少字节的数据
            LastMessage = Encoding.UTF8.GetString(data, 0, length); //解码数据
            Console.WriteLine(LastMessage);
            return LastMessage;
        }
        /// <summary>返回服务器最后返回的响应码</summary>
        /// <returns>整型响应码</returns> 
        public int GetRCode()
        {
            if (LastMessage != null)
            {
                string strCode = LastMessage.Substring(0, 3);//获取最近一条消息的前三位字符串
                int RCode = Int32.Parse(strCode);
                return RCode;
            }
            else
                return 0;
        }
        /// <summary>获取服务器扩展信息</summary
        /// <returns>扩展信息删去头尾后的字符串</returns>
        public string GetFtpExtAttr()
        {
            //发送获取扩展信息的命令
            string ExtAttrCMD = "FEAT" + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(ExtAttrCMD));
            //获取服务器返回的字符串
            string message = GetCmdMessage();
            while (!message.Contains("211 END"))//没到末尾则一直读取
            {
                message += GetCmdMessage();
            }
            //删去头尾无用内容
            message = message.Substring("211-Extended features supported:\r\n".Length);
            message = message.Substring(0, message.Length - "211 END\r\n".Length);
            return message;
        }
        /// <summary>设置UTF8</summary>
        /// <param name="set">true为打开，false为关闭，默认true</param>
        /// <returns>返回设置是否成功的字符串</returns>
        public string SetUTF8(bool set = true)
        {
            if (set)
            {
                string SetUtf8Cmd = "OPTS UTF8 ON" + CRLF;
                cmdSocket.Send(Encoding.UTF8.GetBytes(SetUtf8Cmd));
                GetCmdMessage();
                if (GetRCode() == 200)
                    return "Set UTF8 ON successful";
                else
                    return "Unable to set UTF8";
            }
            else
            {
                string SetUtf8Cmd = "OPTS UTF8 OFF" + CRLF;
                cmdSocket.Send(Encoding.UTF8.GetBytes(SetUtf8Cmd));
                Console.WriteLine(GetCmdMessage());
                return "Set UTF8 OFF successful";
            }
        }

        #endregion

        #region 连接预备
        /// <summary>连接上IP对应的FTP服务器</summary>
        /// <param name="IP">ftp服务器IP地址</param>
        /// <returns>返回服务器hello信息</returns>
        public string Connect(string IP)
        {
            FtpIP = IP;
            cmdSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //创建命令套接字
            cmdSocket.Connect(IP, CmdPort);//尝试连接服务器
            return GetCmdMessage();
        }

        /// <summary>使用用户名和密码登录FTP服务器</summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>是否登录成功的字符串</returns>
        public string LoginIn(string username, string password)
        {
            //先传送用户名
            UserName = username;
            string UserCmd = "USER " + UserName + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(UserCmd));
            GetCmdMessage();//获取一个用户返回信息
            //再传送密码
            PassWord = password;
            string PswCmd = "PASS " + PassWord + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(PswCmd));

            return GetCmdMessage();//返回是否登录成功的字符串
        }
        /// <summary>使FTP服务器进入被动模式</summary>
        /// <returns>数据端口号字符串</returns>
        public string PassiveMode()
        {
            //发送被动模式命令
            string PassiveCmd = "PASV" + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(PassiveCmd));
            string message = GetCmdMessage();
            //处理返回的数据端口
            string retstr;
            string[] retArray = Regex.Split(message, ",");
            //根据端口位数筛选
            if (retArray[5][3] == ')')//三位数
                retstr = retArray[5].Substring(0, 3);
            else if (retArray[5][2] == ')')//两位数
                retstr = retArray[5].Substring(0, 2);
            else//一位数
                retstr = retArray[5].Substring(0, 1);
            DataPort = Convert.ToInt32(retArray[4]) * 256 + Convert.ToInt32(retstr);
            //将数据套接字绑定数据端口
            dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            dataSocket.Connect(FtpIP, DataPort);

            return DataPort.ToString();
        }
        #endregion

        #region 正常的上传下载/加入断点续传
        /// <summary>从FTP服务器下载文件</summary>
        /// <param name="filePath">文件名</param>
        /// <param name="filePath">完整文件路径，包括文件名；当null时默认本地，默认为null</param>
        /// <param name="breakPoint">控制下载的大小</param>
        /// <returns>返回一些下载信息:完成、中断</returns>
        public string DownLoadFile(string fileName, string filePath = null, int breakPoint = 0)//便于测试，加入断点，到断点则停止下载
        {
            if (filePath == null) filePath = fileName;
            if (!File.Exists(filePath))//本地不存在该文件则不需要断点续传
            {
                //进入被动模式
                PassiveMode();
                //申请下载命令
                string downCmd = "RETR " + fileName + CRLF;
                cmdSocket.Send(Encoding.UTF8.GetBytes(downCmd));
                GetCmdMessage();
                //创建文件
                using (FileStream fstrm = new FileStream(filePath, FileMode.Create))
                {
                    byte[] fbytes = new byte[ByteArraySize];

                    int sum = 0;//读取的总字节数
                    int num;//每次读取的字节数
                    //从数据端口读取数据
                    while ((num = dataSocket.Receive(fbytes)) != 0)
                    {
                        if (sum + num > breakPoint && breakPoint > 0) //如果此次读取的字节超过中断点则中断
                        {
                            fstrm.Write(fbytes, 0, breakPoint - sum);
                            dataSocket.Close();//传输成功后关闭数据套接字
                            GetCmdMessage();
                            return "BreakPoint:" + breakPoint.ToString();
                        }
                        else
                        {
                            fstrm.Write(fbytes, 0, num);
                            sum += num;
                        }
                    }

                    return CloseDataSocket();
                }
            }
            else//本地存在该文件则查看是否需要断点续传
            {
                long LocalFileSize = GetLocalFileSize(filePath);//获取本地文件大小
                long FtpFileSize = GetFtpFileSize(fileName);//获取服务器文件大小
                if (LocalFileSize < FtpFileSize)//若服务器文件比本地文件大则启动断点续传
                {
                    DownLoadFileFromBreakPoint(fileName, filePath ,(int) LocalFileSize);
                    return CloseDataSocket();
                }
                else
                    return "Already Finished";
            }
        }
        /// <summary>向FTP服务器上传文件</summary>
        /// <param name="fileName">文件名</param>
        /// <param name="filePath">完整文件路径，包括文件名；当null时默认本地，默认为null</param>
        /// <param name="breakPoint">控制上传的大小</param>
        /// <returns>返回一些上传信息:完成、中断</returns>
        public string UpLoadFile(string fileName,string filePath = null, int breakPoint = 0)//便于测试，加入断点，到断点则停止上传
        {
            if (filePath == null) filePath = fileName;
            long FtpFileSize;
            if ((FtpFileSize = GetFtpFileSize(fileName)) == -1)//云端不存在该文件
            {
                //进入被动模式
                PassiveMode();
                //申请上传命令
                string uplodeCMD = "STOR " + fileName + CRLF;
                cmdSocket.Send(Encoding.UTF8.GetBytes(uplodeCMD));
                GetCmdMessage();
                //打开文件读取数据
                using (FileStream fstrm = new FileStream(filePath, FileMode.Open))
                {
                    byte[] fbytes = new byte[BufferSize];
                    int sum = 0;//计算总共读取了多少文件字节
                    int num;//计算一次读取了多少文件字节
                    while ((num = fstrm.Read(fbytes, 0, BufferSize)) != 0)//没到文件末尾则循环
                    {
                        if (sum + num > breakPoint && breakPoint != 0)//如果此次读取的字节超过中断点则中断
                        {
                            byte[] endBytes = new byte[breakPoint - sum];
                            Array.Copy(fbytes, 0, endBytes, 0, breakPoint - sum);
                            dataSocket.Send(endBytes);
                            dataSocket.Close();//传输成功后关闭数据套接字
                            GetCmdMessage();
                            return "BreakPoint:" + breakPoint.ToString();
                        }
                        else
                        {
                            if (num == BufferSize)//当数组满直接发送
                                dataSocket.Send(fbytes);
                            else//数组不满则只发送前面一部分
                            {
                                byte[] endBytes = new byte[num];
                                Array.Copy(fbytes, 0, endBytes, 0, num);
                                dataSocket.Send(endBytes);
                                break;
                            }

                            sum += num;
                        }
                    }
                }
                return CloseDataSocket();
            }
            else//若ftp服务器存在该文件，则检查是否需要断点续传
            {
                if (FtpFileSize < GetLocalFileSize(filePath))//若服务器文件比本地文件小，则启动断点续传
                {
                    UpLoadFileFromBreakPoint(fileName, filePath, (int)FtpFileSize);
                    return CloseDataSocket();
                }
                else
                {
                    return "File already Finished";
                }
            }
        }
        #endregion

        #region 断点续传
        /// <summary>断点续传：上传</summary>
        /// <param name="fileName">文件名</param>
        /// <param name="filePath">完整文件路径，包括文件名；当null时默认本地，默认为null</param>
        /// <param name="breakPoint">已经上传的大小</param>
        /// /// <returns>返回上传信息</returns>
        public string UpLoadFileFromBreakPoint(string fileName, string filePath, int breakPoint)
        {
            if (filePath == null) filePath = fileName;
            //进入被动模式
            PassiveMode();
            //申请断点续传
            string breakPointCMD = "REST " + breakPoint.ToString() + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(breakPointCMD));
            GetCmdMessage();
            //申请上传命令
            string uplodeCMD = "STOR " + fileName + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(uplodeCMD));
            GetCmdMessage();
            //从断点打开文件读取数据
            using (FileStream fstrm = new FileStream(filePath, FileMode.Open))
            {
                fstrm.Seek(breakPoint, SeekOrigin.Begin);//寻找偏移

                byte[] fbytes = new byte[BufferSize];
                int cnt;//计算读取了多少文件字节
                while ((cnt = fstrm.Read(fbytes, 0, 1024)) != 0)//没到文件末尾则循环
                {
                    if (cnt == BufferSize)//当数组满直接发送
                        dataSocket.Send(fbytes);
                    else//数组不满则只发送前面一部分
                    {
                        byte[] endBytes = new byte[cnt];
                        Array.Copy(fbytes, 0, endBytes, 0, cnt);
                        dataSocket.Send(endBytes);
                        break;
                    }
                }
            }

            return "Finished";
        }
        /// <summary>断点续传:下载</summary>
        /// <param name="fileName">文件名</param>
        /// <param name="filePath">完整文件路径，包括文件名；当null时默认本地，默认为null</param>
        /// <param name="breakPoint">已经下载的大小</param>
        /// /// <returns>返回下载信息</returns>
        public string DownLoadFileFromBreakPoint(string fileName,string filePath, int breakPoint)
        {
            if (filePath == null) filePath = fileName;
            //进入被动模式
            PassiveMode();
            //申请断点续传
            string breakPointCMD = "REST " + breakPoint.ToString() + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(breakPointCMD));
            GetCmdMessage();
            //申请下载命令
            string downCmd = "RETR " + fileName + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(downCmd));
            GetCmdMessage();
            //写入文件
            using (FileStream fstrm = new FileStream(filePath, FileMode.Open))
            {
                byte[] fbytes = new byte[ByteArraySize];
                fstrm.Seek(breakPoint, SeekOrigin.Begin);
                int num;
                while ((num = dataSocket.Receive(fbytes)) != 0)
                {
                    fstrm.Write(fbytes, 0, num);
                }
            }
            return "Finished";
        }
        #endregion

        #region 关闭套接字相关
        /// <summary>关闭数据套接字</summary>
        /// <returns>返回关闭后服务器返回的信息</returns>
        public string CloseDataSocket()
        {
            dataSocket.Close();
            return GetCmdMessage();
        }
        /// <summary>关闭ftp连接</summary>
        /// <returns>返回关闭后服务器返回的信息</returns>
        public string Close()
        {
            string quitCMD = "QUIT" + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(quitCMD));
            string message = GetCmdMessage();
            cmdSocket.Close();
            return message;
        }
        #endregion

        #region  文件列表相关
        /// <summary>获取目录下的所有文件名,返回文件名的list</summary>
        /// <param name="path">目录路径</param>
        /// <returns>返回包含文件名的list</returns>
        public List<string> GetLocalFileList(string path)
        {
            var files = Directory.GetFiles(path, "*.*");//所有文件类型
            List<string> fileList = new List<string>();
            foreach (var file in files)
            {
                string[] temp = Regex.Split(file, @"\\");//取得文件名
                fileList.Add(temp[temp.Length - 1]);
            }

            return fileList;
        }
        /// <summary>获取Ftp服务器的所有文件名</summary>
        /// <returns>返回文件名的list</returns>
        public List<string> GetFtpFileList()
        {
            List<string> ftpFileList = new List<string>();
            //进入被动模式
            PassiveMode();
            //发送查看目录请求
            string listCMD = "LIST" + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(listCMD));
            GetCmdMessage();
            //获取目录内容
            byte[] fbytes = new byte[ByteArraySize];
            string FileInfoList = "";//储存文件信息的字符串
            while ((dataSocket.Receive(fbytes)) != 0)//拼接所有输出
            {
                FileInfoList += Encoding.Default.GetString(fbytes);
            }
            string[] fileLineArray = Regex.Split(FileInfoList, "\n");//换行符分割每个文件信息
            foreach (var fileInfo in fileLineArray)//再次分割获取文件名
            {
                Regex regex = new Regex("\\s+");
                string[] fileInfoSplit = regex.Split(fileInfo, 4);
                string fileName = fileInfoSplit[fileInfoSplit.Length - 1];
                ftpFileList.Add(fileName.Substring(0,fileName.Length-1));
            }
            ftpFileList.RemoveAt(ftpFileList.Count-1);//丢弃最后一个空白输出
            CloseDataSocket();
            return ftpFileList;
        }
        /// <summary>返回本地文件的大小</summary>
        /// <param name="fileName">完整文件名，包括路径</param>
        /// <returns>long型文件大小，单位B</returns>
        public long GetLocalFileSize(string fileName)
        {
            if (!File.Exists(fileName)) return -1;//文件不存在返回-1
            FileInfo fileInfo = new FileInfo(fileName);
            return fileInfo.Length;
        }

        /// <summary>返回ftp服务器文件大小</summary>
        /// <param name="fileName">文件名</param>
        /// <returns>long型文件大小，单位B</returns>
        public long GetFtpFileSize(string fileName)
        {
            //获取文件大小的命令
            string SizeCMD = "SIZE " + fileName + CRLF;
            cmdSocket.Send(Encoding.UTF8.GetBytes(SizeCMD));
            string message = GetCmdMessage();
            //获取服务器返回的响应码
            int RCode = GetRCode();
            if (RCode == 550 || RCode == 451)//响应码错误
            {
                GetCmdMessage();//吞入服务器报错信息
                return -1;
            }
            //响应码正确则分割输出
            string[] messageSplit = Regex.Split(message, " ");
            long fileSize = long.Parse(messageSplit[messageSplit.Length - 1]);
            return fileSize;
        }
        #endregion
    }
}
