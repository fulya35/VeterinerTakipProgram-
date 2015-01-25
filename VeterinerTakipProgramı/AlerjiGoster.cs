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
    public partial class AlerjiGoster : Form
    {
        Veteriner v2;
        OleDbDataReader dr;
        public AlerjiGoster(Veteriner v1)
        {
            InitializeComponent();
            v2 = v1;
          
        }
          
        OleDbConnection bag10 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=VETERINER.accdb");
        OleDbCommand kmt10 = new OleDbCommand();

        private void AlerjiGoster_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = v2.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                bag10.Open();
                kmt10.Connection = bag10;
                kmt10.CommandText = "SELECT Alerji_ismi FROM GecirilenAlerjiler Where Hasta_kimlik_no =" + textBox1.Text + "";
                dr = kmt10.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0]);
                }
                bag10.Close();
                
            }
            catch
            {
                MessageBox.Show("Önce Kayıt Eklemelisiniz!");
            }
        }

        
    }
}
