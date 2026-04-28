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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
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
            опцииToolStripMenuItem.Size = new Size(56, 20);
            опцииToolStripMenuItem.Text = "Опции";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(108, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // сетьToolStripMenuItem
            // 
            сетьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { обновитьToolStripMenuItem, сменитьПортToolStripMenuItem, запускСервераToolStripMenuItem, остановкаСервераToolStripMenuItem, статусСервераToolStripMenuItem });
            сетьToolStripMenuItem.Name = "сетьToolStripMenuItem";
            сетьToolStripMenuItem.Size = new Size(44, 20);
            сетьToolStripMenuItem.Text = "Сеть";
            // 
            // обновитьToolStripMenuItem
            // 
            обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            обновитьToolStripMenuItem.Size = new Size(180, 22);
            обновитьToolStripMenuItem.Text = "Обновить";
            обновитьToolStripMenuItem.Click += обновитьToolStripMenuItem_Click;
            // 
            // сменитьПортToolStripMenuItem
            // 
            сменитьПортToolStripMenuItem.Name = "сменитьПортToolStripMenuItem";
            сменитьПортToolStripMenuItem.Size = new Size(180, 22);
            сменитьПортToolStripMenuItem.Text = "Сменить порт";
            сменитьПортToolStripMenuItem.Click += сменитьПортToolStripMenuItem_Click;
            // 
            // запускСервераToolStripMenuItem
            // 
            запускСервераToolStripMenuItem.Name = "запускСервераToolStripMenuItem";
            запускСервераToolStripMenuItem.Size = new Size(180, 22);
            запускСервераToolStripMenuItem.Text = "Запуск сервера";
            запускСервераToolStripMenuItem.Click += запускСервераToolStripMenuItem_Click;
            // 
            // остановкаСервераToolStripMenuItem
            // 
            остановкаСервераToolStripMenuItem.Enabled = false;
            остановкаСервераToolStripMenuItem.Name = "остановкаСервераToolStripMenuItem";
            остановкаСервераToolStripMenuItem.Size = new Size(180, 22);
            остановкаСервераToolStripMenuItem.Text = "Остановка сервера";
            остановкаСервераToolStripMenuItem.Click += остановкаСервераToolStripMenuItem_Click;
            // 
            // статусСервераToolStripMenuItem
            // 
            статусСервераToolStripMenuItem.Name = "статусСервераToolStripMenuItem";
            статусСервераToolStripMenuItem.Size = new Size(180, 22);
            статусСервераToolStripMenuItem.Text = "Статус сервера";
            статусСервераToolStripMenuItem.Click += статусСервераToolStripMenuItem_Click;
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(94, 20);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(0, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 344);
            panel1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 373);
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
    }
}
