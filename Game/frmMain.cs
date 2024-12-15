using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class frmMain : Form
    {
        private clsPlayer player;
        private List<clsShot> shots;
		private List<clsEnemy> enemies;
		private List<clsShot_en> shots_en;

		private Image imgPlayer;
		private Image imgPlayer_des;
        private Image imgShot;
		private Image imgEnemy;
		private Image imgShot_en;
		public int score = 0;
		public int cnt = 0;
		private int flag = 0;

        public frmMain()
        {
            InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
        {
			imgPlayer = Properties.Resources.Player;
			imgPlayer_des = Properties.Resources.Death;  
			int x = (ClientRectangle.Width - imgPlayer.Width) / 2;
			int y = (ClientRectangle.Height - imgPlayer.Height) - 50;
			Point cXY = Location;
            player = new clsPlayer(x, y, imgPlayer, imgPlayer_des , cXY);

			imgShot = Properties.Resources.Shot_en;
			shots = new List<clsShot>();
			imgShot.RotateFlip(RotateFlipType.Rotate270FlipX);

			imgEnemy = Properties.Resources.Enemy;
			enemies = new List<clsEnemy>();
			enemies.Add(new clsEnemy(Width / 3, 200, imgEnemy));
			enemies.Add(new clsEnemy(Width / 3 * 2, 200, imgEnemy));

            imgShot_en = Properties.Resources.Shot_en;
			shots_en = new List<clsShot_en>();
			imgShot_en.RotateFlip(RotateFlipType.Rotate90FlipX);

            timer1.Interval = 33;
			timer1.Start();
		}
		
		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			Graphics gr = e.Graphics;
			if (player.end_flag == 0)
			{
				player.draw(gr);
			}
			else
			{
				player.draw_gameover(gr);
			}

			Font f = new Font("MSゴシック", 20);
			Point p = new Point(Width - 134, 20);
			Point zanki = new Point(Width - 134, Height - 102);
			Point no = new Point(Width - 92, Height - 102);

			string txt = score.ToString();

            string txt2 = "× " + player.number.ToString();

            gr.DrawString(txt, f, Brushes.Black, p);
            
			gr.DrawString(txt2, f, Brushes.Black, no);
            gr.DrawImage(imgPlayer, zanki);

            foreach (clsShot s in shots)
            {
				s.draw(gr);
            }

			foreach (clsShot_en s in shots_en)
			{
				s.draw(gr);
			}

			foreach (clsEnemy s in enemies)
			{
				s.draw(gr);
			}
		}
		
		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (flag == 0)
			{
				if (e.KeyCode == Keys.Space && player.des == 0)
				{
					Point p = new Point(player.posision.X, player.posision.Y);
					p.X = p.X + (imgPlayer.Width - imgShot.Width) / 2;

					Point v = new Point(0, -30);
					shots.Add(new clsShot(p, v, imgShot));
					SoundPlayer ss = new SoundPlayer(Properties.Resources.sndshot);
					ss.Play();
					flag = 1;
				}
			}
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
			flag = 0;
        }

        private void frmMain_MouseEnter(object sender, EventArgs e)
		{
			Cursor.Hide();
		}

		private void frmMain_MouseLeave(object sender, EventArgs e)
		{
			Cursor.Show();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Point sp = Cursor.Position;
			Point cp = PointToClient(sp);
			int x = cp.X;
			int y = cp.Y;

			int fx = Width;
			int fy = Height - 69;

			if (x < 0) x = 0;
			if (x > fx) x = fx;
			if (y < 0) y = 0;
			if (y > fy) y = fy;

			if(player.des == 1)player.cnt += 1;

			player.move(x, y, ClientRectangle);
			if (cnt == 20)
			{
                En_shot();
				cnt = 0;
            }
			else
			{
				cnt++;
			}
            //Point p = new Point(Width / 2, 200);
            //Point v = new Point(0, -30);
            //enemies.Add(new clsEnemy(Width / 2, 400, imgEnemy));

            for (int k = enemies.Count - 1; k >= 0; k--)
			{
				if (x + imgPlayer.Width - 4 >= enemies[k].posision.X && x <= enemies[k].posision.X + imgEnemy.Width && y + imgPlayer.Height - 4 >= enemies[k].posision.Y && y <= enemies[k].posision.Y + imgEnemy.Height) player.destroy(Width);
			}

			for (int i = shots.Count - 1; i >= 0; i--)
			{
				clsShot shot = shots[i];
				shot.move();
				for (int k = enemies.Count - 1; k >= 0; k--)
				{
					if (shot.posision.X + imgShot.Width >= enemies[k].posision.X && shot.posision.X <= enemies[k].posision.X + imgEnemy.Width && shot.posision.Y + imgShot.Height >= enemies[k].posision.Y && shot.posision.Y <= enemies[k].posision.Y + imgEnemy.Height)
					{
						Add_Point();
						enemies[k].health();
						shots.RemoveAt(i);
                        SoundPlayer sh = new SoundPlayer(Properties.Resources.sndhit);
                        sh.Play();
                        if (enemies[k].hp == 0)
						{
							score += 1000;
                            SoundPlayer sk = new SoundPlayer(Properties.Resources.sndkill);
							sk.Play();
                            enemies.RemoveAt(k);
						}

					}
				}
				if (!shot.intersect(ClientRectangle))
				{
					shots.RemoveAt(i);
				}
			}

			for (int j = shots_en.Count - 1; j >= 0; j--)
			{
				clsShot_en shot_en = shots_en[j];
				shot_en.move();
				if (shot_en.posision.X + imgShot_en.Width >= player.posision.X && shot_en.posision.X <= player.posision.X + imgPlayer.Width - 4 && shot_en.posision.Y + imgShot_en.Height >= player.posision.Y && shot_en.posision.Y <= player.posision.Y + imgPlayer.Height - 4) player.destroy(Width);
				if (!shot_en.intersect(ClientRectangle))
				{
                    shots_en.RemoveAt(j);
				}
			}
			Invalidate();
		}

		private void Add_Point()
		{
			score += 100;
		}

		public void En_shot()
		{
			int k = enemies.Count - 1;
			if (k > 0)
			{
				Point p = new Point(enemies[k].posision.X, enemies[k].posision.Y);
				p.X = p.X + (imgEnemy.Width - imgShot_en.Width) / 2;

				Point v = new Point(0, 30);
				shots_en.Add(new clsShot_en(p, v, imgShot_en));
			}
		}
    }
}
