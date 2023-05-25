using System;
using System.Collections.Generic;

namespace Schedule.Estimation.Factors.Day {
    public class BreakDurationFactor : DayEstimationFactor {
        public double GetVerdict(Dictionary<long, DataTypes.Lesson> schedule) {
            (int firstNumber, int lastNumber) = (7, 0);

            foreach (var key in schedule.Keys) {
                if (key < firstNumber) firstNumber = (int) key;
                if (key > lastNumber) lastNumber = (int) key;
            }

            int breaks = 1;
            for (int n = firstNumber; n <= lastNumber; n++) {
                if (!schedule.ContainsKey(n)) breaks++;
            }

            return (double) 1 / breaks;
        }

        public double GetWeight() {
            return 1;
        }
    }
}
