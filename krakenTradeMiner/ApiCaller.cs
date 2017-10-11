using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace krakenTradeMiner
{
    public interface IApiCall
    {
        string CallApi(string url, out string exception);
    }

    public class ApiCall : IApiCall
    {
        public string CallApi(string url, out string exception)
        {
            Task<string> result = null;
            exception = string.Empty;

            using (var http = new HttpClient())
            {
                try
                {
                    result = http.GetStringAsync(url);
                }
                catch(Exception ex)
                {
                    exception = ex.ToString();
                }
                
                return result.Result;
            }
        }

        //public string CallApi(string url, out long timeTaken)
        //{
        //    using (var http = new HttpClient())
        //    {
        //        var sw = new Stopwatch();
        //        sw.Start();

        //        var result = new HttpClient().GetStringAsync(url);

        //        sw.Stop();
        //        timeTaken = sw.ElapsedMilliseconds;

        //        return result.Result;
        //    }
        //}
    }
}