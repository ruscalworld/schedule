using System.Windows.Forms;

namespace Schedule.Views {
    public interface View {
        string GetDisplayName();
        UserControl GetControl();
    }
}
