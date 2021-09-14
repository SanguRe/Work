using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDateRus.Entities;

namespace WorkDateRus.Entities
{
    public partial class Sehedule
    {
        public string StartEnd { 
            get
            {
                return StartDate.ToString("HH:mm") + " - " + EndDate.ToString("HH:mm");
            }
        }
    }
}
