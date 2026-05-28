using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskFlow.Controls
{
    public class CalendarDayControl : Panel
    {
        private ToolTip toolTip = new ToolTip();

        public DateTime Date { get; private set; }

        public CalendarDayControl()
        {
            Width = 130;
            Height = 90;
            Margin = new Padding(5);
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
        }

        public void SetDay(
    DateTime date,
    string taskText = "",
    string priority = "",
    string description = "")
        {
            Date = date;
            Controls.Clear();

            BackColor = Color.White;

            // Sekmadienis
            if (date.DayOfWeek == DayOfWeek.Sunday)
                BackColor = Color.LemonChiffon;

            // Priority spalvos
            if (priority == "High")
                BackColor = Color.LightCoral;
            else if (priority == "Medium")
                BackColor = Color.Khaki;
            else if (priority == "Low")
                BackColor = Color.LightGreen;

            // Šiandienos diena
            if (date.Date == DateTime.Today)
                BackColor = Color.LightSkyBlue;

            Label lblDay = new Label
            {
                Text = date.Day + " " + GetWeekDayName(date),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(6, 5),
                AutoSize = true
            };

            Label lblTask = new Label
            {
                Text = taskText,
                Font = new Font("Segoe UI", 8),
                Location = new Point(6, 28),
                Size = new Size(118, 55)
            };

            Controls.Add(lblDay);
            Controls.Add(lblTask);

            if (!string.IsNullOrWhiteSpace(description))
            {
                toolTip.SetToolTip(this, description);
                toolTip.SetToolTip(lblTask, description);
            }
        }

        private string GetWeekDayName(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Pir";
                case DayOfWeek.Tuesday:
                    return "Ant";
                case DayOfWeek.Wednesday:
                    return "Tre";
                case DayOfWeek.Thursday:
                    return "Ket";
                case DayOfWeek.Friday:
                    return "Pen";
                case DayOfWeek.Saturday:
                    return "Šeš";
                case DayOfWeek.Sunday:
                    return "Sek";
                default:
                    return "";
            }
        }
        public void SetInactiveDay(DateTime date)
        {
            Date = date;
            Controls.Clear();

            BackColor = Color.FromArgb(245, 245, 245);
            ForeColor = Color.Gray;
            Enabled = false;

            Label lblDay = new Label
            {
                Text = date.Day + " " + GetWeekDayName(date),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Gray,
                Location = new Point(6, 5),
                AutoSize = true
            };

            Controls.Add(lblDay);
        }
    }
}