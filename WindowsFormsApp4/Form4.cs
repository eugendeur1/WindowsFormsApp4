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

namespace WindowsFormsApp4
{
    public partial class Form4 : Form
    {
        private Student studentToChange;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(Student student)
        {
            InitializeComponent();
            studentToChange = student;
            PopulateFields();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (studentToChange == null)
            {
                studentToChange = new Student();
            }

            // Update the student object with values from the input fields
            studentToChange.Id = int.Parse(textBox1.Text);
            studentToChange.FullName = textBox2.Text;
            studentToChange.LastName = textBox3.Text;
            studentToChange.Grade = int.Parse(textBox5.Text);
            studentToChange.Status = textBox4.Text;

            SaveStudentToDatabase(studentToChange);
            // Save the student object to a database or file (this example just shows a message)
            // SaveStudentToDatabase(studentToChange);

            MessageBox.Show("Student details saved successfully.");
            Close();
        }
    
        private void PopulateFields()
        {
            if (studentToChange != null)
            {
                textBox1.Text = studentToChange.Id.ToString();
                textBox2.Text = studentToChange.FullName;
                textBox3.Text = studentToChange.LastName;
                textBox5.Text = studentToChange.Grade.ToString();
                textBox4.Text = studentToChange.Status;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SaveStudentToDatabase(Student student)
        {
            string connectionString = "Data Source=31.147.206.65;Initial Catalog=RWA2324_edeur22_DB;Persist Security Info=True;User ID=RWA2324_edeur22_User;Password=tI}?7>&&;Encrypt=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query;

                    //0 je jer se sam sebe dize u sql je postavljeno tako, i kad upise se broj 0 on automatski prepisuje iduci ID broj.

                    if (student.Id == 0)
                    {
                        // Insert new student
                        query = "INSERT INTO Student (FullName, LastName, Status, Grade) VALUES (@FullName, @LastName, @Status, @Grade)";
                    }
                    else
                    {
                        // Update existing student
                        query = "UPDATE Student SET FullName = @FullName, LastName = @LastName, Status = @Status, Grade = @Grade WHERE Id = @Id";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", student.Id);
                        command.Parameters.AddWithValue("@FullName", student.FullName);
                        command.Parameters.AddWithValue("@LastName", student.LastName);
                        command.Parameters.AddWithValue("@Status", student.Status);
                        command.Parameters.AddWithValue("@Grade", student.Grade); // Use Grade property

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows affected. Data was not saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
