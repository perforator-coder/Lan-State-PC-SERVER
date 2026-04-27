using System.ComponentModel;

namespace Lan_State_PC_SERVER
{
    public partial class Form1 : Form
    {
        private static int port = 0;
        private ADD_PORT Port_form = new ADD_PORT();
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
            ADD_PORT Port_form = new ADD_PORT();
            Port_form.ShowDialog();
        }
    }
}
