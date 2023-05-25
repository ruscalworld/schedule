using DataTypes;
using Schedule.Components;
using System.Collections.Generic;

namespace Schedule.Factories {
    internal class GroupFactory : Factory<Group> {
        public Group Create(Dictionary<string, object> data) {
            Institution institution = Registries.Institutions.FindByName(data["institution"] as string);
            if (institution == null) throw new NotFoundException("институт", "названием");

            Curriculum curriculum = Registries.Curriculums.FindByName(data["curriculum"] as string);
            if (curriculum == null) throw new NotFoundException("учебный план", "названием");

            return new Group(
                data["name"] as string,
                (int)data["studentAmount"],
                institution.Id,
                curriculum.Id
            );
        }
    }
}
