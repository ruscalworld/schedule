using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Storage {
    public class RoomRegistry : Registry<Room> {
        public Room FindByName(string name) {
            foreach (var room in GetEntities()) {
                if (room.Name == name) return room;
            }

            return null;
        }
    }
}
