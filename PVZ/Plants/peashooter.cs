using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace PVZ.Plants
{
    class peashooter : plants
    {
        SoundPlayer attackS = new SoundPlayer(Properties.Resources.PSFire);
        
        public peashooter(int _x, int _y, int _tileX, int _tileY)
        {
            tileX = _tileX;
            tileY = _tileY;
            health = 100;
            cost = 50;
            x = _x;
            y = _y;
            HB.X = x;
            HB.Y = y;
            timeout = 100;
            tick = 150;
            plantImage = new Bitmap(Properties.Resources.pea_shooter, new Size(HB.Width, HB.Height));
        }
        public override bool attack()
        {
            if (GameScreen.zombieList.Count > 0) // crash preventitive
            {              
                bool shouldattack = false; // should the pshooter attack..?

                foreach (zombies z in GameScreen.zombieList)
                {

                    if (tileY == z.tile) // if a zombie is in your row, attack
                    {
                        shouldattack = true;
                        
                        break;
                    }
                }

                if (shouldattack) // if attacking, create proj
                {
                    attackS.Play();
                    GameScreen.projectiles.Add(new projectile(x + GameScreen.plantWidth - 10, y - GameScreen.plantHeight, 15, GameScreen.projectileSize));
                    return true; //attack succeeded
                }
                else return false; // attack failed
            }
            else return false; // attack failed
        }
    }
}
