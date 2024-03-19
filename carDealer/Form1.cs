using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.ComponentModel.DataAnnotations;

namespace carDealer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            make.SelectedText = "Car Model";
            carclass.SelectedText = "Class";
            color.SelectedText = "Color";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC11\SQLEXPRESS; Initial Catalog=carDealer; Integrated Security=True;"))
            {
                bool a = false;
                bool b = false;
                bool c = false;


                sqlCon.Open(); // Open SQL connection

                // Start with a base SQL query
                string query = "SELECT * FROM cars WHERE 1 = 1";
                // Create a list to store the conditions for filtering
                List<string> conditions = new List<string>();

                // Check each ComboBox and add a condition if an item is selected
                if (make.SelectedItem != null)
                {
                    a = true;
                    conditions.Add("make = @make");
                }

                if (carclass.SelectedItem != null)
                {
                    b = true;

                    conditions.Add("carclass = @class");
                }

                if (color.SelectedItem != null)
                {
                    c = true;

                    conditions.Add("color = @color");
                }

                // Combine the conditions into the SQL query
                if (conditions.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", conditions);
                }

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                // Set parameters based on selected values, handling the case where ComboBox is empty
                if (a)
                {
                    cmd.Parameters.AddWithValue("@make", make.SelectedItem.ToString());
                }

                if (b)
                {
                    cmd.Parameters.AddWithValue("@class", carclass.SelectedItem.ToString());
                }

                if (c)
                {
                    cmd.Parameters.AddWithValue("@color", color.SelectedItem.ToString());
                }

                // Use SqlDataAdapter to fetch data and populate DataGridView
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            make.SelectedIndex = -1;
            carclass.SelectedIndex = -1;
            color.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(booking userInputForm = new booking())
            {
                userInputForm.ShowDialog();
            }
        }
    }
}