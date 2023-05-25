using DataTypes;
using Schedule.Components;
using Schedule.Factories;
using Schedule.Windows;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Schedule.Views {
    public partial class RoomsView : UserControl, View {
        public RoomsView() {
            InitializeComponent();

            roomsListControl.Columns.Add("ID", 0);
            roomsListControl.Columns.Add("Название", 150);
            roomsListControl.Columns.Add("Вместимость", 90);

            roomsListControl.Bind(Registries.Rooms, MakeListViewItem);
        }

        public static ListViewItem MakeListViewItem(Room room) {
            var item = new ListViewItem(room.Id.ToString());
            item.SubItems.Add(room.Name);
            item.SubItems.Add(room.Capacity.ToString());
            return item;
        }

        public UserControl GetControl() {
            return this;
        }

        public string GetDisplayName() {
            return "Аудитории";
        }

        private void roomsListControl_AddRequest(ListView listView) {
            ManageEntityWindow<Room> window = MakeManagerWindow(0);

            window.Submit += entity => {
                Registries.Rooms.RegisterEntity(entity);
            };

            window.ShowDialog();
        }

        private void roomsListControl_EditRequest(ListView listView, int key) {
            ManageEntityWindow<Room> window = MakeManagerWindow(key);

            Room room = Registries.Rooms.GetEntity(key);
            window["name"] = room.Name;
            window["capacity"] = room.Capacity;

            window.Submit += (entity) => {
                entity.Id = key;
                Registries.Rooms.SaveEntity(entity);
            };

            window.ShowDialog();
        }

        private ManageEntityWindow<Room> MakeManagerWindow(int currentId) {
            return new ManageEntityWindow<Room>("Добавить аудиторию", new List<Property> {
                new Property("name", Property.Type.Text) { DisplayName = "Название", Validator = v => {
                    Room room = Registries.Rooms.FindByName(v as string);
                    if (room != null && room.Id != currentId) throw new AlreadyExistsException("аудитория", "названием");
                }},

                new Property("capacity", Property.Type.Number) { DisplayName = "Вместимость" },
            }, new RoomFactory());
        }

        private void roomsListControl_DeleteRequest(ListView listView, int key) {
            List<Lesson> dependentLessons = Registries.Lessons.GetEntities(v => v.RoomId == key);
            if (dependentLessons.Count == 0) return;

            throw new AbstractListController.DeletionException(
                "Существуют занятия, в которых упоминается эта аудитория. Измените их параметры или удалите перед удалением аудитории."
            );
        }
    }
}
