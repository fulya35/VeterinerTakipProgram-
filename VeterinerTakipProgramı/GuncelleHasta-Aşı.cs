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
    public partial class GuncelleHasta_Aşı : Form
    {
        Hasta_Aşı_Ekle o2;
        public GuncelleHasta_Aşı(Hasta_Aşı_Ekle o1)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";

            comboBox1.Text = o1.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            comboBox2.Text = o1.dataGridView3.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = o1.dataGridView3.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(o1.dataGridView3.CurrentRow.Cells[3].Value.ToString());
            textBox1.Text = o1.dataGridView3.CurrentRow.Cells[4].Value.ToString();

            o2 = o1;

        }
        OleDbConnection baglanti2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_hastaAsi = new OleDbCommand();
        

        private void keydetButtonu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text.Trim() != "" && comboBox2.Text.Trim() != "" && comboBox3.Text.Trim() != "")
                {
                    baglanti2.Open();
                    kmt_guncelle_hastaAsi.Connection = baglanti2;
                    kmt_guncelle_hastaAsi.CommandText = "UPDATE HastaAsi SET Tarih='" + dateTimePicker1.Value + "', Açıklama='" + textBox1.Text +
                        "' WHERE Aşı_adı='" + comboBox1.Text + "' AND Vuracak_hekim='" + comboBox2.Text + "' AND Vurulacak_hasta=" + comboBox3.Text + "";
                    kmt_guncelle_hastaAsi.ExecuteNonQuery();
                    baglanti2.Close();
                    o2.listele();
                    this.Close();
                    MessageBox.Show("Güncelleme işlemi tamamlandı.");


                }
                else MessageBox.Show("* alanlar boş bırakılamaz! ");
            }
            catch
            {
                MessageBox.Show("Bu kayıt zaten var!");
            }
        }

        private void cikisButtonu_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
