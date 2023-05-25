using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes {
    public class Curriculum : Entity {
        public string Name { get; set; }
        public List<Discipline> Disciplines { get; } = new List<Discipline>();

        public Curriculum(string name, List<Discipline> disciplines) {
            Name = name;
            Disciplines = disciplines;
        }

        public Discipline GetDisciplineByName(string name) {
            foreach (var discipline in Disciplines) {
                if (discipline.Name == name) return discipline;
            }
            return null;
        }

        public int GetTotalHours(LessonType lessonType) {
            int total = 0;
            foreach (Discipline discipline in Disciplines) {
                total += discipline.Hours[lessonType];
            }
            return total;
        }

        public int GetTotalHours() {
            int total = 0;
            foreach (LessonType lessonType in Enum.GetValues(typeof(LessonType))) {
                total += GetTotalHours(lessonType);
            }
            return total;
        }

        public int GetTotalCredits() {
            int total = 0;
            foreach (Discipline discipline in Disciplines) {
                total += discipline.TotalCredits;
            }
            return total;
        }
    }

    public class Discipline {
        public string Name { get; set; }
        public int TotalCredits { get; set; }
        public int Complexity { get; set; }
        public Dictionary<LessonType, int> Hours { get; } = new Dictionary<LessonType, int>();

        public Discipline(string name, int credits, int complexity, Dictionary<LessonType, int> hours) {
            Name = name;
            Hours = hours;
            Complexity = complexity;
            TotalCredits = credits;
        }

        public int GetTotalHours() {
            int total = 0;
            foreach (var h in Hours.Values) {
                total += h;
            }
            return total;
        }
    }
}
