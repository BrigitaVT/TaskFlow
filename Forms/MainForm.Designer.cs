namespace TaskFlow
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.sidebarPanel1 = new System.Windows.Forms.Panel();
            this.MyTasks = new System.Windows.Forms.Button();
            this.Calendar = new System.Windows.Forms.Button();
            this.Statistics = new System.Windows.Forms.Button();
            this.Dashboard = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.flpCalendar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCalendarTitle = new System.Windows.Forms.Label();
            this.btnPreviousMonth = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.lblTotalTasks = new System.Windows.Forms.Label();
            this.lblMyTasks = new System.Windows.Forms.Label();
            this.lblHighPriority = new System.Windows.Forms.Label();
            this.lblCompletedTasks = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.sidebarPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Location = new System.Drawing.Point(430, 55);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(170, 45);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvTasks.Location = new System.Drawing.Point(246, 103);
            this.dgvTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(642, 503);
            this.dgvTasks.TabIndex = 1;
            // 
            // sidebarPanel1
            // 
            this.sidebarPanel1.BackColor = System.Drawing.Color.SteelBlue;
            this.sidebarPanel1.Controls.Add(this.MyTasks);
            this.sidebarPanel1.Controls.Add(this.Calendar);
            this.sidebarPanel1.Controls.Add(this.Statistics);
            this.sidebarPanel1.Controls.Add(this.Dashboard);
            this.sidebarPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel1.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel1.Name = "sidebarPanel1";
            this.sidebarPanel1.Size = new System.Drawing.Size(229, 732);
            this.sidebarPanel1.TabIndex = 2;
            // 
            // MyTasks
            // 
            this.MyTasks.Location = new System.Drawing.Point(14, 75);
            this.MyTasks.Name = "MyTasks";
            this.MyTasks.Size = new System.Drawing.Size(75, 23);
            this.MyTasks.TabIndex = 3;
            this.MyTasks.Text = "MyTasks";
            this.MyTasks.UseVisualStyleBackColor = true;
            this.MyTasks.Click += new System.EventHandler(this.MyTasks_Click);
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(14, 115);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(75, 23);
            this.Calendar.TabIndex = 2;
            this.Calendar.Text = "Calendar";
            this.Calendar.UseVisualStyleBackColor = true;
            this.Calendar.Click += new System.EventHandler(this.Calendar_Click_1);
            // 
            // Statistics
            // 
            this.Statistics.Location = new System.Drawing.Point(14, 157);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(75, 23);
            this.Statistics.TabIndex = 1;
            this.Statistics.Text = "Statistics";
            this.Statistics.UseVisualStyleBackColor = true;
            this.Statistics.Click += new System.EventHandler(this.Statistics_Click_1);
            // 
            // Dashboard
            // 
            this.Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dashboard.ForeColor = System.Drawing.Color.White;
            this.Dashboard.Location = new System.Drawing.Point(14, 33);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(200, 45);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "Dashboard";
            this.Dashboard.UseVisualStyleBackColor = true;
            this.Dashboard.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.Location = new System.Drawing.Point(870, 55);
            this.btnDeleteTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(170, 45);
            this.btnDeleteTask.TabIndex = 3;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // flpCalendar
            // 
            this.flpCalendar.AutoScroll = true;
            this.flpCalendar.Location = new System.Drawing.Point(300, 140);
            this.flpCalendar.Name = "flpCalendar";
            this.flpCalendar.Size = new System.Drawing.Size(850, 500);
            this.flpCalendar.TabIndex = 4;
            this.flpCalendar.Visible = false;
            // 
            // lblCalendarTitle
            // 
            this.lblCalendarTitle.AutoSize = true;
            this.lblCalendarTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendarTitle.Location = new System.Drawing.Point(510, 90);
            this.lblCalendarTitle.Name = "lblCalendarTitle";
            this.lblCalendarTitle.Size = new System.Drawing.Size(172, 38);
            this.lblCalendarTitle.TabIndex = 5;
            this.lblCalendarTitle.Text = "Kalendorius";
            this.lblCalendarTitle.Visible = false;
            // 
            // btnPreviousMonth
            // 
            this.btnPreviousMonth.Location = new System.Drawing.Point(420, 90);
            this.btnPreviousMonth.Name = "btnPreviousMonth";
            this.btnPreviousMonth.Size = new System.Drawing.Size(40, 35);
            this.btnPreviousMonth.TabIndex = 6;
            this.btnPreviousMonth.Text = "<";
            this.btnPreviousMonth.UseVisualStyleBackColor = true;
            this.btnPreviousMonth.Click += new System.EventHandler(this.btnPreviousMonth_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(700, 90);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(40, 35);
            this.btnNextMonth.TabIndex = 8;
            this.btnNextMonth.Text = ">";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.BackColor = System.Drawing.Color.LightCoral;
            this.btnEditTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTask.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTask.ForeColor = System.Drawing.Color.White;
            this.btnEditTask.Location = new System.Drawing.Point(650, 55);
            this.btnEditTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(170, 45);
            this.btnEditTask.TabIndex = 9;
            this.btnEditTask.Text = "Edit Task";
            this.btnEditTask.UseVisualStyleBackColor = false;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // lblTotalTasks
            // 
            this.lblTotalTasks.BackColor = System.Drawing.Color.AliceBlue;
            this.lblTotalTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalTasks.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTasks.Location = new System.Drawing.Point(300, 120);
            this.lblTotalTasks.Name = "lblTotalTasks";
            this.lblTotalTasks.Size = new System.Drawing.Size(250, 100);
            this.lblTotalTasks.TabIndex = 10;
            this.lblTotalTasks.Text = "📋 Visos užduotys";
            this.lblTotalTasks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMyTasks
            // 
            this.lblMyTasks.BackColor = System.Drawing.Color.Honeydew;
            this.lblMyTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMyTasks.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyTasks.Location = new System.Drawing.Point(600, 120);
            this.lblMyTasks.Name = "lblMyTasks";
            this.lblMyTasks.Size = new System.Drawing.Size(250, 100);
            this.lblMyTasks.TabIndex = 11;
            this.lblMyTasks.Text = "👤 Mano užduotys";
            this.lblMyTasks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHighPriority
            // 
            this.lblHighPriority.BackColor = System.Drawing.Color.MistyRose;
            this.lblHighPriority.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighPriority.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighPriority.Location = new System.Drawing.Point(300, 260);
            this.lblHighPriority.Name = "lblHighPriority";
            this.lblHighPriority.Size = new System.Drawing.Size(250, 100);
            this.lblHighPriority.TabIndex = 12;
            this.lblHighPriority.Text = "🔥 Svarbios užduotys";
            this.lblHighPriority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCompletedTasks
            // 
            this.lblCompletedTasks.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblCompletedTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompletedTasks.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedTasks.Location = new System.Drawing.Point(600, 260);
            this.lblCompletedTasks.Name = "lblCompletedTasks";
            this.lblCompletedTasks.Size = new System.Drawing.Size(250, 100);
            this.lblCompletedTasks.TabIndex = 13;
            this.lblCompletedTasks.Text = "✅ Atliktos užduotys";
            this.lblCompletedTasks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1361, 732);
            this.Controls.Add(this.lblCompletedTasks);
            this.Controls.Add(this.lblHighPriority);
            this.Controls.Add(this.lblMyTasks);
            this.Controls.Add(this.lblTotalTasks);
            this.Controls.Add(this.btnEditTask);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPreviousMonth);
            this.Controls.Add(this.lblCalendarTitle);
            this.Controls.Add(this.flpCalendar);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.sidebarPanel1);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.dgvTasks);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(300, 80);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "TaskFlow";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.sidebarPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Panel sidebarPanel1;
        private System.Windows.Forms.Button MyTasks;
        private System.Windows.Forms.Button Calendar;
        private System.Windows.Forms.Button Statistics;
        private System.Windows.Forms.Button Dashboard;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.FlowLayoutPanel flpCalendar;
        private System.Windows.Forms.Label lblCalendarTitle;
        private System.Windows.Forms.Button btnPreviousMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Label lblTotalTasks;
        private System.Windows.Forms.Label lblMyTasks;
        private System.Windows.Forms.Label lblHighPriority;
        private System.Windows.Forms.Label lblCompletedTasks;
    }
}

