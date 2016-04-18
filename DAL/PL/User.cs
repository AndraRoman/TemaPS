using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // string statese = "Vizualizare lista spectacole";
            //Model.Report report = new Model.Report();
            // report.state = statese;
            dataGridView1.AutoGenerateColumns = true;
            BL.BileteCRUD apelare = new BL.BileteCRUD();
            //apelare.writeReport(statese);
            dataGridView1.DataSource = apelare.Bilete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                int spectacolID = Convert.ToInt16(textBox1.Text);
                int rand = Convert.ToInt16(textBox2.Text);
                int nrRand = Convert.ToInt16(textBox3.Text);

                dataGridView1.AutoGenerateColumns = true;
                Models.Bilet bilete = new Models.Bilet(spectacolID, rand, nrRand);
                BL.BileteCRUD bil = new BL.BileteCRUD();
                bil.addBilete(bilete);
                bil.updateBilet(spectacolID, bilete);
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Nu ati introdus date corect");
            }
        }
    }
}
