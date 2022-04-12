using System.Text;
using System.Text.Json;
using Contract;
using Entities;

namespace RESTClient;

public class HttpClientUsersImpl : IUserService
{
    public async Task<User?> GetUserAsync(string username)
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7140/User/{username}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }

        User? ret = JsonSerializer.Deserialize<User>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return ret;
    }

    public async Task CreateUserAsync(User user)
    {
        using HttpClient client = new();
        string userSerialized = JsonSerializer.Serialize(user);
        StringContent content = new(userSerialized, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7140/User", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }
    }
}