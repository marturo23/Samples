using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.AspNet.SignalR.Client.Hubs;
using System.Threading.Tasks;

namespace BasicChat.WinForms
{
    public partial class frmMain : Form
    {
        HubConnection _connection;
        IHubProxy _chat;

        public frmMain()
        {
            InitializeComponent();

            _connection = new HubConnection("http://localhost:44914");
            _chat = _connection.CreateHubProxy("Chat");

            _chat.On<string>("send", MessageReceived);

            _connection.Start();
        }

        private void MessageReceived(string message)
        {
            this.Invoke(new MethodInvoker(() =>
                lbMessages.Items.Add(message)
            ));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMessage.Text))
            {
                _chat.Invoke("send", "WinForm Client: " + txtMessage.Text);
            }
            txtMessage.Text = String.Empty;
        }
    }
}
