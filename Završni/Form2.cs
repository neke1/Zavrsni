using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Završni
{
    public partial class Form2 : Form
    {
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Zavrsni;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ime, adresa FROM Veterinar";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    comboBox1.DataSource = table;
                    comboBox1.DisplayMember = "ime";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataRowView selectedRow = comboBox1.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                
                string adresa = selectedRow["adresa"].ToString();
                
                textBox1.Text = adresa;
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show($"Naručeno kod veterinara {comboBox1.Text} na adresu: {textBox1.Text}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Naručeno kod veterinara {comboBox1.Text} na adresu: {textBox1.Text}");
        }
    }
}
