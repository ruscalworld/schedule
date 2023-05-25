using DataTypes;
using Schedule.Components;
using Schedule.Factories;
using Schedule.Windows;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Schedule.Views {
    public partial class GroupsView : UserControl, View {
        public GroupsView() {
            InitializeComponent();

            groupListControl.Columns.Add("ID", 0);
            groupListControl.Columns.Add("Название", 150);
            groupListControl.Columns.Add("Количество студентов", 150);
            groupListControl.Columns.Add("Институт", 100);
            groupListControl.Columns.Add("Учебный план", 100);

            groupListControl.Bind(Registries.Groups, MakeListViewItem);
        }

        public static ListViewItem MakeListViewItem(Group group) {
            var item = new ListViewItem(group.Id.ToString());
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = group.Name });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = group.StudentAmount.ToString() });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = Registries.Institutions.GetEntity(group.InstitutionId).Name });
            item.SubItems.Add(new ListViewItem.ListViewSubItem { Text = Registries.Curriculums.GetEntity(group.CurriculumId).Name });
            return item;
        }

        public UserControl GetControl() {
            return this;
        }

        public string GetDisplayName() {
            return "Группы";
        }

        private void groupListControl_AddRequest(ListView listView) {
            ManageEntityWindow<Group> window = MakeManagerWindow(0);

            window.Submit += (entity) => {
                Registries.Groups.RegisterEntity(entity);
            };

            window.ShowDialog();
        }

        private void groupListControl_EditRequest(ListView listView, int key) {
            ManageEntityWindow<Group> window = MakeManagerWindow(key);

            Group group = Registries.Groups.GetEntity(key);
            Institution institution = Registries.Institutions.GetEntity(group.InstitutionId);
            Curriculum curriculum = Registries.Curriculums.GetEntity(group.CurriculumId);

            window["name"] = group.Name;
            window["studentAmount"] = group.StudentAmount;
            window["institution"] = institution.Name;
            window["curriculum"] = curriculum.Name;

            window.Submit += (entity) => {
                entity.Id = key;
                Registries.Groups.SaveEntity(entity);
            };

            window.ShowDialog();
        }
        
        private ManageEntityWindow<Group> MakeManagerWindow(int currentId) {
            List<string> institutionNames = new List<string>();
            List<string> curriculumNames = new List<string>();

            foreach (var institution in Registries.Institutions.GetEntities()) {
                institutionNames.Add(institution.Name);
            }

            foreach (var curriculum in Registries.Curriculums.GetEntities()) {
                curriculumNames.Add(curriculum.Name);
            }

            return new ManageEntityWindow<Group>("Добавить группу", new List<Property> {
                new Property("name", Property.Type.Text) { DisplayName = "Название", Validator = v => {
                    Group group = Registries.Groups.FindByName(v as string);
                    if (group != null && group.Id != currentId) throw new AlreadyExistsException("группа", "названием");
                }},

                new Property("studentAmount", Property.Type.Number) { DisplayName = "Число студентов", Validator = v => {
                    if ((int) v < 1) throw new Property.ValidationException("Количество студентов должно быть положительным");
                }},

                new Property("institution", Property.Type.Select, institutionNames) { DisplayName = "Институт" },
                new Property("curriculum", Property.Type.Select, curriculumNames) { DisplayName = "Учебный план" },
            }, new GroupFactory());
        }

        private void groupListControl_DeleteRequest(ListView listView, int key) {
            List<Lesson> dependentLessons = Registries.Lessons.GetEntities(v => v.GroupId == key);
            foreach (var lesson in dependentLessons) Registries.Lessons.RemoveEntity(lesson.Id);
        }
    }
}
