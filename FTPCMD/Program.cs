using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FTPCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFTP myFtp = new MyFTP();
            Console.WriteLine(myFtp.Connect(ConfigurationManager.AppSettings["MyFtpIP"]));

            Console.WriteLine(myFtp.LoginIn(ConfigurationManager.AppSettings["MyUserName"], ConfigurationManager.AppSettings["MyPassWord"]));
            Console.WriteLine(myFtp.SetUTF8());

            //Console.WriteLine(myFtp.GetFtpFileSize("www - 副本.ppt"));

            //Console.WriteLine(myFtp.GetFtpExtAttr());
            //Console.WriteLine(myFtp.DownLoadFile("hello3.txt"));
            //Console.WriteLine(myFtp.GetFtpFileSize("www-副本.ppt"));
            //Console.WriteLine(myFtp.GetLocalFileSize("www-副本.ppt"));
            //Console.WriteLine(myFtp.DownLoadFile("www - 副本.ppt", @"E:\C sharp\NetWorkFtpWithSocket\FTPCMD\bin\www - 副本.ppt"));
            //Console.WriteLine(myFtp.UpLoadFile("www - 副本.ppt", @"E:\C sharp\NetWorkFtpWithSocket\FTPCMD\bin\www - 副本.ppt"));
            //Console.WriteLine(myFtp.UpLoadFileFromBreakPoint("ttt.pptx", 1500));
            //List<string> ftpFileList = myFtp.GetFtpFileList();
            //foreach (var x in ftpFileList)
            //{
            //    Console.WriteLine(x);
            //}
            //Console.WriteLine(myFtp.CloseDataSocket());
            Console.WriteLine(myFtp.Close());

            //List<string> localFileList = myFtp.GetLocalFileList(@"E:\C sharp\NetWorkFtpWithSocket\FTPCMD");
            //foreach (var x in localFileList)
            //{
            //    Console.WriteLine(x);
            //}


        }
    }
}
