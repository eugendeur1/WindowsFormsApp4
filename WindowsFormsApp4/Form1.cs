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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //user za studente
        string Studentuser = "marcfoi";
        string Studentpasword = "marcfoi";
        //
        //user za profesora
        string TeacherUser = "profesor";
        string TeacherPasword = "profesor";
        //
        //user za infsluzbu
        string SluzbaUser = "sluzba";
        string SluzbaPasword = "sluzba";
        //
        private void Login_Click(object sender, EventArgs e)
        {
            
            if (txtUser.Text == SluzbaUser && txtPassword.Text == SluzbaPasword)
            {

                dqvStudent frmStudents = new dqvStudent();
                Hide();
                frmStudents.ShowDialog();

                Close();
            }
            if (txtUser.Text == Studentuser && txtPassword.Text == Studentpasword)
            {

                Form6 frmStudents = new Form6();
                Hide();
                frmStudents.ShowDialog();

                Close();
            }
            if (txtUser.Text == TeacherUser && txtPassword.Text == TeacherPasword)
            {

                Form6 frmStudents = new Form6();
                Hide();
                frmStudents.ShowDialog();

                Close();
            }
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text != Studentpasword || txtUser.Text != Studentuser )
            {
                MessageBox.Show("Lozinka nije unesena! ili je krivo unesena");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
