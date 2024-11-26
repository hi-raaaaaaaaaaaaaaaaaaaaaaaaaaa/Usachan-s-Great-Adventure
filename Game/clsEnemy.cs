﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game
{
    class clsEnemy
    {
        public Point posision;
        private Image img;

        public clsEnemy(int x, int y, Image img)
        {
            posision = new Point(x, y);
            this.img = img;
        }

        public void move(int d, int v, Rectangle bound)
        {
            posision.X += d;
            posision.Y += v;

            if (posision.X < bound.Left) posision.X = bound.X;
            else
            {
                if (posision.X > bound.Right - img.Width) posision.X = bound.Right - img.Width;
            }
        }

        public void draw(Graphics gr)
        {
            gr.DrawImage(img, posision);
        }
    }
}
