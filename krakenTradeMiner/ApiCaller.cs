using System;
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
                    return string.Empty;
                }
                
                return result.Result;
            }
        }

    }
}