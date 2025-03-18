using System;
using NETtime.WinCE.Globals;

namespace NETtime.WinCE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.Init(Array.IndexOf<string>(args, "/debug") > -1);
            }
            catch (Exception ex)
            {
              
            }
        }

    }
}