using System;
using System.Net;
using System.IO;

namespace NETtime.WinCE.APIManagers
{
    static class WebStatusHelper
    {
        //public enum HttpStatus
        //{
        //    Checking,
        //    OK,
        //    Disconnected,
        //    ComDown
        //}

        //public delegate void StatusChangedCallback();
        //private delegate bool Callback();

        //private static bool _initialized = false;
        //private static HttpStatus _Status = HttpStatus.Checking;

        //private static Notifier notify;

        //public static void Init()
        //{
        //    if (!_initialized)
        //    {
        //        _Status = HttpStatus.Checking;

        //        notify = new Notifier(new Notifier.Start(delegate ()
        //        {
        //            SetStatus(HttpStatus.Checking);
        //        }));
        //        notify.MaxDelay = 10000;
        //        _initialized = true;
        //    }
        //}

        public static HttpStatusCode CheckWebServerStatus(string serviceURL)
        {
            //WebRequest requestTest = WebRequest.Create("https://checkip.amazonaws.com");
            //using (WebResponse response = requestTest.GetResponse())
            //    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //    {
            //        string publicIP = reader.ReadToEnd().Trim();
            //        Console.WriteLine("Public IP: " + publicIP);
            //    }

            HttpStatusCode returnCode = new HttpStatusCode();
            HttpWebRequest request = System.Net.WebRequest.Create(serviceURL.Replace("ws-soap", "ws-json") + "/CheckServerStatus") as HttpWebRequest;

            request.AllowAutoRedirect = false;
            request.Timeout = 20000;
            //if (Configuration.CurrentConfiguration.ProxyEnabled)
            //{
            //    WebProxy proxy = new WebProxy(Configuration.CurrentConfiguration.WebProxyServer, Configuration.CurrentConfiguration.WebProxyPort);
            //    if (Configuration.CurrentConfiguration.WebProxyUsername != "")
            //    {
            //        proxy.Credentials = new NetworkCredential(Configuration.CurrentConfiguration.WebProxyUsername, Configuration.CurrentConfiguration.WebProxyPassword, Configuration.CurrentConfiguration.WebProxyDomain);
            //    }
            //    request.Proxy = proxy;
            //}

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    HttpStatusCode code = response.StatusCode;
                    response.Close();
                    returnCode = response.StatusCode;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                GC.Collect();
            }

            return returnCode;
        }

        //public static bool CheckStatus()
        //{
        //    try
        //    {
        //        if (_Status == HttpStatus.OK)
        //        {
        //            notify.Restart();
        //        }

        //        if (NetworkInterface.IsConnected)
        //        {
        //            if (Configuration.CurrentConfiguration.CommMode == CommMode.Ping)
        //            {
        //                using (var ping = new Ping())
        //                {
        //                    var host = new Uri(Configuration.CurrentConfiguration.WebserviceURL).Host;

        //                    var pingReply = ping.Send(host);

        //                    if (pingReply.Status == IPStatus.Success)
        //                    {
        //                        SetStatus(HttpStatus.OK);
        //                        notify.Abort();
        //                        return true;
        //                    }
        //                    else
        //                    {
        //                        SetStatus(HttpStatus.ComDown);
        //                        notify.Abort();
        //                        return false;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                SetStatus(HttpStatus.OK);
        //                notify.Abort();
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            notify.Abort();
        //            SetStatus(HttpStatus.Disconnected);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.AddErrorLog(ex);

        //        notify.Abort();
        //        SetStatus(HttpStatus.ComDown);
        //        return false;
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}

        //public static HttpStatus Status
        //{
        //    get { return _Status; }
        //}

        //public static StatusChangedCallback StatusChanged
        //{
        //    get;
        //    set;
        //}

        //private static void SetStatus(HttpStatus status)
        //{
        //    if (_Status != status)
        //    {
        //        _Status = status;
        //        if (StatusChanged != null)
        //            StatusChanged();
        //    }
        //}
    }
}