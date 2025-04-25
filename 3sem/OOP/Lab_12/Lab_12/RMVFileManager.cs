using System.IO.Compression;
using System.IO;
using System.Linq;

namespace Lab12
{
    /*5. Создать класс XXXFileManager. Набор методов определите самостоятельно. С его помощью выполнить следующие действия:
        a. Прочитать список файлов и папок заданного диска. Создать директорий XXXInspect, создать текстовый файл xxxdirinfo.txt и сохранить туда информацию. Создать копию файла 
        и переименовать его. Удалить первоначальный файл.
        b. Создать еще один директорий XXXFiles. Скопировать в него все файлы с заданным расширением из заданного  пользователем директория. Переместить XXXFiles в XXXInspect.
        c. Сделайте архив из файлов директория XXXFiles. Разархивируйте его в другой директорий.*/
    public static class RMVFileManager
    {
        public static void InspectDriver(string driverName)
        {
            Directory.CreateDirectory(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect");
            File.Create(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVdirinfo.txt").Close();
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driverName);

            using (StreamWriter file = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVdirinfo.txt"))
            {
                file.WriteLine("Список папок:");
                foreach (var s in currentDrive.RootDirectory.GetDirectories())
                {
                    file.WriteLine(s);
                }
                file.WriteLine("Список файлов:");
                foreach (var f in currentDrive.RootDirectory.GetFiles())
                {
                    file.WriteLine(f);
                }
            }

            File.Copy(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVdirinfo.txt", @"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVdirinfoCopy.txt", true);
            File.Delete(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVdirinfo.txt");
        }

        public static void CopyFiles(string path, string extention)
        {
            Directory.CreateDirectory(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVFiles");
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo directory2 = new DirectoryInfo(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVFiles\");
            foreach (var f in directory.GetFiles())
            {
                if (f.Extension == extention)
                    f.CopyTo(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVFiles\" + f.Name + extention, true);
            }
            if (!directory2.Exists)
                Directory.Move(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVFiles\", @"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVFiles\");
            else
                Directory.Delete(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVFiles\", true);
        }

        public static void CreateArchive(string dir)
        {
            string name = @"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect\RMVFiles";
            if (new DirectoryInfo(@"D:\Univer\2 kurs\OOP\Lab_12\Lab_12\RMVInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(name, name + ".zip");
                DirectoryInfo direct = new DirectoryInfo(dir);
                foreach (var innerFile in direct.GetFiles())
                    innerFile.Delete();
                direct.Delete();
                ZipFile.ExtractToDirectory(name + ".zip", dir);
            }
        }
    }
}