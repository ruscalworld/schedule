using Schedule.Components;
using System.Collections.Generic;

namespace Schedule.Factories {
    public interface Factory<T> {
        T Create(Dictionary<string, object> data);
    }

    public class NotFoundException : Property.ValidationException {
        public NotFoundException(string typeName, string propertyName) : base("Не удалось найти " + typeName + " с указанным " + propertyName) { }
    }
}
