using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Schedule.Components {
    public partial class NavigationElement : UserControl {
        public override string Text {
            get => button.Text;
            set => button.Text = value;
        }

        [Category("Action")]
        public new event EventHandler Click;

        public NavigationElement() {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e) {
            Click(this, e);
        }
    }
}
