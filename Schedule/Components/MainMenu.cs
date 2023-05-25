using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Components {
    internal partial class MainMenu : MenuStrip {
        public MainMenu() {
            InitializeComponent();
        }

        private void saveAsFileMenuItem_Click(object sender, EventArgs e) {
            var result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            Registries.ExportAll(saveFileDialog.FileName);
        }

        private void openFileMenuItem_Click(object sender, EventArgs e) {
            var result = openFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;

            Registries.Import(openFileDialog.FileName);
        }
    }
}
