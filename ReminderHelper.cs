using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe
{
    public class Reminder
    {
        int hour = 0;
        int minute = 0;
        string reminder = "";
        
        public int Hour {
            get { return hour; }
            set { hour = value; }
            }
        
        public int Minute {
            get { return minute; }
            set { minute = value; }
            }

        public string ReminderText {
            get { return reminder; }
            set { reminder = value; }
            }
    }
}
