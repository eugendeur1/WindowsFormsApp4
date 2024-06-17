using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            StudentDish();
            StudentDishMonday();
            StudentDishUtorak();
            StudentDishSrijeda();
            StudentDishCetvrtak();
            StudentDishPetak();

        }
        private void StudentDish()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                var studentMenu = context.StudentMenus
                                        .Where(sm => sm.id == 10 || sm.DishName == "BiftekMenu")
                                        .Select(sm => sm.DishName)
                                        .FirstOrDefault();

                // Display the result in a label or any other appropriate UI element
                label1.Text = studentMenu;
            }
            
         }
        private void StudentDishMonday()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                var studentMenu = context.StudentMenus
                                        .Where(sm => sm.id == 1)
                                        .Select(sm => sm.DishName)
                                        .FirstOrDefault();

                // Display the result in a label or any other appropriate UI element
                label6.Text = studentMenu;
            }
        }
        private void StudentDishUtorak()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                var studentMenu = context.StudentMenus
                                        .Where(sm => sm.id == 2 )
                                        .Select(sm => sm.DishName)
                                        .FirstOrDefault();

                // Display the result in a label or any other appropriate UI element
                label7.Text = studentMenu;
            }

        }
        private void StudentDishSrijeda()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                var studentMenu = context.StudentMenus
                                        .Where(sm => sm.id == 6)
                                        .Select(sm => sm.DishName)
                                        .FirstOrDefault();

                // Display the result in a label or any other appropriate UI element
                label8.Text = studentMenu;
            }
        }
        private void StudentDishCetvrtak()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                var studentMenu = context.StudentMenus
                                        .Where(sm => sm.id == 3)
                                        .Select(sm => sm.DishName)
                                        .FirstOrDefault();

                // Display the result in a label or any other appropriate UI element
                label9.Text = studentMenu;
            }
        }
        private void StudentDishPetak()
        {
            using (var context = new RWA2324_edeur22_DBEntities())
            {
                var studentMenu = context.StudentMenus
                                        .Where(sm => sm.id == 5)
                                        .Select(sm => sm.DishName)
                                        .FirstOrDefault();

                // Display the result in a label or any other appropriate UI element
                label10.Text = studentMenu;
            }
        }

    }
}
