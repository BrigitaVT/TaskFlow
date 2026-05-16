using System.Collections.Generic;
using TaskFlow.Models;

namespace TaskFlow.Repositories
{
    public class TaskRepository
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public List<TaskItem> GetAll()
        {
            return tasks;
        }

        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }
    }
}