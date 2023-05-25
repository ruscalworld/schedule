using DataTypes;

namespace Schedule.Estimation.Factors.Lesson {
    public class ComplexitySpreadingFactor : LessonEstimationFactor {
        public override double GetVerdict(DataTypes.Lesson lesson) {
            Discipline discipline = GetDiscipline(lesson);
            if (discipline == null) return 1;
            int complexity = discipline.Complexity;

            if (complexity <= 5) {
                return (double) (lesson.Number + 1) / complexity;
            } else if (complexity >= 6) {
                return (double) complexity / (lesson.Number + 1);
            }

            return 1;
        }

        public override double GetWeight() {
            return 1;
        }
    }
}
