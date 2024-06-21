using Models;
using Newtonsoft.Json;
using Storage.Interfaces;

namespace Storage.Implementations
{
    public class Storage<T> : IStorage<T> where T : Base
    {
        public void Add(T item)
        {
            var items = Read();
            int nextId = items.Count < 1 ? 1 : items.Max(x => x.Id) + 1; 
            
            item.Id = nextId;
            items.Add(item);
            Write(items);
        }

        public void Delete(T item)
        {
            DeleteById(item.Id);
        }

        public void DeleteById(int id)
        {
            var items = Read();

            var found = items.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Entity with id {id} could not be found!");
            items.Remove(found);
            Write(items);
        }

        public List<T> GetAll()
        {
            return Read();
        }

        public T GetById(int id)
        {
            var items = Read();

            var found = items.FirstOrDefault(x => x.Id == id) ?? throw new Exception($"Entity with id {id} could not be found!");
            return found;
        }

        public void Update(T item)
        {
            var items = Read();
            var found = items.FirstOrDefault(x => x.Id == item.Id) ?? throw new Exception($"Entity with id {item.Id} could not be found!");
            items[items.IndexOf(found)] = item; 
            Write(items);
        }
        public List<T> Read()
        {
            var list = new List<T>();
            string folderPath = Environment.CurrentDirectory + @"\Data\";
            string filePath = folderPath + typeof(T).Name + "s.json";

            if (!File.Exists(filePath)) return list;

            using (var sr = new StreamReader(filePath))
            {
                var content = sr.ReadToEnd();
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                list = JsonConvert.DeserializeObject<List<T>>(content, settings);
            }
                return list;
        }
        public void Write(List<T> items)
        {
            string folderPath = Environment.CurrentDirectory + @"\Data\";
            string filePath = folderPath + typeof(T).Name + "s.json";

            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            if (!File.Exists(filePath)) File.Create(filePath).Close();

            using (var sw = new StreamWriter(filePath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var content = JsonConvert.SerializeObject(items, settings);
                sw.WriteLine(content);
            }
        }
    }
}
