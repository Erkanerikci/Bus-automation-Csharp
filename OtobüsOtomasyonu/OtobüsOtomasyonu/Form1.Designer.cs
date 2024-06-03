namespace OtobüsOtomasyonu
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
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 109);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı :";
            // 
            // button1
            // 
            button1.Location = new Point(223, 237);
            button1.Name = "button1";
            button1.Size = new Size(75, 21);
            button1.TabIndex = 1;
            button1.Text = "Giris";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(252, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 170);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 0;
            label2.Text = "sifre : ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(252, 162);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 367);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
    }
}
