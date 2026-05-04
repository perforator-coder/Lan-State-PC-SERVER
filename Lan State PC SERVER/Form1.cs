using System.ComponentModel;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Lan_State_PC_SERVER
{
    public partial class Form1 : Form
    {
        private static int port = 0;
        private ADD_PORT Port_form = new ADD_PORT();
        private static LanSERVERacts ServerAct;
        private Dictionary<string, TcpClient> Client_clone;
        private bool isfirsttime = true;
        private string selectedclient = "";
        public Form1()
        {
            InitializeComponent();
            //проверяем есть ли файл и если нет то просим вести порт
            if (File.Exists("notifyStatus.txt") && bool.TryParse(File.ReadAllText("notifyStatus.txt"), out isfirsttime))
            {
                if (isfirsttime)
                {
                    this.отключитьУведомленияToolStripMenuItem.Text = "Отключить Уведомления";
                }
                else
                {
                    this.отключитьУведомленияToolStripMenuItem.Text = "Включить уведомления";
                }
            }
            if (!File.Exists("Port.txt"))
            {
                Port_form.ShowDialog();
            }
            else
            {
                //читаем порт из файла
                if (!int.TryParse(File.ReadAllText("Port.txt"), out port))
                {
                    //если нет порта из файла выводим форму для получения порта
                    Port_form.ShowDialog();
                }
            }
            Getport = port;
            ServerAct = new LanSERVERacts(port);
            // скрываем строки при отстутствии клиента
            IP_client.Visible = false;
            Net_conection.Visible = false;
            OS_name.Visible = false;
            CPU_Client.Visible = false;
            Gpu_client.Visible = false;
            Mac_client.Visible = false;
            icon_tray.Visible = false;
            Shutdown.Visible = false;
            Restart.Visible = false;
            Server_ms.Visible = false;
            MS_send.Visible = false;
            Ping_bt.Visible = false;
            this.FormClosed += new FormClosedEventHandler(SavePort);
            this.FormClosing += new FormClosingEventHandler(StopClosing);
        }
        [DefaultValue(0)]
        public static int Getport
        {
            get
            {
                return port;
            }
            set
            {

                port = value;

            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //дейстиве при закрытии
        private void SavePort(object sender, EventArgs e)
        {

            File.WriteAllText("Port.txt", port.ToString());
            File.WriteAllText("notifyStatus.txt", isfirsttime.ToString());

        }
        // действие проверяющие запущен сервер или нет
        private void StopClosing(object sender, FormClosingEventArgs e)
        {
            if (ServerAct.IsEnable)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.icon_tray.Visible = true;
                //icon_tray.BalloonTipIcon = Properties.Resources.SERVER_ICON;
                if (isfirsttime)
                {
                    icon_tray.ShowBalloonTip(10, "Lan State PC SERVER", "Программа работает в трее, так как сервер запущен.", ToolTipIcon.Info);

                }
            }
        }

        private void сменитьПортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ServerAct.IsEnable)
            {
                ADD_PORT Port_form = new ADD_PORT();
                Port_form.ShowDialog();
                ServerAct = new LanSERVERacts(port);

            }


        }

        private void запускСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (ServerAct.StartServer()) // если сервер запущен то делаем следующие
            {
                запускСервераToolStripMenuItem.Enabled = false;
                остановкаСервераToolStripMenuItem.Enabled = true;

                сменитьПортToolStripMenuItem.Enabled = false;
            }
            return;
        }

        private void остановкаСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ServerAct.StopServer())//если успешно выключен
            {
                запускСервераToolStripMenuItem.Enabled = true;
                сменитьПортToolStripMenuItem.Enabled = true;

                остановкаСервераToolStripMenuItem.Enabled = false;
                panel1.Controls.Clear();
                IP_client.Visible = false;
                Net_conection.Visible = false;
                OS_name.Visible = false;
                CPU_Client.Visible = false;
                Gpu_client.Visible = false;
                Mac_client.Visible = false;
                Shutdown.Visible = false;
                Restart.Visible = false;
                Server_ms.Visible = false;
                MS_send.Visible = false;
                Ping_bt.Visible = false;
            }
        }

        private void статусСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // сделать нормальное меню или отображение
            string ru_ms;
            if (ServerAct.IsEnable)
            {
                ru_ms = "Включен";
            }
            else
            {
                ru_ms = "Выключен";
            }
            MessageBox.Show($"Cтатус сервера:{ru_ms}\nКоличество подключений:{ServerAct.GetClients.Count}");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            About_app info_form = new About_app();
            info_form.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client_clone = ServerAct.GetClients;
            panel1.Controls.Clear();
            if (Client_clone.Count == 0)
            {
                panel1.Controls.Clear();
            }
            int y = 10;

            foreach (string key in Client_clone.Keys)
            {

                // Доработать расположение кнопок 
                Button client = new Button();
                client.Text = key;

                client.BackColor = Color.White;
                client.Location = new Point(20, y);
                client.FlatStyle = FlatStyle.Flat;
                client.BackColor = Color.LightYellow;
                client.Click += ClientButton_Click;
                y += 30;
                panel1.Controls.Add(client);

            }

        }
        // прописываем метод для каждой кнопки
        private async void ClientButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                //действия прия нажатой кнопке
                Button client_button = (Button)sender;
                string client_ms_er = await ServerAct.GetinfoClient(client_button.Text);
                client_button.Enabled = false;
                selectedclient = client_button.Text;
                //очищяем строку от невидимых символов
                string client_ms = Regex.Replace(client_ms_er, @"[^0-9A-Яа-яA-Za-z.: (),]", "");
                string[] client_inf = client_ms.Split(',');

                IP_client.Text = "IP: " + client_inf[0];
                Net_conection.Text = "Есть интернет: " + client_inf[1];
                OS_name.Text = "OS Клиента: " + client_inf[2];
                CPU_Client.Text = "CPU Клиента: " + client_inf[3];
                Gpu_client.Text = "GPU Клиента: " + client_inf[4];
                Mac_client.Text = "MAC-адрес: " + client_inf[5];
                IP_client.Visible = true;
                Net_conection.Visible = true;
                OS_name.Visible = true;
                CPU_Client.Visible = true;
                Gpu_client.Visible = true;
                Mac_client.Visible = true;
                Shutdown.Visible = true;
                Restart.Visible = true;
                Server_ms.Visible = true;
                MS_send.Visible = true;
                Ping_bt.Visible = true;
                Server_ms.Text = "";

                client_button.Enabled = true;
            }
            catch (Exception ex)
            {
                // для тестировки если клиент отключился

                IP_client.Visible = false;
                Net_conection.Visible = false;
                OS_name.Visible = false;
                CPU_Client.Visible = false;
                Gpu_client.Visible = false;
                Mac_client.Visible = false;
                Shutdown.Visible = false;
                Restart.Visible = false;
                Server_ms.Visible = false;
                MS_send.Visible = false;
                Ping_bt.Visible = false;
                return;
            }
        }

        private void Net_conection_Click(object sender, EventArgs e)
        {

        }

        private void IP_client_Click(object sender, EventArgs e)
        {

        }

        private void выключитьСерверИВыйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerAct.StopServer();
            this.Close();
        }

        private void показатьМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            icon_tray.Visible = false;
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void статусСервераToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string ru_ms;
            if (ServerAct.IsEnable)
            {
                ru_ms = "Включен";
            }
            else
            {
                ru_ms = "Выключен";
            }
            MessageBox.Show($"Cтатус сервера:{ru_ms}\nКоличество подключений:{ServerAct.GetClients.Count}");
        }

        private void Tray_menu_Opening(object sender, CancelEventArgs e)
        {

        }

        private async void Shutdown_Click(object sender, EventArgs e)
        {
            if (selectedclient != "")
            {
                bool status = await ServerAct.SendShutDown(selectedclient);
                if (status)
                {

                    IP_client.Visible = false;
                    Net_conection.Visible = false;
                    OS_name.Visible = false;
                    CPU_Client.Visible = false;
                    Gpu_client.Visible = false;
                    Mac_client.Visible = false;
                    Shutdown.Visible = false;
                    Restart.Visible = false;
                    Server_ms.Visible = false;
                    MS_send.Visible = false;
                    Ping_bt.Visible = false;
                }
                else
                {
                    MessageBox.Show("Ошибка отправки запроса", "Client Send ER");
                    IP_client.Visible = false;
                    Net_conection.Visible = false;
                    OS_name.Visible = false;
                    CPU_Client.Visible = false;
                    Gpu_client.Visible = false;
                    Mac_client.Visible = false;
                    Shutdown.Visible = false;
                    Restart.Visible = false;
                    Server_ms.Visible = false;
                    MS_send.Visible = false;
                    Ping_bt.Visible = false;
                    selectedclient = "";
                }
            }

        }

        private async void Restart_Click(object sender, EventArgs e)
        {
            if (selectedclient != "")
            {
                bool status = await ServerAct.SendRestart(selectedclient);
                if (status)
                {
                    IP_client.Visible = false;
                    Net_conection.Visible = false;
                    OS_name.Visible = false;
                    CPU_Client.Visible = false;
                    Gpu_client.Visible = false;
                    Mac_client.Visible = false;
                    Shutdown.Visible = false;
                    Restart.Visible = false;
                    Server_ms.Visible = false;
                    MS_send.Visible = false;

                }
                else
                {
                    MessageBox.Show("Ошибка отправки запроса", "Client Send ER");
                    IP_client.Visible = false;
                    Net_conection.Visible = false;
                    OS_name.Visible = false;
                    CPU_Client.Visible = false;
                    Gpu_client.Visible = false;
                    Mac_client.Visible = false;
                    Shutdown.Visible = false;
                    Restart.Visible = false;
                    Server_ms.Visible = false;
                    MS_send.Visible = false;
                    selectedclient = "";
                }
            }
        }

        private async void MS_send_Click(object sender, EventArgs e)
        {
            try
            {
                MS_send.Enabled = false;
                if (selectedclient != "")
                {
                    if (!string.IsNullOrEmpty(Server_ms.Text))
                    {
                        bool status = await ServerAct.SendMS(selectedclient, Server_ms.Text);
                        if (status)
                        {
                            MS_send.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка отправки сообщения клиент потерян", "Client Send ER");
                            MS_send.Visible = false;
                            IP_client.Visible = false;
                            Net_conection.Visible = false;
                            OS_name.Visible = false;
                            CPU_Client.Visible = false;
                            Gpu_client.Visible = false;
                            Mac_client.Visible = false;
                            Shutdown.Visible = false;
                            Restart.Visible = false;
                            Server_ms.Visible = false;
                            MS_send.Visible = false;
                            Ping_bt.Visible = false;
                            selectedclient = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Server MS send error", "Строка пуста", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        MS_send.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                MS_send.Enabled = true;
            }
        }

        private void отключитьУведомленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isfirsttime)
            {
                isfirsttime = false;
                this.отключитьУведомленияToolStripMenuItem.Text = "Включить уведомления";
            }
            else
            {
                isfirsttime = true;
                this.отключитьУведомленияToolStripMenuItem.Text = "Отключить Уведомления";
            }
        }

        private void Ping_bt_Click(object sender, EventArgs e)
        {
            Ping_bt.Enabled = false;
            try
            {
                if (selectedclient != "")
                {
                    ServerAct.dev(selectedclient);
                }
                Ping_bt.Enabled = true;
            }
            catch
            {
                Ping_bt.Enabled = true;
            }

        }
    }
}
