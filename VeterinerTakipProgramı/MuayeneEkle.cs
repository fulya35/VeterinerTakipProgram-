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
    public partial class MuayeneEkle : Form
    {
        public MuayeneEkle()
        {
            InitializeComponent();
        }
        OleDbConnection bag4 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand ekle = new OleDbCommand();
        OleDbCommand silme = new OleDbCommand();

        OleDbCommand kmt_veteriner;
        OleDbCommand kmt_hasta_no;


        OleDbDataReader oku_veteriner;
        OleDbDataReader oku_hasta_no;


        DataTable table = new DataTable();

        public void listele()
        {
            table.Clear();
            OleDbDataAdapter adptr = new OleDbDataAdapter("Select * From Muayene", bag4);
            adptr.Fill(table);
            dataGridView2.DataSource = table;
        }

       

        private void MuayeneEkle_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView2.Columns[0].HeaderText = "Muayene Tarihi";
            dataGridView2.Columns[1].HeaderText = "Veteriner";
            dataGridView2.Columns[2].HeaderText = "Hasta No";
            dataGridView2.Columns[3].HeaderText = "Muayene Şekli";
            dataGridView2.Columns[4].HeaderText = "Muayene Nedeni";
            dataGridView2.Columns[5].HeaderText = "Teşhis";

            bag4.Open();
            kmt_veteriner = new OleDbCommand("Select Veteriner_ad_soyad From VeterinerTablosu", bag4);
            kmt_hasta_no = new OleDbCommand("Select Hasta_kimlik_no From Hasta ", bag4);


            oku_veteriner = kmt_veteriner.ExecuteReader();

            while (oku_veteriner.Read())
            {
                comboBox1.Items.Add(oku_veteriner[0].ToString());
            }
            oku_hasta_no = kmt_hasta_no.ExecuteReader();
            while (oku_hasta_no.Read())
            {
                comboBox3.Items.Add(oku_hasta_no[0].ToString());
            }
            bag4.Close();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        

        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    bag4.Open();
                    ekle.Connection = bag4;
                    ekle.CommandText = "INSERT INTO Muayene VALUES('" + dateTimePicker1.Value + "','" + comboBox1.Text + "','" + Convert.ToInt32(comboBox3.Text) + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                    ekle.ExecuteNonQuery();
                    bag4.Close();
                    listele();
                    MessageBox.Show("Muayene eklendi");
                }
                else MessageBox.Show("* olan yerler boş bırakılamaz");

            }
            catch
            {
                MessageBox.Show("Eklemek istediğiniz muayene zaten var");
                bag4.Close();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GuncelleMuayene go = new GuncelleMuayene(this);
            go.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Muayene kaydını silmek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {

                bag4.Open();
                silme.Connection = bag4;
                silme.CommandText = "DELETE FROM Muayene WHERE Muayene.Veteriner_ad_soyad='" + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "' AND Muayene.Hasta_kimlik_no=" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "  AND Muayene.Muayene_şekli='" + dataGridView2.CurrentRow.Cells[3].Value.ToString() + "'";
                silme.ExecuteNonQuery();
                bag4.Close();
                listele();
                MessageBox.Show("Kayıt silindi");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
