using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.FtpClient;

namespace MantisTests
{
    public class FtpHelper : HelperBase
    {
        private FtpClient ftpClient;
        public FtpHelper(AppManager manager) : base(manager) 
        {
            ftpClient = new FtpClient();
            ftpClient.Host = "localhost";
            ftpClient.Credentials = new System.Net.NetworkCredential("mantis", "mantis");
            ftpClient.Connect();
        }

        public void BackupFile(string filePath)
        {
            string backupPath = filePath + ".bak";
            if (ftpClient.FileExists(backupPath))
            {
                return;
            }
            ftpClient.Rename(filePath, backupPath);
        }

        public void RestoreFile(string filePath) 
        {
            string backupPath = filePath + ".bak";
            if (! ftpClient.FileExists(backupPath))
            {
                return;
            }
            if (ftpClient.FileExists(filePath))
            {
                ftpClient.DeleteFile(filePath);
            }
            ftpClient.Rename(backupPath, filePath);
        }

        public void UploadFile(string filePath, Stream localFile)
        {
            if (ftpClient.FileExists(filePath))
            {
                ftpClient.DeleteFile(filePath);
            }
            using (Stream ftpStream = ftpClient.OpenWrite(filePath))
            {
                byte[] buffer = new byte[8 * 1024];
                int count = localFile.Read(buffer, 0, buffer.Length);
                while (count > 0)
                {
                    ftpStream.Write(buffer, 0, count);
                    count = localFile.Read(buffer, 0, buffer.Length);
                }
            }

        }
    }
}
