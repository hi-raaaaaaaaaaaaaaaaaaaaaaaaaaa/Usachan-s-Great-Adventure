using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace Game
{
    class clsEnemy
    {
        public Point posision;
        private Image img;
        public int hp = 6;

        public clsEnemy(int x, int y, Image img)
        {
            posision = new Point(x, y);
            this.img = img;
        }

        public void move(int d, int v)
        {
            posision.X += d;
            posision.Y += v;
        }

        public void draw(Graphics gr)
        {
            gr.DrawImage(img, posision);
        }

        public void health()
        {
            hp -= 1;
        }
    }
}
