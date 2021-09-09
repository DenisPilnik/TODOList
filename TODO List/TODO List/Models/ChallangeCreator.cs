using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO_List.Models;

namespace TODO_List.Models
{
    public static class ChallangeCreator
    {
        public static Chalange AddChallange(string text)
        {
            Chalange chalange = new Chalange() { TaskName = text, TaskСompleteness = false };
            return chalange;
        }
    }
}
