using DataTypes;

namespace Schedule.Storage {
    public class GroupRegistry : Registry<Group> {
        public Group FindByName(string name) {
            foreach (var group in GetEntities()) {
                if (group.Name == name) return group;
            }

            return null;
        }
    }
}
