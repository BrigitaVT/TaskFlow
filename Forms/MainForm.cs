using System;
using System.Drawing;
using System.Windows.Forms;
using TaskFlow.Models;
using TaskFlow.Repositories;

namespace TaskFlow
{
    public partial class MainForm : Form
    {
        // Repository atsakingas už darbą su SQLite DB
        private TaskRepository _repository = new TaskRepository();

        public MainForm()
        {
            InitializeComponent();
            StyleSidebarButtons();
            LoadTasks();
        }

        private void LoadTasks()
        {
            dgvTasks.DataSource = null;
            dgvTasks.DataSource = _repository.GetAll();

            if (dgvTasks.Columns["Id"] != null)
            {
                dgvTasks.Columns["Id"].Visible = false;
            }
        }

        private void StyleSidebarButtons()
        {
            Button[] buttons = { Dashboard, MyTasks, Calendar, Statistics };

            int top = 80;

            foreach (Button btn in buttons)
            {
                btn.Width = 180;
                btn.Height = 45;
                btn.Left = 20;
                btn.Top = top;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.SteelBlue;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;

                top += 60;
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask addTaskForm = new AddTask();

            if (addTaskForm.ShowDialog() == DialogResult.OK)
            {
                TaskItem task = new TaskItem
                {
                    Name = addTaskForm.TaskName,
                    Description = addTaskForm.TaskDescription,
                    StartDate = addTaskForm.StartDate,
                    EndDate = addTaskForm.EndDate,
                    Status = "Planned",
                    UserName = "Brigita"
                };

                _repository.AddTask(task);
                LoadTasks();

                MessageBox.Show("Task added successfully!");
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTasks.SelectedRows[0].Cells["Id"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this task?",
                    "Delete Task",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _repository.DeleteTask(id);
                    LoadTasks();

                    MessageBox.Show("Task deleted successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a task first.");
            }
        }

        private void Dashboard_Click(object sender, EventArgs e) { }

        private void MyTasks_Click(object sender, EventArgs e) { }

        private void Calendar_Click_1(object sender, EventArgs e) { }

        private void Statistics_Click_1(object sender, EventArgs e) { }
    }
}