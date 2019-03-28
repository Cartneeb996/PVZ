using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PVZ.Plants
{
    class repeater : plants
    {
        public repeater(int _x, int _y, int _tileX, int _tileY)
        {
            timeout = 150;
            tileX = _tileX;
            tileY = _tileY;
            health = 100;
            tick = 150;
            cost = 50;
            x = _x; // only differences are these variables and the attack function, attacks twice instead of once
            y = _y;
            HB.X = x;
            HB.Y = y;
            plantImage = new Bitmap(Properties.Resources.repeater, new Size(HB.Width, HB.Height));
        }

        public override bool attack()
        {
            if (GameScreen.zombieList.Count > 0)
            {
                bool shouldattack = false;

                foreach (zombies z in GameScreen.zombieList)
                {

                    if (tileY == z.tile)
                    {
                        shouldattack = true;
                        break;
                    }
                }

                if (shouldattack)
                { //attack 2x
                    GameScreen.projectiles.Add(new projectile(x + GameScreen.plantWidth - 10, y - GameScreen.plantHeight, 15, GameScreen.projectileSize));
                    GameScreen.projectiles.Add(new projectile(x + GameScreen.plantWidth *2, y - GameScreen.plantHeight, 15, GameScreen.projectileSize));
                    //GameScreen.projectiles.Add(new projectile(x + (int)w2, y - (int)w3, 8, (int)w4));
                    return true;
                }
                else return false;

                //find plant to attack

            }
            else return false;
        }
    }
}
