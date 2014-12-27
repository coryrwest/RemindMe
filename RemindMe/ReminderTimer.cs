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
        Timer postponeTimer = new Timer();
        private CustomApplicationContext Context;

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

            context = Context;
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

        public int Postpone()
        {
            timer.Stop();
            postponeTimer.Interval = 300000;
            postponeTimer.Start();
            postponeTimer.Tick += postponeTimer_Tick;
            postponeTimer.Tick += Context.TimerTick;
        }

        void postponeTimer_Tick(object sender, EventArgs e)
        {
            postponeTimer.Stop();
            postponeTimer = null;
            timer.Start();
        }
    }
}
