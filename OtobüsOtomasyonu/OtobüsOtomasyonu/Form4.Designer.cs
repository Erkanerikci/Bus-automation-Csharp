namespace OtobüsOtomasyonu
{
    partial class Form4
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
            PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            dataGridView1 = new DataGridView();
            btnsat = new Button();
            txtid = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 92);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(433, 33);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(692, 150);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellEnter += dataGridView1_CellEnter;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // btnsat
            // 
            btnsat.Location = new Point(1112, 283);
            btnsat.Name = "btnsat";
            btnsat.Size = new Size(75, 61);
            btnsat.TabIndex = 4;
            btnsat.Text = "Satın Al";
            btnsat.UseVisualStyleBackColor = true;
            btnsat.Click += btnsat_Click;
            // 
            // txtid
            // 
            txtid.Location = new Point(1097, 224);
            txtid.Name = "txtid";
            txtid.Size = new Size(100, 23);
            txtid.TabIndex = 5;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 627);
            Controls.Add(txtid);
            Controls.Add(btnsat);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Button btnsat;
        private TextBox txtid;
    }
}