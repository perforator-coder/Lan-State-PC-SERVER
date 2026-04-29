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
        public Form1()
        {
            InitializeComponent();
            //проверяем есть ли файл и если нет то просим вести порт
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
            this.FormClosed += new FormClosedEventHandler(SavePort);
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
        private void SavePort(object sender, EventArgs e)
        {
            File.WriteAllText("Port.txt", port.ToString());
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
            }
        }

        private void статусСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // сделать нормальное меню или отображение
            MessageBox.Show($"Cтатус сервера:{ServerAct.IsEnable}\nКоличество подключений:{ServerAct.GetClients.Count}");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //ServerAct.dev("testNick");
            About_app info_form = new About_app();
            info_form.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client_clone = ServerAct.GetClients;
            if (Client_clone.Count == 0)
            {
                panel1.Controls.Clear();
            }
            int y = 10;
            int count = 0;
            foreach (string key in Client_clone.Keys)
            {
                // Доработать расположение кнопок + реализацию получение данных при нажатии кнопки
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
            //действия прия нажатой кнопке
            Button client_button = (Button)sender;
            string client_ms_er =  await ServerAct.GetinfoClient(client_button.Text);
            string client_ms = Regex.Replace(client_ms_er,@"[^1-9A-Яа-я.:]","");
            string[] client_inf = client_ms.Split(':');
            IP_client.Text = "IP: " + client_inf[0];
            Net_conection.Text = "Есть интернет(Ping yandex dns): " + client_inf[1];
        }
    }
}
