using Schedule.Estimation.Factors.Day;
using System.Collections.Generic;

namespace Schedule.Estimation.Factors.Lesson {
    public class EstimationFactorPool {
        private static LessonEstimationFactor[] knownLessonFactors = new LessonEstimationFactor[] {
            new FirstLessonComplexityFactor(),
            new ComplexitySpreadingFactor(),
        };

        private static DayEstimationFactor[] knownDayFactors = new DayEstimationFactor[] {
            new BreakDurationFactor(),
        };

        private static double GetVerdict<T>(T entity, EstimationFactor<T>[] knownFactors) {
            double result = 0;

            foreach (var factor in knownFactors) {
                result += factor.GetVerdict(entity) * factor.GetWeight();
            }

            return result;
        }

        public static double GetVerdict(DataTypes.Lesson lesson) {
            return GetVerdict(lesson, knownLessonFactors);
        }

        public static double GetVerdict(Dictionary<long, DataTypes.Lesson> lessons) {
            return GetVerdict(lessons, knownDayFactors);
        }
    }
}
