using DataTypes;

namespace Schedule.Windows {
    partial class ManageEntityWindow<T> {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.propertiesContainer = new System.Windows.Forms.Panel();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertiesContainer
            // 
            this.propertiesContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesContainer.Location = new System.Drawing.Point(12, 12);
            this.propertiesContainer.Name = "propertiesContainer";
            this.propertiesContainer.Size = new System.Drawing.Size(200, 171);
            this.propertiesContainer.TabIndex = 0;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(137, 189);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Готово";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // ManageEntityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 224);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.propertiesContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ManageEntityWindow";
            this.Text = "ManageEntityWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel propertiesContainer;
        private System.Windows.Forms.Button submitButton;
    }
}