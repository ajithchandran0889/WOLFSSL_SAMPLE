using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using NETtime.WinCE.APIManagers;

namespace NETtime.WinCE.Globals
{
    static class Application
    {
    

        public static void Init(bool withTrace)
        {

            try
            {

                //Do TLS 1.2 Handshake here
                WOLFSSLWrapper.ConnectToServer();
                WebStatusHelper.CheckWebServerStatus("https://stratus-clock-n2a.cloud.paychex.com/Service/ws-soap/internal");
              
            }
            catch (Exception ex)
            {
                //Failed(ex);
            }
        }
    }
}
