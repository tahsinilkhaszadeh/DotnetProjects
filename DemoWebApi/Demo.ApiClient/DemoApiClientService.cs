using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Demo.ApiClient.Models;
using Demo.ApiClient.Models.ApiModels;



namespace Demo.ApiClient
{
    public class DemoApiClientService
    {
        private readonly HttpClient _httpClient;

        public DemoApiClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        

        public DemoApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiClientOptions.ApiBaseAddress ?? string.Empty);
        }

        public async Task<List<Product>?> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>?>("api/Product");
        }


        public async Task<Product?> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product?>("api/Product");

        }
    }
}
