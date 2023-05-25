namespace Schedule.Views {
    partial class CurriculumsView {
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
            this.curriculumsListControl = new Schedule.Views.AbstractListController();
            this.SuspendLayout();
            // 
            // curriculumsListControl
            // 
            this.curriculumsListControl.AllowEdit = true;
            this.curriculumsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curriculumsListControl.Location = new System.Drawing.Point(0, 0);
            this.curriculumsListControl.Name = "curriculumsListControl";
            this.curriculumsListControl.ShowSearch = true;
            this.curriculumsListControl.Size = new System.Drawing.Size(500, 200);
            this.curriculumsListControl.TabIndex = 0;
            this.curriculumsListControl.AddRequest += new Schedule.Views.AbstractListController.ListRequestHandler(this.curriculumsListControl_AddRequest);
            this.curriculumsListControl.EditRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.curriculumsListControl_EditRequest);
            this.curriculumsListControl.DeleteRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.curriculumsListControl_DeleteRequest);
            // 
            // CurriculumsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.curriculumsListControl);
            this.Name = "CurriculumsView";
            this.Size = new System.Drawing.Size(500, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private AbstractListController curriculumsListControl;
    }
}
