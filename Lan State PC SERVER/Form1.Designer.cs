namespace Lan_State_PC_SERVER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            опцииToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            сетьToolStripMenuItem = new ToolStripMenuItem();
            обновитьToolStripMenuItem = new ToolStripMenuItem();
            сменитьПортToolStripMenuItem = new ToolStripMenuItem();
            запускСервераToolStripMenuItem = new ToolStripMenuItem();
            остановкаСервераToolStripMenuItem = new ToolStripMenuItem();
            статусСервераToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            IP_client = new Label();
            Net_conection = new Label();
            OS_name = new Label();
            CPU_Client = new Label();
            Gpu_client = new Label();
            Mac_client = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.MediumPurple;
            menuStrip1.BackgroundImageLayout = ImageLayout.Zoom;
            menuStrip1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            menuStrip1.Items.AddRange(new ToolStripItem[] { опцииToolStripMenuItem, сетьToolStripMenuItem, оПрограммеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(623, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // опцииToolStripMenuItem
            // 
            опцииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
            опцииToolStripMenuItem.Name = "опцииToolStripMenuItem";
            опцииToolStripMenuItem.Size = new Size(59, 20);
            опцииToolStripMenuItem.Text = "Опции";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(116, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // сетьToolStripMenuItem
            // 
            сетьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { обновитьToolStripMenuItem, сменитьПортToolStripMenuItem, запускСервераToolStripMenuItem, остановкаСервераToolStripMenuItem, статусСервераToolStripMenuItem });
            сетьToolStripMenuItem.Name = "сетьToolStripMenuItem";
            сетьToolStripMenuItem.Size = new Size(48, 20);
            сетьToolStripMenuItem.Text = "Сеть";
            // 
            // обновитьToolStripMenuItem
            // 
            обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            обновитьToolStripMenuItem.Size = new Size(194, 22);
            обновитьToolStripMenuItem.Text = "Обновить";
            обновитьToolStripMenuItem.Click += обновитьToolStripMenuItem_Click;
            // 
            // сменитьПортToolStripMenuItem
            // 
            сменитьПортToolStripMenuItem.Name = "сменитьПортToolStripMenuItem";
            сменитьПортToolStripMenuItem.Size = new Size(194, 22);
            сменитьПортToolStripMenuItem.Text = "Сменить порт";
            сменитьПортToolStripMenuItem.Click += сменитьПортToolStripMenuItem_Click;
            // 
            // запускСервераToolStripMenuItem
            // 
            запускСервераToolStripMenuItem.Name = "запускСервераToolStripMenuItem";
            запускСервераToolStripMenuItem.Size = new Size(194, 22);
            запускСервераToolStripMenuItem.Text = "Запуск сервера";
            запускСервераToolStripMenuItem.Click += запускСервераToolStripMenuItem_Click;
            // 
            // остановкаСервераToolStripMenuItem
            // 
            остановкаСервераToolStripMenuItem.Enabled = false;
            остановкаСервераToolStripMenuItem.Name = "остановкаСервераToolStripMenuItem";
            остановкаСервераToolStripMenuItem.Size = new Size(194, 22);
            остановкаСервераToolStripMenuItem.Text = "Остановка сервера";
            остановкаСервераToolStripMenuItem.Click += остановкаСервераToolStripMenuItem_Click;
            // 
            // статусСервераToolStripMenuItem
            // 
            статусСервераToolStripMenuItem.Name = "статусСервераToolStripMenuItem";
            статусСервераToolStripMenuItem.Size = new Size(194, 22);
            статусСервераToolStripMenuItem.Text = "Статус сервера";
            статусСервераToolStripMenuItem.Click += статусСервераToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(102, 20);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.Khaki;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(127, 349);
            panel1.TabIndex = 1;
            // 
            // IP_client
            // 
            IP_client.AutoSize = true;
            IP_client.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            IP_client.Location = new Point(224, 72);
            IP_client.Name = "IP_client";
            IP_client.Size = new Size(28, 14);
            IP_client.TabIndex = 2;
            IP_client.Text = "IP: ";
            IP_client.Click += IP_client_Click;
            // 
            // Net_conection
            // 
            Net_conection.AutoSize = true;
            Net_conection.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Net_conection.Location = new Point(147, 124);
            Net_conection.Name = "Net_conection";
            Net_conection.Size = new Size(105, 14);
            Net_conection.TabIndex = 3;
            Net_conection.Text = "Есть интернет: ";
            Net_conection.Click += Net_conection_Click;
            // 
            // OS_name
            // 
            OS_name.AutoSize = true;
            OS_name.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            OS_name.Location = new Point(164, 47);
            OS_name.Name = "OS_name";
            OS_name.Size = new Size(88, 14);
            OS_name.TabIndex = 4;
            OS_name.Text = "OS Клиента: ";
            // 
            // CPU_Client
            // 
            CPU_Client.AutoSize = true;
            CPU_Client.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            CPU_Client.Location = new Point(157, 148);
            CPU_Client.Name = "CPU_Client";
            CPU_Client.Size = new Size(95, 14);
            CPU_Client.TabIndex = 5;
            CPU_Client.Text = "CPU Клиента: ";
            // 
            // Gpu_client
            // 
            Gpu_client.AutoSize = true;
            Gpu_client.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Gpu_client.Location = new Point(157, 173);
            Gpu_client.Name = "Gpu_client";
            Gpu_client.Size = new Size(95, 14);
            Gpu_client.TabIndex = 6;
            Gpu_client.Text = "GPU Клиента: ";
            // 
            // Mac_client
            // 
            Mac_client.AutoSize = true;
            Mac_client.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Mac_client.Location = new Point(167, 99);
            Mac_client.Name = "Mac_client";
            Mac_client.Size = new Size(85, 14);
            Mac_client.TabIndex = 7;
            Mac_client.Text = "MAC-адрес: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(623, 373);
            Controls.Add(Mac_client);
            Controls.Add(Gpu_client);
            Controls.Add(CPU_Client);
            Controls.Add(OS_name);
            Controls.Add(Net_conection);
            Controls.Add(IP_client);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lan State PC SERVER";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem опцииToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem сетьToolStripMenuItem;
        private ToolStripMenuItem обновитьToolStripMenuItem;
        private ToolStripMenuItem сменитьПортToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem запускСервераToolStripMenuItem;
        private ToolStripMenuItem остановкаСервераToolStripMenuItem;
        private ToolStripMenuItem статусСервераToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private Label IP_client;
        private Label Net_conection;
        private Label OS_name;
        private Label CPU_Client;
        private Label Gpu_client;
        private Label Mac_client;
    }
}
