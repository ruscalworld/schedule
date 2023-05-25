using DataTypes;
using System.Collections.Generic;

namespace Schedule.Factories {
    internal class InstitutionFactory : Factory<Institution> {
        public Institution Create(Dictionary<string, object> data) {
            return new Institution(data["name"] as string);
        }
    }
}
