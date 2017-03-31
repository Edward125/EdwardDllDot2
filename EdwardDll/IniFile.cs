using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Edward
{
    /// <summary>
    /// INI文件的操作类
    /// </summary>
    public class IniFile
    {

        /// <summary>
        /// ini file path value
        /// </summary>
        public  static  string iniFilePathValue;

        /// <summary>
        /// set/get ini file path value
        /// </summary>
        public static string IniFilePath
        {
            get
            {
                return iniFilePathValue;
            }

            set
            {
                iniFilePathValue = value;
            }
        }


   

#region declare Read_Write ini file API

    [DllImport ("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath); 

    [DllImport ("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath); 
	#endregion

#region Write INI file
        /// <summary>
        /// 写INI文件
        /// </summary>
       /// <param name="section">段落</param>
       /// <param name="key">键</param>
       /// <param name="iValue">值</param>
       /// <param name="filePath">ini文件地址</param>
		
        public static  void IniWriteValue(string section,string key,string iValue,string filePath)
        {
            WritePrivateProfileString (section,key,iValue,filePath);
        }

        /// <summary>
        ///  Write INI File
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="iValue">值</param>
        public static void IniWriteValue(string section, string key, string iValue)
        {
            if (!string.IsNullOrEmpty(iniFilePathValue))
            {

                WritePrivateProfileString(section, key, iValue, iniFilePathValue);
            }
            else
            {
                throw (new ArgumentNullException("Write INI File", "INI file path can't be null or empty,please assign INI file path again!"));
            }
        }
	#endregion

#region Read INI file

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="filePath">ini文件的地址</param>      
        public static  string IniReadValue(string section, string key,string filePath) 
        { 
           StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, filePath ); 
            return temp.ToString();
        }



        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        public static string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            if (!string.IsNullOrEmpty(iniFilePathValue))
            {
                int i = GetPrivateProfileString(section, key, "", temp, 255, iniFilePathValue);
            }
            else
            {
                throw (new ArgumentNullException("Read INI file", "INI file path can't be null or empty,please assign INI file path again!"));
            }
            return temp.ToString();
        }

	#endregion

        #region CreateIniFile

        /// <summary>
        /// create ini file
        /// </summary>
        /// <param name="filePath">ini file path</param>
        public static void  CreateIniFile(string filePath)
        {

            if (!string.IsNullOrEmpty(filePath))
            {
                //check file exits

                if (!File.Exists(filePath))
                {
                    //file is not exits,create it
                    try
                    {
                        FileStream fs = File.Create(filePath);
                        fs.Close();
                    }
                    catch (Exception e)
                    {                        
                        throw e;
                    }                  

                }
            }

            else  //file path is null or empty
            {
                throw (new ArgumentNullException("Read INI file", "INI file path can't be null or empty,please assign INI file path again!"));
               
            }
       

        }

        /// <summary>
        /// create ini file
        /// </summary>
        public static void CreateIniFile()
        {

            if (!string.IsNullOrEmpty(iniFilePathValue))
            {
                //check file exits

                if (!File.Exists(iniFilePathValue ))
                {
                    //file is not exits,create it
                    try
                    {
                        FileStream fs = File.Create(iniFilePathValue );
                        fs.Close();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                }
            }

            else  //file path is null or empty
            {
                throw (new ArgumentNullException("Read INI file", "INI file path can't be null or empty,please assign INI file path again!"));

            }


        }

        #endregion



    }    

}
