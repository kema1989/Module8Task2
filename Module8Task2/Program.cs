using System;
using System.IO;

namespace Module8Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirPath = @"C:\Users\YOGA\Documents\Electronic Arts";
            DirectoryInfo dirSpace = new DirectoryInfo(dirPath);
            try
            {
                long size = 0;
                if (dirSpace.Exists)
                {
                    long totalsize = EvaluateSpace(size, dirSpace);
                    Console.WriteLine($"Папка {dirSpace} занимает {totalsize} байт");
                }
                else
                {
                    Console.WriteLine("Такой папки нет...");
                }
            }
            catch (Exception ex)
            {
                if(ex is UnauthorizedAccessException)
                {
                    Console.WriteLine("Нет прав доступа...");
                }
            }
        }
        static long EvaluateSpace(long size, DirectoryInfo dirSpace)
        {
            foreach (FileInfo file in dirSpace.GetFiles())
            {
                size += file.Length;
            }
            foreach (DirectoryInfo papka in dirSpace.GetDirectories())
            {
                size += EvaluateSpace(0, papka);
            }
            return size;
        }
    }
}
