using DataAccess.Interface;
using DomainModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public void Add(T entity)
        {
            var items = Read();
            var nextId = items.Max(x => x.Id) + 1;

            entity.Id = nextId;
            items.Add(entity);
            Write(items);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var items = Read();

            var result = items.FirstOrDefault(x => x.Id == id);

            if (result == null) throw new KeyNotFoundException($"Entity with Id {id} was not found!");

        }

        public List<T> GetAll()
        {
            return Read();
        }

        public T GetById(int id)
        {
            var items = Read();
            var result = items.FirstOrDefault(x => x.Id == id);

            if (result == null) throw new KeyNotFoundException($"Entity with Id {id} was not found!");

            return result;
        }

        public void Update(T entity)
        {
            var items = Read();

            var result = items.FirstOrDefault(x => x.Id == entity.Id);
            if (result == null) throw new KeyNotFoundException($"Entity with Id {entity.Id} was not found!");

            items[items.IndexOf(result)] = entity;
            Write(items);
        }
        public List<T> Read()
        {
            var result = new List<T>();
            string folderPath = @"..\..\..\Data";
            string filePath = $"{typeof(T).Name}s.json";

            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(filePath)) return result;
            
            using(var sr = new StreamReader(filePath))
            {
                var content = sr.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<T>>(content);
            }
            return result;
        }
        public void Write(List<T> items)
        {
            string folderPath = @"..\..\..\Data";
            string filePath = $"{typeof(T).Name}s.json";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(filePath)) { 
                File.Create(filePath).Close();
            }

            using (var sw = new StreamWriter(filePath)) 
            {
                var content = JsonConvert.SerializeObject(items);
                sw.WriteLine(content);
            }
        }
    }
}
