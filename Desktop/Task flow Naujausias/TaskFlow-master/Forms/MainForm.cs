using System;
using System.Collections.Generic;
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
        private Panel _statisticsPanel;

        public MainForm(string userName)
        {
            InitializeComponent();

            _currentUserName = userName;
            _repository.EnsureDatabase();

            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;
            flpCalendar.Visible = false;

            btnPreviousMonth.BringToFront();
            btnNextMonth.BringToFront();
            lblCalendarTitle.BringToFront();

            UIHelper.StyleSidebarButtons(
                new Button[] { Dashboard, MyTasks, Calendar, Statistics });

            UIHelper.StyleDataGridView(dgvTasks);

            BuildStatisticsPanel();

            ShowCalendarView();
        }

        private void LoadTasks()
        {
            dgvTasks.DataSource = null;
            dgvTasks.DataSource = _repository.GetAll();

            FormatGridColumns();
            ColorPriorityRows();
        }

        private void FormatGridColumns()
        {
            if (dgvTasks.Columns["Id"] != null)
                dgvTasks.Columns["Id"].Visible = false;

            if (dgvTasks.Columns["Priority"] != null)
                dgvTasks.Columns["Priority"].HeaderText = "Svarbumas";

            if (dgvTasks.Columns["Status"] != null)
                dgvTasks.Columns["Status"].HeaderText = "Būsena";

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

                if (priority == "High")
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (priority == "Medium")
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                else if (priority == "Low")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void ShowCalendarView()
        {
            HideStatisticsView();
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
            HideStatisticsView();
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
                    Status = addTaskForm.TaskStatus,
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
                selectedTask.Status = editForm.TaskStatus;

                _repository.UpdateTask(selectedTask);
                LoadTasks();

                MessageBox.Show("Task updated successfully!");
            }
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            ShowTasksView();
        }

        private void MyTasks_Click(object sender, EventArgs e)
        {
            HideStatisticsView();

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
        }

        private void Calendar_Click_1(object sender, EventArgs e)
        {
            ShowCalendarView();
        }

        private void Statistics_Click_1(object sender, EventArgs e)
        {
            ShowStatisticsView();
        }

        // ─── Statistics ───────────────────────────────────────────────

        private void BuildStatisticsPanel()
        {
            _statisticsPanel = new Panel
            {
                Location = new Point(246, 55),
                Size = new Size(642, 560),
                BackColor = Color.WhiteSmoke,
                Visible = false,
                AutoScroll = true
            };

            Controls.Add(_statisticsPanel);
            _statisticsPanel.BringToFront();
        }

        private void ShowStatisticsView()
        {
            dgvTasks.Visible = false;
            btnAddTask.Visible = false;
            btnEditTask.Visible = false;
            btnDeleteTask.Visible = false;
            flpCalendar.Visible = false;
            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;

            RefreshStatistics();
            _statisticsPanel.Visible = true;
        }

        private void HideStatisticsView()
        {
            _statisticsPanel.Visible = false;
        }

        private void RefreshStatistics()
        {
            _statisticsPanel.Controls.Clear();

            var tasks = _repository.GetAll();
            int total = tasks.Count;

            int y = 20;
            int panelWidth = _statisticsPanel.Width - 40;

            // ── Antraštė ──────────────────────────────────────────────
            var lblTitle = new Label
            {
                Text = "Statistika",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.SteelBlue,
                Location = new Point(20, y),
                AutoSize = true
            };
            _statisticsPanel.Controls.Add(lblTitle);
            y += 50;

            // ── Bendra suvestinė ──────────────────────────────────────
            var summaryPanel = CreateSectionPanel(y, panelWidth, 90);
            y += 100;

            AddSummaryTile(summaryPanel, 0,   "Iš viso",       total,                                        Color.SteelBlue);
            AddSummaryTile(summaryPanel, 140, "Atlikta",        tasks.Count(t => t.Status == "Finished"),     Color.MediumSeaGreen);
            AddSummaryTile(summaryPanel, 280, "Vykdoma",        tasks.Count(t => t.Status == "In Progress"),  Color.Goldenrod);
            AddSummaryTile(summaryPanel, 420, "Suplanuota",     tasks.Count(t => t.Status == "Planned"),      Color.MediumSlateBlue);

            _statisticsPanel.Controls.Add(summaryPanel);

            // ── Pagal prioritetą ──────────────────────────────────────
            y = AddSectionTitle(_statisticsPanel, "Pagal prioritetą", y);

            var priorityData = new Dictionary<string, (int count, Color color)>
            {
                { "High",   (tasks.Count(t => t.Priority == "High"),   Color.LightCoral) },
                { "Medium", (tasks.Count(t => t.Priority == "Medium"), Color.Khaki) },
                { "Low",    (tasks.Count(t => t.Priority == "Low"),    Color.LightGreen) }
            };

            foreach (var kv in priorityData)
            {
                y = AddBarRow(_statisticsPanel, kv.Key, kv.Value.count, total, kv.Value.color, y, panelWidth);
            }

            y += 10;

            // ── Pagal statusą ─────────────────────────────────────────
            y = AddSectionTitle(_statisticsPanel, "Pagal būseną", y);

            var statusData = new Dictionary<string, (int count, Color color)>
            {
                { "Planned",     (tasks.Count(t => t.Status == "Planned"),     Color.CornflowerBlue) },
                { "In Progress", (tasks.Count(t => t.Status == "In Progress"), Color.Goldenrod) },
                { "Finished",    (tasks.Count(t => t.Status == "Finished"),    Color.MediumSeaGreen) }
            };

            foreach (var kv in statusData)
            {
                y = AddBarRow(_statisticsPanel, kv.Key, kv.Value.count, total, kv.Value.color, y, panelWidth);
            }

            y += 10;

            // ── Pagal vartotoją ───────────────────────────────────────
            var byUser = tasks
                .GroupBy(t => t.UserName)
                .OrderByDescending(g => g.Count())
                .ToList();

            if (byUser.Count > 0)
            {
                y = AddSectionTitle(_statisticsPanel, "Pagal vartotoją", y);

                foreach (var group in byUser)
                {
                    string name = string.IsNullOrWhiteSpace(group.Key) ? "(nežinomas)" : group.Key;
                    y = AddBarRow(_statisticsPanel, name, group.Count(), total, Color.MediumPurple, y, panelWidth);
                }
            }
        }

        // ── Pagalbiniai metodai ────────────────────────────────────────

        private Panel CreateSectionPanel(int y, int width, int height)
        {
            return new Panel
            {
                Location = new Point(20, y),
                Size = new Size(width, height),
                BackColor = Color.Transparent
            };
        }

        private void AddSummaryTile(Panel parent, int x, string label, int count, Color color)
        {
            var tile = new Panel
            {
                Location = new Point(x, 0),
                Size = new Size(120, 80),
                BackColor = color
            };

            var lblCount = new Label
            {
                Text = count.ToString(),
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 8),
                Size = new Size(120, 40)
            };

            var lblLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 52),
                Size = new Size(120, 22)
            };

            tile.Controls.Add(lblCount);
            tile.Controls.Add(lblLabel);

            parent.Controls.Add(tile);
        }

        private int AddSectionTitle(Panel parent, string text, int y)
        {
            var lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(20, y),
                AutoSize = true
            };
            parent.Controls.Add(lbl);
            return y + 30;
        }

        private int AddBarRow(Panel parent, string label, int count, int total, Color barColor, int y, int panelWidth)
        {
            int barMaxWidth = panelWidth - 160;
            int barWidth = total > 0 ? (int)((double)count / total * barMaxWidth) : 0;
            if (barWidth < 4 && count > 0) barWidth = 4;

            var lblName = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.DimGray,
                Location = new Point(20, y + 4),
                Size = new Size(110, 22),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var barBg = new Panel
            {
                Location = new Point(135, y),
                Size = new Size(barMaxWidth, 22),
                BackColor = Color.Gainsboro
            };

            var barFill = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(barWidth, 22),
                BackColor = barColor
            };

            barBg.Controls.Add(barFill);

            var lblCount = new Label
            {
                Text = count.ToString(),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DimGray,
                Location = new Point(135 + barMaxWidth + 8, y + 2),
                AutoSize = true
            };

            parent.Controls.Add(lblName);
            parent.Controls.Add(barBg);
            parent.Controls.Add(lblCount);

            return y + 32;
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