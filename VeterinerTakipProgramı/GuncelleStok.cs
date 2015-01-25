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
    public partial class GuncelleStok : Form
    {
        Stok_Ekle s2;
        public GuncelleStok(Stok_Ekle s1)
        {
            InitializeComponent();
            textBox1.Text = s1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = s1.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = s1.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToInt16 (s1.dataGridView1.CurrentRow.Cells[3].Value.ToString());
            textBox3.Text = s1.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = s1.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            s2 = s1;
            
            
        }

        OleDbConnection bag_guncelle_stok = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt_guncelle_stok = new OleDbCommand();

      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && numericUpDown1.Value != 0)
                {
                    bag_guncelle_stok.Open();
                    kmt_guncelle_stok.Connection = bag_guncelle_stok;
                                        
                    kmt_guncelle_stok.CommandText = "UPDATE Stok SET Urun_ismi='" + textBox2.Text + "',Urun_tipi='"+ textBox5.Text +
                        "',Miktar='" + numericUpDown1.Value + "',Birim_fiyat='"+ textBox3.Text +"',Ozellikler='"+ textBox4.Text +"' WHERE Stok_kodu ="+ textBox1.Text + "";
                    kmt_guncelle_stok.ExecuteNonQuery();
                    bag_guncelle_stok.Close();
                    s2.listele();                  
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
                
                MessageBox.Show("Eklemek istediğiniz stok kodu zaten var!");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
