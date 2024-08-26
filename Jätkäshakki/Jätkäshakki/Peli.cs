using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jätkäshakki
{
    internal class Peli
    {
        public string merkki = "";
        bool pelaajavuoro = true;
        int ruudutTarkistus = 0;
        int Yhteensa = 0;
        public void Tarkistus(string[,] ruudut)
        {
            
        }
        public string Vuorot()
        {
            Kentta kentta = new Kentta();
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
