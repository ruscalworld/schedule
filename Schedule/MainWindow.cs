using Schedule.Components;
using Schedule.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Schedule
{
    public partial class MainWindow : Form
    {
        public Dictionary<string, Views.View> Views = new Dictionary<string, Views.View> {};

        public MainWindow()
        {
            InitializeComponent();

            Views.Add("institutions", new InstitutionsView());
            Views.Add("curriculums", new CurriculumsView());
            Views.Add("groups", new GroupsView());
            Views.Add("rooms", new RoomsView());
            Views.Add("teachers", new TeachersView());
            Views.Add("schedule", new ScheduleView());
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            UpdateMenu();
        }

        private void UpdateMenu() {
            var menu = splitContainer.Panel1;
            menu.Controls.Clear();
            int y = 0;
            const int navElementSize = 30;

            foreach (Views.View view in Views.Values) {
                var element = new NavigationElement{ Text = view.GetDisplayName() };
                element.Location = new Point(0, y);
                element.Size = new Size(menu.Width, navElementSize);
                element.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                element.Click += (a, b) => ShowView(view);
                y += navElementSize;
                menu.Controls.Add(element);
            }
        }

        private void ShowView(Views.View view) {
            viewContainer.Controls.Clear();
            var control = view.GetControl();
            control.Dock = DockStyle.Fill;
            viewContainer.Controls.Add(control);
            viewTitleLabel.Text = view.GetDisplayName();
        }
    }
}
