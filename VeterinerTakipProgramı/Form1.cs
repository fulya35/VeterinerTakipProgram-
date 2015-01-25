using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VeterinerTakipProgramı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "a" && textBox2.Text == "a")
            {
                this.Hide();
                Veteriner v1 = new Veteriner();
                v1.ShowDialog();
                this.Close();
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Kullanıcı adını Boş bırakamazsınız!");
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("Şifre sahasını boş bırakamazsınız!");
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre!");
            }

        }
        
    }
}
