using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PVZ.Zombies
{
    class basic_zombie : zombies
    {
        public Image i;
        public basic_zombie(int _x, int _y, int _tile)
        {
            tile = _tile;
            i = new Bitmap(Properties.Resources.basic_zombie, new Size(HB.Width, HB.Height));
            img = i;
            x = _x;
            y = _y;
            walkspeed = 3;
            health = 50;
            HB.X = x;
            HB.Y = y;
            damage = 1; // initailize all variables for use
        }
    }
}
