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
    public partial class AşıEkle : Form
    {
        public AşıEkle()
        {
            InitializeComponent();

        }

        OleDbConnection bag2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt2 = new OleDbCommand();
        OleDbCommand silmeKomutu = new OleDbCommand();

        DataTable tablo = new DataTable();

        public void listele()
        {
            tablo.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From AsiTanimi ", bag2);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void AşıEkle_Load(object sender, EventArgs e)
        {
            listele();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            dataGridView1.Columns[0].HeaderText = "Aşı Adı";
            dataGridView1.Columns[1].HeaderText = "Seri no";
            dataGridView1.Columns[2].HeaderText = "Etki Süresi";
            dataGridView1.Columns[3].HeaderText = "Stok Miktarı";
            dataGridView1.Columns[4].HeaderText = "Üretici Firma";
            dataGridView1.Columns[5].HeaderText = "Son Kullanma Tarihi";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text.Trim() != "")
                {

                    bag2.Open();
                    kmt2.Connection = bag2;
                    //asinin seri nosu sayı
                    int sayi = Convert.ToInt32(textBox1.Text);
                    kmt2.CommandText = " INSERT INTO AsiTanimi VALUES('" + textBox2.Text + "','" + sayi + "','" + numericUpDown1.Value + "','" + numericUpDown2.Value + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "')";
                    kmt2.ExecuteNonQuery();
                    bag2.Close();
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
                MessageBox.Show("Eklemek istediğiniz Aşı Tanımı zaten var!");
                bag2.Close();
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
                bag2.Open();
                silmeKomutu.Connection = bag2;
                silmeKomutu.CommandText = "DELETE FROM AsiTanimi WHERE Aşı_adı='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                silmeKomutu.ExecuteNonQuery();
                bag2.Close();
                listele();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuncelleAsiTanimi ga = new GuncelleAsiTanimi(this);
            ga.ShowDialog();
        }

       
    }
}
