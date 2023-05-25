using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes {
    public enum LessonType {
        Practical, Lecture, Laboratory,
    }

    public static class LessonTypeExt {
        public const string LecturesName = "лек.";
        public const string PracticalName = "пр.";
        public const string LaboratoryName = "лаб.";

        public static string GetDisplayName(this LessonType type) {
            switch (type) {
                case LessonType.Lecture:
                    return LecturesName;
                case LessonType.Practical:
                    return PracticalName;
                case LessonType.Laboratory:
                    return LaboratoryName;
            }
            return null;
        }

        public static LessonType Parse(string input) {
            switch (input) {
                case LecturesName:
                    return LessonType.Lecture;
                case PracticalName:
                    return LessonType.Practical;
                case LaboratoryName:
                    return LessonType.Laboratory;
                default: throw new NotImplementedException();
            }
        }
    }
}
