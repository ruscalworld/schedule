namespace Schedule.Components {
    partial class Search {
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
            this.searchBox = new System.Windows.Forms.GroupBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.queryLabel = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.searchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Controls.Add(this.searchButton);
            this.searchBox.Controls.Add(this.queryLabel);
            this.searchBox.Controls.Add(this.queryTextBox);
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Location = new System.Drawing.Point(0, 0);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(221, 74);
            this.searchBox.TabIndex = 14;
            this.searchBox.TabStop = false;
            this.searchBox.Text = "Поиск";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(140, 45);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Найти";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // queryLabel
            // 
            this.queryLabel.AutoSize = true;
            this.queryLabel.Location = new System.Drawing.Point(6, 21);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(44, 13);
            this.queryLabel.TabIndex = 1;
            this.queryLabel.Text = "Запрос";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryTextBox.Location = new System.Drawing.Point(56, 18);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(159, 20);
            this.queryTextBox.TabIndex = 0;
            this.queryTextBox.TextChanged += new System.EventHandler(this.queryTextBox_TextChanged);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchBox);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(221, 74);
            this.searchBox.ResumeLayout(false);
            this.searchBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.TextBox queryTextBox;
    }
}
