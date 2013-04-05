using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    class ReminderTimer
    {
        Timer timer = new Timer();

        public void StartTimer(int hour, int minute, bool timerOn, CustomApplicationContext context)
        {
            int Hour = 0;
            int Minute = 60000;

            if (hour != 0)
                Hour = hour * 3600000;

            if (minute != 0)
                Minute = minute * 60000;

            int interval = Hour + Minute;

            timer.Interval = interval;

            if (timerOn)
                timer.Enabled = true;
            else
                timer.Enabled = false;

            timer.Tick += context.TimerTick;
        }

        public void UpdateTimer(int hour, int minute, bool timerOn)
        {
            int Hour = 0;
            int Minute = 60000;

            if (hour != 0)
                Hour = hour * 3600000;

            if (minute != 0)
                Minute = minute * 60000;

            int interval = Hour + Minute;

            timer.Interval = interval;

            if (timerOn)
                timer.Enabled = true;
            else
                timer.Enabled = false;
        }

        public void UpdateTimer(int hour, int minute)
        {
            int Hour = 0;
            int Minute = 60000;

            if (hour != 0)
                Hour = hour * 3600000;

            if (minute != 0)
                Minute = minute * 60000;

            int interval = Hour + Minute;

            timer.Interval = interval;
        }

        public void UpdateTimer(bool timerOn)
        {
            if (timerOn)
                timer.Enabled = true;
            else
                timer.Enabled = false;
        }

        public bool GetState()
        {
            return timer.Enabled;
        }
    }
}
