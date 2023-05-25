using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Factories {
    public class TeacherFactory : Factory<Teacher> {
        public Teacher Create(Dictionary<string, object> data) {
            return new Teacher(
                data["firstName"] as string,
                data["lastName"] as string,
                data["middleName"] as string
            );
        }
    }
}
