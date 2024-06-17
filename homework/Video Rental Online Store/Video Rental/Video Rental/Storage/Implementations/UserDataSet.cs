using Models;
using Newtonsoft.Json;
using Storage.Interfaces;

namespace Storage.Implementations
{
    public class UserDataSet : IDataSet<User>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _folderPath;
        private readonly string _filePath;

        public UserDataSet(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _folderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "App_Data");
            _filePath = Path.Combine(_folderPath, "Users.json");
        }

        public void Add(User item)
        {
            var users = Read();
            users.Add(item);
            Save(users);
        }

        public List<User> GetAll()
        {
            return Read();
        }

        public void Update(User user)
        {
            var users = Read();
            User found = users.FirstOrDefault(x => x.Id == user.Id) ?? throw new KeyNotFoundException($"User with Id: [{user.Id}] was not found!");
            users[users.IndexOf(found)] = user;
            Save(users);
        }

        private List<User> Read()
        {
            var result = new List<User>();

            if (!Directory.Exists(_folderPath) || !File.Exists(_filePath)) return result;

            try
            {
                using (var sr = new StreamReader(_filePath))
                {
                    string content = sr.ReadToEnd();
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    result = JsonConvert.DeserializeObject<List<User>>(content, settings) ?? new List<User>();
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Error reading the JSON file.", ex);
            }

            return result;
        }

        private void Save(List<User> users)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            JsonSerializerSettings settings = new() { TypeNameHandling = TypeNameHandling.All };
            string convertedUsers = JsonConvert.SerializeObject(users, settings);

            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(convertedUsers);
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Error writing to the JSON file.", ex);
            }
        }
    }
}
