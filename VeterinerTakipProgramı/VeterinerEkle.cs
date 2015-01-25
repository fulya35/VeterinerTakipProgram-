using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VeterinerTakipProgramı
{
    public partial class VeterinerEkle : Form
    {
        public VeterinerEkle()
        {
            InitializeComponent();
        }

        OleDbConnection bag1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt1 = new OleDbCommand();
        OleDbCommand silmeKomutu = new OleDbCommand();

        DataTable tablo = new DataTable();
        

        public void listele()
        {
            tablo.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From VeterinerTablosu ", bag1);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void VeterinerEkle_Load(object sender, EventArgs e)
        {
            listele();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            dataGridView1.Columns[0].HeaderText = "Ad Soyad";
            dataGridView1.Columns[1].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Email";
            dataGridView1.Columns[4].HeaderText = "Adres";
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (textBox1.Text.Trim() != "")
                {
                    
                    bag1.Open();
                    kmt1.Connection = bag1;
                    kmt1.CommandText = " INSERT INTO VeterinerTablosu VALUES('" + textBox1.Text + "','" + dateTimePicker1.Value + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "')";
                    kmt1.ExecuteNonQuery();
                    bag1.Close();
                    listele();
                    MessageBox.Show("Kayıt işlemi gerçekleşti");

                }
                else
                {
                    MessageBox.Show("* olan yerler boş bırakılamaz!");
                }
            }
            catch
            {
                MessageBox.Show("Eklemek istediğiniz veteriner zaten var!");
                bag1.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                bag1.Open();
                silmeKomutu.Connection = bag1;/*kayıt olmayıp silmeye kalkınca hata veriuor*/
                silmeKomutu.CommandText = "DELETE FROM VeterinerTablosu WHERE Veteriner_ad_soyad='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                silmeKomutu.ExecuteNonQuery();
                bag1.Close();
                listele();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuncelleVeterinerEkle g1 = new GuncelleVeterinerEkle(this);
            g1.ShowDialog();
        }
        
    }
}
