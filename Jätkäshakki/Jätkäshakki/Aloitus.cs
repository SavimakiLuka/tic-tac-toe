using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jätkäshakki
{
    public partial class Aloitus : Form
    {
        int onNumeroX;
        int onNumeroY;
        string fileName1= "pisteet1.txt";
        string fileName2= "pisteet2.txt";
        PisteidenLasku pisteidenLasku;
        public Aloitus()
        {
            InitializeComponent();
        }

        private void btnKentanLuonti_Click(object sender, EventArgs e)
        {
            if (tbX.Text != "" && tbY.Text != "")
            {
                if (int.TryParse(tbX.Text, out onNumeroX) && int.TryParse(tbY.Text, out onNumeroY))
                {
                    if (tbX.Text == tbY.Text)
                    {
                        Kentta kentta = new Kentta(onNumeroX, onNumeroY);
                        kentta.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("X ja Y pitää olla samat");
                    }
                }
                else
                {
                    MessageBox.Show("Vain numeroita.");
                }
            }
            else
            {
                MessageBox.Show("Ruudut ei voi olla tyhjiä.");
            }
        }

        public void AloitusLaitto(bool pelaajaVuoro)
        {
            pisteidenLasku = new PisteidenLasku();
            pisteidenLasku.LisaaPiste(pelaajaVuoro);
            if (pelaajaVuoro)
            {
                int pisteet2 = File.ReadAllLines(fileName2).Length;
                string Pisteet2 = Convert.ToString(pisteet2);
                lblPisteet2.Text = Pisteet2;
            }
            else
            {
                int pisteet1 = File.ReadAllLines(fileName1).Length;
                string Pisteet1 = Convert.ToString(pisteet1);
                lblPisteet1.Text = Pisteet1;
            }
            this.Show();
        }

        private void btnTyhjennä_Click(object sender, EventArgs e)
        {
            pisteidenLasku = new PisteidenLasku();
            pisteidenLasku.NollaaPisteet();
            lblPisteet1.Text = "0";
            lblPisteet2.Text = "0";
        }
    }
}
