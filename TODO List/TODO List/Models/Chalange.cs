using System;
using System.Windows.Data;
using VelocityDb;

namespace TODO_List.Models
{
    public class Chalange : OptimizedPersistable
    {
        private string taskName;
        private bool taskСompleteness;

        public string TaskName { get => taskName; set => taskName = value; }
        public bool TaskСompleteness
        {
            get
            {
                return taskСompleteness;
            }
            set
            {
                taskСompleteness = value;  
            }
        }

        public void test(Object obj, DataTransferEventArgs arg) { } 
    }
}
