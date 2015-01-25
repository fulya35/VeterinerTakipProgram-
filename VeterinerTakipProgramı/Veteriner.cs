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
    public partial class Veteriner : Form
    {
        public Veteriner()
        {
            InitializeComponent();
            
            
        }
        OleDbConnection bag5 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt5 = new OleDbCommand();
        OleDbCommand gostermeKomutu = new OleDbCommand();
        OleDbCommand silmeKomutu = new OleDbCommand();

        DataTable tablo = new DataTable();

        public void listele()
        {
            tablo.Clear();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta ", bag5);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            HastaBilgisi h1 = new HastaBilgisi();
            h1.ShowDialog();
            
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            VeterinerEkle v1 = new VeterinerEkle();
            v1.ShowDialog();
        }

        private void toolStripButton5_Click_1(object sender, EventArgs e)
        {
            Stok_Ekle s1 = new Stok_Ekle();
            s1.ShowDialog();
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            AşıEkle asiEkle = new AşıEkle();
            // asiEkle.MdiParent = this;
            asiEkle.ShowDialog();
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            ReceteEkle r1 = new ReceteEkle();
            r1.ShowDialog();
        }

        private void toolStripButton8_Click_1(object sender, EventArgs e)
        {
            Operasyon_Ekle o1 = new Operasyon_Ekle();
            o1.ShowDialog();
        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            Hasta_Aşı_Ekle ha = new Hasta_Aşı_Ekle();
            ha.ShowDialog();
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            MuayeneEkle m1 = new MuayeneEkle();
            m1.ShowDialog();
        }

        private void Veteriner_Load(object sender, EventArgs e)
        {
            listele();
          
            dataGridView1.Columns[0].HeaderText = "Hasta Kimlik No";
            dataGridView1.Columns[1].HeaderText = "Hasta Adı";
            dataGridView1.Columns[2].HeaderText = "Hasta Tipi";
            dataGridView1.Columns[3].HeaderText = "Kayıt Tarihi";
            dataGridView1.Columns[4].HeaderText = "Türü";
            dataGridView1.Columns[5].HeaderText = "Irkı";
            dataGridView1.Columns[6].HeaderText = "Renk";
            dataGridView1.Columns[7].HeaderText = "Cinsiyet";
            dataGridView1.Columns[8].HeaderText = "Safkan";
            dataGridView1.Columns[9].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[10].HeaderText = "Doğum Yeri";
            dataGridView1.Columns[11].HeaderText = "Kilosu";
            dataGridView1.Columns[12].HeaderText = "Boyu";
            dataGridView1.Columns[13].HeaderText = "Sahibinin TC No";
            dataGridView1.Columns[14].HeaderText = "Sahibinin Adı";
            dataGridView1.Columns[15].HeaderText = "Sahibinin Soyadı";
            dataGridView1.Columns[16].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[17].HeaderText = "Telefonu";
            dataGridView1.Columns[18].HeaderText = "Email Adresi";
            dataGridView1.Columns[19].HeaderText = "Adresi";
            dataGridView1.Columns[20].HeaderText = "Resmi";



            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void button1_Click(object sender, EventArgs e)//silme
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            try
            {
                if (cevap == DialogResult.Yes)
                {
                    bag5.Open();
                    silmeKomutu.Connection = bag5;
                    silmeKomutu.CommandText = "DELETE FROM Hasta WHERE Hasta_kimlik_no=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
                    silmeKomutu.ExecuteNonQuery();
                    listele();
                    bag5.Close();
                    
                }
            }
            catch
            {
                MessageBox.Show("Önce Kayıt Eklemelisiniz!");
                bag5.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)/*acceste sayı tipindekii sahaları burda text gibi kabul ettin düzelt*/
        {
            try
            {

                bag5.Open();
                kmt5.Connection = bag5;
                kmt5.CommandText = "UPDATE Hasta SET Hasta_adi='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() +
                    "',Hasta_tipi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',Kayıt_tarihi='" + Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value.ToString()) +
                    "',Türü='" + dataGridView1.CurrentRow.Cells[4].Value.ToString() + "',Irkı='" + dataGridView1.CurrentRow.Cells[5].Value.ToString() +
                    "',Renk='" + dataGridView1.CurrentRow.Cells[6].Value.ToString() + "',Cinsiyet='" + dataGridView1.CurrentRow.Cells[7].Value.ToString() +
                    "',Safkan='" + Convert.ToInt16(dataGridView1.CurrentRow.Cells[8].Value) + "',Dogum_tarihi='" + Convert.ToDateTime(dataGridView1.CurrentRow.Cells[9].Value.ToString()) +
                    "',Dogum_yeri='" + dataGridView1.CurrentRow.Cells[10].Value.ToString() + "',Kilosu='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[11].Value.ToString()) +
                    "',Boyu='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value.ToString()) + "',Sahip_tc_no='" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value.ToString()) +
                    "',Sahip_adi='" + dataGridView1.CurrentRow.Cells[14].Value.ToString() + "',Sahip_soyadi='" + dataGridView1.CurrentRow.Cells[15].Value.ToString() +
                    "',Sahip_DTarihi='" + Convert.ToDateTime(dataGridView1.CurrentRow.Cells[16].Value.ToString()) + "',Telefon='" + dataGridView1.CurrentRow.Cells[17].Value.ToString() +
                    "',Email='" + dataGridView1.CurrentRow.Cells[18].Value.ToString() + "',Adres='" + dataGridView1.CurrentRow.Cells[19].Value.ToString() + "',Hasta_resmi='" + dataGridView1.CurrentRow.Cells[20].Value.ToString() + "' WHERE Hasta_kimlik_no=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "";
                kmt5.ExecuteNonQuery();
                listele();
                bag5.Close();
            }
            catch
            {                
                MessageBox.Show("Önce Kayıt Eklemelisiniz!");
                bag5.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta WHERE Hasta_adi Like '%" + textBox1.Text + "%'", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta WHERE Türü Like'%" + textBox2.Text + "%'", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta WHERE Cinsiyet Like '%" + textBox3.Text + "%'", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                tablo.Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta", bag5);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else
            {
                try
                {
                    tablo.Clear();
                    OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From Hasta WHERE Sahip_tc_no=" + Convert.ToInt32(textBox4.Text) + "", bag5);
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
                catch
                {
                    MessageBox.Show("TC no'ya Göre Aramada Rakam Giriniz!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
              ResimGoster r1 = new ResimGoster(this);
  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AlerjiGoster a1 = new AlerjiGoster(this);
            a1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HastalıkGoster h1 = new HastalıkGoster(this);
            h1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IlacGoster i1 = new IlacGoster(this);
            i1.ShowDialog();
        }

        

       
       

       

        

       

    }
}
