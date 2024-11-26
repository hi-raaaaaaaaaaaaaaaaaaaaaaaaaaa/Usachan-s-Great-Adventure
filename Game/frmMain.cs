using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class frmMain : Form
    {
        private clsPlayer player;
        private List<clsShot> shots;
		private clsEnemy enemy;
		private List<clsShot_en> shots_en;

		private Image imgPlayer;
        private Image imgShot;
		private Image imgEnemy;
		private Image imgShot_en;

		public frmMain()
        {
            InitializeComponent();
		}

        private void frmMain_Load(object sender, EventArgs e)
        {
			imgPlayer = Properties.Resources.Player;
			int x = (ClientRectangle.Width - imgPlayer.Width) / 2;
			int y = (ClientRectangle.Height - imgPlayer.Height) - 50;
			player = new clsPlayer(x, y, imgPlayer);

			imgShot = Properties.Resources.Shot;
			shots = new List<clsShot>();

			imgEnemy = Properties.Resources.Enemy;
			x = (ClientRectangle.Width - imgEnemy.Width) / 2;
			y = (ClientRectangle.Height - imgEnemy.Height) / 4;
			enemy = new clsEnemy(x, y, imgEnemy);

			imgShot_en = Properties.Resources.Shot_en;
			shots_en = new List<clsShot_en>();
			imgShot_en.RotateFlip(RotateFlipType.Rotate90FlipX);

			timer1.Interval = 20;
			timer1.Start();
		}

		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
			System.Drawing.Point cp = this.PointToClient(sp);
			int x = cp.X;
			int y = cp.Y;

			int fx = this.Width;
			int fy = this.Height - 68;

			if (x < 0) x = 0;
			if (x > fx) x = fx;
			if (y < 0) y = 0;
			if (y > fy) y = fy;




			if (imgEnemy.Width == x)
			{
				player.destroy();
			}
			else
			{
				player.move(x, y, ClientRectangle);
			}

			Graphics gr = e.Graphics;
			player.draw(gr);
			enemy.draw(gr);

			foreach(clsShot s in shots)
            {
				s.draw(gr);
            }

			foreach (clsShot_en s in shots_en)
			{
				s.draw(gr);
			}
		}

		private void frmMain_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				Point p = new Point(player.posision.X, player.posision.Y);
				p.X = p.X + (imgPlayer.Width - imgShot.Width) / 2;

				Point v = new Point(0, -30);
				shots.Add(new clsShot(p, v, imgShot));
			}
			else if(e.KeyCode == Keys.Up)
            {
				Point pe = new Point(enemy.posision.X, enemy.posision.Y);
				pe.X = pe.X + (imgEnemy.Width - imgShot_en.Width) / 2;

				Point v = new Point(0, 30);
				shots_en.Add(new clsShot_en(pe, v, imgShot_en));
			}
        }

        private void frmMain_MouseEnter(object sender, EventArgs e)
		{
			System.Windows.Forms.Cursor.Hide();
		}

		private void frmMain_MouseLeave(object sender, EventArgs e)
		{
			System.Windows.Forms.Cursor.Show();
		}

		private void timer1_Tick(object sender, EventArgs e)
        {
			for (int i = shots.Count - 1; i >= 0; i--)
			{
				clsShot shot = shots[i];
				shot.move();
				if (!shot.intersect(ClientRectangle))
				{
					shots.RemoveAt(i);
				}
			}

			for (int j = shots_en.Count - 1; j >= 0; j--)
			{
				clsShot_en shot_en = shots_en[j];
				shot_en.move();
				if (!shot_en.intersect(ClientRectangle))
				{
					shots_en.RemoveAt(j);
				}
			}
			Invalidate();
        }


    }
}
