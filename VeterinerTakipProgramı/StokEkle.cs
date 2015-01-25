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
    public partial class Stok_Ekle : Form
    {
              
        public Stok_Ekle()
        {
            InitializeComponent();
            
        }
        
        
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt = new OleDbCommand();
        OleDbCommand silmeKomutu = new OleDbCommand();

        DataTable tablo = new DataTable();
        
        

        public void listele()
        {
            tablo.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Stok ", bag);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void Stok_Ekle_Load(object sender, EventArgs e)
        {

            listele();

            dataGridView1.Columns[0].HeaderText = "Stok Kodu";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Ürün Tipi";
            dataGridView1.Columns[3].HeaderText = "Miktarı";
            dataGridView1.Columns[4].HeaderText = "Birim Fiyatı";
            dataGridView1.Columns[5].HeaderText = "Özellikler";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && numericUpDown1.Value != 0)
                {

                    bag.Open();
                    kmt.Connection = bag;//convert.toint textBox1.Text yappppppp
                    kmt.CommandText = " INSERT INTO Stok VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + numericUpDown1.Value + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    kmt.ExecuteNonQuery();
                    bag.Close();
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
                MessageBox.Show("Eklemek istediğiniz stok kodu zaten var!");
                bag.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinize emin misiniz ?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                bag.Open();
                silmeKomutu.Connection = bag;
                silmeKomutu.CommandText = "DELETE FROM Stok WHERE Stok_kodu=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
                silmeKomutu.ExecuteNonQuery();
                bag.Close();
                listele();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuncelleStok g1 = new GuncelleStok(this);
            g1.ShowDialog();
            
            
        }
    }
}
