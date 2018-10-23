using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WindowHelper.Delete
{
    public class DeleteManager
    {
        private static string username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private static FileSystemAccessRule access = new FileSystemAccessRule(username, FileSystemRights.FullControl, AccessControlType.Allow);
        private static int deleted = 0;
        private static void SetAccessRight(FileInfo file)
        {
            var accessControl = file.GetAccessControl();
            accessControl.AddAccessRule(access);
            file.SetAccessControl(accessControl);
            file.Attributes = FileAttributes.Normal;
        }
        private static void SetAccessRight(DirectoryInfo directory)
        {
            var accessControl = directory.GetAccessControl();
            accessControl.AddAccessRule(access);
            directory.SetAccessControl(accessControl);
            directory.Attributes = FileAttributes.Normal;
        }

        private static void Delete(FileInfo file)
        {
            try
            {
                SetAccessRight(file);
                file.Delete();
                deleted++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void Delete(DirectoryInfo directory)
        {
            try
            {
                var listSubDirs = directory.GetDirectories();
                foreach (var d in listSubDirs)
                {
                    Delete(d);
                    deleted++;
                }
                var listSubFiles = directory.GetFiles();
                foreach (var f in listSubFiles)
                {
                    Delete(f);
                }
                SetAccessRight(directory);
                directory.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int Delete(string path)
        {
            deleted = 0;
            if (File.Exists(path))
                Delete(new FileInfo(path));
            else if (Directory.Exists(path))
                Delete(new DirectoryInfo(path));
            else Console.WriteLine("Path doesn't exist");
            return deleted;
        }

    }
}
