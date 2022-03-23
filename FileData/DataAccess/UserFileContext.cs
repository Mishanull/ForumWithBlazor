using System.Text.Json;
using Entities;

namespace FileData.DataAccess;

public class UserFileContext
{
    private string userFilePath = "users.json";

    private ICollection<User> users;

    public ICollection<User> Users
    {
        get
        {
            if (users == null)
            {
                LoadData();
            }

            return users;
        }
        set
        {
            users = value;
        }
    }
    public UserFileContext()
    {
        if (!File.Exists(userFilePath))
        {
            Seed();
        }
    }
    private void Seed()
    {
        User[] ts = {
            new User {
                Name="Mihai Avram",
                UserName = "Mike",
                Password = "12345",
                Role = "admin",
                SecurityLevel = 1
            },
           
            
        };
        users = ts.ToList();
        SaveChanges();
    }
    public void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Users);
        File.WriteAllText(userFilePath,serialize);
        users = null;
    }
    private void LoadData()
    {
        string content = File.ReadAllText(userFilePath);
        Users = JsonSerializer.Deserialize<List<User>>(content);
    }
}