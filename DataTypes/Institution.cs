using System;

namespace DataTypes {
    public class Institution : Entity {
        public string Name { get; set; }

        public Institution(string name) {
            Name = name;
        }
    }
}
