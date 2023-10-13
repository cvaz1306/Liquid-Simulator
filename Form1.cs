﻿using System;
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
        int frameCT=0;
        Bitmap bitmap1;
        Bitmap bitmap2;
        Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Red));
        particle p;
        particle p1;
        public Form1()
        {
            InitializeComponent();
            this.timer1.Interval = 10;
            this.timer1.Start();
            bitmap1=new Bitmap(this.Width, this.Height);
            bitmap2=new Bitmap(this.Width, this.Height);
            p = new particle(new Vector2(0, -.981f), new Vector2((float)Width / 2, 0), Vector2.Zero);
            p1 = new particle(new Vector2(0, -.981f), new Vector2((float)Width / 2+25, -25), new Vector2(1,0));

        }
        void Draw(Graphics g)
        {
            p.physics();
            p.Draw(g, brush);
            p1.physics();
            p1.Draw(g, brush);
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
    }
}
