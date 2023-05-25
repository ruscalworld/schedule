namespace Schedule
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewTitleLabel = new System.Windows.Forms.Label();
            this.viewContainer = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mainMenu = new Schedule.Components.MainMenu();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewTitleLabel
            // 
            this.viewTitleLabel.AutoSize = true;
            this.viewTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewTitleLabel.Location = new System.Drawing.Point(3, 9);
            this.viewTitleLabel.Name = "viewTitleLabel";
            this.viewTitleLabel.Size = new System.Drawing.Size(0, 21);
            this.viewTitleLabel.TabIndex = 0;
            // 
            // viewContainer
            // 
            this.viewContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewContainer.Location = new System.Drawing.Point(0, 41);
            this.viewContainer.Name = "viewContainer";
            this.viewContainer.Size = new System.Drawing.Size(637, 385);
            this.viewContainer.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.viewContainer);
            this.splitContainer.Panel2.Controls.Add(this.viewTitleLabel);
            this.splitContainer.Size = new System.Drawing.Size(800, 426);
            this.splitContainer.SplitterDistance = 159;
            this.splitContainer.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainMenu);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Расписание";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label viewTitleLabel;
        private System.Windows.Forms.Panel viewContainer;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Components.MainMenu mainMenu;
    }
}

