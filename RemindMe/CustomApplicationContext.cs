using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    class CustomApplicationContext : ApplicationContext
    {
        public CustomApplicationContext()
        {
            reminder = null;

            if (!Directory.Exists(path + "\\RemindMe"))
            {
                reminder = new Reminder {Hour = 0, Minute = 1, ReminderText = "This is a default reminder"};
                Directory.CreateDirectory(path + "\\RemindMe");
                stream = File.Open(path + "\\RemindMe\\reminder.rm", FileMode.Create);
                bformat.Serialize(stream, reminder);
                stream.Close();
            }
            else
            {
                stream = File.Open(path + "\\RemindMe\\reminder.rm", FileMode.Open);
                reminder = (Reminder)bformat.Deserialize(stream);
                stream.Close();
            }

            InitializeContext();
            _notifyIcon.BalloonTipTitle = "Down Here!";
            _notifyIcon.BalloonTipText = "Right Click to get started";
            _notifyIcon.ShowBalloonTip(1000);
        }

        private NotifyIcon _notifyIcon;
        private IContainer components;
        Reminder reminder;
        ReminderTimer timer = new ReminderTimer();
        bool fullscreen;
        public SettingsForm settingsForm;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        Stream stream;
        BinaryFormatter bformat = new BinaryFormatter();
        public FullScreenCover fullscreenDialog;

        private void InitializeContext()
        {
            components = new Container();
            _notifyIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = TrayIcon.route,
                Text = "RemindMe",
                Visible = true
            };
            _notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Create Alert", createBtn_click));
            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Turn On Alert", onBtn_click));
            _notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Turn Off Alert", offBtn_click));
            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Full Screen Reminder?", FullBtnClick));
            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _notifyIcon.ContextMenuStrip.Items.Add("Alert is off");
            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("Quit", quit_Click));

            _notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            _notifyIcon.MouseUp += notifyIcon_MouseUp;

            timer.StartTimer(0, 1, false, this);
        }

        #region Events
        public void TimerTick(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                fullscreenDialog = new FullScreenCover(reminder)
                                                       {
                                                           Opacity = 0.8,
                                                           TopMost = true
                                                       };
                fullscreenDialog.ShowDialog();
            }
            else
            {
                _notifyIcon.BalloonTipTitle = "Reminder!";
                _notifyIcon.BalloonTipText = reminder.ReminderText;
                _notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void FullBtnClick(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                fullscreen = false;
                foreach (ToolStripItem item in _notifyIcon.ContextMenuStrip.Items)
                {
                    if (item.Text.Contains("Tray Reminder"))
                        item.Text = "Full Screen Reminder?";
                }
            }
            else
            {
                fullscreen = true;
                foreach (ToolStripItem item in _notifyIcon.ContextMenuStrip.Items)
                {
                    if (item.Text.Contains("Full Screen"))
                        item.Text = "Tray Reminder?";
                }
            }
        }

        private void createBtn_click(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private void offBtn_click(object sender, EventArgs e)
        {
            if (timer.GetState())
                timer.UpdateTimer(false);

            foreach (ToolStripItem item in _notifyIcon.ContextMenuStrip.Items)
            {
                if (item.Text.Contains("Alert is"))
                    item.Text = "Alert is off";
            }
        }

        private void onBtn_click(object sender, EventArgs e)
        {
            if (!timer.GetState())
                timer.UpdateTimer(true);

            foreach (ToolStripItem item in _notifyIcon.ContextMenuStrip.Items)
            {
                if (item.Text.Contains("Alert is"))
                    item.Text = "Alert is on";
            }
        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(_notifyIcon, null);
            }
        }

        void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowSettingsForm();
        }

        private void settingsForm_Closed(object sender, FormClosedEventArgs e)
        {
            timer.UpdateTimer(reminder.Hour, reminder.Minute);
            settingsForm = null;
        }

        void quit_Click(object sender, EventArgs e)
        {
            stream = File.Open(path + "\\RemindMe\\reminder.rm", FileMode.Create);
            bformat.Serialize(stream, reminder);
            stream.Close();

            ExitThread();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) { components.Dispose(); }
        }

        protected override void ExitThreadCore()
        {
            if (settingsForm != null) { settingsForm.Close(); }
            _notifyIcon.Visible = false;
            base.ExitThreadCore();
        }
        #endregion

        #region Helpers
        public ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            if (eventHandler != null) { item.Click += eventHandler; }
            return item;
        }

        private void ShowSettingsForm()
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm(reminder, timer);
                settingsForm.FormClosed += settingsForm_Closed;
                settingsForm.ShowDialog();
            }
            else
            {
                settingsForm.Activate();
            }
        }
        #endregion
    }
}
