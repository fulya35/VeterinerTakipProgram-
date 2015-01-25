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
    public partial class GuncelleOperasyon : Form
    {
        Operasyon_Ekle o2;
        public GuncelleOperasyon(Operasyon_Ekle o1)
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";
            
            textBox2.Text = o1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = o1.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = o1.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(o1.dataGridView1.CurrentRow.Cells[3].Value.ToString());
           
            o2 = o1;/*o2 yi listelemek icin*/
        }

        OleDbConnection bag_guncelle_operasyon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_operasyon = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Trim() != "")/*text->int donusumunu unutma*/
                {

                    bag_guncelle_operasyon.Open();
                    kmt_guncelle_operasyon.Connection = bag_guncelle_operasyon;//sadece tarih

                    kmt_guncelle_operasyon.CommandText = "UPDATE Operasyon SET Operasyon_tarihi='" + dateTimePicker1.Value +
                          "' WHERE  Operasyon_adi='" + textBox2.Text +
                    "' AND Veteriner_ad_soyad='" + comboBox1.Text + "' AND Hasta_kimlik_no=" +comboBox2.Text + "";
                    kmt_guncelle_operasyon.ExecuteNonQuery();
                    bag_guncelle_operasyon.Close();
                    o2.listele();
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
