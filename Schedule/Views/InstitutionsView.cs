using DataTypes;
using Schedule.Components;
using Schedule.Factories;
using Schedule.Windows;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Schedule.Views {
    public partial class InstitutionsView : UserControl, View {
        public InstitutionsView() {
            InitializeComponent();
            institutionListControl.Columns.Add("ID", 0);
            institutionListControl.Columns.Add("Название", 100);
            institutionListControl.Bind(Registries.Institutions, MakeListViewItem);
        }

        public static ListViewItem MakeListViewItem(Institution institution) {
            var item = new ListViewItem(institution.Id.ToString());
            item.SubItems.Add(institution.Name);
            return item;
        }

        public UserControl GetControl() {
            return this;
        }

        public string GetDisplayName() {
            return "Институты";
        }

        private void institutionListControl_AddRequest(ListView listView) {
            ManageEntityWindow<Institution> window = MakeManagerWindow(0);

            window.Submit += (entity) => {
                Registries.Institutions.RegisterEntity(entity);
            };

            window.ShowDialog();
        }

        private void institutionListControl_EditRequest(ListView listView, int key) {
            ManageEntityWindow<Institution> window = MakeManagerWindow(key);

            Institution institution = Registries.Institutions.GetEntity(key);
            window["name"] = institution.Name;

            window.Submit += (entity) => {
                entity.Id = key;
                Registries.Institutions.SaveEntity(entity);
            };

            window.ShowDialog();
        }

        public List<string> GetInstitutionNames() {
            List<string> names = new List<string>();
            foreach (ListViewItem item in institutionListControl.GetItems()) {
                names.Add(item.Text);
            }

            return names;
        }

        private ManageEntityWindow<Institution> MakeManagerWindow(int currentId) {
            return new ManageEntityWindow<Institution>("Добавить институт", new List<Property> {
                new Property("name", Property.Type.Text) { DisplayName = "Название", Validator = v => {
                    Institution institution = Registries.Institutions.FindByName(v as string);
                    if (institution != null && institution.Id != currentId) throw new AlreadyExistsException("институт", "названием");
                }}
            }, new InstitutionFactory());
        }

        private void institutionListControl_DeleteRequest(ListView listView, int key) {
            List<Group> dependentGroups = Registries.Groups.GetEntities(v => v.InstitutionId == key);
            if (dependentGroups.Count == 0) return;

            List<string> names = new List<string>();
            foreach (var group in dependentGroups) names.Add(group.Name);

            throw new AbstractListController.DeletionException(
                "С данным институтом связаны группы: " +
                string.Join(", ", names) +
                ". Измените их параметры или удалите перед удалением института."
            );
        }
    }
}
