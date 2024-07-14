using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace GestionPersonnel
{
    public partial class ConnectionSelectionForm : Form
    {
        private Button localButton;
        private Button onlineButton;
        private ProgressBar progressBar1;
        private Label percentageLabel;

        private readonly string _localConnectionString;
        private readonly string _onlineConnectionString;
        private Timer progressTimer;
        private int progressValue;
        private int currentState; 
        public string SelectedConnectionString { get; private set; }

        public ConnectionSelectionForm(string localConnectionString, string onlineConnectionString)
        {
            InitializeComponent();
            _localConnectionString = localConnectionString;
            _onlineConnectionString = onlineConnectionString;

            progressTimer = new Timer();
            progressTimer.Interval = 50;
            progressTimer.Tick += progressTimer_Tick;
        }

        private void localButton_Click(object sender, EventArgs e)
        {
            SelectedConnectionString = _localConnectionString;
            StartProgress();
        }

        private void onlineButton_Click(object sender, EventArgs e)
        {
            SelectedConnectionString = _onlineConnectionString;
            StartProgress();
        }

        private void StartProgress()
        {
            progressValue = 0;
            currentState = 0;
            progressTimer.Start();
        }

        private async void progressTimer_Tick(object sender, EventArgs e)
        {
            if (currentState == 0 && progressValue < 20)
            {
                UpdateProgress(1);
            }
            else if (currentState == 0 && progressValue == 20)
            {
                progressTimer.Stop();
                await Task.Delay(2000); 
                currentState = 2; 
                progressTimer.Interval = 100; 
                progressTimer.Start();
            }
            else if (currentState == 2 && progressValue < 40)
            {
                UpdateProgress(1);
            }
            else if (currentState == 2 && progressValue == 40)
            {
                currentState = 3; 
                progressTimer.Interval = 25; 
            }
            else if (currentState == 3 && progressValue < 100)
            {
                UpdateProgress(1);
            }
            else if (progressValue >= 100)
            {
                progressTimer.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void UpdateProgress(int value)
        {
            progressValue += value;
            progressBar1.Value = progressValue;
            percentageLabel.Text = progressValue + "%";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSelectionForm));
            localButton = new Button();
            onlineButton = new Button();
            progressBar1 = new ProgressBar();
            percentageLabel = new Label();
            SuspendLayout();

            localButton.BackColor = Color.MediumBlue;
            localButton.Cursor = Cursors.Hand;
            localButton.Font = new Font("Segoe UI", 14F);
            localButton.ForeColor = SystemColors.ButtonHighlight;
            localButton.Location = new Point(219, 226);
            localButton.Name = "localButton";
            localButton.Size = new Size(141, 53);
            localButton.TabIndex = 0;
            localButton.Text = "Local";
            localButton.UseVisualStyleBackColor = false;
            localButton.Click += localButton_Click;
 
            onlineButton.BackColor = Color.DeepPink;
            onlineButton.Cursor = Cursors.Hand;
            onlineButton.Font = new Font("Segoe UI", 14F);
            onlineButton.ForeColor = SystemColors.ButtonHighlight;
            onlineButton.Location = new Point(579, 226);
            onlineButton.Name = "onlineButton";
            onlineButton.Size = new Size(139, 53);
            onlineButton.TabIndex = 1;
            onlineButton.Text = "Online";
            onlineButton.UseVisualStyleBackColor = false;
            onlineButton.Click += onlineButton_Click;
 
            progressBar1.Location = new Point(283, 363);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(435, 29);
            progressBar1.TabIndex = 2;

            percentageLabel.AutoSize = true;
            percentageLabel.BackColor = Color.White;
            percentageLabel.Cursor = Cursors.WaitCursor;
            percentageLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            percentageLabel.ForeColor = Color.SeaGreen;
            percentageLabel.Location = new Point(724, 357);
            percentageLabel.Name = "percentageLabel";
            percentageLabel.Size = new Size(51, 35);
            percentageLabel.TabIndex = 3;
            percentageLabel.Text = "0%";
  
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(944, 537);
            Controls.Add(percentageLabel);
            Controls.Add(progressBar1);
            Controls.Add(localButton);
            Controls.Add(onlineButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConnectionSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Connection";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
