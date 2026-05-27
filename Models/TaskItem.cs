using System;

namespace TaskFlow.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }
        public string UserName { get; set; }
    }
}