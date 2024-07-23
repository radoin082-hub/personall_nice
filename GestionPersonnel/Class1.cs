using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionPersonnel
{
    public partial class ConnectionSelectionForm : Form
    {
        private Button localButton;
        private Button onlineButton;

        private readonly string _localConnectionString;
        private readonly string _onlineConnectionString;

        public string SelectedConnectionString { get; private set; }

        public ConnectionSelectionForm(string localConnectionString, string onlineConnectionString)
        {
            InitializeComponent();
            _localConnectionString = localConnectionString;
            _onlineConnectionString = onlineConnectionString;
        }

        private void localButton_Click(object sender, EventArgs e)
        {
            SelectedConnectionString = _localConnectionString;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void onlineButton_Click(object sender, EventArgs e)
        {
            SelectedConnectionString = _onlineConnectionString;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSelectionForm));
            localButton = new Button();
            onlineButton = new Button();

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

            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(944, 537);
            Controls.Add(localButton);
            Controls.Add(onlineButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ConnectionSelectionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Connection";
            ResumeLayout(false);
        }
    }
}
