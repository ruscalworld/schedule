namespace Schedule.Views {
    partial class RoomsView {
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
            this.roomsListControl = new Schedule.Views.AbstractListController();
            this.SuspendLayout();
            // 
            // roomsListControl
            // 
            this.roomsListControl.AllowEdit = true;
            this.roomsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomsListControl.Location = new System.Drawing.Point(0, 0);
            this.roomsListControl.Name = "roomsListControl";
            this.roomsListControl.ShowSearch = true;
            this.roomsListControl.Size = new System.Drawing.Size(500, 200);
            this.roomsListControl.TabIndex = 0;
            this.roomsListControl.AddRequest += new Schedule.Views.AbstractListController.ListRequestHandler(this.roomsListControl_AddRequest);
            this.roomsListControl.EditRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.roomsListControl_EditRequest);
            this.roomsListControl.DeleteRequest += new Schedule.Views.AbstractListController.ListEntityActionHandler(this.roomsListControl_DeleteRequest);
            // 
            // RoomsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roomsListControl);
            this.Name = "RoomsView";
            this.Size = new System.Drawing.Size(500, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private AbstractListController roomsListControl;
    }
}
