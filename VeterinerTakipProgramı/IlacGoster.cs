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
    public partial class IlacGoster : Form
    {
        Veteriner v3;
        OleDbDataReader drd;
        public IlacGoster(Veteriner v4)
        {
            InitializeComponent();
            v3 = v4;
        }
        OleDbConnection bag12 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt12 = new OleDbCommand();


        private void IlacGoster_Load(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = v3.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                bag12.Open();
                kmt12.Connection = bag12;
                kmt12.CommandText = "SELECT İlaç_ismi FROM KullanılanIlaclar Where Hasta_kimlik_no =" + textBox1.Text + "";
                drd = kmt12.ExecuteReader();
                while (drd.Read())
                {
                    listBox1.Items.Add(drd[0]);
                }

                bag12.Close();
            }
            catch
            {
                MessageBox.Show("Önce Kayıt Eklemelisiniz!");
            }
        }
    }
}
