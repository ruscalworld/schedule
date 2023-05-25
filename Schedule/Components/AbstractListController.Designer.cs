namespace Schedule.Views {
    partial class AbstractListController {
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
            this.listView = new System.Windows.Forms.ListView();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.searchBox = new Schedule.Components.Search();
            this.controlPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(500, 118);
            this.listView.TabIndex = 10;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.buttonPanel);
            this.controlPanel.Controls.Add(this.searchBox);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 116);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(500, 84);
            this.controlPanel.TabIndex = 14;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanel.ColumnCount = 3;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.buttonPanel.Controls.Add(this.deleteButton, 0, 0);
            this.buttonPanel.Controls.Add(this.addButton, 2, 0);
            this.buttonPanel.Controls.Add(this.editButton, 1, 0);
            this.buttonPanel.Location = new System.Drawing.Point(257, 52);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.buttonPanel.Size = new System.Drawing.Size(240, 29);
            this.buttonPanel.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(3, 3);
            this.deleteButton.MaximumSize = new System.Drawing.Size(73, 23);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(73, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(161, 3);
            this.addButton.MaximumSize = new System.Drawing.Size(73, 23);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(73, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(82, 3);
            this.editButton.MaximumSize = new System.Drawing.Size(73, 23);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(73, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(3, 8);
            this.searchBox.Name = "searchBox";
            this.searchBox.Query = "";
            this.searchBox.Size = new System.Drawing.Size(221, 74);
            this.searchBox.TabIndex = 0;
            this.searchBox.QuerySubmitted += new System.EventHandler(this.searchBox_QuerySubmitted);
            // 
            // AbstractListController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.controlPanel);
            this.Name = "AbstractListController";
            this.Size = new System.Drawing.Size(500, 200);
            this.controlPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Panel controlPanel;
        private Components.Search searchBox;
        private System.Windows.Forms.TableLayoutPanel buttonPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
    }
}
