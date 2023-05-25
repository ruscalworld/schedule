using DataTypes;
using Schedule.Components;
using Schedule.Factories;
using Schedule.Windows;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Schedule.Views {
    public partial class TeachersView : UserControl, View {
        public TeachersView() {
            InitializeComponent();

            teachersListControl.Columns.Add("ID", 0);
            teachersListControl.Columns.Add("Фамилия", 200);
            teachersListControl.Columns.Add("Имя", 200);
            teachersListControl.Columns.Add("Отчество", 200);

            teachersListControl.Bind(Registries.Teachers, MakeListViewItem);
        }

        public static ListViewItem MakeListViewItem(Teacher teacher) {
            var item = new ListViewItem(teacher.Id.ToString());
            item.SubItems.Add(teacher.LastName);
            item.SubItems.Add(teacher.FirstName);
            item.SubItems.Add(teacher.MiddleName);
            return item;
        }

        public UserControl GetControl() {
            return this;
        }

        public string GetDisplayName() {
            return "Преподаватели";
        }

        private void teachersListControl_AddRequest(ListView listView) {
            ManageEntityWindow<Teacher> window = MakeManagerWindow();

            window.Submit += entity => {
                Registries.Teachers.RegisterEntity(entity);
            };

            window.ShowDialog();
        }

        private void teachersListControl_EditRequest(ListView listView, int key) {
            ManageEntityWindow<Teacher> window = MakeManagerWindow();

            Teacher teacher = Registries.Teachers.GetEntity(key);
            window["lastName"] = teacher.LastName;
            window["firstName"] = teacher.FirstName;
            window["middleName"] = teacher.MiddleName;

            window.Submit += entity => {
                entity.Id = key;
                Registries.Teachers.SaveEntity(entity);
            };

            window.ShowDialog();
        }

        private ManageEntityWindow<Teacher> MakeManagerWindow() {
            return new ManageEntityWindow<Teacher>("Добавить преподавателя", new List<Property> {
                new Property("lastName", Property.Type.Text) { DisplayName = "Фамилия" },
                new Property("firstName", Property.Type.Text) { DisplayName = "Иия" },
                new Property("middleName", Property.Type.Text) { DisplayName = "Отчество" },
            }, new TeacherFactory());
        }

        private void teachersListControl_DeleteRequest(ListView listView, int key) {
            List<Lesson> dependentLessons = Registries.Lessons.GetEntities(v => v.TeacherId == key);
            if (dependentLessons.Count == 0) return;

            throw new AbstractListController.DeletionException(
                "Существуют занятия, в которых упоминается этот преподаватель. Измените их параметры или удалите перед удалением преподавателя."
            );
        }
    }
}
