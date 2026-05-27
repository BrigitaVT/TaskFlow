using SQLitePCL;
using System;
using System.Windows.Forms;
using TaskFlow.Forms;
using TaskFlow.Repositories;

namespace TaskFlow
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Batteries.Init();

            var repository = new TaskRepository();
            repository.EnsureDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(
                    new MainForm(loginForm.UserName));
            }
        }
    }
}