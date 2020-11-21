using Newtonsoft.Json;
using QuotesAppPrism.Interfaces;
using QuotesAppPrism.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuotesAppPrism.Services
{
    public class QuotesApi : IQuote
    {
        public async Task<List<Quote>> GetQuotes()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://quotessamplerestfulwebapi.azurewebsites.net/api/quotes");
            return JsonConvert.DeserializeObject<List<Quote>>(response);
        }
    }
}
