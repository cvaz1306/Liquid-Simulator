using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
namespace RRR3Liquid
{

    public partial class Form1 : Form
    {
        float pressure = .2f;
        int frameCT=0;
        Bitmap bitmap1;
        Bitmap bitmap2;
        Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Red));
        List<particle> particles=new List<particle>();
        public Form1()
        {
            
            InitializeComponent();
            this.timer1.Interval = 10;
            this.timer1.Start();
            this.timer2.Interval = 10;
            this.timer2.Start();
            particle.height = this.Height-100;
            particle.width = this.Width-100;
            bitmap1 =new Bitmap(particle.width, particle.height);
            bitmap2=new Bitmap(particle.width, particle.height);
            SquareRootWithRemainderResult sr = SquareRootCalculator.CalculateSquareRootWithRemainder(100);
            
            for (int i=0; i<sr.SquareRoot; i++)
            {
                for (int j = 0; j < sr.SquareRoot; j++)
                {

                    particles.Add(new particle(new Vector2(-0, -1.3f), new Vector2((float)(this.Width / 8) + (30 * i) - 300, (float)(this.Width / 8)+(30*j)-300/*(30 * (((i % 100)%10) - 5))+60*/), new Vector2(13, 10)));

                }

            }

        }
        void Draw(Graphics g)
        {
            foreach(particle p in particles)
            {
                p.Physics();
                p.Draw(g, brush);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            frameCT++;
            //physics();
            if (frameCT % 2 == 0)
            {
                using (Graphics g = Graphics.FromImage(bitmap1))
                {
                    Draw(g);
                }
                using (Graphics g = Graphics.FromImage(bitmap2))
                {
                    g.Clear(Color.Black);
                }
            }
            else
            {
                using (Graphics g = Graphics.FromImage(bitmap2))
                {
                    Draw(g);
                }
                using (Graphics g = Graphics.FromImage(bitmap1))
                {
                    g.Clear(Color.Black);
                }
            }
            using (Graphics g=CreateGraphics())
            {
                if (frameCT % 2 == 0)
                {
                    g.DrawImage(bitmap1, 0, 0);
                }
                else
                {
                    g.DrawImage(bitmap2, 0, 0);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach(particle particle in particles)
            {
                foreach(particle p in particles)
                {
                    if((particle.pos-p.pos).Length() < 30f)
                    {
                        Vector2 l = (particle.pos - p.pos);
                        p.velocity -= (l / 100 * l.Length())*pressure;
                    }
                }
            }
            GC.Collect();
        }
    }
}
