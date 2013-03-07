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
    public partial class SettingsForm : Form
    {
        Reminder reminder;
        bool TimerOn = false;

        public SettingsForm(Reminder Reminder)
        {
            InitializeComponent();
            reminder = Reminder;
            if (reminder != null)
            {
                if (reminder.Minute > 60000)
                    label4.Text = "Your next reminder is in " + reminder.Hour + " hours and " + reminder.Minute + " minutes.";
                else
                    label4.Text = "Your next reminder is in " + reminder.Hour + " hours and " + reminder.Minute + " minute.";
            }
            hrBox.Text = reminder.Hour.ToString();
            minBox.Text = reminder.Minute.ToString();
            reminderBox.Text = reminder.ReminderText;
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
        }

        private void turnOnBtn_Click(object sender, EventArgs e)
        {
            reminder.Hour = Convert.ToInt32(hrBox.Text);
            reminder.Minute = Convert.ToInt32(minBox.Text);
            reminder.ReminderText = reminderBox.Text;
            TimerOn = true;
            if (reminderBox.Text.Length < 1)
            {
                MessageBox.Show("You did not specify a reminder.");
            }
            else
            {
                this.Close();
            }
        }

        private void turnOffBtn_Click(object sender, EventArgs e)
        {
            if(reminder.Minute > 60000)
                label4.Text = "Your next reminder is in " + reminder.Hour + " hours and " + reminder.Minute + " minutes.";
            else
                label4.Text = "Your next reminder is in " + reminder.Hour + " hours and " + reminder.Minute + " minute.";

            TimerOn = false;
            this.Close();
        }

        public bool GetTimerState()
        {
            return TimerOn;
        }
    }
}
