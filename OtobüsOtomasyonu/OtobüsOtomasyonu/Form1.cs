using System.Data.SqlClient;

namespace OtobüsOtomasyonu
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=DARK;Initial Catalog=OtobusOtomasyonu;Integrated Security=True";
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kadi, ksifre;
            kadi = textBox1.Text;
            ksifre = textBox2.Text;


            connection.Open();
            SqlCommand sorgu = new SqlCommand("SELECT * FROM Admin where kullanici='" + kadi + "' and sifre='" + ksifre + "'", connection);
            SqlDataReader oku = sorgu.ExecuteReader();
            if (oku.Read())
            {
                Form2 admin = new Form2();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya sifre hatalı");
            }



            connection.Close();
        }
    }
}
