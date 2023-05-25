using DataTypes;
using Schedule.Storage;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Schedule.Components {
    public partial class LessonCell : UserControl {
        const string EmptyValue = "-";

        public new bool Enabled {
            get {
                return disciplineComboBox.Enabled && teacherComboBox.Enabled && roomComboBox.Enabled;
            }
            set {
                disciplineComboBox.Enabled = value;
                teacherComboBox.Enabled = value;
                roomComboBox.Enabled = value;
            }
        }

        public bool ShowEstimation {
            get {
                return estimationLabel.Visible;
            }
            set {
                estimationLabel.Visible = value;
            }
        }

        public double Estimation {
            set {
                estimationLabel.Text = !IsFilled() ? "" : string.Format("{0:0.00}", value);
            }
        }

        public Func<Curriculum> CurriculumSupplier { get; set; }
        private Curriculum curriculum;

        public event EntityEventHandler<Lesson> LessonChanged;

        private Lesson lesson;

        public Lesson Lesson {
            get => lesson;
            set {
                lesson = value;

                if (value.RoomId != 0) {
                    var room = Registries.Rooms.GetEntity(value.RoomId);
                    if (room != null) roomComboBox.SelectedItem = room.Name;
                } else {
                    roomComboBox.Text = EmptyValue;
                }

                if (value.TeacherId != 0) {
                    var teacher = Registries.Teachers.GetEntity(value.TeacherId);
                    if (teacher != null) teacherComboBox.SelectedItem = MakeTeacherName(teacher);
                } else {
                    teacherComboBox.Text = EmptyValue;
                }

                if (value.DisciplineName != null) {
                    var discipline = curriculum.GetDisciplineByName(value.DisciplineName);
                    disciplineComboBox.SelectedItem = MakeDisciplineName(discipline.Name, value.Type);
                } else {
                    disciplineComboBox.Text = EmptyValue;
                }
            } 
        }

        public LessonCell(Lesson lesson) {
            InitializeComponent();
            Lesson = lesson;

            Registries.Teachers.RegistryUpdated += _ => UpdateTeachers();
            Registries.Rooms.RegistryUpdated += _ => UpdateRooms();
        }

        public void UpdateEverything() {
            UpdateCurriculum();
            UpdateTeachers();
            UpdateRooms();
        }

        public void UpdateCurriculum() {
            var curriculum = CurriculumSupplier.Invoke();
            if (curriculum == null) return;
            this.curriculum = curriculum;

            disciplineComboBox.Items.Clear();
            disciplineComboBox.Items.Add(EmptyValue);

            foreach (var discipline in curriculum.Disciplines) {
                foreach (LessonType type in Enum.GetValues(typeof(LessonType))) {
                    if (discipline.Hours[type] == 0) continue;
                    disciplineComboBox.Items.Add(MakeDisciplineName(discipline.Name, type));
                }
            }
        }

        private string MakeDisciplineName(string name, LessonType type) {
            return name + " (" +  type.GetDisplayName() + ")";
        }

        private string MakeTeacherName(Teacher teacher) {
            return teacher.GetShortName() + " [" + teacher.Id + "]";
        }

        public void UpdateTeachers() {
            var teachers = Registries.Teachers.GetEntities();
            teacherComboBox.Items.Clear();
            teacherComboBox.Items.Add(EmptyValue);

            foreach (var teacher in teachers) {
                teacherComboBox.Items.Add(MakeTeacherName(teacher));
            }
        }

        public void UpdateRooms() {
            var rooms = Registries.Rooms.GetEntities();
            roomComboBox.Items.Clear();
            roomComboBox.Items.Add(EmptyValue);

            foreach (var room in rooms) {
                roomComboBox.Items.Add(room.Name);
            }
        }

        private void disciplineComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (disciplineComboBox.SelectedItem == null || disciplineComboBox.SelectedItem as string == EmptyValue) {
                lesson.DisciplineName = null;
                HandleUpdate();
                return;
            }

            string rawName = disciplineComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(rawName)) return;

            int start = rawName.LastIndexOf('(') + 1;
            string rawType = rawName.Substring(start, rawName.LastIndexOf(')') - start);
            rawName = rawName.Substring(0, start - 2);

            lesson.Type = ParseType(rawType);
            lesson.DisciplineName = curriculum.GetDisciplineByName(rawName).Name;
            HandleUpdate();
        }

        private LessonType ParseType(string input) {
            return LessonTypeExt.Parse(input);
        }

        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (teacherComboBox.SelectedItem == null || teacherComboBox.SelectedItem as string == EmptyValue) {
                lesson.TeacherId = 0;
                HandleUpdate();
                return;
            }

            string rawName = teacherComboBox.SelectedItem.ToString();
            if (string.IsNullOrEmpty(rawName)) return;
            int start = rawName.LastIndexOf('[') + 1;
            string rawId = rawName.Substring(start, rawName.LastIndexOf(']') - start);

            Teacher teacher = Registries.Teachers.GetEntity(long.Parse(rawId));
            if (teacher == null) return;

            lesson.TeacherId = teacher.Id;
            HandleUpdate();
        }

        private void roomComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (roomComboBox.SelectedItem == null || roomComboBox.SelectedItem as string == EmptyValue) {
                lesson.RoomId = 0;
                HandleUpdate();
                return;
            }

            string rawName = roomComboBox.SelectedItem.ToString();
            Room room = Registries.Rooms.FindByName(rawName);
            if (room == null) return;

            lesson.RoomId = room.Id;
            HandleUpdate();
        }

        public void ValidateLesson() {
            ValidateTeacher();
            ValidateRoom();
        }

        private void ValidateTeacher() {
            List<Lesson> sameTeacherOtherRoom = Registries.Lessons.GetEntities(lesson => lesson.GroupId != Lesson.GroupId
                    && lesson.Day == Lesson.Day && lesson.Week == Lesson.Week && lesson.Number == Lesson.Number
                    && lesson.TeacherId == Lesson.TeacherId && lesson.RoomId != Lesson.RoomId);
            if (sameTeacherOtherRoom.Count > 0) {
                var room = Registries.Rooms.GetEntity(sameTeacherOtherRoom[0].RoomId);
                throw new LessonArrangementException("Этот преподаватель уже занят в аудитории " + room.Name);
            }
        }

        private void ValidateRoom() {
            List<Lesson> sameRoom = Registries.Lessons.GetEntities(lesson => lesson.GroupId != Lesson.GroupId
                    && lesson.Day == Lesson.Day && lesson.Week == Lesson.Week && lesson.Number == Lesson.Number
                    && lesson.RoomId == Lesson.RoomId);

            List<long> groupIds = new List<long>();
            foreach (var lesson in sameRoom) groupIds.Add(lesson.GroupId);

            List<Group> groups = Registries.Groups.GetEntities(group => groupIds.Contains(group.Id));
            Group currentGroup = Registries.Groups.GetEntity(Lesson.GroupId);
            int totalStudents = currentGroup.StudentAmount;
            foreach (var group in groups) totalStudents += group.StudentAmount;

            Room room = Registries.Rooms.GetEntity(Lesson.RoomId);
            if (room == null) return;
            if (room.Capacity < totalStudents) throw new LessonArrangementException("Эта аудитория переполнена");
        }

        private void HandleUpdate() {
            try {
                if (IsFilled()) ValidateLesson();
                LessonChanged(lesson);
            } catch (LessonArrangementException ex) {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool IsFilled() {
            return lesson.TeacherId != 0 && !string.IsNullOrEmpty(lesson.DisciplineName) && lesson.RoomId != 0;
        }
    }

    public class LessonArrangementException : Exception {
        public LessonArrangementException(string message) : base(message) { }
    }
}
