
using MedicalDirector.Domain.Entities;
using System.Text.Json;

namespace MedicalDirector.Services
{
    public class ExternalService : IExternalService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string endpoint = "https://jsonplaceholder.typicode.com/";

        public ExternalService(IHttpClientFactory httpClientFactory) =>
        _httpClientFactory = httpClientFactory;

        public async Task<IEnumerable<User>> GetUsers()
        {
            string url = endpoint + "users";
            return await HttpGetRequest<IEnumerable<User>>(url);
        }

        public async Task<User> GetUser(int id)
        {
            string url = endpoint + "users/" + id.ToString();
            return await HttpGetRequest<User>(url);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            string url = endpoint + "posts/";
            return await HttpGetRequest<IEnumerable<Post>>(url);
        }

        public async Task<IEnumerable<Post>> GetUserPosts(int userId)
        {
            string url = endpoint + "users/" + userId.ToString() + "/posts";
            return await HttpGetRequest<IEnumerable<Post>>(url);
        }

        private async Task<T> HttpGetRequest<T>(string url)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                return JsonSerializer.Deserialize<T>(contentStream);
            }
            else
            {
               throw new Exception(httpResponseMessage.ReasonPhrase);
            }
        }
    }
}
