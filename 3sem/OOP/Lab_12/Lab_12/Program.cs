using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*****************************************************************************************************");
                RMVDiskInfo.WriteDiskInfo("D:\\");
                RMVLog.WriteInLog("RMVDiskInfo.getFreeDrivesSpace()");

                Console.WriteLine("******************************************************************************************************");
                RMVFileInfo.WriteFileInfo(@"D:\Univer\2 kurs\OOP\Lab_12\12_Потоки_файловая система.pdf");
                RMVLog.WriteInLog("RMVFileInfo.WriteFileInfo()", "RMVLogfile.txt", @"D:\Univer\2 kurs\OOP\Lab_12\RMVLogfile.txt");

                Console.WriteLine("******************************************************************************************************");
                RMVDirInfo.WriteDirInfo(@"D:\Univer\2 kurs\OOP");
                RMVLog.WriteInLog("RMVDirInfo.WriteDirInfo()", @"D:\Univer\2 kurs\OOP");

                RMVFileManager.InspectDriver("D:\\");
                RMVLog.WriteInLog("RMVFileManager.InspectDriver()", "D:\\");
                RMVFileManager.CopyFiles(@"D:\Univer\2 kurs\OOP\Lab_12", ".txt");
                RMVLog.WriteInLog("RMVFileManager.CopyFiles()", @"D:\Univer\2 kurs\OOP\Lab_12");
                RMVFileManager.CreateArchive(@"D:\Univer\2 kurs\OOP\Lab_12\Lab12\ForArchive");
                RMVLog.WriteInLog("RMVFileManager.CreateArchive()");

                RMVLog.FindInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}