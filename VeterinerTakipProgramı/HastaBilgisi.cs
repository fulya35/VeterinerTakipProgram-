using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace VeterinerTakipProgramı
{
    public partial class HastaBilgisi : Form
    {
        public HastaBilgisi()
        {
            InitializeComponent();
        }

        Veteriner veteriner_tablosu = new Veteriner();

        OleDbConnection bag4 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt4 = new OleDbCommand();
        OleDbCommand kmt6 = new OleDbCommand();//4 dier formda var
        OleDbCommand kmt7 = new OleDbCommand();
        OleDbCommand kmt8 = new OleDbCommand();
        OleDbCommand kmt9 = new OleDbCommand();

        DataTable tablo = new DataTable();

        int hangiRadioButton =0;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    comboBox3.Items.Add("Labrador Retriever");
                    comboBox3.Items.Add("Yorkshire Teriyeri");
                    comboBox3.Items.Add("Buldog");
                    comboBox3.Items.Add("Alman Çoban Köpeği");
                    comboBox3.Items.Add("Golden Retriever");
                    comboBox3.Items.Add("Sibirya Kurdu");
                    comboBox3.Items.Add("Chihuahua");
                    comboBox3.Items.Add("Pitbull");
                    comboBox3.Items.Add("Border Collie");
                    comboBox3.Items.Add("Doberman");
                    comboBox3.Items.Add("Çov-çov");
                    comboBox3.Items.Add("Sivas Kangalı");
                    comboBox3.Items.Add("Çoban Köpeği");
                    break;
                case 1:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Ankara Kedisi");
                    comboBox3.Items.Add("Van Kedisi");
                    comboBox3.Items.Add("Tekir Kedisi");
                    comboBox3.Items.Add("İran Kedisi");
                    comboBox3.Items.Add("Bengal Kedisi");
                    comboBox3.Items.Add("European Shorthair Kedisi");
                    comboBox3.Items.Add("Himalaya Kedisi");
                    break;
                case 2:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Serçe");
                    comboBox3.Items.Add("Güvercin");
                    comboBox3.Items.Add("Bülbül");
                    comboBox3.Items.Add("Papağan");
                    comboBox3.Items.Add("Kanarya");
                    comboBox3.Items.Add("İspinoz");
                    break;
                case 3:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Mahmuzlu Akdeniz kaplumbağası ");
                    comboBox3.Items.Add("Hermann kaplumbağası");
                    comboBox3.Items.Add("Benekli kaplumbağa ");
                    comboBox3.Items.Add("Çizgili kaplumbağa ");
                    comboBox3.Items.Add("Fırat kaplumbağası ");
                    comboBox3.Items.Add("Yeşil kaplumbağa");
                    comboBox3.Items.Add("Nil kaplumbağası ");
                    comboBox3.Items.Add("Sini kaplumbağası ");
                    break;
                case 4:
                    comboBox3.Items.Add("Dağ Tavşanı");
                    comboBox3.Items.Add("Yaban Tavşanı");
                    comboBox3.Items.Add("Himalaya Tavşanı");
                    comboBox3.Items.Add("Ankara Tavşanı");
                    comboBox3.Items.Add("Paskalya Tavşanı");
                    comboBox3.Items.Add("Kutup Tavşanı");
                    comboBox3.Items.Add("Deniz Tavşanı");
                    break;
                case 5:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Ak Ayaklı Farecik");
                    comboBox3.Items.Add("Avurdu keseli fare");
                    comboBox3.Items.Add("Bandikut faresi");
                    comboBox3.Items.Add("Çekirge faresi");
                    comboBox3.Items.Add("Çeltik faresi");
                    comboBox3.Items.Add("Dikenli fare");
                    comboBox3.Items.Add("Fırça kuyruklu fare");
                    comboBox3.Items.Add("Hasat faresi");
                    comboBox3.Items.Add("Huş faresi");
                    comboBox3.Items.Add("Kanguru faresi");
                    comboBox3.Items.Add("Orman faresi");
                    comboBox3.Items.Add("Pamuk faresi");
                    comboBox3.Items.Add("Sıçrayan fare");
                    comboBox3.Items.Add("Yeleli fare");
                    comboBox3.Items.Add("Bilgisayar faresi");
                    break;
                case 6:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("Hamsi");
                    comboBox3.Items.Add("Sazan Balığı");
                    comboBox3.Items.Add("Vatuz");
                    comboBox3.Items.Add("Yunus Balığı");
                    comboBox3.Items.Add("Mürekkerep Balığı");
                    comboBox3.Items.Add("Barbunya Balığı");
                    comboBox3.Items.Add("Mercan Balığı");
                    comboBox3.Items.Add("Çipura");
                    comboBox3.Items.Add("Köpek Balığı");
                    comboBox3.Items.Add("Pirana");
                    break;
                case 7:
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add("At");
                    comboBox3.Items.Add("Eşek");
                    comboBox3.Items.Add("Koyun");
                    comboBox3.Items.Add("Keçi");
                    comboBox3.Items.Add("İnek");
                    comboBox3.Items.Add("Tavuk");
                    comboBox3.Items.Add("Öküz");
                    comboBox3.Items.Add("Kaz");
                    comboBox3.Items.Add("Ördek");
                    break;
                    
                
                    

            }
                              
        }

        private void HastaBilgisi_Load(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd MM yyyy";
        }

        private void button10_Click(object sender, EventArgs e)//ekleme
        {
            try
            {

                if (textBox3.Text.Trim() != "" && comboBox1.Text.Trim() != "")//* olan yerler
                {
                    
                    bag4.Open();
                    kmt4.Connection = bag4;
                    kmt6.Connection = bag4;
                    kmt7.Connection = bag4;
                    kmt8.Connection = bag4;
                    //kmt9.Connection = bag4;


                    if (hangiRadioButton == 0)
                    {
                        MessageBox.Show("Safkan olup olmadıgını belirtin");
                    }
                    else
                    {
                        if (hangiRadioButton == 1)
                        {//hasta resmini cikardim sonradan eklemek gerek
                            kmt4.CommandText = " INSERT INTO Hasta VALUES('" + textBox3.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" +
                            dateTimePicker1.Value + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" +
                            comboBox5.Text + "','" + 1 + "','" + dateTimePicker2.Value + "','" + comboBox7.Text + "','" +
                            numericUpDown1.Value + "','" + numericUpDown2.Value + "','" + textBox7.Text + "','" + textBox8.Text + "','" +
                            textBox9.Text + "','" + dateTimePicker3.Value + "','" + textBox10.Text + "','" + textBox2.Text + "','" + textBox11.Text + "','" + _resimsakla + "')";



                            kmt4.ExecuteNonQuery();
                            //kmt9.CommandText = "INSERT INTO HastaResimleri VALUES('" +Convert.ToInt32( textBox3.Text )+ "','" + _resimsakla + "')";
                            //kmt9.ExecuteNonQuery();

                        }
                        else
                        {

                            kmt4.CommandText = " INSERT INTO Hasta VALUES('" + textBox3.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" +
                           dateTimePicker1.Value + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" +
                           comboBox5.Text + "','" + 0 + "','" + dateTimePicker2.Value + "','" + comboBox7.Text + "','" +
                           numericUpDown1.Value + "','" + numericUpDown2.Value + "','" + textBox7.Text + "','" + textBox8.Text + "','" +
                           textBox9.Text + "','" + dateTimePicker3.Value + "','" + textBox10.Text + "','" + textBox2.Text + "','" + textBox11.Text + "','" + _resimsakla + "')";

                            kmt4.ExecuteNonQuery();

                        }

                        for (int i = 0; i < listBox3.Items.Count; i++)
                        {

                            kmt6.CommandText = " INSERT INTO GecirilenHastaliklar (Hastalık_ismi,Hasta_kimlik_no) VALUES('" + listBox3.Items[i].ToString() + "','" + textBox3.Text + "')";
                            kmt6.ExecuteNonQuery();

                        }

                        for (int j = 0; j < listBox2.Items.Count; j++)
                        {
                            kmt7.CommandText = " INSERT INTO GecirilenAlerjiler (Alerji_ismi,Hasta_kimlik_no) VALUES('" + listBox2.Items[j].ToString() + "','" + textBox3.Text + "')";
                            kmt7.ExecuteNonQuery();
                        }

                        for (int k = 0; k < listBox1.Items.Count; k++)
                        {
                            kmt8.CommandText = " INSERT INTO KullanılanIlaclar (İlaç_ismi,Hasta_kimlik_no) VALUES('" + listBox1.Items[k].ToString() + "','" + textBox3.Text + "')";
                            kmt8.ExecuteNonQuery();
                        }

                        MessageBox.Show("Kayıt işlemi gerçekleşti");
                    }

                }
                else
                {
                    MessageBox.Show("* olan yerler boş bırakılamaz!");
                }
            }
            catch//(exception hata)
            {
                MessageBox.Show("Eklemek istediğiniz Hasta zaten var!");
                bag4.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox4.Text);
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(textBox5.Text);
            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add(textBox6.Text);
            textBox6.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            hangiRadioButton = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            hangiRadioButton = 2;
        }

        public static string _resimsakla;
        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Resim dosyaları |*.jpg;*.jpeg;*.gif;*.bmp;" +
                "*.png;*ico|JPEG Files ( *.jpg;*.jpeg )|*.jpg;*.jpeg|GIF Files ( *.gif )|*.gif|BMP Files ( *.bmp )" +
                "|*.bmp|PNG Files ( *.png )|*.png|Icon Files ( *.ico )|*.ico";
            openDialog.Title = "Resim seçiniz.";
            openDialog.InitialDirectory = Application.StartupPath + @"\\DataPicture\";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _resimsakla = openDialog.FileName.ToString();
                
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = _resimsakla;
                
            }
            openDialog.Dispose();
        }

    }
}
