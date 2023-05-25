using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes {
    public class Teacher : Entity {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public Teacher(string firstName, string lastName, string middleName) {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }

        public string GetName() {
            string result = LastName;
            if (!string.IsNullOrEmpty(FirstName)) {
                result += " " + FirstName + ".";
                if (!string.IsNullOrEmpty(MiddleName)) result += " " + MiddleName + ".";
            }
            return result;
        }

        public string GetShortName() {
            string result = LastName;
            if (!string.IsNullOrEmpty(FirstName)) {
                result += " " + FirstName.ToUpper()[0] + ".";
                if (!string.IsNullOrEmpty(MiddleName)) result += " " + MiddleName.ToUpper()[0] + ".";
            }
            return result;
        }
    }
}
