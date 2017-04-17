using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Windows.Forms;

namespace Edward
{
    /// <summary>
    /// 其他一些常用操作
    /// </summary>
   public static class Other
    {
        #region checkTime

        /// <summary>
        /// check time
        /// </summary>
        /// <param name="str">encrpt date</param>
        /// <returns></returns>
        public static bool checkTime(string str)
        {
            DateTime t = Convert.ToDateTime(DES.DesDecrypt(str, "Edward86"));

            if (File.Exists("C:\\Windows\\System32\\" + System.Windows.Forms.Application.ProductName + ".dll"))
            {
                return false;
            }
            FileInfo[] files = new DirectoryInfo("C:\\").GetFiles();
            int index = 0;
            while (index < files.Length)
            {
                if (DateTime.Compare(files[index].LastAccessTime, t) > 0)
                {
                    FileStream iniStram = File.Create("C:\\Windows\\System32\\" + System.Windows.Forms.Application.ProductName + ".dll");
                    iniStram.Close();
                    return false;
                }
                checked { ++index; }
            }
            return true;

        }
        #endregion

        #region pingIP
        /// <summary>
        /// ping一個IP地址,看是否能連接通
        /// </summary>
        /// <param name="address">IP地址</param>
        /// <returns>ping通返回True,ping不通返回false</returns>
        public static Boolean pingIp(string address)
        {
            if (string.IsNullOrEmpty(address))
                return false;

            Ping ping = null;
            try
            {
                ping = new Ping();

                var pingReply = ping.Send(address);
                if (pingReply == null)
                    return false;

                return pingReply.Status == IPStatus.Success;
            }
            finally
            {
                if (ping != null)
                {
                    // 2.0 下ping 的一个bug，需要显示转型后释放
                    IDisposable disposable = ping;
                    disposable.Dispose();

                    ping.Dispose();
                }
            }
        }
        #endregion

        #region Asc Chr convert
        /// <summary>
        /// convert the asc code to character
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }

        }

        /// <summary>
        /// convert the character to Asc code
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("Character is not valid.");
            }
        }
        #endregion


        #region DeleteMyself
		 
        /// <summary>
        /// delete myselef
        /// </summary>
        public static void DelMe()
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "remove.bat");

            StreamWriter bat = new StreamWriter(fileName, false, Encoding.Default);
            bat.WriteLine(string.Format("del \"{0}\" /q", Application.ExecutablePath));
            bat.WriteLine(string.Format("del \"{0}\" /q", fileName));
            bat.Close();
            File.SetAttributes(fileName, FileAttributes.Hidden);
            ProcessStartInfo info = new ProcessStartInfo(fileName);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
            Environment.Exit(0);
        }

        #endregion

    }
}
