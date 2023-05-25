using DataTypes;
using Schedule.Components;
using Schedule.Factories;
using Schedule.Storage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Schedule.Windows {
    public partial class ManageEntityWindow<T> : Form {
        public object this[string key] {
            get {
                if (!mappedProperties.ContainsKey(key)) return null;
                Property property = mappedProperties[key];
                return property.Value;
            }
            set {
                Property property = mappedProperties[key];
                property.Value = value;
            }
        }

        public string Title {
            get => Text;
            set => Text = value;
        }

        public event AnyEntityEventHandler<T> Submit;

        private readonly Dictionary<string, Property> mappedProperties = new Dictionary<string, Property>();
        private readonly Factory<T> factory;

        public ManageEntityWindow(string title, List<Property> properties, Factory<T> factory) {
            InitializeComponent();

            int y = 0;
            foreach (var property in properties) {
                property.Width = propertiesContainer.Width;
                property.Location = new Point(0, y);
                property.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                y += property.Height;
                propertiesContainer.Controls.Add(property);
                mappedProperties.Add(property.GetName(), property);
            }

            Height = y + 92;
            Text = title;

            this.factory = factory;
        }

        private void submitButton_Click(object sender, EventArgs e) {
            Dictionary<string, object> values;

            try {
                values = GetValues();

                if (Submit != null) {
                    T entity = factory.Create(values);
                    Submit(entity);
                }
            } catch (Property.ValidationException exception) {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Close();
        }

        private Dictionary<string, object> GetValues() {
            Dictionary<string, object> values = new Dictionary<string, object>();

            foreach (var key in mappedProperties.Keys) {
                var property = mappedProperties[key];
                property.ValidateProperty();
                values.Add(key, property.Value);
            }

            return values;
        }
    }
}
