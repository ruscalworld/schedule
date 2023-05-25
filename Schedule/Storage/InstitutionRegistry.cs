using DataTypes;

namespace Schedule.Storage {
    public class InstitutionRegistry : Registry<Institution> {
        public Institution FindByName(string name) {
            foreach (var institution in GetEntities()) {
                if (institution.Name == name) return institution;
            }

            return null;
        }
    }
}
