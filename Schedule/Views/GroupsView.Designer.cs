namespace Schedule.Views {
    partial class GroupsView {
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
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupListControl = new Schedule.Views.AbstractListController();
            this.groupNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupStudentAmountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Название";
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "Количество студентов";
            // 
            // groupListControl
            // 
            this.groupListControl.AllowEdit = true;
            this.groupListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupListControl.Location = new System.Drawing.Point(0, 0);
            this.groupListControl.Name = "groupListControl";
            this.groupListControl.ShowSearch = true;
            this.groupListControl.Size = new System.Drawing.Size(500, 200);
            this.groupListControl.TabIndex = 0;
            this.groupListControl.AddRequest += new Schedule.Views.AbstractListController.ListRequestHandler(this.groupListControl_AddRequest);
            this.groupListControl.EditRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.groupListControl_EditRequest);
            this.groupListControl.DeleteRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.groupListControl_DeleteRequest);
            // 
            // groupNameHeader
            // 
            this.groupNameHeader.Text = "Название";
            // 
            // groupStudentAmountHeader
            // 
            this.groupStudentAmountHeader.Text = "Количество студентов";
            // 
            // GroupsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupListControl);
            this.Name = "GroupsView";
            this.Size = new System.Drawing.Size(500, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private AbstractListController groupListControl;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader sizeHeader;
        private System.Windows.Forms.ColumnHeader groupNameHeader;
        private System.Windows.Forms.ColumnHeader groupStudentAmountHeader;
    }
}
