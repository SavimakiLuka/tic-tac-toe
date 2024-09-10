using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jätkäshakki
{
    internal class PisteidenLasku : Aloitus
    {
        string fileName1= "pisteet1.txt";
        string fileName2= "pisteet2.txt";

        public void LisaaPiste(bool pelaajaVuoro)
        {
            if (pelaajaVuoro)
            {
                File.AppendAllText(fileName2, "Piste\n");
            }
            else
            {
                File.AppendAllText(fileName1, "Piste\n");
            }
        }

        public void NollaaPisteet()
        {
            File.WriteAllText(fileName1, "");
            File.WriteAllText(fileName2, "");
        }
    }
}
