using DataTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Storage {
    public class Registry<T> : Exportable where T : Entity {
        private readonly Dictionary<long, T> dictionary = new Dictionary<long, T>();
        private long lastId = 0;

        public event EntityEventHandler<T> EntityAdded;
        public event EntityEventHandler<T> EntityRemoved;
        public event EntityEventHandler<T> EntityModified;
        public event EntityEventHandler<T> RegistryUpdated;

        public Registry() {
            EntityAdded += entity => { if (RegistryUpdated != null) RegistryUpdated.Invoke(entity); };
            EntityRemoved += entity => { if (RegistryUpdated != null) RegistryUpdated.Invoke(entity); };
            EntityModified += entity => { if (RegistryUpdated != null) RegistryUpdated.Invoke(entity); };
        }

        public void RegisterEntity(T entity) {
            lastId += 1;
            entity.Id = lastId;
            dictionary.Add(entity.Id, entity);
            EntityAdded(entity);
        }

        public void SaveEntity(T entity) {
            if (entity.Id == -1) {
                RegisterEntity(entity);
                return;
            }

            dictionary.Remove(entity.Id);
            dictionary.Add(entity.Id, entity);
            EntityModified(entity);
        }

        public T GetEntity(long id) {
            if (dictionary.ContainsKey(id)) return dictionary[id];
            return null;
        }

        public T RemoveEntity(long id) {
            var entity = GetEntity(id);
            dictionary.Remove(id);
            EntityRemoved(entity);
            return entity;
        }

        public List<T> GetEntities() {
            return dictionary.Values.ToList();
        }

        public List<T> GetEntities(Func<T, bool> predicate) {
            List<T> result = new List<T> ();

            foreach (var value in dictionary.Values) {
                if (predicate(value)) result.Add(value);
            }

            return result;
        }

        public string ExportAll() {
            return JsonConvert.SerializeObject(dictionary.Values);
        }

        public void Import(string data) {
            var entities = JsonConvert.DeserializeObject<List<T>>(data);
            foreach (var entity in entities) RegisterEntity(entity);
        }
    }
}
