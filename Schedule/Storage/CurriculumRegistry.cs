using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Storage {
    public class CurriculumRegistry : Registry<Curriculum> {
        public Curriculum FindByName(string name) {
            foreach (var curriculum in GetEntities()) {
                if (curriculum.Name == name) return curriculum;
            }

            return null;
        }
    }
}
