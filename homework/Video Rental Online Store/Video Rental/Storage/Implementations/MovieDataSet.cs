using Models;
using Newtonsoft.Json;
using Storage.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Storage.Implementations
{
    public class MovieDataSet : IDataSet<Movie>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _folderPath;
        private readonly string _filePath;

        public MovieDataSet(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _folderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "App_Data");
            _filePath = Path.Combine(_folderPath, "Movies.json");
        }

        public void Add(Movie item)
        {
            var movies = Read();
            movies.Add(item);
            Save(movies);
        }

        public List<Movie> GetAll()
        {
            return Read();
        }

        public void Update(Movie item)
        {
            var movies = Read();
            var found = movies.FirstOrDefault(x => x.Id == item.Id) ?? throw new KeyNotFoundException($"Movie with Id: [{item.Id}] was not found!");
            movies[movies.IndexOf(found)] = item;
            Save(movies);
        }

        private List<Movie> Read()
        {
            var result = new List<Movie>();

            if (!Directory.Exists(_folderPath) || !File.Exists(_filePath)) return result;

            try
            {
                using (var sr = new StreamReader(_filePath))
                {
                    string content = sr.ReadToEnd();
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    result = JsonConvert.DeserializeObject<List<Movie>>(content, settings) ?? new List<Movie>();
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Error reading the JSON file.", ex);
            }

            return result;
        }

        private void Save(List<Movie> movies)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            JsonSerializerSettings settings = new() { TypeNameHandling = TypeNameHandling.All };
            string convertedMovies = JsonConvert.SerializeObject(movies, settings);

            try
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(convertedMovies);
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Error writing to the JSON file.", ex);
            }
        }
    }
}
