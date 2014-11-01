using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace TranslateChineseByStep
{
    public class MyPostGet
    {
        public string UserAgent { get; set; }

        public string Accept { get; set; }

        public string ContentType { get; set; }
        public bool Sleep { get; set; }


        public CookieContainer _cookies;

        public string ResponseUrl { get; set; }

        public MyPostGet(bool sleep)
        {
            this.Sleep = sleep;
            this.ContentType = "application/x-www-form-urlencoded";
            this.UserAgent = "Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_2 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8H7 Safari/6533.18.5";
            this.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            _cookies = new CookieContainer();
        }

        public string POST(string url, string postData)
        {
            string str = string.Empty;
            System.Net.ServicePointManager.Expect100Continue = false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = this.Accept;
            request.KeepAlive = true;
            request.Timeout = 60000;
            request.ReadWriteTimeout = 60000;
            request.Method = "POST";
            request.UserAgent = this.UserAgent;
            request.KeepAlive = true;
            //request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,vi;q=0.6");
            request.KeepAlive = true;
            request.CookieContainer = this._cookies;
            request.ContentType = this.ContentType;
            byte[] tmp = System.Text.Encoding.ASCII.GetBytes(postData);
            request.ContentLength = tmp.Length;
            try
            {

                System.Net.ServicePointManager.Expect100Continue = false; // prevents 417 error

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(tmp, 0, tmp.Length);
                }

                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {

                        ResponseUrl = response.ResponseUri.ToString();
                        using (Stream stream2 = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream2, Encoding.UTF8))
                            {
                                str = System.Net.WebUtility.HtmlDecode(reader.ReadToEnd());
                            }

                        }

                    }
                    //}    
                }
                catch (WebException ex)
                {

                    WebResponse wre;
                    if ((wre = ex.Response) != null)
                    {
                        using (Stream stream3 = wre.GetResponseStream())
                        {
                            using (StreamReader read = new StreamReader(stream3))
                            {
                                str = System.Net.WebUtility.HtmlDecode(read.ReadToEnd());
                            }
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;
        }
        public Image GET(string url)
        {
            Image bitImage = null;
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = this.Accept;
                request.KeepAlive = true;
                request.Timeout = 60000;
                request.ReadWriteTimeout = 60000;
                request.Method = "GET";
                request.UserAgent = this.UserAgent;
                request.CookieContainer = this._cookies;
                request.Referer = url;
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            bitImage = Bitmap.FromStream(stream);
                        }
                        //}
                    }
                }
                catch (WebException ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
            return bitImage;
        }
        public string GET(string url, string referer)
        {
            if (this.Sleep)
            {
                Thread.Sleep(1000);
            }
            string str = string.Empty;
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = this.Accept;
                request.KeepAlive = true;
                request.Timeout = 60000;
                request.ReadWriteTimeout = 60000;
                request.Method = "GET";
                request.UserAgent = this.UserAgent;
                request.CookieContainer = this._cookies;
                request.Referer = url;
                //request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate,sdch");
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8,vi;q=0.6");
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        ResponseUrl = response.ResponseUri.ToString();
                        using (Stream stream2 = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream2, Encoding.UTF8))
                            {
                                str = System.Net.WebUtility.HtmlDecode(reader.ReadToEnd());
                            }

                        }
                    }
                }
                catch (WebException ex)
                {

                    str = string.Empty;
                    throw ex;
                }
            }
            catch (Exception ex)
            {

                //throw ex;
                str = string.Empty;
                //throw ex;
            }
            return str;
        }
    }
}
