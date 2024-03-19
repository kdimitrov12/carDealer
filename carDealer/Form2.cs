using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarDealershipApp
{
    public partial class LoginForm : Form
    {
        // Connection string to the SQL Server database

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
        }

        // Method to validate username and password (dummy validation for demonstration)
        private bool IsValidUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=LAB109PC11\SQLEXPRESS; Initial Catalog=carDealer; Integrated Security=True;"))
            {
                // Define the SQL query to check for the user
                string query = "SELECT COUNT(*) FROM Clients WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the command and check if the user exists
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(25, 109);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(100, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(25, 148);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(25, 209);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // LoginForm
            // 
            ClientSize = new Size(284, 261);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button button1;

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate username and password
            if (IsValidUser(username, password))
            {
                MessageBox.Show("Login successful!");
                // Redirect to main application or perform necessary actions
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}