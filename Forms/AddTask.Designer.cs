namespace TaskFlow
{
    partial class AddTask
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TaskFinishButton = new System.Windows.Forms.Button();
            this.TaskCancelButton = new System.Windows.Forms.Button();
            this.TaskTitleText = new System.Windows.Forms.TextBox();
            this.TaskDescriptionText = new System.Windows.Forms.RichTextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.DatelLabel = new System.Windows.Forms.Label();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ToLabel = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // TaskFinishButton
            // 
            this.TaskFinishButton.Location = new System.Drawing.Point(379, 340);
            this.TaskFinishButton.Name = "TaskFinishButton";
            this.TaskFinishButton.Size = new System.Drawing.Size(96, 23);
            this.TaskFinishButton.TabIndex = 9;
            this.TaskFinishButton.Text = "Finish";
            this.TaskFinishButton.UseVisualStyleBackColor = true;
            this.TaskFinishButton.Click += new System.EventHandler(this.TaskFinishButton_Click);
            // 
            // TaskCancelButton
            // 
            this.TaskCancelButton.Location = new System.Drawing.Point(277, 340);
            this.TaskCancelButton.Name = "TaskCancelButton";
            this.TaskCancelButton.Size = new System.Drawing.Size(96, 23);
            this.TaskCancelButton.TabIndex = 10;
            this.TaskCancelButton.Text = "Cancel";
            this.TaskCancelButton.UseVisualStyleBackColor = true;
            this.TaskCancelButton.Click += new System.EventHandler(this.TaskCancelButton_Click);
            // 
            // TaskTitleText
            // 
            this.TaskTitleText.Location = new System.Drawing.Point(72, 47);
            this.TaskTitleText.Name = "TaskTitleText";
            this.TaskTitleText.Size = new System.Drawing.Size(233, 20);
            this.TaskTitleText.TabIndex = 11;
            // 
            // TaskDescriptionText
            // 
            this.TaskDescriptionText.Location = new System.Drawing.Point(72, 107);
            this.TaskDescriptionText.Name = "TaskDescriptionText";
            this.TaskDescriptionText.Size = new System.Drawing.Size(232, 90);
            this.TaskDescriptionText.TabIndex = 12;
            this.TaskDescriptionText.Text = "";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(17, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(60, 13);
            this.NameLabel.TabIndex = 13;
            this.NameLabel.Text = "Task name";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(17, 79);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(85, 13);
            this.DescriptionLabel.TabIndex = 14;
            this.DescriptionLabel.Text = "Task description";
            // 
            // DatelLabel
            // 
            this.DatelLabel.AutoSize = true;
            this.DatelLabel.Location = new System.Drawing.Point(17, 217);
            this.DatelLabel.Name = "DatelLabel";
            this.DatelLabel.Size = new System.Drawing.Size(55, 13);
            this.DatelLabel.TabIndex = 15;
            this.DatelLabel.Text = "Task date";
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(45, 248);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(140, 20);
            this.StartDatePicker.TabIndex = 16;
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(191, 254);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(16, 13);
            this.ToLabel.TabIndex = 17;
            this.ToLabel.Text = "to";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(213, 248);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(140, 20);
            this.EndDatePicker.TabIndex = 18;
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 376);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.DatelLabel);
            this.Controls.Add(this.TaskDescriptionText);
            this.Controls.Add(this.TaskTitleText);
            this.Controls.Add(this.TaskCancelButton);
            this.Controls.Add(this.TaskFinishButton);
            this.Name = "AddTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button TaskFinishButton;
        private System.Windows.Forms.Button TaskCancelButton;
        private System.Windows.Forms.TextBox TaskTitleText;
        private System.Windows.Forms.RichTextBox TaskDescriptionText;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label DatelLabel;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
    }
}
