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
            //Test
            MyFTP myFtp = new MyFTP();
            myFtp.Connect(ConfigurationManager.AppSettings["MyFtpIP"]);
            myFtp.LoginIn(ConfigurationManager.AppSettings["MyUserName"], ConfigurationManager.AppSettings["MyPassWord"]);
            Console.WriteLine(myFtp.DownLoadFileFromBreakPoint("hello3.txt", null, 500));
            //Console.WriteLine(myFtp.CloseDataSocket());
            myFtp.Close();
        }
    }
}
