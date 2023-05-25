﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes {
    public class Room : Entity {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public Room(string name, int capacity) {
            Name = name;
            Capacity = capacity;
        }
    }
}
