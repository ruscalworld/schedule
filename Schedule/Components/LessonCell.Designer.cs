namespace Schedule.Components {
    partial class LessonCell {
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
            this.disciplineComboBox = new System.Windows.Forms.ComboBox();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.roomComboBox = new System.Windows.Forms.ComboBox();
            this.estimationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // disciplineComboBox
            // 
            this.disciplineComboBox.FormattingEnabled = true;
            this.disciplineComboBox.Location = new System.Drawing.Point(3, 3);
            this.disciplineComboBox.Name = "disciplineComboBox";
            this.disciplineComboBox.Size = new System.Drawing.Size(194, 21);
            this.disciplineComboBox.TabIndex = 0;
            this.disciplineComboBox.SelectedIndexChanged += new System.EventHandler(this.disciplineComboBox_SelectedIndexChanged);
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(3, 30);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(120, 21);
            this.teacherComboBox.TabIndex = 1;
            this.teacherComboBox.SelectedIndexChanged += new System.EventHandler(this.teacherComboBox_SelectedIndexChanged);
            // 
            // roomComboBox
            // 
            this.roomComboBox.FormattingEnabled = true;
            this.roomComboBox.Location = new System.Drawing.Point(129, 30);
            this.roomComboBox.Name = "roomComboBox";
            this.roomComboBox.Size = new System.Drawing.Size(68, 21);
            this.roomComboBox.TabIndex = 2;
            this.roomComboBox.SelectedIndexChanged += new System.EventHandler(this.roomComboBox_SelectedIndexChanged);
            // 
            // estimationLabel
            // 
            this.estimationLabel.AutoSize = true;
            this.estimationLabel.Location = new System.Drawing.Point(3, 3);
            this.estimationLabel.Name = "estimationLabel";
            this.estimationLabel.Size = new System.Drawing.Size(0, 13);
            this.estimationLabel.TabIndex = 3;
            this.estimationLabel.Visible = false;
            // 
            // LessonCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.estimationLabel);
            this.Controls.Add(this.roomComboBox);
            this.Controls.Add(this.teacherComboBox);
            this.Controls.Add(this.disciplineComboBox);
            this.Name = "LessonCell";
            this.Size = new System.Drawing.Size(200, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox disciplineComboBox;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.ComboBox roomComboBox;
        private System.Windows.Forms.Label estimationLabel;
    }
}
