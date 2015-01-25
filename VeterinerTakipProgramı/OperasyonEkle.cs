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
    public partial class Operasyon_Ekle : Form
    {
        public Operasyon_Ekle()
        {
            InitializeComponent();
        }

        OleDbConnection bag3 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt3 = new OleDbCommand();
        OleDbCommand silmeKomutu = new OleDbCommand();

        OleDbCommand kmt_veteriner;
        OleDbCommand kmt_hasta;
        

        OleDbDataReader oku_veteriner;
        OleDbDataReader oku_hasta_kimlik_no;

        DataTable tablo = new DataTable();


        public void listele()
        {
            tablo.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Operasyon ", bag3);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void Operasyon_Ekle_Load(object sender, EventArgs e)
        {
            listele();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            dataGridView1.Columns[0].HeaderText = "Operasyon Adı";
            dataGridView1.Columns[1].HeaderText = "Veteriner";
            dataGridView1.Columns[2].HeaderText = "Hasta Kimlik No";
            dataGridView1.Columns[3].HeaderText = "Operasyon Tarihi";

            bag3.Open();
            kmt_veteriner = new OleDbCommand("Select Veteriner_ad_soyad From VeterinerTablosu ", bag3);
            kmt_hasta = new OleDbCommand("Select Hasta_kimlik_no From Hasta ", bag3);

            oku_veteriner = kmt_veteriner.ExecuteReader();
            while (oku_veteriner.Read())
            {
                comboBox1.Items.Add(oku_veteriner[0].ToString());
            }
            
            oku_hasta_kimlik_no = kmt_hasta.ExecuteReader();

            while (oku_hasta_kimlik_no.Read())
            {
                comboBox2.Items.Add(oku_hasta_kimlik_no[0]);
            }

            bag3.Close();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text.Trim() != "" && comboBox1.Text !="" && comboBox2.Text != "")/*burda da text->int*/
                {

                    bag3.Open();
                    kmt3.Connection = bag3;
                    kmt3.CommandText = " INSERT INTO Operasyon VALUES('" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Value +  "')";
                    kmt3.ExecuteNonQuery();
                    bag3.Close();
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
                bag3.Close();
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
                bag3.Open();
                silmeKomutu.Connection = bag3;
                silmeKomutu.CommandText = "DELETE FROM Operasyon WHERE Operasyon_adi='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + 
                    "' AND Veteriner_ad_soyad='"+dataGridView1.CurrentRow.Cells[1].Value.ToString()+"' AND Hasta_kimlik_no="+ dataGridView1.CurrentRow.Cells[2].Value.ToString()+"";
                silmeKomutu.ExecuteNonQuery();
                bag3.Close();
                listele();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuncelleOperasyon go = new GuncelleOperasyon(this);
            go.ShowDialog();
        }
    }
}
