using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jätkäshakki
{
    internal class Peli : Aloitus
    {
        public string merkki = "";
        public bool pelaajavuoro = true;
        bool pelaajaPisteet = false;

        public void Tarkistus(int vaakaRivi, int pystyRivi, int ristiRivi)
        {
            if (vaakaRivi >= 5 || pystyRivi >= 5 || ristiRivi >= 5)
            {
                if (pelaajavuoro)
                {
                    MessageBox.Show("Pelaaja 2 voitti.");
                    AloitusLaitto(pelaajavuoro);
                }
                else
                {
                    MessageBox.Show("Pelaaja 1 voitti.");
                    AloitusLaitto(pelaajavuoro);
                }
            }
        }
        public string Vuorot()
        {
            if (pelaajavuoro)
            {
                merkki = "X";
                pelaajavuoro = false;
                return merkki;
            }
            else
            {
                merkki = "O";
                pelaajavuoro = true;
                return merkki;
            }
        }
    }
}
