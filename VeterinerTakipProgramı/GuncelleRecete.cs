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
    public partial class GuncelleRecete : Form
    {
        ReceteEkle o2;
        public GuncelleRecete(ReceteEkle o1)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            dateTimePicker1.Value = Convert.ToDateTime(o1.dataGridView3.CurrentRow.Cells[0].Value.ToString());
            comboBox1.Text = o1.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = o1.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = o1.dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = o1.dataGridView3.CurrentRow.Cells[4].Value.ToString();

            o2 = o1;

        }

      
        OleDbConnection baglanti3 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_recete = new OleDbCommand();
        

        private void kaydetButtonu_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "" && comboBox2.Text.Trim() != "" && textBox1.Text.Trim() != "")
            {
                baglanti3.Open();
                kmt_guncelle_recete.Connection = baglanti3;
                kmt_guncelle_recete.CommandText = "UPDATE Recete SET Recete_tarihi='" + dateTimePicker1.Value + "', Açıklama='" + textBox1.Text +
                    "'  WHERE Veteriner_ad_soyad='" + comboBox1.Text + "' AND Hasta_kimlik_no=" + comboBox2.Text + " AND Verilen_ilaçlar='" + textBox2.Text + "'";
                kmt_guncelle_recete.ExecuteNonQuery();
                baglanti3.Close();
                o2.listele();
                this.Close();
                MessageBox.Show("Güncelle başarıyla yapılmıştır");
            }

            else MessageBox.Show("* olan yerler boş bırakılamaz!");

        }

        private void cikisButtonu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
