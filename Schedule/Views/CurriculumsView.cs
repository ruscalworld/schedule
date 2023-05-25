using DataTypes;
using Schedule.Components;
using Schedule.Factories;
using Schedule.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Schedule.Views {
    public partial class CurriculumsView : UserControl, View {
        public CurriculumsView() {
            InitializeComponent();

            curriculumsListControl.Columns.Add("ID", 0);
            curriculumsListControl.Columns.Add("Название", 200);
            curriculumsListControl.Columns.Add("Кол-во дисциплин", 100);
            curriculumsListControl.Columns.Add("Практ.", 50);
            curriculumsListControl.Columns.Add("Лек.", 50);
            curriculumsListControl.Columns.Add("Лаб.", 50);
            curriculumsListControl.Columns.Add("Зач. ед.", 70);

            curriculumsListControl.Bind(Registries.Curriculums, MakeListViewItem);
        }

        public static ListViewItem MakeListViewItem(Curriculum curriculum) {
            var item = new ListViewItem(curriculum.Id.ToString());
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = curriculum.Name });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = curriculum.Disciplines.Count.ToString() });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = curriculum.GetTotalHours(LessonType.Practical).ToString() });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = curriculum.GetTotalHours(LessonType.Lecture).ToString() });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = curriculum.GetTotalHours(LessonType.Laboratory).ToString() });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = curriculum.GetTotalCredits().ToString() });
            return item;
        }

        public static ListViewItem MakeDisciplineListViewItem(Discipline discipline) {
            var item = new ListViewItem(discipline.Name);
            item.SubItems.Add(string.Join(" ", discipline.Hours[LessonType.Practical], discipline.Hours[LessonType.Lecture], discipline.Hours[LessonType.Laboratory]));
            item.SubItems.Add(discipline.TotalCredits.ToString());
            item.SubItems.Add(discipline.Complexity.ToString());
            return item;
        }

        public UserControl GetControl() {
            return this;
        }

        public string GetDisplayName() {
            return "Учебные планы";
        }

        private void curriculumsListControl_AddRequest(ListView listView) {
            ManageEntityWindow<Curriculum> window = MakeManagerWindow(0);

            window.Submit += (entity) => {
                Registries.Curriculums.RegisterEntity(entity);
            };

            window.ShowDialog();
        }

        private void curriculumsListControl_EditRequest(ListView listView, int key) {
            ManageEntityWindow<Curriculum> window = MakeManagerWindow(key);

            Curriculum curriculum = Registries.Curriculums.GetEntity(key);
            window["name"] = curriculum.Name;
            ListView.ListViewItemCollection items = window["disciplines"] as ListView.ListViewItemCollection;
            foreach (var discipline in curriculum.Disciplines) items.Add(MakeDisciplineListViewItem(discipline));

            window.Submit += (entity) => {
                entity.Id = key;
                Registries.Curriculums.SaveEntity(entity);
            };

            window.ShowDialog();
        }

        private ManageEntityWindow<Curriculum> MakeManagerWindow(int currentId) {
            ManageEntityWindow<Curriculum> window = new ManageEntityWindow<Curriculum>("Добавить учебный план", new List<Property> {
                new Property("name", Property.Type.Text) { DisplayName = "Название", Validator = v => {
                    Curriculum curriculum = Registries.Curriculums.FindByName(v as string);
                    if (curriculum != null && curriculum.Id != currentId) throw new AlreadyExistsException("учебный план", "названием");
                }},

                new Property("disciplines", items => {}, headers => {
                    headers.Add("Название", 100);
                    headers.Add("Часы", 50);
                    headers.Add("ЗЕ", 40);
                    headers.Add("Сложность", 60);
                }, disciplinesListView_AddRequest) { DisplayName = "Дисциплины" },
            }, new CurriculumFactory());

            window.Width = 300;
            return window;
        }

        private void disciplinesListView_AddRequest(ListView listView) {
            ManageEntityWindow<Discipline> window = MakeDisciplinesManagerWindow(listView);

            window.Submit += (entity) => {
                listView.Items.Add(MakeDisciplineListViewItem(entity));
            };

            window.ShowDialog();
        }

        private ManageEntityWindow<Discipline> MakeDisciplinesManagerWindow(ListView listView) {
            List<Property> properties = new List<Property> {
                new Property("name", Property.Type.Text) { DisplayName = "Название", Validator = v => {
                    foreach (ListViewItem item in listView.Items) {
                        if (item.Text == v as string) throw new AlreadyExistsException("дисциплина", "названием");
                    }
                }},

                new Property("credits", Property.Type.Number) { DisplayName = "Зач. ед.", Validator = v => {
                    if ((int) v < 1) throw new Property.ValidationException("Количество зачётных единиц должно быть положительным");
                }},

                new Property("complexity", Property.Type.Number) { DisplayName = "Сложность", Validator = v => {
                    if ((int) v > 10 || (int) v < 0) throw new Property.ValidationException("Сложность должна быть от 0 до 10");
                }},
            };

            foreach (LessonType lessonType in Enum.GetValues(typeof(LessonType))) {
                string displayName = "";
                switch (lessonType) {
                    case LessonType.Practical:
                        displayName = "Часов пр.";
                        break;
                    case LessonType.Lecture:
                        displayName = "Часов лек.";
                        break;
                    case LessonType.Laboratory:
                        displayName = "Часов лаб.";
                        break;
                };

                properties.Add(new Property("hours" + lessonType.ToString(), Property.Type.Number) { DisplayName = displayName, Optional = true });
            }

            return new ManageEntityWindow<Discipline>("Добавить дисциплину", properties, new DisciplineFactory());
        }

        private void curriculumsListControl_DeleteRequest(ListView listView, int key) {
            List<Group> dependentGroups = Registries.Groups.GetEntities(v => v.CurriculumId == key);
            if (dependentGroups.Count == 0) return;

            List<string> names = new List<string>();
            foreach (var group in dependentGroups) names.Add(group.Name);

            throw new AbstractListController.DeletionException(
                "Существуют группы, использующие данный учебный план: " +
                string.Join(", ", names) +
                ". Измените их параметры или удалите перед удалением учебного плана."
            );
        }
    }
}
