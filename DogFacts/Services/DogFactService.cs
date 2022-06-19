using ClosedXML.Excel;
using DogFacts.Models;
using DogFacts.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFacts.Services
{
    public class DogFactService : BaseService
    {
        private HttpClient Client { get; }

        public DogFactService() : base() 
        {
            Client = new HttpClient();
        }

        public virtual async Task<DogFact?> Get(int count, CancellationToken ct = default)
        {
            var endpoint = new Uri(Settings.Default.Endpoint.Replace("#", count.ToString()));

            var result = await Client.GetAsync(endpoint, ct);

            if (result == null || !result.IsSuccessStatusCode)
            {
                throw new Exception("Não foi possivel acessar o endpoint.");
            }

            var content = await result.Content.ReadAsStringAsync(ct);
            return JsonConvert.DeserializeObject<DogFact>(content);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    Client.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
