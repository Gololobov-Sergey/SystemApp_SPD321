namespace Time
{
    public partial class Form1 : Form
    {
        Thread thread;

        public Form1()
        {
            InitializeComponent();


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            thread = new Thread(ShowTime);
            thread.IsBackground = true;
            thread.Start();
        }

        void ShowTime()
        {
            Action action = () =>
            {
                label1.Text = DateTime.Now.ToLongTimeString();
            };

            while (true)
            {
                if (this.InvokeRequired)
                    this.Invoke(action);

                Thread.Sleep(1000);
            }
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            //thread.Suspend();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            //thread.Resume();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            thread.Abort();
            label1.Text = string.Empty;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
