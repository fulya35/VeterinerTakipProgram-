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
    public partial class GuncelleAsiTanimi : Form
    {
        AşıEkle a2;

        public GuncelleAsiTanimi(AşıEkle a1)
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            textBox2.Text = a1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = a1.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            numericUpDown1.Value = Convert.ToInt16(a1.dataGridView1.CurrentRow.Cells[2].Value.ToString());
            numericUpDown2.Value = Convert.ToInt16(a1.dataGridView1.CurrentRow.Cells[3].Value.ToString());
            textBox3.Text = a1.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(a1.dataGridView1.CurrentRow.Cells[5].Value.ToString());
                     
            a2 = a1;
        }

        OleDbConnection bag_guncelle_asi_ekle = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_asi_ekle = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {

                    bag_guncelle_asi_ekle.Open();
                    kmt_guncelle_asi_ekle.Connection = bag_guncelle_asi_ekle;

                    kmt_guncelle_asi_ekle.CommandText = "UPDATE AsiTanimi SET Aşı_seri_no='" + textBox1.Text +
                         "',Etki_süresi='" + numericUpDown1.Value + "' ,Stok_miktarı='" + numericUpDown2.Value +
                         "',Üretici_firma='" + textBox3.Text + "',Son_kullanma_tarihi='"+dateTimePicker1.Value+ "' WHERE Aşı_adı ='" + textBox2.Text + "'";
                    kmt_guncelle_asi_ekle.ExecuteNonQuery();
                    bag_guncelle_asi_ekle.Close();
                    a2.listele();
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

                MessageBox.Show("Eklemek istediğiniz Aşı TAnımı zaten var!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
