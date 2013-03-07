using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    class CustomApplicationContext : ApplicationContext
    {
        private static readonly string IconFileName = "route.ico";
        private static readonly string DefaultTooltip = "RemindMe";
        private NotifyIcon notifyIcon;
        private System.ComponentModel.IContainer components;
        Reminder reminder;

        public CustomApplicationContext()
        {
            InitializeContext();
            reminder = new Reminder();
        }

        private void InitializeContext()
        {
            components = new Container();
            notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon(IconFileName),
                Text = DefaultTooltip,
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Turn On Alert", onBtn_click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Turn Off Alert", offBtn_click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Quit", quit_Click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            notifyIcon.MouseUp += notifyIcon_MouseUp;
        }

        public ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            if (eventHandler != null) { item.Click += eventHandler; }
            return item;
        }

        Timer timer = new Timer();
        void Timer(int hour, int minute, bool timerOn)
        {
            int Hour = 0;
            int Minute = 60000;

            if (hour != 0)
                Hour = hour * 3600000;

            if (minute != 0)
                Minute = minute * 60000;

            timer.Interval = 5000;
            timer.Tick += timer_Tick;

            if(timerOn)
                timer.Enabled = true;
        }

        #region Events
        private void offBtn_click(object sender, EventArgs e)
        {
            if (TimerOn)
                timer.Enabled = false;
        }

        private void onBtn_click(object sender, EventArgs e)
        {
            if (!TimerOn)
                timer.Enabled = true;
        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            notifyIcon.ContextMenuStrip.Items.Add("Alert is " + onOff);
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowIntroForm();
        }

        public SettingsForm settingsForm;

        private void ShowIntroForm()
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm(reminder);
                settingsForm.FormClosed += settingsForm_Closed;
                settingsForm.ShowDialog();
            }
            else
            {
                settingsForm.Activate();
            }
        }

        bool TimerOn;
        string onOff;

        private void settingsForm_Closed(object sender, FormClosedEventArgs e)
        {
            TimerOn = settingsForm.GetTimerState();
            Timer(reminder.Hour, reminder.Minute, TimerOn);
            settingsForm = null;

            if (TimerOn)
                onOff = "On";
            else
                onOff = "Off";
        }

        void quit_Click(object sender, EventArgs e)
        {
            ExitThread();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) { components.Dispose(); }
        }

        protected override void ExitThreadCore()
        {
            if (settingsForm != null) { settingsForm.Close(); }
            notifyIcon.Visible = false;
            base.ExitThreadCore();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipTitle = "Reminder!";
            notifyIcon.BalloonTipText = reminder.ReminderText;
            notifyIcon.ShowBalloonTip(1000);
        }
        #endregion
    }
}
