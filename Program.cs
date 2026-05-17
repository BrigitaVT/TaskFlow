using System;
using System.Windows.Forms;
using SQLitePCL;
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
            Application.Run(new MainForm());
        }
    }
}