using System;
using System.Collections.Generic;
using System.Text;

namespace Classes {
    public class Group : Entity {
        public string Name { get; set; }
        public string StudentAmount { get; set; }
        public long InstitutionId { get; set; }

        public Group(long id, string name, string studentAmount, long institutionId) : base(id) {
            Name = name;
            StudentAmount = studentAmount;
            InstitutionId = institutionId;
        }
    }
}
