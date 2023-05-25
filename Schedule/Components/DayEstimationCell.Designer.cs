namespace Schedule.Components {
    partial class DayEstimationCell {
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
            this.estimationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // estimationLabel
            // 
            this.estimationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.estimationLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.estimationLabel.Location = new System.Drawing.Point(0, 0);
            this.estimationLabel.Name = "estimationLabel";
            this.estimationLabel.Size = new System.Drawing.Size(200, 32);
            this.estimationLabel.TabIndex = 0;
            this.estimationLabel.Text = "0.00";
            this.estimationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayEstimationCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.estimationLabel);
            this.Name = "DayEstimationCell";
            this.Size = new System.Drawing.Size(200, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label estimationLabel;
    }
}
