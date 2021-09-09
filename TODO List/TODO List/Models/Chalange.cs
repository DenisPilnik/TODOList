using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_List.Models
{
    public class Chalange
    {
        private string taskName;
        private bool taskСompleteness;

        public string TaskName { get => taskName; set => taskName = value; }
        public bool TaskСompleteness { get => taskСompleteness; set => taskСompleteness = value; }
    }
}
