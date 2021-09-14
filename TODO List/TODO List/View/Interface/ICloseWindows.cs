using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO_List.View.Interface
{
    internal interface ICloseWindows
    {
        Action Close { get; set; }
        bool CanClose();
    }
}
