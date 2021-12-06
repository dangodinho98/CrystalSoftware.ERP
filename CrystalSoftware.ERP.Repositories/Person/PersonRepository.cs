using CrystalSoftware.ERP.Border.Models;
using CrystalSoftware.ERP.Border.Repositories;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Repositories.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly HttpClient _httpClient;

        public PersonRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Border.Models.Person> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/persons/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var context = $"Error searching person {id}";
                throw new HttpRequestException(context);
            }

            return JsonConvert.DeserializeObject<Border.Models.Person>(responseBody);
        }
    }
}
