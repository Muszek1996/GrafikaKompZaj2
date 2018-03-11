using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punkty;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2);
        Punkt[] points = { new Punkt(), new Punkt() };
        Punkt center;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            center = new Punkt(pictureBox1.ClientSize.Height / 2, pictureBox1.ClientSize.Width / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double r = 150;
            double przyrost;
            if (checkBox1.Checked){
                    przyrost = 2 * Math.PI / 100; // 1.2a;
                }else{
                    przyrost = 360 / 100;  // 1.2b;
                }
            double alfa = 0.0;

            points[0] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
            for (int i = 0; i < 100; i++)
            {
                alfa += przyrost;
                points[1] = points[0];
                points[0] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
                g.DrawLine(pen1, (float)points[0].x, (float)points[0].y, (float)points[1].x, (float)points[1].y);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            double r = 10;
            double przyrost = 2 * Math.PI / 100; // 1.2a;
            double alfa = 0.0;
            int paramA = 4, paramB = 6;

            for (int j = 0; j < 4; j++)
            {
                points[0] = new Punkt((float)(paramB * r * Math.Cos(alfa)), (float)(paramA * r * Math.Sin(alfa))) + center;
                for (int i = 0; i < 100; i++)
                {
                    alfa += przyrost;
                    points[1] = points[0];
                    points[0] = new Punkt((float)(paramB * r * Math.Cos(alfa)), (float)(paramA * r * Math.Sin(alfa))) + center;
                    if (j < 4)
                        g.DrawLine(pen1, (float)points[0].x, (float)points[0].y, (float)points[1].x, (float)points[1].y);
                }
                r += 5;
            }
            r = 10;
            alfa = 0.0;
            for (int j = 0; j < 4; j++)
            {
                points[0] = new Punkt((float)(paramA * r * Math.Cos(alfa)), (float)(paramB * r * Math.Sin(alfa))) + center;
                for (int i = 0; i < 100; i++)
                {
                    alfa += przyrost;
                    points[1] = points[0];
                    points[0] = new Punkt((float)(paramA * r * Math.Cos(alfa)), (float)(paramB * r * Math.Sin(alfa))) + center;
                    if (j < 4)
                        g.DrawLine(pen1, (float)points[0].x, (float)points[0].y, (float)points[1].x, (float)points[1].y);
                }
                r += 5;
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            double r = 1;
            double limitR = 300;
            double współczynnikPrzyrostu = 1.2;
            double przyrost = 2 * Math.PI / 100; // 1.2a;
            //double przyrost = 360/100;  // 1.2b;
            double alfa = 0.0;

            points[0] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
            for (int i = 0; i > -1; i++)
            {
                if (r > limitR) break;
                alfa += przyrost;
                r += współczynnikPrzyrostu * przyrost;
                points[1] = points[0];
                points[0] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
                g.DrawLine(pen1, (float)points[0].x, (float)points[0].y, (float)points[1].x, (float)points[1].y);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double r = 0;
            double limitR = 300;
            double współczynnikPrzyrostu = 8;
            double przyrost = 2 * Math.PI / 100; // 1.2a;
            //double przyrost = 360/100;  // 1.2b;
            double alfa = 0.0;

          
            for (int j = 1; j <= 4; j++)
            {

                r = 0;
                alfa = 2 * Math.PI / 4*j;
                points[0] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
                for (int i = 0; i > -1; i++)
                {
                    if (r > limitR) break;
                    alfa += przyrost;
                    r += współczynnikPrzyrostu * przyrost;
                    points[1] = points[0];
                    points[0] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
                   
                    g.DrawLine(pen1, (float)points[0].x, (float)points[0].y, (float)points[1].x, (float)points[1].y);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double iloscPtk = (Double.Parse(numericUpDown2.Text));
            Punkt [] tablica = new Punkt[(int)iloscPtk];
            double przyrost = 2 * Math.PI / iloscPtk;
            double alfa = 0.0;
            double r = 250;
            for (int i = 0; i < iloscPtk; i++)
            {
                alfa += przyrost;
                tablica[i] = new Punkt((float)( r * Math.Cos(alfa)), (float)( r * Math.Sin(alfa))) + center;
            }
            for (int j = 0; j < iloscPtk; j++)
            {
                for (int i = 0; i < iloscPtk; i++)
                {
                    g.DrawLine(pen1, (float)tablica[j].x, (float)tablica[j].y, (float)tablica[i].x, (float)tablica[i].y);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double R = (Double.Parse(textBox2.Text))/2;
            double N = (Double.Parse(numericUpDown1.Text));

            List<int> fibonacci = new List<int>();
            int fib = 1;
            while (fib < N * 4)
            {
                fibonacci.Add(fib);
                fib += fib;
            }


            List<Punkt> lewo = new List<Punkt>();
            List<Punkt> gora = new List<Punkt>();
            List<Punkt> prawo = new List<Punkt>();
            List<Punkt> dol = new List<Punkt>();


       
            

 
            for (int i = 0; i < N-1; i++)
            {
                lewo.Add(new Punkt(-R,R-((R*2/(N-1))*i))+center);
            }
            for (int i = 0; i < N-1; i++)
            {
                lewo.Add(new Punkt(-R + ((R * 2 / (N - 1)) * i) ,- R) + center);
            }
            for (int i = 0; i < N - 1; i++)
            {
                lewo.Add(new Punkt(R, -R + ((R * 2 / (N - 1)) * i)) + center);
            }
            for (int i = 0; i < N - 1; i++)
            {
                lewo.Add(new Punkt(R - ((R * 2 / (N - 1)) * i), +R) + center);
            }
            lewo.Add(lewo.First());


            List<Punkt> wierzchołki = new List<Punkt>();
            lewo.ForEach(p => wierzchołki.Add(p));

            for (int i = 0; i < wierzchołki.Count-1; i++)
                {
                    g.DrawLine(pen1, (float)wierzchołki.ElementAt(i).x, (float)wierzchołki.ElementAt(i).y, (float)wierzchołki.ElementAt(i+1).x, (float)wierzchołki.ElementAt(i+1).y);
                }

            for (int j = 0; j < wierzchołki.Count - 1; j++)
            for (int i = 0; i < wierzchołki.Count - 1; i++)
            {
                    if (fibonacci.Contains((j + 1 - i + 1) % (int)N))
             g.DrawLine(pen1, (float)wierzchołki.ElementAt(i).x, (float)wierzchołki.ElementAt(i).y, (float)wierzchołki.ElementAt(j).x, (float)wierzchołki.ElementAt(j).y);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double iloscPtk = 4;
            double licznik = (Double.Parse(numericUpDown4.Text));
            double mianownik = (Double.Parse(numericUpDown4.Text))+1;
            int iloscKwadratow = (int)(Double.Parse(numericUpDown3.Text));
            Punkt[] tablica = new Punkt[(int)iloscPtk];
            double przyrost = 2 * Math.PI / iloscPtk;
            double alfa = 0.0+ 2 * Math.PI /8;
            double r = 450;
            for (int i = 0; i < iloscPtk; i++)
            {
                alfa += przyrost;
                tablica[i] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
            }
            



           for(int j = 0; j < iloscKwadratow; j++)
            {
                for (int i = 0; i < iloscPtk; i++)
                {
                    g.DrawLine(pen1, (float)tablica[i].x, (float)tablica[i].y, (float)tablica[(i + 1) % (int)iloscPtk].x, (float)tablica[(i + 1) % (int)iloscPtk].y);
                }
                for (int k = 0; k < 4; k++)
                    tablica[k] = new Punkt((((licznik * tablica[k].x) + (tablica[(k + 1) % (int)iloscPtk].x))) / mianownik, (((licznik * tablica[k].y) + (tablica[(k + 1) % (int)iloscPtk].y))) / mianownik);
            }





        }

        private void button9_Click(object sender, EventArgs e)
        {
            double iloscPtk = 4;
            double licznik = (Double.Parse(numericUpDown4.Text));
            double mianownik = (Double.Parse(numericUpDown4.Text)) + 1;
            int iloscKwadratow = (int)(Double.Parse(numericUpDown3.Text));
            Punkt[] tablica = new Punkt[(int)iloscPtk];
            double przyrost = 2 * Math.PI / iloscPtk;
            double alfa = 0.0 + 2 * Math.PI / 8;
            double r = 50;

            Punkt backup = center;
            center.x -= 150;
            center.y -= 150;

            for (int f = 0; f< 5; f++)
            {
                for (int z = 0; z < 5; z++)
                {



                    for (int i = 0; i < iloscPtk; i++)
                    {
                        alfa += przyrost;
                        tablica[i] = new Punkt((float)(r * Math.Cos(alfa)), (float)(r * Math.Sin(alfa))) + center;
                    }




                    for (int j = 0; j < iloscKwadratow; j++)
                    {
                        for (int i = 0; i < iloscPtk; i++)
                        {
                            g.DrawLine(pen1, (float)tablica[i].x, (float)tablica[i].y, (float)tablica[(i + 1) % (int)iloscPtk].x, (float)tablica[(i + 1) % (int)iloscPtk].y);
                        }
                        for (int k = 0; k < 4; k++)
                            tablica[k] = new Punkt((((licznik * tablica[k].x) + (tablica[(k + 1) % (int)iloscPtk].x))) / mianownik, (((licznik * tablica[k].y) + (tablica[(k + 1) % (int)iloscPtk].y))) / mianownik);
                    }
                    center.x += 73;
                }
                center.x -= 73 * 5;
                center.y += 73;


            }
                



        }
    }
    
}
