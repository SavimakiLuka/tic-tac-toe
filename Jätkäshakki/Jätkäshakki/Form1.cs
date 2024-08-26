using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jätkäshakki
{
    public partial class Kentta : Form
    {
        public Label ruutu;
        public string[,] ruudut = new string[9, 9];
        public int leveys = 10;
        public int korkeus = 10;
        int koko = 50;
        int vali = 10;
        public int Oikealla = 0;
        public int Vasemmalla = 0;
        Peli peli = new Peli();

        public Kentta()
        {
            InitializeComponent();
            KentanLuonti();
        }

        private void KentanLuonti()
        {
            Ruudukko();   
        }
        private void Ruudukko()
        {
            int ruutujaRivissa = (int)(Math.Sqrt(ruudut.Length));
            for (int i = 0; i < ruudut.Length; i++)
            {
                ruutu = new Label();
                ruutu.Size = new Size(koko, koko);
                ruutu.Location = new Point(leveys, korkeus);
                ruutu.Font = new Font("Arial", 24, FontStyle.Bold);
                ruutu.TextAlign = ContentAlignment.MiddleCenter;
                ruutu.Text = "";
                ruutu.BackColor = Color.LightGray;
                this.Controls.Add(ruutu);

                ruutu.Click += new EventHandler(Ruutu_Click);

                
                if (i%ruutujaRivissa==(ruutujaRivissa-1))
                {
                    korkeus += koko + vali;
                    leveys -= (koko + vali) * (ruutujaRivissa-1);
                }
                else
                {
                    leveys += koko + vali;
                }
            }
        }
        private void Ruutu_Click(object sender, EventArgs e)
        {
            Label ruutu = (Label)sender;
            MouseEventArgs e2 = (MouseEventArgs)e;
            leveys = e2.X;
            korkeus = e2.Y;

            Point hiirenSijainti = this.PointToClient(Cursor.Position);

        
                    if (ruutu.Text == "")
                    {
                        int x = ruutu.Location.X / 60;
                        int y = ruutu.Location.Y / 60;

                        ruutu.Text = peli.Vuorot();
                        ruudut[x, y] = ruutu.Text;

                        if (ruutu.Text == "X")
                        {
                            
                            for (int i = x + 1;  i < x + 2; i++)
                            {
                                if (ruudut[i, y] == "X")
                                {
                                    Oikealla++;
                                }
                            }
                            for (int i = x - 1; i < x + 2; i--)
                            {
                                if (ruudut[i, y] == "X")
                                {
                                    Vasemmalla++;
                                }
                            }

                }
                        if (ruutu.Text == "O")
                        {
                            if (ruudut[x + 1, y] == "O")
                            {
                                if (ruudut[x + 2, y] == "O")
                                {
                                    MessageBox.Show("hyvä");
                                }
                            }
                        }


                peli.Tarkistus(ruudut);
                    }
           
        }

    }
}
