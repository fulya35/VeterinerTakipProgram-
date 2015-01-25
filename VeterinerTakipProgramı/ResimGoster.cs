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
    public partial class ResimGoster : Form
    {

        public ResimGoster(Veteriner v1)
        {
            InitializeComponent();
            try
            {
                if (v1.dataGridView1.CurrentRow.Cells[0].Value.ToString() != "1")
                {

                    textBox1.Text = v1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    pictureBox1.Image = Image.FromFile(v1.dataGridView1.CurrentRow.Cells[20].Value.ToString());
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.ShowDialog();
                }
                else
                    MessageBox.Show("Hasta resmi yok!");

            }
            catch
            {
                MessageBox.Show("Önce Kayıt Eklemelisiniz!");
            }


        }

  
    }
}
