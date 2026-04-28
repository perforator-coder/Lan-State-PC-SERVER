using System.ComponentModel;

namespace Lan_State_PC_SERVER
{
    public partial class Form1 : Form
    {
        private static int port = 0;
        private ADD_PORT Port_form = new ADD_PORT();
        private static LanSERVERacts ServerAct;
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
            MessageBox.Show($"Cтатус сервера:{ServerAct.IsEnable}\nКоличество подключений:{ServerAct.GetClients.Count}");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerAct.dev("nicita");
        }
    }
}
