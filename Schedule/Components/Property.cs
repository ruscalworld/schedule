using Schedule.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Schedule.Views.AbstractListController;

namespace Schedule.Components {
    public partial class Property : UserControl {
        private Control control;
        private string name;
        private Type type;

        public string DisplayName {
            get => nameLabel.Text; 
            set => nameLabel.Text = value;
        }

        public object Value {
            get {
                switch (type) {
                    case Type.Text:
                    case Type.Select:
                        return control.Text;
                    case Type.Number:
                        return (int)(control as NumericUpDown).Value;
                    case Type.List:
                        return (control as AbstractListController).Items;
                    default: throw new NotImplementedException();
                }
            }

            set {
                switch (type) {
                    case Type.Text:
                    case Type.Select:
                        control.Text = value as string;
                        break;
                    case Type.Number:
                        (control as NumericUpDown).Value = (int) value;
                        break;
                    case Type.List:
                        var items = (control as AbstractListController).Items;
                        items.Clear();
                        items.AddRange(value as ListView.ListViewItemCollection);
                        break;
                    default: throw new NotImplementedException();
                }
            }
        }

        public Action<object> Validator;
        public bool Optional { get; set; }

        public Property(string name, Type type) {
            InitializeComponent();

            control = MakeControl(type);
            Size = new Size(200, control.Height + 8 + (type == Type.List ? nameLabel.Height + 8 : 0));
            Controls.Add(control);
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            this.name = name;
            this.type = type;
        }

        public Property(string name, Type type, List<string> items) : this(name, type) {
            if (control is ComboBox comboBox) {
                foreach (string item in items) {
                    comboBox.Items.Add(item);
                }
            }
        }

        public Property(string name, Action<ListView.ListViewItemCollection> itemsHandler, Action<ListView.ColumnHeaderCollection> headersHandler, ListRequestHandler addRequestHandler) : this(name, Type.List) {
            if (control is AbstractListController listControl) {
                itemsHandler.Invoke(listControl.Items);
                headersHandler.Invoke(listControl.Columns);
                listControl.AddRequest += addRequestHandler;
            }
        }

        private Control MakeControl(Type type) {
            var location = type == Type.List ? new Point(4, 4 + nameLabel.Height + 8) : new Point(Size.Width - 104, 4);
            var size = type == Type.List ? new Size(Size.Width - 8, 200) : new Size(100, 20);

            switch (type) {
                case Type.Text:
                    return new TextBox { Location = location, Size = size };
                case Type.Number:
                    return new NumericUpDown { Location = location, Size = size };
                case Type.Select: 
                    return new ComboBox { Location = location, Size = size };
                case Type.List:
                    return new AbstractListController { Location = location, Size = size, ShowSearch = false, AllowEdit = false };
                default:
                    throw new NotImplementedException();
            }
        }

        public string GetName() {
            return name;
        }

        public void ValidateProperty() {
            if (!Optional) {
                if (Value == null) throw new ValidationException("Укажите значение для \"" + DisplayName + "\"");
                if (Value is string && string.IsNullOrWhiteSpace(Value as string))
                    throw new ValidationException("Укажите непустое значение для \"" + DisplayName + "\"");
                if (Value is int && (int)Value == 0)
                    throw new ValidationException("Укажите ненулевое значение для \"" + DisplayName + "\"");
            }

            if (Validator == null) return;
            Validator.Invoke(Value);
        }

        public enum Type {
            Text, Number, Select, List,
        }

        public class ValidationException : Exception {
            public ValidationException(string message) : base(message) { }
        }
    }
}
