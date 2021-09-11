using VelocityDb;

namespace TODO_List.Models
{
    public class Chalange : OptimizedPersistable
    {
        private string taskName;
        public bool taskСompleteness;

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
    }
}
