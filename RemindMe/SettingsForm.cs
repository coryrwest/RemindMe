using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace RemindMe
{
    partial class SettingsForm : Form
    {
        Reminder reminder;
        ReminderTimer timer;

        public SettingsForm(Reminder Reminder, ReminderTimer Timer)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
            reminder = Reminder;
            timer = Timer;
            if (reminder != null)
            {
                hrBox.Text = reminder.Hour.ToString();
                minBox.Text = reminder.Minute.ToString();
                reminderBox.Text = reminder.ReminderText;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Convert.ToInt32(hrBox.Text) != reminder.Hour || Convert.ToInt32(minBox.Text) != reminder.Minute || reminderBox.Text != reminder.ReminderText)
            {
                if (MessageBox.Show("You have an unsaved reminder. \r\n Do you want to save your reminder?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    reminder.Hour = Convert.ToInt32(hrBox.Text);
                    reminder.Minute = Convert.ToInt32(minBox.Text);
                    reminder.ReminderText = reminderBox.Text;
                }
            }

            if (reminderBox.Text.Length < 0)
            {
                MessageBox.Show("You did not specify a reminder");
                e.Cancel = true;
            }

            if (Convert.ToInt32(hrBox.Text) == 0 && Convert.ToInt32(minBox.Text) == 0)
            {
                MessageBox.Show("You did not specify a reminder time");
                e.Cancel = true;
            }
        }

        private void turnOnBtn_Click(object sender, EventArgs e)
        {
            reminder.Hour = Convert.ToInt32(hrBox.Text);
            reminder.Minute = Convert.ToInt32(minBox.Text);
            reminder.ReminderText = reminderBox.Text;
            timer.UpdateTimer(true);
            if (reminderBox.Text.Length < 1)
            {
                MessageBox.Show("You did not specify a reminder.");
            }
            else if (Convert.ToInt32(hrBox.Text) == 0 && Convert.ToInt32(minBox.Text) == 0)
            {
                MessageBox.Show("You did not specify a reminder time");
            }
            else
            {
                this.Close();
            }
        }

        private void turnOffBtn_Click(object sender, EventArgs e)
        {
            timer.UpdateTimer(false);
            this.Close();
        }
    }
}
