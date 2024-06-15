namespace Time
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            btnStart = new Button();
            btnSuspend = new Button();
            btnResume = new Button();
            btnAbort = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(166, 29);
            label1.Name = "label1";
            label1.Size = new Size(232, 55);
            label1.TabIndex = 0;
            label1.Text = "00:00:00";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(21, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnSuspend
            // 
            btnSuspend.Location = new Point(21, 55);
            btnSuspend.Name = "btnSuspend";
            btnSuspend.Size = new Size(94, 29);
            btnSuspend.TabIndex = 2;
            btnSuspend.Text = "Suspend";
            btnSuspend.UseVisualStyleBackColor = true;
            btnSuspend.Click += btnSuspend_Click;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(21, 101);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(94, 29);
            btnResume.TabIndex = 3;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += btnResume_Click;
            // 
            // btnAbort
            // 
            btnAbort.Location = new Point(21, 152);
            btnAbort.Name = "btnAbort";
            btnAbort.Size = new Size(94, 29);
            btnAbort.TabIndex = 4;
            btnAbort.Text = "Abort";
            btnAbort.UseVisualStyleBackColor = true;
            btnAbort.Click += btnAbort_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(166, 126);
            label2.Name = "label2";
            label2.Size = new Size(232, 55);
            label2.TabIndex = 5;
            label2.Text = "00:00:00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 593);
            Controls.Add(label2);
            Controls.Add(btnAbort);
            Controls.Add(btnResume);
            Controls.Add(btnSuspend);
            Controls.Add(btnStart);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnStart;
        private Button btnSuspend;
        private Button btnResume;
        private Button btnAbort;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
    }
}
