using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Components {
    internal partial class MainMenu {
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem openFileMenuItem;
        private SaveFileDialog saveFileDialog;
        private ToolStripMenuItem saveAsFileMenuItem;

        private void InitializeComponent() {
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveAsFileMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "Файл";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openFileMenuItem.Text = "Открыть";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // saveAsFileMenuItem
            // 
            this.saveAsFileMenuItem.Name = "saveAsFileMenuItem";
            this.saveAsFileMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsFileMenuItem.Text = "Сохранить как...";
            this.saveAsFileMenuItem.Click += new System.EventHandler(this.saveAsFileMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "sch";
            this.saveFileDialog.Filter = "Файлы расписания (*.sch)|*.sch";
            this.saveFileDialog.Title = "Сохранить как...";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Файлы расписания (*.sch)|*.sch|Все файлы (*.*)|*.*";
            // 
            // MainMenu
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.ResumeLayout(false);

        }

        private OpenFileDialog openFileDialog;
    }
}
