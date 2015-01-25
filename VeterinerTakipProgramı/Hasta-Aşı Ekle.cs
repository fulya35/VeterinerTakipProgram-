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
    public partial class Hasta_Aşı_Ekle : Form
    {
        public Hasta_Aşı_Ekle()
        {
            InitializeComponent();
        }
        OleDbConnection bag5 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand ekle2 = new OleDbCommand();
        OleDbCommand silme = new OleDbCommand();


        OleDbCommand kmt_hasta_kimlik_no;
        OleDbCommand kmt_veteriner;
        OleDbCommand kmt_asi_adi;

        OleDbDataReader oku_hasta_kimlik_no;
        OleDbDataReader oku_veteriner;
        OleDbDataReader oku_asi_adi;

        DataTable tablo_hasta_asi = new DataTable();
        public void listele()
        {
            tablo_hasta_asi.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From HastaAsi ", bag5);
            adtr.Fill(tablo_hasta_asi);
            dataGridView3.DataSource = tablo_hasta_asi;

        }

        private void Hasta_Aşı_Ekle_Load(object sender, EventArgs e)
        {
            listele();

            dataGridView3.Columns[0].HeaderText = "Aşı İsmi";
            dataGridView3.Columns[2].HeaderText = "Vuracak Veteriner Hekim";
            dataGridView3.Columns[1].HeaderText = "Vurulacak Hasta Kimlik No";
            dataGridView3.Columns[3].HeaderText = "Vurulacak Tarih";
            dataGridView3.Columns[4].HeaderText = "Açıklama";

            bag5.Open();
            kmt_asi_adi = new OleDbCommand("Select Aşı_adı From AsiTanimi ", bag5);
            kmt_hasta_kimlik_no = new OleDbCommand("Select Hasta_kimlik_no From Hasta ", bag5);
            kmt_veteriner = new OleDbCommand("Select Veteriner_ad_soyad From VeterinerTablosu ", bag5);


            oku_asi_adi = kmt_asi_adi.ExecuteReader();
            while (oku_asi_adi.Read())
            {
                comboBox1.Items.Add(oku_asi_adi[0].ToString());
            }

            oku_hasta_kimlik_no = kmt_hasta_kimlik_no.ExecuteReader();
            while (oku_hasta_kimlik_no.Read())
            {
                comboBox2.Items.Add(oku_hasta_kimlik_no[0]);
            }

            
            oku_veteriner = kmt_veteriner.ExecuteReader();
            while (oku_veteriner.Read())
            {
                comboBox3.Items.Add(oku_veteriner[0].ToString());
            }

            bag5.Close();

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.Text != "" && comboBox3.Text != "" && comboBox2.Text != "")
                {

                    bag5.Open();
                    ekle2.Connection = bag5;
                    ekle2.CommandText = "INSERT INTO HastaAsi VALUES('" + comboBox1.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox1.Text + "')";
                    ekle2.ExecuteNonQuery();
                    bag5.Close();
                    listele();
                    bag5.Close();

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
                bag5.Close();
            }

        }

        private void guncelleButtonu_Click_1(object sender, EventArgs e)
        {
            GuncelleHasta_Aşı go = new GuncelleHasta_Aşı(this);
            go.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Hasta-Aşı kaydını silmek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                bag5.Open();
                silme.Connection = bag5;
                silme.CommandText = "DELETE FROM HastaAsi WHERE HastaAsi.Aşı_adı='" + dataGridView3.CurrentRow.Cells[0].Value.ToString() + "' AND HastaAsi.Vuracak_hekim='" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + "' AND HastaAsi.Vurulacak_hasta=" + dataGridView3.CurrentRow.Cells[2].Value.ToString() + "";
                silme.ExecuteNonQuery();
                bag5.Close();
                listele();
                MessageBox.Show("Kayıt silindi");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
