using DataTypes;
using Schedule.Components;
using Schedule.Estimation.Factors.Lesson;
using Schedule.Storage;
using Schedule.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Schedule.Views {
    public partial class ScheduleView : UserControl, View {
        const int lessonCount = 7;
        const int dayShift = 2;

        private readonly Dictionary<int, Dictionary<int, Dictionary<int, LessonCell>>> lessonCells = new Dictionary<int, Dictionary<int, Dictionary<int, LessonCell>>> ();
        private readonly Dictionary<int, Dictionary<int, DayEstimationCell>> estimationCells = new Dictionary<int, Dictionary<int, DayEstimationCell>> ();

        private Group currentGroup;
        private Curriculum currentCurriculum;
        public event EntityEventHandler<Curriculum> CurriculumChanged;

        public ScheduleView() {
            InitializeComponent();
            InitializeTable();

            Registries.Groups.RegistryUpdated += _ => UpdateGroups();
        }

        private void InitializeTable() {
            SuspendLayout();
            AddLessonNumbers();
            AddWeekNumbers();
            AddDayNames();
            AddLessonCells();
            AddEstimationCells();
            ResumeLayout(false);
        }

        private void UpdateGroups() {
            groupComboBox.Items.Clear();
            foreach (var group in Registries.Groups.GetEntities()) {
                groupComboBox.Items.Add(group.Name);
            }
        }

        private void AddLessonNumbers() {
            int row = 1;
            int n = 1;

            while (row <= lessonCount * 2) {
                var label = MakeLabel(n.ToString());
                scheduleTable.Controls.Add(label, 0, row);
                scheduleTable.SetRowSpan(label, 2);

                row += 2;
                n += 1;
            }

            var finalLabel = MakeLabel("Оценка за день");
            scheduleTable.Controls.Add(finalLabel, 0, row);
            scheduleTable.SetRowSpan(finalLabel, 2);
        }

        private void AddWeekNumbers() {
            for (int row = 1; row <= lessonCount * 2 + 2; row++) {
                var label = MakeLabel(row % 2 == 0 ? "II" : "I");
                scheduleTable.Controls.Add(label, 1, row);
            }
        }

        private void AddDayNames() {
            for (int column = dayShift; column < scheduleTable.ColumnCount; column++) {
                string text;

                switch (column - dayShift) {
                    case 0:
                        text = "Понедельник";
                        break;
                    case 1:
                        text = "Вторник";
                        break;
                    case 2:
                        text = "Среда";
                        break;
                    case 3:
                        text = "Четверг";
                        break;
                    case 4:
                        text = "Пятница";
                        break;
                    case 5:
                        text = "Суббота";
                        break;
                    default: return;
                }

                var label = MakeLabel(text);
                scheduleTable.Controls.Add(label, column, 0);
            }
        }

        private void AddLessonCells() {
            for (int day = 0; day < 6; day++) {
                var dayCells = new Dictionary<int, Dictionary<int, LessonCell>>();
                for (int lesson = 0; lesson < 7; lesson++) {
                    var lessonCells = new Dictionary<int, LessonCell>();
                    for (int week = 0; week < 2; week++) {
                        var cell = new LessonCell(new Lesson { Day = day, Number = lesson, Week = week }) {
                            CurriculumSupplier = GetCurriculum, Enabled = false,
                        };

                        cell.UpdateEverything();
                        CurriculumChanged += curriculum => cell.UpdateCurriculum();

                        cell.LessonChanged += lessonEntity => {
                            if (cell.IsFilled()) {
                                Registries.Lessons.SaveEntity(lessonEntity);
                            } else if (lessonEntity.Id > 0) Registries.Lessons.RemoveEntity(lessonEntity.Id);

                            UpdateLessonEstimation(cell);
                            UpdateDayEstimation(lessonEntity.Day, lessonEntity.Week);
                        };

                        cell.Dock = DockStyle.Fill;
                        cell.Margin = new Padding(0, 0, 0, 0);
                        
                        lessonCells.Add(week, cell);
                        scheduleTable.Controls.Add(cell, 2 + day, 1 + lesson * 2 + week);
                    }
                    dayCells.Add(lesson, lessonCells);
                }
                lessonCells.Add(day, dayCells);
            }
        }

        private void AddEstimationCells() {
            for (int day = 0; day < 6; day++) {
                var dayCells = new Dictionary<int, DayEstimationCell>();

                for (int week = 0; week < 2; week++) {
                    var cell = new DayEstimationCell();
                    dayCells.Add(week, cell);

                    scheduleTable.Controls.Add(cell, dayShift + day, 1 + lessonCount * 2 + week);
                }

                estimationCells.Add(day, dayCells);
            }
        }

        private void ForAllCells(Action<LessonCell> action) {
            foreach (var x in lessonCells.Values) {
                foreach (var y in x.Values) {
                    foreach (var z in y.Values) {
                        action.Invoke(z);
                    }
                }
            }
        }

        private Label MakeLabel(string text) {
            var label = new Label();
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.Margin = new Padding(0, 0, 0, 0);
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
        }

        public UserControl GetControl() {
            return this;
        }

        public string GetDisplayName() {
            return "Расписание";
        }

        public Curriculum GetCurriculum() {
            return currentCurriculum;
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Group group = Registries.Groups.FindByName(groupComboBox.SelectedItem.ToString());
            if (group == null) {
                ForAllCells(cell => cell.Enabled = false);
                return;
            }

            Curriculum curriculum = Registries.Curriculums.GetEntity(group.CurriculumId);
            if (curriculum == null) {
                ForAllCells(cell => cell.Enabled = false);
                return;
            }

            currentGroup = group;
            currentCurriculum = curriculum;
            CurriculumChanged(curriculum);

            ForAllCells(cell => {
                cell.Lesson = new Lesson() { Week = cell.Lesson.Week, Day = cell.Lesson.Day, Number = cell.Lesson.Number };
                cell.Enabled = true;
                cell.Lesson.GroupId = group.Id;
            });

            UpdateCells(GetCurrentLessons());
        }

        private void UpdateCells(List<Lesson> lessons) {
            foreach (Lesson lesson in lessons) {
                LessonCell cell = lessonCells[lesson.Day][lesson.Number][lesson.Week];
                cell.Lesson = lesson;
            }
        }

        public void UpdateLessonEstimations() {
            ForAllCells(UpdateLessonEstimation);
        }

        public void UpdateLessonEstimation(LessonCell cell) {
            cell.Estimation = EstimationFactorPool.GetVerdict(cell.Lesson);
        }

        public void UpdateDayEstimations() {
            for (int day = 0; day < 6; day++) {
                UpdateDayEstimation(day);
            }
        }

        public void UpdateDayEstimation(int day) {
            for (int week = 0; week < 2; week++) {
                UpdateDayEstimation(day, week);
            }
        }

        public void UpdateDayEstimation(int day, int week) {
            List<Lesson> lessons = Registries.Lessons.GetEntities(lesson => lesson.Day == day && lesson.Week == week);
            Dictionary<long, Lesson> lessonsDictionary = new Dictionary<long, Lesson>();
            foreach (Lesson lesson in lessons) lessonsDictionary.Add(lesson.Number, lesson);
            double estimation = EstimationFactorPool.GetVerdict(lessonsDictionary);
            estimationCells[day][week].Value = estimation;
        }

        private void estimationDisplayCheckBox_CheckedChanged(object sender, EventArgs e) {
            bool value = estimationDisplayCheckBox.Checked;
            UpdateLessonEstimations();
            ForAllCells(cell => cell.ShowEstimation = value);
        }

        private void curriculumButton_Click(object sender, EventArgs e) {
            CurriculumWindow window = new CurriculumWindow(currentCurriculum, GetCurrentLessons());
            window.Show();
        }

        public List<Lesson> GetCurrentLessons() {
            return Registries.Lessons.GetEntities(lesson => lesson.GroupId == currentGroup.Id);
        }
    }
}
