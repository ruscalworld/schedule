using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes {
    public class Lesson : Entity {
        public int Day { get; set; }
        public int Week { get; set; }
        public int Number { get; set; }

        public long RoomId { get; set; }
        public long GroupId { get; set; }
        public long TeacherId { get; set; }
        public string DisciplineName { get; set; }
        public LessonType Type { get; set; }

        public Lesson() { }

        public Lesson(int day, int week, int number, long roomId, long groupId, long teacherId, string disciplineName, LessonType type) { 
            Day = day;
            Week = week;
            Number = number;
            RoomId = roomId;
            GroupId = groupId;
            TeacherId = teacherId;
            DisciplineName = disciplineName;
            Type = type;
        }

        public Lesson(long roomId, long groupId, long teacherId, string disciplineName, LessonType type) {
            RoomId = roomId;
            GroupId = groupId;
            TeacherId = teacherId;
            DisciplineName = disciplineName;
            Type = type;
        }
    }
}
