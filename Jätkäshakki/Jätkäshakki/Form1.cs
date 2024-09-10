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
        public string[,] ruudut;
        public int leveys = 10;
        public int korkeus = 10;
        public int rivit;
        public int sarakkeet;
        int koko = 50;
        int vali = 10;
        Peli peli = new Peli();

        public Kentta(int x, int y)
        {
            rivit = x;
            sarakkeet = y;
            InitializeComponent();
            KentanLuonti();
        }

        private void KentanLuonti()
        {
            KentanKoonMaarittaminen();
            Ruudukko();   
        }
        public void KentanKoonMaarittaminen()
        {
            ruudut = new string[rivit, sarakkeet];
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
             int vaakaRivi = 1;
             int pystyRivi = 1;
             int ristiRivi = 1;
             int x = ruutu.Location.X / (koko + vali);
             int y = ruutu.Location.Y / (koko + vali);
                ruutu.Text = peli.Vuorot();
             ruudut[x, y] = ruutu.Text;

             if (ruutu.Text == "X")
             {
                  //Vaakarivi     
                  for (int i = x + 1; i < Math.Min(9, x + (9 - 4)) && ruudut[i, y] == "X"; i++)
                  {
                      if (ruudut[i, y] == "X")
                      {
                           vaakaRivi++;
                      }
                  }
                  for (int i = x - 1; i >= Math.Max(0, x - (9 - 4)) && ruudut[i, y] == "X"; i--)
                  {
                        if (ruudut[i, y] == "X")
                        {
                            vaakaRivi++;
                        }
                  }
                    //Pystyrivi
                    for (int i = y + 1; i < Math.Min(9, y + (9 - 4)) && ruudut[x, i] == "X"; i++)
                    {
                        if (ruudut[x, i] == "X")
                        {
                            pystyRivi++;
                        }
                    }
                    for (int i = y - 1; i >= Math.Max(0, y - (9 - 4)) && ruudut[x, i] == "X"; i--)
                    {
                        if (ruudut[x, i] == "X")
                        {
                            pystyRivi++;
                        }
                    }
                    //Ristirivi
                    for (int i = y + 1, j = x + 1; i < Math.Min(9, y + (9 - 4)) && j < Math.Min(9, x + (9 - 4)) && ruudut[j, i] == "X"; i++, j++)
                    {
                        if (ruudut[j, i] == "X")
                        {
                            ristiRivi++;
                        }
                    }

                    for (int i = y - 1, j = x - 1; i >= Math.Max(0, y - (9 - 4)) && j >= Math.Max(0, x - (9 - 4)) && ruudut[j, i] == "X"; i--, j--)
                    {
                        if (ruudut[j, i] == "X")
                        {
                            ristiRivi++;
                        }
                    }

                    for (int i = y + 1, j = x - 1; i < Math.Min(9, y + (9 - 4)) && j >= Math.Max(0, x - (9 - 4)) && ruudut[j, i] == "X"; i++, j--)
                    {
                        if (ruudut[j, i] == "X")
                        {
                            ristiRivi++;
                        }
                    }

                    for (int i = y - 1, j = x + 1; i >= Math.Max(0, y - (9 - 4)) && j < Math.Min(9, x + (9 - 4)) && ruudut[j, i] == "X"; i--, j++)
                    {
                        if (ruudut[j, i] == "X")
                        {
                            ristiRivi++;
                        }
                    }
                }
             if (ruutu.Text == "O")
             {
                    //Vaakarivi 
                    for (int i = x + 1; i < Math.Min(9, x + (9 - 4)) && ruudut[i, y] == "O"; i++)
                    {
                        if (ruudut[i, y] == "O")
                        {
                            vaakaRivi++;
                        }
                    }
                    for (int i = x - 1; i >= Math.Max(0, x - (9 - 4)) && ruudut[i, y] == "O"; i--)
                    {
                        if (ruudut[i, y] == "O")
                        {
                            vaakaRivi++;
                        }
                    }
                    //Pystyrivi
                    for (int i = y + 1; i < Math.Min(9, y + (9 - 4)) && ruudut[x, i] == "O"; i++)
                    {
                        if (ruudut[x, i] == "O")
                        {
                            pystyRivi++;
                        }
                    }
                    for (int i = y - 1; i >= Math.Max(0, y - (9 - 4)) && ruudut[x, i] == "O"; i--)
                    {
                        if (ruudut[x, i] == "O")
                        {
                            pystyRivi++;
                        }
                    }
                    //Ristirivi
                    for (int i = y + 1, j = x + 1; i < Math.Min(9, y + (9 - 4)) && j < Math.Min(9, x + (9 - 4)) && ruudut[j, i] == "O"; i++, j++)
                    {
                        if (ruudut[j, i] == "O")
                        {
                            ristiRivi++;
                        }
                    }

                    for (int i = y - 1, j = x - 1; i >= Math.Max(0, y - (9 - 4)) && j >= Math.Max(0, x - (9 - 4)) && ruudut[j, i] == "O"; i--, j--)
                    {
                        if (ruudut[j, i] == "O")
                        {
                            ristiRivi++;
                        }
                    }

                    for (int i = y + 1, j = x - 1; i < Math.Min(9, y + (9 - 4)) && j >= Math.Max(0, x - (9 - 4)) && ruudut[j, i] == "O"; i++, j--)
                    {
                        if (ruudut[j, i] == "O")
                        {
                            ristiRivi++;
                        }
                    }

                    for (int i = y - 1, j = x + 1; i >= Math.Max(0, y - (9 - 4)) && j < Math.Min(9, x + (9 - 4)) && ruudut[j, i] == "O"; i--, j++)
                    {
                        if (ruudut[j, i] == "O")
                        {
                            ristiRivi++;
                        }
                    }
                }
             peli.Tarkistus(vaakaRivi, pystyRivi, ristiRivi);
             }
        }
    }
}
