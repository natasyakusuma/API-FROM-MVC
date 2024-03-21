using System.Text.Json;
using APISolution.BLL.DTOs;
using Humanizer;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;

namespace SampleMVC.Services
{
    public class CategoryServices : ICategoryService
    {
        private const string BaseUrl = "http://localhost:5055/api/Category";
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoryServices> _logger;

        public CategoryServices(HttpClient client, IConfiguration configuration, ILogger<CategoryServices> logger)
        {
            _client = client;
            _configuration = configuration;
            _logger = logger;
        }

        private string GetBaseUrl()
        {
            return _configuration["BaseUrl"] + "/Categories";
        }

        public async Task<bool> Delete(int id)
        {
            var httpResponse = await _client.DeleteAsync($"{GetBaseUrl()}/{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot Delete Category");
            }

            return true; // Jika permintaan berhasil dihapus, kembalikan true
        }


        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            _logger.LogInformation(GetBaseUrl());
            var httpResponse = await _client.GetAsync(GetBaseUrl());
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve data from API");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();

            // ini untuk convert dari Json String ke Object IEnumerable<CategoryDTO>
            var categories = JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return categories;
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var httpResponse = await _client.GetAsync($"{GetBaseUrl()}/{id}");
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve category");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            var category = JsonSerializer.Deserialize<CategoryDTO>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return category;
        }

        public Task<CategoryDTO> Insert(CategoryCreateDTO categoryCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
