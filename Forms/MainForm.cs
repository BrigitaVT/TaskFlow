using System;
using System.Drawing;
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
        private TaskRepository _repository = new TaskRepository();
        private string _currentUserName;

        public MainForm(string userName)
        {
            InitializeComponent();

            _currentUserName = userName;
            _repository.EnsureDatabase();
            HideStatisticsLabels();

            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;
            flpCalendar.Visible = false;
            lblTotalTasks.Visible = false;
            lblMyTasks.Visible = false;
            lblHighPriority.Visible = false;
            lblCompletedTasks.Visible = false;


            btnPreviousMonth.BringToFront();
            btnNextMonth.BringToFront();
            lblCalendarTitle.BringToFront();

            UIHelper.StyleSidebarButtons(
                new Button[] { Dashboard, MyTasks, Calendar, Statistics });

            UIHelper.StyleDataGridView(dgvTasks);

            ShowCalendarView();
        }

        private void LoadTasks()
        {
            dgvTasks.DataSource = null;

            dgvTasks.DataSource = _repository.GetAll();

            FormatGridColumns();

            dgvTasks.ClearSelection();

            Application.DoEvents();

            ColorPriorityRows();

            dgvTasks.ClearSelection();

            dgvTasks.CurrentCell = null;

            dgvTasks.Refresh();
        }

        private void FormatGridColumns()
        {
            if (dgvTasks.Columns["Id"] != null)
                dgvTasks.Columns["Id"].Visible = false;

            if (dgvTasks.Columns["Name"] != null)
                dgvTasks.Columns["Name"].HeaderText = "Pavadinimas";

            if (dgvTasks.Columns["Description"] != null)
                dgvTasks.Columns["Description"].HeaderText = "Aprašymas";

            if (dgvTasks.Columns["StartDate"] != null)
                dgvTasks.Columns["StartDate"].HeaderText = "Pradžia";

            if (dgvTasks.Columns["EndDate"] != null)
                dgvTasks.Columns["EndDate"].HeaderText = "Pabaiga";

            if (dgvTasks.Columns["Status"] != null)
                dgvTasks.Columns["Status"].HeaderText = "Būsena";

            if (dgvTasks.Columns["Priority"] != null)
                dgvTasks.Columns["Priority"].HeaderText = "Svarbumas";

            if (dgvTasks.Columns["UserName"] != null)
                dgvTasks.Columns["UserName"].HeaderText = "Naudotojas";
        }

        private void ColorPriorityRows()
        {
            foreach (DataGridViewRow row in dgvTasks.Rows)
            {
                if (row.Cells["Priority"].Value == null)
                    continue;

                string priority = row.Cells["Priority"].Value.ToString();

                row.DefaultCellStyle.BackColor = Color.White;

                if (priority == "High")
                    row.Cells["Priority"].Style.BackColor = Color.LightCoral;
                else if (priority == "Medium")
                    row.Cells["Priority"].Style.BackColor = Color.Khaki;
                else if (priority == "Low")
                    row.Cells["Priority"].Style.BackColor = Color.LightGreen;
            }
        }

        private void ShowCalendarView()
        {
            LoadCalendar();

            dgvTasks.Visible = false;
            btnAddTask.Visible = false;
            btnEditTask.Visible = false;
            btnDeleteTask.Visible = false;

            flpCalendar.Visible = true;
            btnPreviousMonth.Visible = true;
            btnNextMonth.Visible = true;
            lblCalendarTitle.Visible = true;
        }

        private void ShowTasksView()
        {
            HideStatisticsLabels();
            LoadTasks();

            dgvTasks.Visible = true;
            btnAddTask.Visible = true;
            btnEditTask.Visible = true;
            btnDeleteTask.Visible = true;

            flpCalendar.Visible = false;
            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;
        }

        private void LoadCalendar()
        {
            flpCalendar.Controls.Clear();

            var tasks = _repository.GetAll();

            DateTime firstDay = new DateTime(
                _currentCalendarMonth.Year,
                _currentCalendarMonth.Month,
                1);

            lblCalendarTitle.Text =
                _currentCalendarMonth.ToString("MMMM yyyy");

            int daysInMonth = DateTime.DaysInMonth(
                _currentCalendarMonth.Year,
                _currentCalendarMonth.Month);

            for (int i = 0; i < daysInMonth; i++)
            {
                CalendarDayControl day = new CalendarDayControl();

                DateTime currentDay = firstDay.AddDays(i);

                string taskText = "";
                string priority = "";

                foreach (var task in tasks)
                {
                    if (task.StartDate.Date == currentDay.Date)
                    {
                        taskText += task.Name + "\n" + task.UserName + "\n";

                        if (task.Priority == "High")
                            priority = "High";
                        else if (task.Priority == "Medium" && priority != "High")
                            priority = "Medium";
                        else if (task.Priority == "Low" && priority == "")
                            priority = "Low";
                    }
                }

                day.SetDay(currentDay, taskText, priority);
                flpCalendar.Controls.Add(day);
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
                    Priority = addTaskForm.TaskPriority,
                    UserName = _currentUserName
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
                selectedTask.Priority = editForm.TaskPriority;

                _repository.UpdateTask(selectedTask);
                LoadTasks();

                MessageBox.Show("Task updated successfully!");
            }
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            ShowTasksView();

            dgvTasks.ClearSelection();

            dgvTasks.CurrentCell = null;

            ColorPriorityRows();

            dgvTasks.Refresh();
        }

        private void MyTasks_Click(object sender, EventArgs e)
        {
            HideStatisticsLabels();

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
                .Where(t => t.UserName == _currentUserName)
                .ToList();

            FormatGridColumns();
            ColorPriorityRows();

            dgvTasks.ClearSelection();
            dgvTasks.CurrentCell = null;
            dgvTasks.Refresh();
        }
        private void HideStatisticsLabels()
        {
            lblTotalTasks.Visible = false;
            lblMyTasks.Visible = false;
            lblHighPriority.Visible = false;
            lblCompletedTasks.Visible = false;
        }
        private void Calendar_Click_1(object sender, EventArgs e)
        {
            ShowCalendarView();
            HideStatisticsLabels(); HideStatisticsLabels();
        }

        private void Statistics_Click_1(object sender, EventArgs e)
        {
            dgvTasks.Visible = false;

            flpCalendar.Visible = false;

            btnAddTask.Visible = false;
            btnDeleteTask.Visible = false;
            btnEditTask.Visible = false;

            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;

            var tasks = _repository.GetAll();

            lblTotalTasks.Visible = true;
            lblMyTasks.Visible = true;
            lblHighPriority.Visible = true;
            lblCompletedTasks.Visible = true;

            lblTotalTasks.Text =
                "Visos užduotys: " + tasks.Count;

            lblMyTasks.Text =
                "Mano užduotys: " +
                tasks.Count(t => t.UserName == _currentUserName);

            lblHighPriority.Text =
                "Svarbios užduotys: " +
                tasks.Count(t => t.Priority == "High");

            lblCompletedTasks.Text =
                "Atliktos užduotys: " +
                tasks.Count(t => t.Status == "Completed");
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
    }
}