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
    public partial class GuncelleVeterinerEkle : Form
    {
        VeterinerEkle v2;

        public GuncelleVeterinerEkle(VeterinerEkle v1)
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            textBox1.Text = v1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(v1.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            textBox2.Text = v1.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = v1.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = v1.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            v2 = v1 ;/*v2 yi listelemek icin*/
        }

        OleDbConnection bag_guncelle_veteriner_ekle = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_veteriner_ekle = new OleDbCommand();
        

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    
                    bag_guncelle_veteriner_ekle.Open();
                    kmt_guncelle_veteriner_ekle.Connection = bag_guncelle_veteriner_ekle;

                    kmt_guncelle_veteriner_ekle.CommandText = "UPDATE VeterinerTablosu SET Telefon='" + textBox2.Text +
                         "',Dogum_tarihi='" + dateTimePicker1.Value + "' ,Email='" + textBox4.Text + "',Adres='" + textBox3.Text + "' WHERE Veteriner_ad_soyad ='" + textBox1.Text + "'";
                    kmt_guncelle_veteriner_ekle.ExecuteNonQuery();
                    bag_guncelle_veteriner_ekle.Close();
                    v2.listele();
                    this.Close();
                    MessageBox.Show("Güncelleme işlemi tamamlandı.");


                }
                else
                {
                    MessageBox.Show("* olan yerler boş bırakılamaz!");
                }
            }
            catch
            {

                MessageBox.Show("Eklemek istediğiniz veteriner zaten var!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
