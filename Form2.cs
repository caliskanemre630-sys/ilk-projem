using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Öğrenci_Kayıt_Uygulaması
{
    public partial class Form1 : Form
    {
 
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OgrenciDB;Integrated Security=True;TrustServerCertificate=True;");
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogrenciler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Form1()

        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, comboBox2.Text);

            int toplam = dataGridView1.AllowUserToAddRows ? dataGridView1.Rows.Count - 1 : dataGridView1.Rows.Count;
            label6.Text = "Toplam öğrenci sayısı: " + toplam.ToString();
            label7.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            MessageBox.Show("Öğrenci bilgileri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
               label7.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            Listele();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            int toplam = dataGridView1.AllowUserToAddRows ? dataGridView1.Rows.Count - 1 : dataGridView1.Rows.Count;
            label6.Text = "Toplam öğrenci sayısı: " + toplam.ToString();
            MessageBox.Show("Öğrenci bilgileri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MessageBox.Show("Öğrenci bilgileri başarıyla temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                int seciliIndex = dataGridView1.CurrentRow.Index;

                dataGridView1.Rows[seciliIndex].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[seciliIndex].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[seciliIndex].Cells[2].Value = textBox3.Text;
                dataGridView1.Rows[seciliIndex].Cells[3].Value = comboBox1.Text;
                dataGridView1.Rows[seciliIndex].Cells[4].Value = comboBox2.Text;

                MessageBox.Show("Öğrenci bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen önce tablodan güncelleyeceğiniz öğrencinin üzerine tıklayın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string aranan = textBox4.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aranan))
            {
                MessageBox.Show("Lütfen arama yapmak için bir öğrenci no, ad veya soyad girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool bulundu = false;
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

             
                string no = row.Cells[0].Value?.ToString().ToLower() ?? "";
                string ad = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string soyad = row.Cells[2].Value?.ToString().ToLower() ?? "";

                //
                if (no.Contains(aranan) || ad.Contains(aranan) || soyad.Contains(aranan))
                {
                    row.Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index; 
                    bulundu = true;
                    break; 
                }
            }

            if (!bulundu)
            {
                MessageBox.Show("Aranan kritere uygun bir öğrenci kaydı bulunamadı.", "Arama Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}