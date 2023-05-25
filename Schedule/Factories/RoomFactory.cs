using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Factories {
    public class RoomFactory : Factory<Room> {
        public Room Create(Dictionary<string, object> data) {
            return new Room(
                data["name"] as string,
                (int) data["capacity"]
            );
        }
    }
}
