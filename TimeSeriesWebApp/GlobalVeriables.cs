using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TimeSeriesWebApp
{
    public static class GlobalVeriables
    {
        public static HttpClient timeSeriesApiClient = new HttpClient();

        static GlobalVeriables()
        {
            timeSeriesApiClient.BaseAddress = new Uri("https://localhost:44346/api/");
            timeSeriesApiClient.DefaultRequestHeaders.Clear();
            timeSeriesApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
