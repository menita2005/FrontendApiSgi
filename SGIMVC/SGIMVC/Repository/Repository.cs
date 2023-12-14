using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using SGIMVC.Repository.Interfaces;
using System.Collections;
using System.Text.Json.Serialization;

namespace SGIMVC.Repository
{
    public class Repository<T> : Interfaces.IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Repository(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public Task<bool> DeleteAsync(string url, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);  
            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage responseMessage = client.SendAsync(request).Result;

            if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                var jsonString =  await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable>(jsonString);
            }
            else
            {
                return null;
            }
        }

        public Task<T> GetByIdAsync(string url, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostAsync(string url, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(string url, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
