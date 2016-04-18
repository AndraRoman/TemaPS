using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace PL
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string statese = "Vizualizare lista spectacole";
            //Model.Report report = new Model.Report();
           // report.state = statese;
           dataGridView1.AutoGenerateColumns = true;
            BL.SpectacoleCRUD apelare = new BL.SpectacoleCRUD();
            //apelare.writeReport(statese);
            dataGridView1.DataSource = apelare.Spectacole();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                int idSpectacol = Convert.ToInt16(textBox1.Text);
                string titlul = textBox2.Text;
                string regia = textBox3.Text;
                string distributia = textBox4.Text;
                DateTime dataPremierei = Convert.ToDateTime(textBox5.Text);
                int nrBilete = Convert.ToInt16(textBox6.Text);
                //string statese = "Adaugare in lista angajati";

                dataGridView1.AutoGenerateColumns = true;
                Models.Spectacol spectacole = new Models.Spectacol(idSpectacol, titlul, regia, distributia, dataPremierei, nrBilete);
                BL.SpectacoleCRUD spect = new BL.SpectacoleCRUD();
                spect.addSpectacol(spectacole);
                //spect.updateSpectacol(idSpectacol, spectacole);
                dataGridView1.Refresh();

            }
            else
            {
                MessageBox.Show("Nu ati introdus corect datele");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int rowID = int.Parse(dataGridView1[0, selectedIndex].Value.ToString());
                BL.SpectacoleCRUD delete = new BL.SpectacoleCRUD();
                delete.deleteSpectacol(rowID);
                dataGridView1.Refresh();

                // delete.writeReport(statese);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        //create cont user de catre admin
        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                //int idUser = Convert.ToInt16(textBox7.Text);
                string username = textBox8.Text;
                string parola = textBox9.Text;
                string tipUser = "user";
                //string statese = "Adaugare in lista angajati";

                dataGridView1.AutoGenerateColumns = true;
                MD5 md5Hash = MD5.Create();
                string pass = BL.UserManager.GetMd5Hash(md5Hash, parola);
                //string pass = BL.GetMd5Hash(md5Hash, parola);
                Models.User users = new Models.User(/*idUser,*/username, pass, tipUser);
                BL.UserManager us = new BL.UserManager();
                us.addUser(users);

                dataGridView1.Refresh();
            }
            else { MessageBox.Show("Nu ati introdus corect datele"); }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;
            BL.UserManager apelare = new BL.UserManager();
            //apelare.writeReport(statese);
            dataGridView1.DataSource = apelare.Users();
        }
    }
}
