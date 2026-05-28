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
                if (row.IsNewRow)
                    continue;

                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;

                string status = row.Cells["Status"].Value?.ToString();
                string priority = row.Cells["Priority"].Value?.ToString();

                if (status == "Atlikta")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
                else if (status == "Daroma")
                {
                    row.Cells["Status"].Style.BackColor = Color.LightBlue;
                }
                else if (status == "Planuojama")
                {
                    row.Cells["Status"].Style.BackColor = Color.WhiteSmoke;
                }

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

            string monthTitle =
                _currentCalendarMonth.ToString("MMMM yyyy");

            lblCalendarTitle.Text =
                char.ToUpper(monthTitle[0]) +
                monthTitle.Substring(1);

            int daysInMonth = DateTime.DaysInMonth(
                _currentCalendarMonth.Year,
                _currentCalendarMonth.Month);

            int startOffset =
                ((int)firstDay.DayOfWeek + 6) % 7;

            DateTime previousMonth =
    firstDay.AddMonths(-1);

            int previousMonthDays =
                DateTime.DaysInMonth(
                    previousMonth.Year,
                    previousMonth.Month);

            for (int i = startOffset - 1; i >= 0; i--)
            {
                DateTime inactiveDate =
                    new DateTime(
                        previousMonth.Year,
                        previousMonth.Month,
                        previousMonthDays - i);

                CalendarDayControl inactiveDay =
                    new CalendarDayControl();

                inactiveDay.SetInactiveDay(inactiveDate);

                flpCalendar.Controls.Add(inactiveDay);
            }

            for (int i = 0; i < daysInMonth; i++)
            {
                CalendarDayControl day =
                    new CalendarDayControl();

                DateTime currentDay =
                    firstDay.AddDays(i);

                string taskText = "";
                string priority = "";
                string description = "";

                foreach (var task in tasks)
                {
                    if (task.StartDate.Date == currentDay.Date)
                    {
                        string status = task.Status;

                        if (status == "Planned")
                            status = "Planuojama";

                        taskText +=
                            task.Name + "\n" +
                            status + "\n" +
                            task.UserName + "\n";

                        description += task.Description + "\n\n";

                        if (task.Priority == "High")
                            priority = "High";
                        else if (task.Priority == "Medium" && priority != "High")
                            priority = "Medium";
                        else if (task.Priority == "Low" && priority == "")
                            priority = "Low";
                    }
                }

                day.SetDay(
                    currentDay,
                    taskText,
                    priority,
                    description);

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
                    Status = addTaskForm.TaskStatus,
                    Priority = addTaskForm.TaskPriority,
                    UserName = _currentUserName
                };

                _repository.AddTask(task);

                LoadTasks();
                LoadCalendar();

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
                selectedTask.Status = editForm.TaskStatus;

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
            lblStatisticsTitle.Visible = false;
            lblPendingTasks.Visible = false;
            lblMediumPriority.Visible = false;
            lblLowPriority.Visible = false;
            lblCompletionRate.Visible = false;
            lblStatusBreakdown.Visible = false;
            progressBarCompletion.Visible = false;
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
            int total = tasks.Count;
            int myTasks = tasks.Count(t => t.UserName == _currentUserName);
            int highPriority = tasks.Count(t => t.Priority == "High");
            int mediumPriority = tasks.Count(t => t.Priority == "Medium");
            int lowPriority = tasks.Count(t => t.Priority == "Low");
            int completed = tasks.Count(t => t.Status == "Atlikta");
            int pending = total - completed;
            int planned = tasks.Count(t => t.Status == "Planuojama");
            int inProgress = tasks.Count(t => t.Status == "Daroma");

            int completionPercent = total > 0
                ? (int)Math.Round((double)completed / total * 100)
                : 0;

            lblStatisticsTitle.Visible = true;

            lblTotalTasks.Visible = true;
            lblMyTasks.Visible = true;
            lblHighPriority.Visible = true;
            lblCompletedTasks.Visible = true;
            lblPendingTasks.Visible = true;
            lblMediumPriority.Visible = true;
            lblLowPriority.Visible = true;
            lblCompletionRate.Visible = true;
            progressBarCompletion.Visible = false;
            lblStatusBreakdown.Visible = true;

            lblTotalTasks.Text = "📋 Visos užduotys\n" + total;
            lblMyTasks.Text = "👤 Mano užduotys\n" + myTasks;
            lblHighPriority.Text = "🔥 Aukštas prioritetas\n" + highPriority;
            lblCompletedTasks.Text = "✅ Atliktos\n" + completed;
            lblPendingTasks.Text = "⏳ Nebaigtos\n" + pending;
            lblMediumPriority.Text = "⚡ Vidutinis prioritetas\n" + mediumPriority;
            lblLowPriority.Text = "🟢 Žemas prioritetas\n" + lowPriority;
            lblCompletionRate.Text = "📊 Atlikimo procentas: " + completionPercent + "%";

            lblStatusBreakdown.Text =
                "📌 Planuojama: " + planned +
                "   |   🔄 Daroma: " + inProgress +
                "   |   ✅ Atlikta: " + completed;
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