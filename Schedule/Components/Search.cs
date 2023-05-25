using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Schedule.Components {
    public partial class Search : UserControl {
        [Category("Action")]
        public event EventHandler QuerySubmitted;

        public string Query {
            get => queryTextBox.Text;
            set => queryTextBox.Text = value;
        }

        public Search() {
            InitializeComponent();
        }

        private void queryTextBox_TextChanged(object sender, EventArgs e) {
            searchButton.Enabled = queryTextBox.Text.Length > 0;
        }

        private void searchButton_Click(object sender, EventArgs e) {
            if (QuerySubmitted != null) QuerySubmitted(this, e);
        }
    }
}
