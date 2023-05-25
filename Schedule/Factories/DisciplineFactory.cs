using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Schedule.Factories {
    public class DisciplineFactory : Factory<Discipline> {
        public Discipline Create(Dictionary<string, object> data) {
            return new Discipline(
                data["name"] as string,
                (int) data["credits"],
                (int) data["complexity"],
                new Dictionary<LessonType, int> {
                    { LessonType.Practical, (int) data["hoursPractical"] },
                    { LessonType.Lecture, (int) data["hoursLecture"] },
                    { LessonType.Laboratory, (int) data["hoursLaboratory"] },
                }
            );
        }
    }
}
