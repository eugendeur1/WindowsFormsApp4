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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new RWA2324_edeur22_DBEntities())
                {
                    var newStudentMenu = new StudentMenu
                    {
                        id = int.Parse(textBox1.Text), 
                        DishName = textBox2.Text,
                        FullPrice = decimal.Parse(textBox3.Text), 
                        DiscoundPrice = decimal.Parse(textBox4.Text) 
                    };

                    context.StudentMenus.Add(newStudentMenu);
                    context.SaveChanges();

                    MessageBox.Show("Student menu added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student menu: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
