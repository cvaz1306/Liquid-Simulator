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

        public void Physics()
        {
            float gravityFactor = 0.5f; // Adjust this value as needed
            velocity += gravity * gravityFactor;

            float dampingFactor = 0.98f; // Adjust this value as needed
            velocity *= dampingFactor;

            if ((int)(-pos.Y + 75) > height)
            {
                

                // Damping during bounce
                float bounceDamping = 0.7f; // Adjust this value as needed
                velocity.Y *=-bounceDamping;

                // Damping of overall velocity
                velocity *= dampingFactor;

                // Move the position to just above the ground (you can adjust this value)
                

                // Optional: Apply a horizontal damping to simulate friction
                float horizontalDamping = 0.95f; // Adjust this value as needed
                velocity.X *= horizontalDamping;
            }
            Console.WriteLine("H: " + pos.X);
            if ((int)(pos.X ) < -350|| (int)(pos.X) > 350)
            {

                

                // Damping during bounce
                float bounceDamping = 0.9f; // Adjust this value as needed
                velocity.X *= -bounceDamping;

                // Damping of overall velocity
                //velocity *= dampingFactor;

                // Move the position to just above the ground (you can adjust this value)


                // Optional: Apply a horizontal damping to simulate friction
                //float horizontalDamping = 0.95f; // Adjust this value as needed
                //velocity.X *= horizontalDamping;
            }

            pos += velocity;

            Console.WriteLine(pos.X + 50 + ";" + width);
        }

        public void Draw(Graphics g, Brush brush)
        {
            g.FillEllipse(brush, (width / 2) + pos.X, -pos.Y + 50, 25, 25);
        }
    }
}
