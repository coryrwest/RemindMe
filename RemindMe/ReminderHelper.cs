using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RemindMe
{
    [Serializable()]
    public class Reminder : ISerializable
    {
        int hour = 0;
        int minute = 0;
        string reminder = "";

        public Reminder()
        {
        }

        public Reminder(SerializationInfo info, StreamingContext context)
        {
            hour = (int)info.GetValue("Hour", typeof(int));
            minute = (int)info.GetValue("Minute", typeof(int));
            reminder = (string)info.GetValue("Reminder", typeof(string));
        }

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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Hour", hour);
            info.AddValue("Minute", minute);
            info.AddValue("Reminder", reminder);
        }
    }
}
