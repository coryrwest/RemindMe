using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemindMe
{
    public partial class FullScreenCover : Form
    {
        ReminderTimer Timer;

        public FullScreenCover(Reminder reminder)
        {
            InitializeComponent();
            textBox1.Text = reminder.ReminderText;
            panel1.Location = new Point(this.ClientSize.Width / 2 - this.panel1.Width / 2, this.ClientSize.Height / 2 - this.panel1.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void postpone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
