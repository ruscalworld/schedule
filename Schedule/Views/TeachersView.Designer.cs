namespace Schedule.Views {
    partial class TeachersView {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.teachersListControl = new Schedule.Views.AbstractListController();
            this.SuspendLayout();
            // 
            // teachersListControl
            // 
            this.teachersListControl.AllowEdit = true;
            this.teachersListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teachersListControl.Location = new System.Drawing.Point(0, 0);
            this.teachersListControl.Name = "teachersListControl";
            this.teachersListControl.ShowSearch = true;
            this.teachersListControl.Size = new System.Drawing.Size(500, 200);
            this.teachersListControl.TabIndex = 0;
            this.teachersListControl.AddRequest += new Schedule.Views.AbstractListController.ListRequestHandler(this.teachersListControl_AddRequest);
            this.teachersListControl.EditRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.teachersListControl_EditRequest);
            this.teachersListControl.DeleteRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.teachersListControl_DeleteRequest);
            // 
            // TeachersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.teachersListControl);
            this.Name = "TeachersView";
            this.Size = new System.Drawing.Size(500, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private AbstractListController teachersListControl;
    }
}
