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

            //Console.WriteLine(myFtp.DownLoadFile("hello.txt", 500));
            //Console.WriteLine(myFtp.DownLoadFileFromBreakPoint("hello.txt",500));
            //Console.WriteLine(myFtp.UpLoadFile("ttt.pptx", 1500));
            Console.WriteLine(myFtp.UpLoadFileFromBreakPoint("ttt.pptx", 1500));

            Console.WriteLine(myFtp.CloseDataSocket());
            Console.WriteLine(myFtp.Close());
        }
    }
}
