using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Components {
    public partial class DayEstimationCell : UserControl {
        public double Value {
            get {
                return double.Parse(estimationLabel.Text);
            }

            set {
                estimationLabel.Text = string.Format("{0:0.00}", value);
            }
        }

        public DayEstimationCell() {
            InitializeComponent();
        }
    }
}
