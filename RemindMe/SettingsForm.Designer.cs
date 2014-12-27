namespace RemindMe
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.hrBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.minBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reminderBox = new System.Windows.Forms.TextBox();
            this.turnOnBtn = new System.Windows.Forms.Button();
            this.turnOffBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remind me every";
            // 
            // hrBox
            // 
            this.hrBox.HidePromptOnLeave = true;
            this.hrBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.hrBox.Location = new System.Drawing.Point(134, 21);
            this.hrBox.Mask = "00";
            this.hrBox.Name = "hrBox";
            this.hrBox.PromptChar = ' ';
            this.hrBox.Size = new System.Drawing.Size(19, 20);
            this.hrBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "hr";
            // 
            // minBox
            // 
            this.minBox.HidePromptOnLeave = true;
            this.minBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.minBox.Location = new System.Drawing.Point(182, 21);
            this.minBox.Mask = "00";
            this.minBox.Name = "minBox";
            this.minBox.PromptChar = ' ';
            this.minBox.Size = new System.Drawing.Size(19, 20);
            this.minBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "min   about:";
            // 
            // reminderBox
            // 
            this.reminderBox.Location = new System.Drawing.Point(35, 47);
            this.reminderBox.Multiline = true;
            this.reminderBox.Name = "reminderBox";
            this.reminderBox.Size = new System.Drawing.Size(363, 48);
            this.reminderBox.TabIndex = 5;
            // 
            // turnOnBtn
            // 
            this.turnOnBtn.Location = new System.Drawing.Point(63, 102);
            this.turnOnBtn.Name = "turnOnBtn";
            this.turnOnBtn.Size = new System.Drawing.Size(113, 23);
            this.turnOnBtn.TabIndex = 6;
            this.turnOnBtn.Text = "Turn On Alert";
            this.turnOnBtn.UseVisualStyleBackColor = true;
            this.turnOnBtn.Click += new System.EventHandler(this.turnOnBtn_Click);
            // 
            // turnOffBtn
            // 
            this.turnOffBtn.Location = new System.Drawing.Point(247, 101);
            this.turnOffBtn.Name = "turnOffBtn";
            this.turnOffBtn.Size = new System.Drawing.Size(113, 23);
            this.turnOffBtn.TabIndex = 7;
            this.turnOffBtn.Text = "Turn Off Alert";
            this.turnOffBtn.UseVisualStyleBackColor = true;
            this.turnOffBtn.Click += new System.EventHandler(this.turnOffBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 148);
            this.Controls.Add(this.turnOffBtn);
            this.Controls.Add(this.turnOnBtn);
            this.Controls.Add(this.reminderBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hrBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RemindMe Alert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox hrBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox minBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reminderBox;
        private System.Windows.Forms.Button turnOnBtn;
        private System.Windows.Forms.Button turnOffBtn;
    }
}

