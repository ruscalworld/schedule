namespace Schedule.Views {
    partial class InstitutionsView {
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
            this.institutionListControl = new Schedule.Views.AbstractListController();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // institutionListControl
            // 
            this.institutionListControl.AllowEdit = true;
            this.institutionListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.institutionListControl.Location = new System.Drawing.Point(0, 0);
            this.institutionListControl.Name = "institutionListControl";
            this.institutionListControl.ShowSearch = true;
            this.institutionListControl.Size = new System.Drawing.Size(500, 200);
            this.institutionListControl.TabIndex = 1;
            this.institutionListControl.AddRequest += new Schedule.Views.AbstractListController.ListRequestHandler(this.institutionListControl_AddRequest);
            this.institutionListControl.EditRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.institutionListControl_EditRequest);
            this.institutionListControl.DeleteRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.institutionListControl_DeleteRequest);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Название";
            // 
            // InstitutionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.institutionListControl);
            this.Name = "InstitutionsView";
            this.Size = new System.Drawing.Size(500, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private AbstractListController institutionListControl;
        private System.Windows.Forms.ColumnHeader nameHeader;
    }
}
