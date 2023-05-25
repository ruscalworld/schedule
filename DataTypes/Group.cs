using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes {
    public class Group : Entity {
        public string Name { get; set; }
        public int StudentAmount { get; set; }
        public long InstitutionId { get; set; }
        public long CurriculumId { get; set; }

        public Group(string name, int studentAmount, long institutionId, long curriculumId) {
            Name = name;
            StudentAmount = studentAmount;
            InstitutionId = institutionId;
            CurriculumId = curriculumId;
        }
    }
}
