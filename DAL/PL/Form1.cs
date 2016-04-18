using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
namespace PL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            //MessageBox.Show(username);
            string password = textBox2.Text;
           // MessageBox.Show(password);
            string tipUser;
            //string states = "Login admin";
            //string states1 = "Login regular user";
            BL.UserManager logare = new BL.UserManager();
            tipUser= logare.log(username, password);

            MessageBox.Show(tipUser);
            
            if (tipUser == "admin")
            {
                //logare.writeReport(states);
               Admin a1 = new Admin();
                a1.ShowDialog();
              //  MessageBox.Show("Admin");
            }
            else if (tipUser== "user")
            {
                //logare.writeReport(states1);
              User f1 = new User();
                f1.ShowDialog();
                //MessageBox.Show("User");
            }

            else
            {
                MessageBox.Show("Password or username incorrect!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
