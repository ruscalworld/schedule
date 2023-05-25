using System;

namespace Classes {
    public class Institution : Entity {
        public string Name { get; set; }

        public Institution(long id, string name) : base(id) {
            Name = name;
        }
    }
}
