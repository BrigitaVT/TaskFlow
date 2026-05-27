using System;
using System.Linq;
using System.Windows.Forms;
using TaskFlow.Controls;
using TaskFlow.Helpers;
using TaskFlow.Models;
using TaskFlow.Repositories;

namespace TaskFlow
{
    public partial class MainForm : Form
    {

        private DateTime _currentCalendarMonth = DateTime.Today;
        // Repository darbui su SQLite DB
        private TaskRepository _repository = new TaskRepository();

        public MainForm()
        {
            InitializeComponent();

            // Kalendoriaus elementai pradžioje paslėpti
            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;
            flpCalendar.Visible = false;

            // Prijungia kalendoriaus mėnesių mygtukus
            btnPreviousMonth.Click += btnPreviousMonth_Click;
            btnNextMonth.Click += btnNextMonth_Click;

            // Užtikrina kad būtų virš kalendoriaus
            btnPreviousMonth.BringToFront();
            btnNextMonth.BringToFront();
            lblCalendarTitle.BringToFront();

            // Sidebar mygtukų stilius
            UIHelper.StyleSidebarButtons(
                new Button[] { Dashboard, MyTasks, Calendar, Statistics });

            // DataGridView stilius
            UIHelper.StyleDataGridView(dgvTasks);

            // Užkrauna taskus
            LoadTasks();
        }
        // Užkrauna taskus į lentelę
        private void LoadTasks()
        {
            dgvTasks.DataSource = null;
            dgvTasks.DataSource = _repository.GetAll();

            // Paslepia techninį ID stulpelį
            if (dgvTasks.Columns["Id"] != null)
            {
                dgvTasks.Columns["Id"].Visible = false;
            }
        }
        private void LoadCalendar()
        {
            flpCalendar.Controls.Clear();

            var tasks = _repository.GetAll();

            DateTime firstDay =
                new DateTime(
                    _currentCalendarMonth.Year,
                    _currentCalendarMonth.Month,
                    1);

            lblCalendarTitle.Text =
                _currentCalendarMonth.ToString("MMMM yyyy");

            int daysInMonth =
                DateTime.DaysInMonth(
                    _currentCalendarMonth.Year,
                    _currentCalendarMonth.Month);

            for (int i = 0; i < daysInMonth; i++)
            {
                CalendarDayControl day =
                    new CalendarDayControl();

                DateTime currentDay =
                    firstDay.AddDays(i);

                string taskText = "";

                foreach (var task in tasks)
                {
                    if (task.StartDate.Date == currentDay.Date)
                    {
                        taskText +=
                            task.Name +
                            "\n" +
                            task.UserName +
                            "\n";
                    }
                }

                day.SetDay(currentDay, taskText);

                flpCalendar.Controls.Add(day);
            }
        }

        // Add Task mygtukas
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

        // Delete Task mygtukas
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(
                    dgvTasks.SelectedRows[0].Cells["Id"].Value);

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

        // // Dashboard mygtukas – grąžina į pagrindinį užduočių vaizdą
        private void Dashboard_Click(object sender, EventArgs e)
        {
            LoadTasks();

            dgvTasks.Visible = true;
            btnAddTask.Visible = true;
            btnDeleteTask.Visible = true;
            flpCalendar.Visible = false;
            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;
            btnEditTask.Visible = true;
        }

        // My Tasks mygtukas – rodo visas užduotis
        private void MyTasks_Click(object sender, EventArgs e)
        {
            dgvTasks.Visible = true;

            btnAddTask.Visible = true;
            btnDeleteTask.Visible = true;
            btnEditTask.Visible = true;

            flpCalendar.Visible = false;
            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;

            dgvTasks.DataSource = null;

            dgvTasks.DataSource =
                _repository
                .GetAll()
                .Where(t => t.UserName == "Brigita")
                .ToList();

            if (dgvTasks.Columns["Id"] != null)
                dgvTasks.Columns["Id"].Visible = false;
        }

        // Calendar mygtukas – rodo kalendoriaus vaizdą
        private void Calendar_Click_1(object sender, EventArgs e)
        {
            dgvTasks.Visible = false;
            btnAddTask.Visible = false;
            btnDeleteTask.Visible = false;
            btnPreviousMonth.Visible = true;
            btnNextMonth.Visible = true;
            lblCalendarTitle.Visible = true;
            btnEditTask.Visible = false;

            flpCalendar.Visible = true;
            LoadCalendar();
        }


        // Statistics mygtukas – vėliau čia bus statistikos vaizdas
        private void Statistics_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Statistics view will be added later.");
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            _currentCalendarMonth =
                _currentCalendarMonth.AddMonths(-1);

            LoadCalendar();
        }


        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            _currentCalendarMonth =
                _currentCalendarMonth.AddMonths(1);

            LoadCalendar();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a task first.");
                return;
            }

            TaskItem selectedTask =
                (TaskItem)dgvTasks.SelectedRows[0].DataBoundItem;

            AddTask editForm = new AddTask();

            editForm.SetTask(selectedTask);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedTask.Name = editForm.TaskName;
                selectedTask.Description = editForm.TaskDescription;
                selectedTask.StartDate = editForm.StartDate;
                selectedTask.EndDate = editForm.EndDate;

                _repository.UpdateTask(selectedTask);

                LoadTasks();

                MessageBox.Show("Task updated successfully!");
            }
        }
    }
}