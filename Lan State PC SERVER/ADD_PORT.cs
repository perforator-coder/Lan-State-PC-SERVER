using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Lan_State_PC_SERVER
{
    public partial class ADD_PORT : Form
    {

        IPAddress[] IPs = Dns.GetHostAddresses(Dns.GetHostName());
        public ADD_PORT()
        {
            InitializeComponent();
            foreach (IPAddress ip in IPs)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    label2.Text = "IP:   " + ip.ToString();
                    break;
                }
            }
            
            
            Port_box.Text = Form1.Getport.ToString();
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SAVE_PORT_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Port_box.Text) )
            {
                MessageBox.Show("Ошибка: Порт не может быть пустым","Port error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(Port_box.Text, out int tmp_port) || Port_box.Text.Length > 4)
            {
                MessageBox.Show("Ошибка: Не коректный Порт", "Port transver error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form1.Getport = tmp_port;
            this.Close();
        }
    }
}
