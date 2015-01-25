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
    public partial class ReceteEkle : Form
    {
        public ReceteEkle()
        {
            InitializeComponent();
        }
        OleDbConnection bag5 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand ekle2 = new OleDbCommand();
        OleDbCommand silme = new OleDbCommand();

        OleDbCommand kmt_hasta_kimlik_no;
        OleDbCommand kmt_veteriner;


        OleDbDataReader oku_hasta_kimlik_no;
        OleDbDataReader oku_veteriner;


        DataTable tablo_recete = new DataTable();
        public void listele()
        {
            tablo_recete.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Recete ", bag5);
            adtr.Fill(tablo_recete);
            dataGridView3.DataSource = tablo_recete;

        }

        private void ReceteEkle_Load(object sender, EventArgs e)
        {
            listele();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            dataGridView3.Columns[0].HeaderText = "Reçete Tarihi";
            dataGridView3.Columns[1].HeaderText = "Veteriner Hekim Adi";
            dataGridView3.Columns[2].HeaderText = "Hasta Kimlik No";
            dataGridView3.Columns[3].HeaderText = "Verilen İlaçlar";
            dataGridView3.Columns[4].HeaderText = "Açıklama";

            bag5.Open();

            kmt_hasta_kimlik_no = new OleDbCommand("Select Hasta_kimlik_no From Hasta ", bag5);
            kmt_veteriner = new OleDbCommand("Select Veteriner_ad_soyad From VeterinerTablosu ", bag5);



            oku_veteriner = kmt_veteriner.ExecuteReader();
            while (oku_veteriner.Read())
            {
                comboBox1.Items.Add(oku_veteriner[0].ToString());
            }

            oku_hasta_kimlik_no = kmt_hasta_kimlik_no.ExecuteReader();
            while (oku_hasta_kimlik_no.Read())
            {
                comboBox2.Items.Add(oku_hasta_kimlik_no[0]);
            }

            bag5.Close();

            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.Text != "" && comboBox2.Text != "" && listBox1.Items.Count != 0)
                {

                    bag5.Open();
                    ekle2.Connection = bag5;
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        ekle2.CommandText = " INSERT INTO Recete VALUES('" + dateTimePicker1.Value + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + listBox1.Items[i].ToString() + "','" + textBox2.Text + "')";
                        ekle2.ExecuteNonQuery();

                    }
                    
                    bag5.Close();
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
                MessageBox.Show("Eklemek istediğiniz reçete zaten var!");
                bag5.Close();
            }
        }

        private void guncelleButtonu_Click_1(object sender, EventArgs e)
        {
            GuncelleRecete go = new GuncelleRecete(this);
            go.ShowDialog();
        }

        private void silmeButonu_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Silmek istediğinizden emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                bag5.Open();
                silme.Connection = bag5;
                silme.CommandText = "DELETE FROM Recete WHERE Veteriner_ad_soyad='" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + "' AND Hasta_kimlik_no=" + dataGridView3.CurrentRow.Cells[2].Value.ToString() + " AND Verilen_ilaçlar='" + dataGridView3.CurrentRow.Cells[3].Value.ToString() + "'";
                silme.ExecuteNonQuery();
                bag5.Close();
                listele();
                MessageBox.Show("Kayıt silindi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox3.Text);
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
