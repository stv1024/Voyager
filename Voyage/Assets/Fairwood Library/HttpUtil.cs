using System;
using System.IO;
using System.Net;

namespace Fairwood.Util
{

    public class HttpUtil
    {
        public HttpUtil()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">形如www.iguandan.com/....前面不要加http://</param>
        /// <returns></returns>
        public string HttpGet(string url)
        {
            try
            {
                var request = WebRequest.Create(url) as HttpWebRequest;
                if (request != null)
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        if (response == null)
                        {
                            return null;
                        }
                        var reader = new StreamReader(response.GetResponseStream());
                        string result = null;
                        result = reader.ReadToEnd();
                        reader.Close();
                        response.Close();
                        return result;
                    }
            }
            catch
            {
            }
            return null;
        }

    }
    public static class UriUtil
    {
        public static string GetUrlFromLocalPath(string path)
        {
            if (path.Contains(":/")) return path;
            var prefix = path.StartsWith("/") ? "file://" : "file:///";
            var url = prefix + path;
            return url;
        }
    }
}