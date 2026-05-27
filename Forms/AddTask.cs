using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TaskFlow.Models;

namespace TaskFlow
{
    public partial class AddTask : Form
    {

        public TaskItem TaskResult { get; set; }

        public string TaskName => TaskTitleText.Text;
        public string TaskDescription => TaskDescriptionText.Text;
        public DateTime StartDate => StartDatePicker.Value;
        public DateTime EndDate => EndDatePicker.Value;

        public AddTask()
        {
            InitializeComponent();
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
        }

        
    }
}
