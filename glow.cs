using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace gmod_glow
{
    //gmod-glow by (c) Hirako Shiniji

    //Assembled in C#.NET 

    //Last Signed 13/2019

    //WARNING: This is an beta version just for testing purposes! im not responsible any problem you had by using my software because it's for educational purposes.

    //you can get banned from VAC secured servers by using this im not giving you any guarantees! have fun -hirako


    class Program
    {
        // WriteMemory Import
        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr ppHandle, IntPtr lpAddress, byte[] bytes, int length, int written = 0);

        [DllImport("kernel32.dll")]
        public static extern int ReadProcessMemory(IntPtr ppHandle, long lpAddress, byte[] bytes, int length, int written = 0);

        [DllImport("kernel32.dll")]
        private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        static long client = 0;
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int AllAccess, bool nonimportant, int ppid);

        static IntPtr handle;
        static byte[] nol;
        static int reset = 0;
        static void Main(string[] args)
        {

            Process[] gmod_proc = Process.GetProcessesByName("hl2");
            if (gmod_proc.Length < 0)
            {
                Console.WriteLine("Start garry's mod before running the hack...");
                Console.ReadKey();
               
                    }
                    else
            {
                        long baseaddress = 0;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Title = "Glow by (c) Hirako Shiniji";
                        Console.WriteLine("gmod-glow C# by (c) Hirako Shiniji - Version 1.0.0");

                        Console.ForegroundColor = ConsoleColor.White;
        
                Console.WriteLine("----------------------------------------------------");

                System.Diagnostics.Process gmod = System.Diagnostics.Process.GetProcessesByName("hl2")[0];
                handle = OpenProcess(0x001F0FFF, true, gmod.Id);
                var gmodMEM = System.Diagnostics.Process.GetProcessesByName("hl2")[0];
                foreach (System.Diagnostics.ProcessModule dll in gmodMEM.Modules)
                {
                    baseaddress = dll.BaseAddress.ToInt32();
                    String eror = "";



                    if (dll.ModuleName == "client.dll")
                    {
                        Console.WriteLine("client.dll: 0x" + dll.BaseAddress.ToString("X").ToUpper());
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("player index: 0x67E8E8");
                        Console.WriteLine("----------------------------------------------------");
                        byte[] glow_index = new byte[] { 0x83, 0x78, 0x30, 0x02, 0x8B, 0x45, 0x08 };
                        Console.WriteLine("old glow index: ");
                        for (; ; )
                        {
                            try
                            {
                                bool glow_toggle = false;
                                if (Console.ReadLine().Contains("ON"))
                                {
                                    glow_toggle = true;
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.Clear();
                                    Console.WriteLine("new glow index: ");
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine("kmem-structure: ");
                                    Console.WriteLine("--------------------Player Menu------------------------");
                                    Console.WriteLine("ESP > OFF");

                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("gmod-glow C# by (c) Hirako Shiniji - Version 1.0.0");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("----------------------------------------------------");

                                    Console.WriteLine("new glow index: ");
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine("kmem-structure: ");
                                    Console.WriteLine("--------------------Player Menu------------------------");
                                    Console.WriteLine("ESP > ON");
                                    //vam.WriteUInt32((IntPtr)dll.BaseAddress + 0x121B61, 2425393296);
                                    uint kek;
                                    VirtualProtectEx(handle, dll.BaseAddress + 0x121B61, (UIntPtr)((ulong)((long)4)), 0x40, out kek);
                                    WriteProcessMemory(handle, dll.BaseAddress + 0x121B61, new byte[] { 0x90, 0x90, 0x90, 0x90 }, 4, 0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("gmod-glow C# by (c) Hirako Shiniji - Version 1.0.0");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine("new glow index: ");
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine("kmem-structure: ");
                                    Console.WriteLine("--------------------Player Menu------------------------");
                                    //Console.WriteLine("ESP > OFF");
                                    uint kek;
                                    VirtualProtectEx(handle, dll.BaseAddress + 0x121B61, (UIntPtr)((ulong)((long)4)), 0x40, out kek);
                                    WriteProcessMemory(handle, dll.BaseAddress + 0x121B61, new byte[] { 0x83, 0x78, 0x30, 0x02 }, 4, 0);
                                }




                            }





                            catch (Exception ex)
                            {
                                eror = ex.Message;
                                System.Windows.Forms.MessageBox.Show(ex.Message + " " + ex.Data);
                            }

                        }

                    }
          
              

                }


            }
        }
    }
}
