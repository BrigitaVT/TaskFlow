using System;
using System.Windows.Forms;
using TaskFlow.Helpers;
using TaskFlow.Models;
using TaskFlow.Repositories;
using TaskFlow.Controls;

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

            // Sidebar mygtukų stilius
            UIHelper.StyleSidebarButtons(
                new Button[] { Dashboard, MyTasks, Calendar, Statistics });

            // DataGridView stilius
            UIHelper.StyleDataGridView(dgvTasks);

            // Užkrauna taskus paleidus programą
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

            DateTime start = new DateTime(
                _currentCalendarMonth.Year,
                _currentCalendarMonth.Month,
                1);

            // Viršuje rodo tik mėnesį
            lblCalendarTitle.Text =
                _currentCalendarMonth.ToString("MMMM yyyy");

            for (int i = 0; i < 35; i++)
            {
                CalendarDayControl day = new CalendarDayControl();

                DateTime currentDay = start.AddDays(i);

                string taskText = "";

                foreach (var task in tasks)
                {
                    if (task.StartDate.Date == currentDay.Date)
                    {
                        // Dienos langelyje rodo task pavadinimą ir žmogų
                        taskText += task.Name + "\n" + task.UserName + "\n";
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
        }

        // My Tasks mygtukas – rodo visas užduotis
        private void MyTasks_Click(object sender, EventArgs e)
        {
            LoadTasks();

            dgvTasks.Visible = true;
            btnAddTask.Visible = true;
            btnDeleteTask.Visible = true;
            flpCalendar.Visible = false;
            btnPreviousMonth.Visible = false;
            btnNextMonth.Visible = false;
            lblCalendarTitle.Visible = false;
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
    }
}