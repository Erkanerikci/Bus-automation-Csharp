using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace OtobüsOtomasyonu
{
    public partial class Form3 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public Form3()
        {
            InitializeComponent();
        }
        void OtobusGetir()
        {
            baglanti = new SqlConnection(@"Data Source=DARK;Initial Catalog=OtobusOtomasyonu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT id, firma, kalkacak, inecek,saat,fiyat, resim,koltukid FROM Otobus", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OtobusGetir();
            dataGridView1.Columns["resim"].DefaultCellStyle.NullValue = null;
            dataGridView1.Columns["resim"].DefaultCellStyle.Padding = new Padding(-31);
            ((DataGridViewImageColumn)dataGridView1.Columns["resim"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtfirma.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtkalk.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtin.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtsaat.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtfiyat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            byte[] imageData = (byte[])dataGridView1.CurrentRow.Cells[6].Value;
            pictureBox1.Image = ByteArrayToImage(imageData);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imageData = ImageToByteArray(pictureBox1.Image);
            string sorgu = "INSERT INTO Otobus(id, firma, kalkacak, inecek,saat,fiyat, resim) VALUES(@id, @firma, @kalkacak, @inecek,@saat,@fiyat, @resim)" +
                "INSERT INTO koltuklar (koltukno, durum)\r\nVALUES \r\n    (1, 'Boş'),\r\n    (2, 'Boş'),\r\n    (3, 'Boş'),\r\n    (4, 'Boş'),\r\n    (5, 'Boş'),\r\n    (6, 'Boş'),\r\n    (7, 'Boş'),\r\n    (8, 'Boş'),\r\n    (9, 'Boş'),\r\n    (10, 'Boş'),\r\n    (11, 'Boş'),\r\n    (12, 'Boş'),\r\n    (13, 'Boş'),\r\n    (14, 'Boş'),\r\n    (15, 'Boş'),\r\n    (16, 'Boş'),\r\n    (17, 'Boş'),\r\n    (18, 'Boş'),\r\n    (19, 'Boş'),\r\n    (20, 'Boş'),\r\n    (21, 'Boş'),\r\n    (22, 'Boş'),\r\n    (23, 'Boş'),\r\n    (24, 'Boş'),\r\n    (25, 'Boş'),\r\n    (26, 'Boş'),\r\n    (27, 'Boş'),\r\n    (28, 'Boş'),\r\n    (29, 'Boş'),\r\n    (30, 'Boş'),\r\n    (31, 'Boş'), \r\n    (32, 'Boş'), \r\n    (33, 'Boş'),\r\n    (34, 'Boş'),\r\n    (35, 'Boş'), \r\n    (36, 'Boş'), \r\n    (37, 'Boş'), \r\n    (38, 'Boş'); ";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", txtno.Text);
            komut.Parameters.AddWithValue("@firma", txtfirma.Text);
            komut.Parameters.AddWithValue("@kalkacak", txtkalk.Text);
            komut.Parameters.AddWithValue("@inecek", txtin.Text);
            komut.Parameters.AddWithValue("@saat", txtsaat.Text);
            komut.Parameters.AddWithValue("@fiyat", txtfiyat.Text);
            komut.Parameters.Add("@resim", SqlDbType.VarBinary, -1).Value = imageData;
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            OtobusGetir();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Otobus WHERE id=@id";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(txtno.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            OtobusGetir();
        }
        private bool AreImagesEqual(Image image1, Image image2)
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                return false;
            }

            using (MemoryStream ms1 = new MemoryStream())
            using (MemoryStream ms2 = new MemoryStream())
            {
                image1.Save(ms1, ImageFormat.Png);
                image2.Save(ms2, ImageFormat.Png);

                byte[] image1Bytes = ms1.ToArray();
                byte[] image2Bytes = ms2.ToArray();

                return StructuralComparisons.StructuralEqualityComparer.Equals(image1Bytes, image2Bytes);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = txtno.Text;
            string yeniFirma = txtfirma.Text;
            string yenikalk= txtkalk.Text;
            string yeniinecek = txtin.Text;
            string yenisaat = txtsaat.Text;
            string yenifiyat = txtfiyat.Text;


            byte[] currentImageData = GetImageFromDatabase(Convert.ToInt32(id));
            Image eskiresim = ByteArrayToImage(currentImageData);

            Image yeniresim = pictureBox1.Image;

            byte[] yeniresimBytes;
            if (!AreImagesEqual(yeniresim, eskiresim))
            {
                yeniresimBytes = ImageToByteArray(yeniresim);
            }
            else
            {
                yeniresimBytes = currentImageData;
            }

            string connectionString = "Data Source=DARK;Initial Catalog=OtobusOtomasyonu;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string kontrolQuery = "SELECT COUNT(*) FROM Otobus WHERE id = @id";

                using (SqlCommand kontrolCommand = new SqlCommand(kontrolQuery, connection))
                {
                    kontrolCommand.Parameters.AddWithValue("@id", id);

                    int OtobusSayisi = (int)kontrolCommand.ExecuteScalar();

                    if (OtobusSayisi > 0)
                    {
                        string guncellemeQuery = "UPDATE Otobus SET firma = @yeniFirma, kalkacak = @yenikalk, inecek = @yeniinecek, saat = @yenisaat ,fiyat = @yenifiyat , resim = @Yeniresim WHERE id = @id";

                        using (SqlCommand guncellemeCommand = new SqlCommand(guncellemeQuery, connection))
                        {
                            guncellemeCommand.Parameters.AddWithValue("@id", id);
                            guncellemeCommand.Parameters.AddWithValue("@yeniFirma", yeniFirma);
                            guncellemeCommand.Parameters.AddWithValue("@yenikalkacak", yenikalk);
                            guncellemeCommand.Parameters.AddWithValue("@yeniinecek", yeniinecek);
                            guncellemeCommand.Parameters.AddWithValue("@yenisaat", yenisaat);
                            guncellemeCommand.Parameters.AddWithValue("@yenifiyat", yenifiyat);
                            guncellemeCommand.Parameters.Add("@Yeniresim", SqlDbType.VarBinary, -1).Value = yeniresimBytes;

                            guncellemeCommand.ExecuteNonQuery();

                            MessageBox.Show("Öğrenci bilgileri ve resmi başarıyla güncellendi.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci bulunamadı. Lütfen geçerli bir öğrenci numarası girin.");
                    }
                }
            }

            OtobusGetir();
        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            btnfoto.Text = dosyayolu;
            pictureBox1.ImageLocation = dosyayolu;
        }
        private byte[] GetImageFromDatabase(int id)
        {
            byte[] imageData = null;
            string connectionString = "Data Source=DARK;Initial Catalog=OtobusOtomasyonu;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT resim FROM Otobus WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                imageData = (byte[])reader[0];
                            }
                        }
                    }
                }
            }

            return imageData;
        }


        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return new Bitmap(image);
            }
        }
    }
}
