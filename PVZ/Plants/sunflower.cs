using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PVZ
{
    class sunflower : plants
    {
        private const int tickTot = 300;

        public sunflower(int _x, int _y, int _tileX, int _tileY)
        {
            timeout = 300;
            tileX = _tileX;
            tileY = _tileY;
            timeout = tickTot;
            health = 100;
            cost = 50;
            x = _x;
            y = _y;
            HB.X = x;
            HB.Y = y;
            plantImage = new Bitmap(Properties.Resources.sunflower, new Size(HB.Width, HB.Height));
        }
        public override bool attack() // spawns sun instead of pea proj
        {
            string tile = tileX + ", " + tileY;
            GameScreen.sunProj.Add(new sunProjectile(x + HB.Width/2, y - HB.Size.Height, null, 5, GameScreen.projectileSize, true, tile));
            return true;
        }
    }
}
