using DataTypes;

namespace Schedule.Storage {
    public delegate void EntityEventHandler<T>(T entity) where T : Entity;
    public delegate void AnyEntityEventHandler<T>(T entity);

    public class Event {
        public EntityEventHandler<T> HandleNewEntity<T>(Registry<T> registry) where T : Entity {
            return (T entity) => {
                registry.RegisterEntity(entity);
            };
        }
    }
}
