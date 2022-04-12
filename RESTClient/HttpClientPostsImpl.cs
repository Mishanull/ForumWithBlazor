using System.Net;
using System.Text;
using System.Text.Json;
using Contract;
using Entities;

namespace RESTClient;

public class HttpClientPostsImpl : IPostService
{
    public async Task CreatePostAsync(Post? post)
    {
        using HttpClient client = new();
        string postSerialized = JsonSerializer.Serialize(post);
        StringContent content = new(postSerialized, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7140/Post", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }
        
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7140/Post/{id}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }

        Post? ret = JsonSerializer.Deserialize<Post>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return ret;
    }

    public async Task<ICollection<Post>> GetAllPosts()
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync("https://localhost:7140/Post");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }

        ICollection<Post> ret = JsonSerializer.Deserialize<ICollection<Post>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return ret;
    }

    public async Task DeletePostAsync(int id)
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7140/Post/{id}");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }

        
    }

    public async Task EditPostAsync(Post? post)
    {
        using HttpClient client = new();
        string postSerialize= JsonSerializer.Serialize(post);
        StringContent content = new(postSerialize, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PatchAsync($"https://localhost:7140/Post/{post.Id}", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }    
    }

    public  async Task AddCommentToPost(Comment comment, int id)
    {
        using HttpClient client = new();
        string postSerialize= JsonSerializer.Serialize(comment);
        StringContent content = new(postSerialize, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync($"https://localhost:7140/Post/{id}/comments", content);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error: {response.StatusCode},{responseContent}");
        }    
    }

    public async Task<ICollection<Comment>> GetComments(int id)
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7140/Post/{id}/comments");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error:{response.StatusCode},{responseContent}");
        }  
        ICollection<Comment> ret = JsonSerializer.Deserialize<ICollection<Comment>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return ret;
    }
}
