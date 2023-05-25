using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes {
    public class Entity {
        public long Id { get; set; }

        public Entity() {
            Id = -1;
        }

        public Entity(long id) {
            Id = id;
        }
    }
}
