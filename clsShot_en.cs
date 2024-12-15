using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class clsShot_en
    {
        public Point posision;
        private Point velocity;
        private Image img;

        public clsShot_en(Point p, Point v, Image img)
        {
            posision = new Point(p.X, p.Y);
            velocity = new Point(v.X, v.Y);
            this.img = img;
        }

        public void move()
        {
            posision.X += velocity.X;
            posision.Y += velocity.Y;
        }

        public void draw(Graphics gr)
        {
            gr.DrawImage(img, posision);
        }

        public bool intersect(Rectangle boader)
        {
            Rectangle rt = new Rectangle(posision.X, posision.Y, img.Width, img.Height);
            return rt.IntersectsWith(boader);
        }
    }
}
