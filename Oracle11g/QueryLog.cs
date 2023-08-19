using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace Oracle11g
{
    class QueryLog
    {
        /// <summary>
        /// enum
        /// </summary>
        public enum LOGTYPE
        {
            TEXT,
            XML
        }

        private string m_LogPath = System.AppDomain.CurrentDomain.BaseDirectory;
        private string m_LogName;

        /// <summary>
        /// LOGNAME
        /// </summary>
        public string LOGNAME
        {
            get
            {
                return m_LogName;
            }
            set
            {
                m_LogName = value;
            }
        }

        /// <summary>
        /// Logging
        /// </summary>
        /// <param name="logLabel"></param>
        /// <param name="logData"></param>
        /// <param name="result"></param>
        /// <param name="logType"></param>
        public void Logging(
            string logLabel,
            string logData,
            string result,
            LOGTYPE logType
            )
        {
            XmlWriterSettings xSetting = null;
            XmlDocument xDoc = null;
            StringBuilder logWriter = null;
            string filePath = string.Empty;

            try
            {
                logWriter = new StringBuilder();
                logWriter.Append("\r\n==========================================================================================\r\n");
                logWriter.Append("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] ");
                logWriter.Append("[" + logLabel + " / " + result + "]");
                logWriter.Append("\r\n==========================================================================================\r\n");
                // --
                DirectoryCheck();


                filePath = m_LogPath + "Log\\" + "_" + DateTime.Now.ToString("yyyyMMdd-HH") + ".log";
                // --
                if (!Directory.Exists(m_LogPath + "Log\\"))
                {
                    Directory.CreateDirectory(m_LogPath + "Log\\");
                }
                

                // --

                if (logType == LOGTYPE.XML)
                {
                    //XML Null Character
                    logData = logData.Replace("&#x0;", "\\0");

                    xSetting = new XmlWriterSettings();
                    xSetting.Indent = true;
                    xSetting.OmitXmlDeclaration = true;

                    // --
                    using (XmlWriter xWriter = XmlTextWriter.Create(logWriter, xSetting))
                    {
                        xDoc = new XmlDocument();
                        xDoc.LoadXml(logData);
                        xDoc.Save(xWriter);
                        xWriter.Close();
                    }
                }
                else
                {
                    logWriter.Append(logData);
                }

                // --
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(logWriter.ToString());
                    sw.Close();
                }
            }
            catch
            {

            }
            finally
            {
                xSetting = null;
                xDoc = null;
                logWriter = null;
            }
        }

        /// <summary>
        /// DirectoryCheck
        /// </summary>
        private void DirectoryCheck(
            )
        {
            if (m_LogPath == string.Empty)
            {
                m_LogPath = Application.StartupPath + "\\Log";
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(m_LogPath);

                if (dirInfo.Exists == false)
                {
                    dirInfo.Create();
                }
            }

        }
    }
}
