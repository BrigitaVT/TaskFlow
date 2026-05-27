using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskFlow.Controls
{
    public class CalendarDayControl : Panel
    {
        public DateTime Date { get; private set; }

        public CalendarDayControl()
        {
            Width = 120;
            Height = 70;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
        }

        public void SetDay(DateTime date, string taskText = "", string priority = "")
        {
            Date = date;
            Controls.Clear();

            BackColor = Color.White;

            if (priority == "High")
                BackColor = Color.LightCoral;
            else if (priority == "Medium")
                BackColor = Color.Khaki;
            else if (priority == "Low")
                BackColor = Color.LightGreen;

            Label lblDay = new Label
            {
                Text = date.Day.ToString(),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(5, 5),
                AutoSize = true
            };

            Label lblTask = new Label
            {
                Text = taskText,
                Font = new Font("Segoe UI", 8),
                Location = new Point(5, 25),
                Size = new Size(105, 35)
            };

            Controls.Add(lblDay);
            Controls.Add(lblTask);
        }
    }
}