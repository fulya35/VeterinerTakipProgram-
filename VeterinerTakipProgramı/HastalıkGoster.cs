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
    public partial class HastalıkGoster : Form
    {
        Veteriner v2;
        OleDbDataReader dr;
        public HastalıkGoster(Veteriner v1)
        {
            InitializeComponent();
            v2 = v1;
        }
        OleDbConnection bag11 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt11 = new OleDbCommand();

        private void HastalıkGoster_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = v2.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                bag11.Open();
                kmt11.Connection = bag11;
                kmt11.CommandText = "SELECT Hastalık_ismi FROM GecirilenHastaliklar Where Hasta_kimlik_no =" + textBox1.Text + "";
                dr = kmt11.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0]);
                }
                bag11.Close();
            }
            catch
            {
                MessageBox.Show("Önce Kayıt Eklemelisiniz!");
            }
        }
    }
}
