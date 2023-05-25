using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Schedule.Storage;
using DataTypes;

namespace Schedule.Views {
    public partial class AbstractListController : UserControl {
        [Category("Behavior")]
        public ListView.ListViewItemCollection Items {
            get {
                return listView.Items;
            }
        }

        [Category("Behavior")]
        public ListView.ColumnHeaderCollection Columns {
            get {
                return listView.Columns;
            }
        }

        [Category("Behavior")]
        public bool ShowSearch {
            get {
                return searchBox.Visible;
            }
            set {
                if (value) {
                    listView.Height = Size.Height - 82;
                    buttonPanel.Width = 240;
                    buttonPanel.Location = new Point(controlPanel.Size.Width - buttonPanel.Width - 3, controlPanel.Size.Height - buttonPanel.Height - 3);
                    buttonPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                } else {
                    listView.Height = Size.Height - 38;
                    buttonPanel.Dock = DockStyle.Bottom;
                }

                searchBox.Visible = value;
            }
        }

        [Category("Behavior")]
        public bool AllowEdit {
            get {
                return editButton.Visible;
            }
            set {
                editButton.Visible = value;
            }
        }

        [Category("Action")]
        public event ListRequestHandler AddRequest;

        [Category("Action")]
        public event ListEntityActionHandler EditRequest;

        [Category("Action")]
        public event ListEntityActionHandler DeleteRequest;

        public delegate void ListRequestHandler(ListView listView);
        public delegate void ListEntityActionHandler(ListView listView, int key);


        public AbstractListController() {
            InitializeComponent();
        }

        public void Bind<T>(Registry<T> registry, Func<T, ListViewItem> mapper) where T: Entity {
            registry.EntityAdded += entity => Items.Add(mapper(entity));
            registry.EntityRemoved += entity => DeleteItem(entity.Id);
            registry.EntityModified += entity => UpdateItem(entity.Id, mapper(entity));

            DeleteRequest += (view, id) => registry.RemoveEntity(id);
        }

        private ListViewItem GetItemByEntityId(long id) {
            foreach (ListViewItem item in Items) {
                if (item.Text == id.ToString()) return item;
            }

            return null;
        }

        private void UpdateItem(long id, ListViewItem newItem) {
            ListViewItem item = GetItemByEntityId(id);

            for (int i = 1; i < newItem.SubItems.Count; i++) {
                item.SubItems[i] = newItem.SubItems[i];
            }
        }

        private void DeleteItem(long id) {
            ListViewItem item = GetItemByEntityId(id);
            Items.Remove(item);
        }

        private void addButton_Click(object sender, EventArgs e) {
            if (AddRequest != null) AddRequest(listView);
        }

        private void searchBox_QuerySubmitted(object sender, EventArgs e) {
            foreach (ListViewItem item in listView.Items) {
                bool found = false;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems) {
                    if (subItem.Text.ToLower().Contains(searchBox.Query.ToLower())) {
                        found = true;
                        break;
                    }
                }

                item.Selected = found;
            }
        }

        private void editButton_Click(object sender, EventArgs e) {
            EditSelection();
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView.SelectedItems) {
                try {
                    if (DeleteRequest != null) DeleteRequest(listView, int.Parse(item.Text));
                    else listView.Items.Remove(item);
                } catch (DeletionException ex) {
                    MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e) {
            editButton.Enabled = listView.SelectedItems.Count == 1;
            deleteButton.Enabled = listView.SelectedItems.Count > 0;
        }

        private void listView_DoubleClick(object sender, EventArgs e) {
            EditSelection();
        }

        private void EditSelection() {
            if (!AllowEdit) return;
            if (listView.SelectedItems.Count != 1) return;
            int key = int.Parse(listView.SelectedItems[0].Text);
            if (EditRequest != null) EditRequest(listView, key);
        }

        public ListView.ListViewItemCollection GetItems() {
            return listView.Items;
        }

        public class DeletionException : Exception {
            public DeletionException(string message) : base(message) { }
        }
    }
}
