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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.sidebarPanel1 = new System.Windows.Forms.Panel();
            this.MyTasks = new System.Windows.Forms.Button();
            this.Calendar = new System.Windows.Forms.Button();
            this.Statistics = new System.Windows.Forms.Button();
            this.Dashboard = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
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
            this.btnAddTask.Location = new System.Drawing.Point(237, 33);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvTasks.Location = new System.Drawing.Point(300, 140);
            this.dgvTasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.RowTemplate.Height = 24;
            this.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.Size = new System.Drawing.Size(800, 500);
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
            this.sidebarPanel1.Size = new System.Drawing.Size(229, 619);
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
            this.btnDeleteTask.Location = new System.Drawing.Point(413, 33);
            this.btnDeleteTask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(170, 45);
            this.btnDeleteTask.TabIndex = 3;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(900, 619);
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
    }
}

