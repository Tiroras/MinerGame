namespace MinerGame
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.difficultyLabel = new System.Windows.Forms.Label();
            this.difficultySelect = new System.Windows.Forms.ComboBox();
            this.saveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(12, 31);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(69, 15);
            this.difficultyLabel.TabIndex = 0;
            this.difficultyLabel.Text = "Сложность";
            this.difficultyLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // difficultySelect
            // 
            this.difficultySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultySelect.FormattingEnabled = true;
            this.difficultySelect.Items.AddRange(new object[] {
            "Легкая",
            "Средняя",
            "Сложная"});
            this.difficultySelect.Location = new System.Drawing.Point(87, 28);
            this.difficultySelect.Name = "difficultySelect";
            this.difficultySelect.Size = new System.Drawing.Size(98, 23);
            this.difficultySelect.TabIndex = 1;
            this.difficultySelect.SelectedIndexChanged += new System.EventHandler(this.difficultySelect_SelectedIndexChanged);
            // 
            // saveSettings
            // 
            this.saveSettings.Enabled = false;
            this.saveSettings.Location = new System.Drawing.Point(12, 76);
            this.saveSettings.Name = "saveSettings";
            this.saveSettings.Size = new System.Drawing.Size(173, 23);
            this.saveSettings.TabIndex = 2;
            this.saveSettings.Text = "Сохранить";
            this.saveSettings.UseVisualStyleBackColor = true;
            this.saveSettings.Click += new System.EventHandler(this.saveSettings_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 111);
            this.Controls.Add(this.saveSettings);
            this.Controls.Add(this.difficultySelect);
            this.Controls.Add(this.difficultyLabel);
            this.Name = "Settings";
            this.Text = "Найстройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label difficultyLabel;
        private ComboBox difficultySelect;
        private Button saveSettings;
    }
}