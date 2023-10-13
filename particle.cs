using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RRR3Liquid
{
    class particle
    {
        public Vector2 velocity;
        Vector2 gravity;
        public Vector2 pos;
        public static int height;
        public static int width;
        public particle(Vector2 gravityX, Vector2 startpos, Vector2 initialVelocity)
        {
            gravity = gravityX;
            pos = startpos;
            velocity = initialVelocity;
            velocity += gravity;
        }

        public void physics()
        {
            
            velocity.Y /= 1.1f;// * ((velocity.Length()*-(velocity.Y/Math.Abs(velocity.Y))) / 6f);
            velocity += gravity;
            float dampingFactor = 0.98f; // You can adjust this value as needed
            velocity *= dampingFactor;
            if ((int)(-pos.Y + 75) > 489)
            {
                Console.WriteLine("H");
                velocity.Y = (-(velocity.Y) * 2.5f) + 12; // Invert the Y component of velocity
                //pos.Y = -this.Height + 50; // Reset the ball's position to the correct height
                velocity /= 1.3f;
            }
            pos += velocity;


            Console.WriteLine(-pos.Y + 50 + ";" + height);
        }
        public void Draw(Graphics g, Brush brush)
        {
            g.FillEllipse(brush, (width / 2) + pos.X, -pos.Y + 50, 25, 25);
        }
    }
}
