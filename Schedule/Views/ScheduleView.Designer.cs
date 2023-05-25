namespace Schedule.Views {
    partial class ScheduleView {
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
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.groupLabel = new System.Windows.Forms.Label();
            this.scheduleTable = new System.Windows.Forms.TableLayoutPanel();
            this.estimationDisplayCheckBox = new System.Windows.Forms.CheckBox();
            this.curriculumButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(3, 19);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(121, 21);
            this.groupComboBox.TabIndex = 0;
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged);
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Location = new System.Drawing.Point(3, 3);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(42, 13);
            this.groupLabel.TabIndex = 3;
            this.groupLabel.Text = "Группа";
            // 
            // scheduleTable
            // 
            this.scheduleTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleTable.AutoScroll = true;
            this.scheduleTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.scheduleTable.ColumnCount = 9;
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.scheduleTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.scheduleTable.Location = new System.Drawing.Point(0, 46);
            this.scheduleTable.Name = "scheduleTable";
            this.scheduleTable.RowCount = 18;
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.scheduleTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.scheduleTable.Size = new System.Drawing.Size(640, 434);
            this.scheduleTable.TabIndex = 0;
            // 
            // estimationDisplayCheckBox
            // 
            this.estimationDisplayCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.estimationDisplayCheckBox.AutoSize = true;
            this.estimationDisplayCheckBox.Location = new System.Drawing.Point(510, 7);
            this.estimationDisplayCheckBox.Name = "estimationDisplayCheckBox";
            this.estimationDisplayCheckBox.Size = new System.Drawing.Size(127, 17);
            this.estimationDisplayCheckBox.TabIndex = 6;
            this.estimationDisplayCheckBox.Text = "Отображать оценки";
            this.estimationDisplayCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.estimationDisplayCheckBox.UseVisualStyleBackColor = true;
            this.estimationDisplayCheckBox.CheckedChanged += new System.EventHandler(this.estimationDisplayCheckBox_CheckedChanged);
            // 
            // curriculumButton
            // 
            this.curriculumButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.curriculumButton.Location = new System.Drawing.Point(400, 3);
            this.curriculumButton.Name = "curriculumButton";
            this.curriculumButton.Size = new System.Drawing.Size(104, 23);
            this.curriculumButton.TabIndex = 7;
            this.curriculumButton.Text = "Учебный план";
            this.curriculumButton.UseVisualStyleBackColor = true;
            this.curriculumButton.Click += new System.EventHandler(this.curriculumButton_Click);
            // 
            // ScheduleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.curriculumButton);
            this.Controls.Add(this.estimationDisplayCheckBox);
            this.Controls.Add(this.scheduleTable);
            this.Controls.Add(this.groupLabel);
            this.Controls.Add(this.groupComboBox);
            this.Name = "ScheduleView";
            this.Size = new System.Drawing.Size(640, 480);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.TableLayoutPanel scheduleTable;
        private System.Windows.Forms.CheckBox estimationDisplayCheckBox;
        private System.Windows.Forms.Button curriculumButton;
    }
}
