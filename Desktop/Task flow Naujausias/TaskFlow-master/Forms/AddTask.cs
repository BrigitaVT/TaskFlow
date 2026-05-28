using System;
using System.Drawing;
using System.Windows.Forms;
using TaskFlow.Models;

namespace TaskFlow
{
    public partial class AddTask : Form
    {
        private ComboBox PriorityComboBox;
        private ComboBox StatusComboBox;

        public TaskItem TaskResult { get; set; }

        public string TaskName => TaskTitleText.Text;
        public string TaskDescription => TaskDescriptionText.Text;
        public DateTime StartDate => StartDatePicker.Value;
        public DateTime EndDate => EndDatePicker.Value;
        public string TaskPriority => PriorityComboBox.Text;
        public string TaskStatus => StatusComboBox.Text;

        public AddTask()
        {
            InitializeComponent();
            CreatePriorityComboBox();
        }

        private void CreatePriorityComboBox()
        {
            Label priorityLabel = new Label
            {
                Text = "Svarbumas",
                Location = new Point(45, 285),
                AutoSize = true
            };

            PriorityComboBox = new ComboBox
            {
                Location = new Point(130, 280),
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            PriorityComboBox.Items.Add("Low");
            PriorityComboBox.Items.Add("Medium");
            PriorityComboBox.Items.Add("High");
            PriorityComboBox.SelectedIndex = 1;

            Label statusLabel = new Label
            {
                Text = "Būsena",
                Location = new Point(45, 325),
                AutoSize = true
            };

            StatusComboBox = new ComboBox
            {
                Location = new Point(130, 320),
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            StatusComboBox.Items.Add("Planned");
            StatusComboBox.Items.Add("In Progress");
            StatusComboBox.Items.Add("Finished");
            StatusComboBox.SelectedIndex = 0;

            Controls.Add(priorityLabel);
            Controls.Add(PriorityComboBox);
            Controls.Add(statusLabel);
            Controls.Add(StatusComboBox);
        }

        private void TaskFinishButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TaskCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void SetTask(TaskItem task)
        {
            TaskTitleText.Text = task.Name;
            TaskDescriptionText.Text = task.Description;
            StartDatePicker.Value = task.StartDate;
            EndDatePicker.Value = task.EndDate;
            PriorityComboBox.Text = task.Priority;
            StatusComboBox.Text = task.Status;
        }
    }
}