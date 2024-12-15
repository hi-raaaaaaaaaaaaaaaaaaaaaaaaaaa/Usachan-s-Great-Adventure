using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Game
{
    class clsPlayer
    {
        public Point posision;
        private Point restart;
        private Point des_pos;
        private Point p_gameover = new Point(20, 20);
        private Image img;
        private Image img_des;
        private Image img_gameover = Properties.Resources.Gameover;
        public int des = 0;
        private int X;
        private int Y;
        public int number = 3;
        public int cnt = 0;
        private int gr_flag = 1;
        public int end_flag = 0;

        public clsPlayer(int x, int y, Image img ,Image img_des, Point cXY)
        {
            posision = new Point(x, y);
            restart = cXY;
            this.img = img;
            this.img_des = img_des;
            X = x;
            Y = y;
        }

        public void move(int d, int v, Rectangle bound)
        {
            if (number > 0)
            {
                if (des == 0)
                {
                    //自機の移動
                    posision.X = d;
                    posision.Y = v;
                    des_pos = posision;
                }
                else if (posision.Y >= Y)
                {
                    //自機の復活
                    posision.Y -= 4;
                    if (cnt == 4)
                    {
                        gr_flag ^= 1;
                        cnt = 0;
                    }
                }
                else
                {
                    //カーソルを復活した位置の移動
                    Cursor.Position = new Point(restart.X + X, restart.Y + Y);
                    gr_flag = 1;
                    des = 0;
                }
            }
            else
            {
                //ゲームオーバーフラグ
                if (cnt >= 50 && end_flag == 0)
                {
                    end_flag = 1;
                    SoundPlayer sg = new SoundPlayer(Properties.Resources.sndgameover);
                    sg.Play();
                }
            }

            if (posision.X < bound.Left) posision.X = bound.X;
            else
            {
                if (posision.X > bound.Right - img.Width) posision.X = bound.Right - img.Width;
            }
        }

        public void destroy(int w)
        {
            if (des == 0)
            {
                //死亡イベント
                des = 1;
                number -= 1;
                posision.X = X;
                posision.Y = w - 50;
                SoundPlayer sd = new SoundPlayer(Properties.Resources.snddeath);
                sd.Play();
            }
        }

        public void draw(Graphics gr)
        {
            //playerの描写
            if (gr_flag == 1) gr.DrawImage(img, posision);
            if (des == 1) gr.DrawImage(img_des, des_pos);
        }

        public void draw_gameover(Graphics gr)
        {
            //ゲームオーバー画面の描写
            gr.DrawImage(img_gameover, p_gameover);
        }
    }
}
