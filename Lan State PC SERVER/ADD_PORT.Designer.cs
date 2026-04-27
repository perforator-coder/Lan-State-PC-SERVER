namespace Lan_State_PC_SERVER
{
    partial class ADD_PORT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            Port_box = new TextBox();
            SAVE_PORT = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Порт:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 18);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 1;
            label2.Text = "IP:";
            label2.Click += label2_Click;
            // 
            // Port_box
            // 
            Port_box.Location = new Point(56, 41);
            Port_box.Name = "Port_box";
            Port_box.Size = new Size(100, 23);
            Port_box.TabIndex = 2;
            // 
            // SAVE_PORT
            // 
            SAVE_PORT.Location = new Point(47, 83);
            SAVE_PORT.Name = "SAVE_PORT";
            SAVE_PORT.Size = new Size(75, 23);
            SAVE_PORT.TabIndex = 3;
            SAVE_PORT.Text = "Сохранить";
            SAVE_PORT.UseVisualStyleBackColor = true;
            SAVE_PORT.Click += SAVE_PORT_Click;
            // 
            // ADD_PORT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(172, 118);
            Controls.Add(SAVE_PORT);
            Controls.Add(Port_box);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ADD_PORT";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Изменение порта";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Port_box;
        private Button SAVE_PORT;
    }
}