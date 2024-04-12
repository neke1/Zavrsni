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

namespace Završni
{
    public partial class Form3 : Form
    {
        

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Zavrsni;Integrated Security=True";

        public string Lijek { get; private set; }

        public Form3()
        {
            InitializeComponent();
            FillComboBox();
        }

        private void FillComboBox()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                string query = "SELECT ime FROM Lijek";

                
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
            
            Lijek = comboBox1.Text;
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Lijek {Lijek} je kupljen!");
        }
    }
}
