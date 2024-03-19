using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carDealer
{
    public partial class booking : Form
    {
        public booking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC11\SQLEXPRESS; Initial Catalog=carDealer; Integrated Security=True;"))
            {
                sqlCon.Open(); // Open SQL connection


                string insertQuery = "INSERT INTO testdrive VALUES (@LastName, @FirstName, @CarModel)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, sqlCon);

                insertCmd.Parameters.AddWithValue("@LastName", LastName.Text);
                insertCmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                insertCmd.Parameters.AddWithValue("@CarModel", CarModel.Text);


                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Booking Successful!");

            }
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            LastName = new TextBox();
            FirstName = new TextBox();
            CarModel = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(159, 253);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LastName
            // 
            LastName.Location = new Point(43, 100);
            LastName.Name = "LastName";
            LastName.PlaceholderText = "Last Name";
            LastName.Size = new Size(100, 23);
            LastName.TabIndex = 1;
            // 
            // FirstName
            // 
            FirstName.Location = new Point(159, 100);
            FirstName.Name = "FirstName";
            FirstName.PlaceholderText = "First Name";
            FirstName.Size = new Size(100, 23);
            FirstName.TabIndex = 2;
            // 
            // CarModel
            // 
            CarModel.Location = new Point(276, 100);
            CarModel.Name = "CarModel";
            CarModel.PlaceholderText = "Car Model";
            CarModel.Size = new Size(100, 23);
            CarModel.TabIndex = 3;
            // 
            // booking
            // 
            ClientSize = new Size(416, 372);
            Controls.Add(CarModel);
            Controls.Add(FirstName);
            Controls.Add(LastName);
            Controls.Add(button1);
            Name = "booking";
            ResumeLayout(false);
            PerformLayout();
        }

        private void check_in_Load(object sender, EventArgs e)
        {

        }

        private TextBox LastName;
        private TextBox FirstName;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox CarModel;
    }
}