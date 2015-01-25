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
    public partial class GuncelleMuayene : Form
    {
        MuayeneEkle o2;

        public GuncelleMuayene(MuayeneEkle o1)
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            dateTimePicker1.Value = Convert.ToDateTime(o1.dataGridView2.CurrentRow.Cells[0].Value.ToString());
            comboBox1.Text = o1.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = o1.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = o1.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = o1.dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = o1.dataGridView2.CurrentRow.Cells[5].Value.ToString();

            o2 = o1;
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_muayene = new OleDbCommand();

       

        private void kaydetButtonu_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Trim() != "" || comboBox2.Text.Trim() != "" || comboBox3.Text.Trim() != "")
                {
                    baglanti.Open();
                    kmt_guncelle_muayene.Connection = baglanti;
                    kmt_guncelle_muayene.CommandText = "UPDATE Muayene SET Muayene_tarihi='" + dateTimePicker1.Value + "', Muayene_nedeni='" + textBox1.Text + "', Teşhis ='" + textBox2.Text +
                        "' WHERE Veteriner_ad_soyad='" + comboBox1.Text.ToString() + "' AND Hasta_kimlik_no=" + comboBox2.Text.ToString() + " AND Muayene_şekli='" + comboBox3.Text.ToString() + "'";
                    kmt_guncelle_muayene.ExecuteNonQuery();
                    baglanti.Close();
                    o2.listele();
                    this.Close();
                    MessageBox.Show("Güncelleme işlemi tamamlandı.");

                }
                else MessageBox.Show("* olan yerler boş kalamaz!");
            }
            catch
            {
                MessageBox.Show("Bu kayıt zaten var!");
            }
        }

        private void Cikis_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }










    }
}
