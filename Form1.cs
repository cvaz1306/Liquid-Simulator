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
        int frameCT=0;
        Bitmap bitmap1;
        Bitmap bitmap2;
        Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Red));
        Vector2 velocity;
        Vector2 gravity;
        Vector2 pos;
        public Form1()
        {
            InitializeComponent();
            this.timer1.Interval = 10;
            this.timer1.Start();
            bitmap1=new Bitmap(this.Width, this.Height);
            bitmap2=new Bitmap(this.Width, this.Height);
            gravity = new Vector2(0, -.98f);
            pos = Vector2.Zero;
            velocity= Vector2.Zero + new Vector2(-0f, 10);
        }
        void physics()
        {
            velocity += gravity;
            velocity.Y /= 1.1f;
            float dampingFactor = 0.98f; // You can adjust this value as needed
            velocity *= dampingFactor;
            if ((int)(-pos.Y + 75) > 489)
            {
                Console.WriteLine("H");
                velocity.Y = (-(velocity.Y) *2.5f)-3; // Invert the Y component of velocity
                //pos.Y = -this.Height + 50; // Reset the ball's position to the correct height
            }
            pos += velocity;
            frameCT++;


            Console.WriteLine(-pos.Y + 50 + ";" + this.Height);
        }
        void Draw(Graphics g)
        {
            g.FillEllipse(brush, (this.Width / 2) + pos.X, -pos.Y + 50, 25, 25);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            physics();
            if (frameCT % 2 == 0)
            {
                using (Graphics g = Graphics.FromImage(bitmap1))
                {
                    Draw(g);
                }
                using (Graphics g = Graphics.FromImage(bitmap2))
                {
                    g.Clear(Color.White);
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
                    g.Clear(Color.White);
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
