using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class dqvStudent : Form
    {
        public dqvStudent()
        {
            InitializeComponent();
        }

        private void dqvStudent_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                List<Student> students = context.Students.ToList();
                dgvStudent.DataSource = students;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4(); // Pass null to indicate a new student
            form.ShowDialog();
            LoadStudents(); // Refresh the student list
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            // Not implemented
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Not needed anymore since we will fetch the selected student directly in btnDelete_Click
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                int selectedRow = dgvStudent.SelectedRows[0].Index;
                int studentId = Convert.ToInt32(dgvStudent.Rows[selectedRow].Cells["Id"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteStudentFromDatabase(studentId);
                    LoadStudents(); // Refresh the student list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStudentFromDatabase(int studentId)
        {
            string connectionString = "Data Source=31.147.206.65;InitialCatalog=RWA2324_edeur22_DB;PersistSecurityInfo=True;User ID=RWA2324_edeur22_User;Password=tI}?7>&&;Encrypt=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Student WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", studentId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows affected. Student not found or deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            Hide();
            form3.ShowDialog();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Not implemented
        }
    }
}
