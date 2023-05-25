using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Estimation.Factors.Lesson {
    public class FirstLessonComplexityFactor : LessonEstimationFactor {
        public override double GetVerdict(DataTypes.Lesson lesson) {
            if (lesson.Number != 0) return 1;
            var discipline = GetDiscipline(lesson);
            if (discipline == null) return 1;
            var complexity = discipline.Complexity;
            if (complexity == 0) complexity = 1;
            return (double) 1 / complexity;
        }

        public override double GetWeight() {
            return 1;
        }
    }
}
