using DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Windows {
    public partial class CurriculumWindow : Form {
        private readonly List<Lesson> lessons;
        private readonly Curriculum curriculum;

        public CurriculumWindow(Curriculum curriculum, List<Lesson> lessons) {
            InitializeComponent();

            this.curriculum = curriculum;
            this.lessons = lessons;

            if (curriculum != null) {
                UpdateList();
                Name = string.Format("Учебный план \"{0}\"", curriculum.Name);
            }
        }

        public void UpdateList() {
            if (lessons == null) return;

            foreach (Discipline discipline in curriculum.Disciplines) {
                foreach (LessonType lessonType in Enum.GetValues(typeof(LessonType))) {
                    int hours = discipline.Hours[lessonType];
                    if (hours <= 0) continue;

                    ListViewItem item = new ListViewItem();
                    item.Text = discipline.Name;
                    item.SubItems.Add(lessonType.GetDisplayName());
                    item.SubItems.Add(GetAllocatedHours(discipline, lessonType).ToString());
                    item.SubItems.Add(hours.ToString());
                    listView.Items.Add(item);
                }
            }
        }

        private List<Lesson> FindLessons(Discipline discipline, LessonType type) {
            List<Lesson> result = new List<Lesson>();

            foreach (var lesson in lessons) {
                if (lesson.DisciplineName == discipline.Name && lesson.Type == type) result.Add(lesson);
            }

            return result;
        }

        private int GetAllocatedHours(Discipline discipline, LessonType type) {
            List<Lesson> lessons = FindLessons(discipline, type);
            int result = 0;
            foreach (var lesson in lessons) result += 16;
            return result;
        }
    }
}
