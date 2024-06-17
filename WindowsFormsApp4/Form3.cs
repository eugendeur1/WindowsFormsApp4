using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ShowStudentMenus();
        }
        private void ShowStudentMenus()
        {
            List<StudentMenu> studentMenu;
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                studentMenu=context.StudentMenus.ToList();
            }
            Form3Grid.DataSource=studentMenu;
        }

        private void Form3Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5(); // Pass null to indicate a new student
            form.ShowDialog();
            ShowStudentMenus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form3Grid.SelectedRows.Count > 0)
            {
                int selectedRow = Form3Grid.SelectedRows[0].Index;
                int studentMenuId = Convert.ToInt32(Form3Grid.Rows[selectedRow].Cells["id"].Value);

                try
                {
                    using (var context = new RWA2324_edeur22_DBEntities())
                    {
                        // Find the student menu item by its ID
                        var studentMenu = context.StudentMenus.Find(studentMenuId);

                        if (studentMenu != null)
                        {
                            // Remove the student menu item from the database
                            context.StudentMenus.Remove(studentMenu);
                            context.SaveChanges();

                            MessageBox.Show("Student menu deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data grid after deletion
                            ShowStudentMenus();
                        }
                        else
                        {
                            MessageBox.Show("Student menu not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting student menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a student menu to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
