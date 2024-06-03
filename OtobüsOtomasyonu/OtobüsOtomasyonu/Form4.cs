using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Reflection.Metadata;
using Document = iTextSharp.text.Document;
using com.itextpdf.text.pdf;



namespace OtobüsOtomasyonu
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        private string connectionString = "Data Source=DARK;Initial Catalog=OtobusOtomasyonu;Integrated Security=True";
        private List<Button> koltukButtons = new List<Button>();

        public Form4()
        {
            InitializeComponent();
            KoltuklariYukle();
        }

        private void KoltuklariYukle()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT K.koltukno, K.durum FROM koltuklar K JOIN Otobus O ON O.koltukid = 9";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        int koltukno = reader.GetInt32(0);
                        string durum = reader.GetString(1);
                        string buttonName = "button" + koltukno;

                        foreach (Button btn in koltukButtons)
                        {
                            if (btn.Name == buttonName)
                            {
                                if (durum == "Bos")
                                {
                                    btn.BackColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    btn.BackColor = System.Drawing.Color.Red;
                                }
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void KoltukButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int koltukNo = int.Parse(clickedButton.Name.Replace("button", ""));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT durum FROM koltuklar WHERE koltukno = @KoltukNo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@KoltukNo", koltukNo);
                connection.Open();
                string durum = (string)command.ExecuteScalar();
                if (durum == "Dolu")
                {
                    MessageBox.Show($"Koltuk {koltukNo} dolu.");
                }
                else
                {
                    MessageBox.Show($"Koltuk {koltukNo} bos.");
                }
            }
        }

        private void BiletSatinAl(int koltukNo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE koltuklar SET durum = 'Dolu' WHERE koltukno = @KoltukNo";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@KoltukNo", koltukNo);

                connection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Koltuk {koltukNo} için bilet satın alındı!");

                    Button btn = koltukButtons.FirstOrDefault(b => b.Name == "button" + koltukNo);
                    if (btn != null)
                    {
                        btn.BackColor = System.Drawing.Color.Red;
                    }

                    // PDF fişi oluştur
                    PdfFisOlustur(koltukNo);
                }
                else
                {
                    MessageBox.Show($"Koltuk {koltukNo} için bilet satın alma islemi basarısız oldu!");
                }
            }
        }

        
       private void PdfFisOlustur(int koltukNo)
        {
       
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("------ Fis Ciktisi ------");
            receipt.AppendLine($"Koltuk No: {koltukNo}");
            receipt.AppendLine($"Tarih: {DateTime.Now}");
   
            receipt.AppendLine("-------------------------");







            try
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Dosyaları|*.pdf";
                saveFileDialog.Title = "PDF Olarak Kaydet";
                saveFileDialog.ShowDialog();

                // Eğer kullanıcı bir dosya seçtiyse
                if (saveFileDialog.FileName != "")
                {
                    // PDF dokümanı oluştur
                    Document pdfDoc = new Document();
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    pdfDoc.Open();

                    // Fiş çıktısını PDF'e yazdır
                    pdfDoc.Add(new Paragraph(receipt.ToString()));

                    pdfDoc.Close();
                    MessageBox.Show("Fiş çıktısı başarıyla PDF olarak kaydedildi: " + saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturma hatası: " + ex.Message);
            }


        }

        private void btnsat_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedButton = (Button)sender;
                int koltukNo = int.Parse(clickedButton.Name.Replace("button", ""));

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string checkQuery = "SELECT durum FROM koltuklar WHERE koltukno = @KoltukNo";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@KoltukNo", koltukNo);

                    connection.Open();
                    string durum = (string)checkCommand.ExecuteScalar();

                    if (durum == "Dolu")
                    {
                        MessageBox.Show($"Koltuk {koltukNo} zaten satılmıs!");
                    }
                    else
                    {
                        BiletSatinAl(koltukNo);
                    }
                    KoltuklariYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata olustu: {ex.Message}");
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            KoltuklariYukle();
            OtobusGetir();

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            this.Controls.Add(panel);

            int koltukSayisi = 38;
            int koltukGenislik = 30;
            int koltukYukseklik = 25;
            int padding = 20;
            int yOffset = 80; // Butonları aşağı kaydırmak için ofset
            int sutunSayisi = 4;
            for (int i = 0; i < koltukSayisi; i++)
            {
                Button btnSat = new Button();
                btnSat.Name = "button" + (i + 1);
                btnSat.Text = (i + 1).ToString();
                btnSat.Size = new Size(koltukGenislik, koltukYukseklik);
                int row = i / sutunSayisi;
                int col = i % sutunSayisi;
                btnSat.Location = new Point(padding + col * (koltukGenislik + padding), yOffset + padding + row * (koltukYukseklik + padding));
                btnSat.Click += btnsat_Click;
                panel.Controls.Add(btnSat);

                koltukButtons.Add(btnSat);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        void OtobusGetir()
        {
            baglanti = new SqlConnection(@"Data Source=DARK;Initial Catalog=OtobusOtomasyonu;Integrated Security=True");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT id, firma, kalkacak, inecek, saat, fiyat, resim, koltukid FROM Otobus", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void IDyeGoreKoltuklariGetir(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select koltukno,durum from Otobus O join koltuklar K on O.koltukid = K.koltukid WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int koltukNo = reader.GetInt32(0);
                    string durum = reader.GetString(1);

   
                    Button btn = koltukButtons.FirstOrDefault(b => b.Name == "button" + koltukNo);
                    if (btn != null)
                    {
                        if (durum == "Dolu")
                        {
                            btn.BackColor = Color.Red;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                        }
                    }
                }
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            
            }

            private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                IDyeGoreKoltuklariGetir(selectedID);
            }
        }
    }
}
