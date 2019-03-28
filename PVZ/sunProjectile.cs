using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PVZ
{
    public class sunProjectile
    {
        private int x;
        private int y;
        private Image pi;
        private int speed;
        private int size;
        public Rectangle HB;
        public string tile;
        public int tick = 0;
        bool isSunflower = false;

        public string tileIn() // this will check and assign a tile value for the sun so that they can be picked up
        {
            for (int _y = 0; _y < 9; _y++)
            {
                if (_y + 1 < 9)
                {
                    if (x >= GameScreen.cols[_y] && x < GameScreen.cols[_y +1])
                    {
                        tile = _y + ", ";
                    }
                }
                else if (x >= GameScreen.cols[_y])
                {
                    tile = _y + ", ";
                }
            }
            for (int _y = 0; _y < 5; _y++)
            {
                if (_y == 0)
                {
                    if (y <= GameScreen.rows[0])
                    {
                        tile += 0 + "";
                    }
                }
                else if (_y < 5)
                {
                    if (y > GameScreen.rows[_y - 1] && y <= GameScreen.rows[_y])
                    {
                        tile += _y + "";
                    }
                }
                
            }
            return tile;
        }

        public sunProjectile(int _x, int _y, Image i, int spd, int _size, bool _sunflower, string tile)
        {
            //initialize class
            x = _x;
            y = _y;
            pi = i;
            HB = new Rectangle(x, y, _size, _size);
            speed = spd;
            size = _size;
            isSunflower = _sunflower;
            tileIn();
        }

        public void move()
        {  
            //called in gamescreen during iterations
            tileIn();
            if (tick < 10 && isSunflower) // this is for sunflower generated sun, they act differently than sun from the sky
            {                             // however, the sun falling from the sky is not implemented, however it would be rather simple to do so
                y -= speed;
                HB.Y -= speed;
                x += speed / 2;
                HB.X += speed / 2;
                if(tick% 2 == 0) speed--; // this gives a psuedo gravitiy affect, slow down going up, then speed up going down
                
            }
            
            else if (tick> 10 && tick <20 && isSunflower)
            {
                y += speed;
                HB.Y += speed;
                x += speed / 2;
                HB.X += speed / 2;
                if (tick % 2 == 0) speed++;
            }
            if(!isSunflower && tick < 60)
            {
                y += speed; // if sun is from sky, fall straight down
                HB.Y += speed;
            }
            
        }
        public void Tick()
        {
            tick++; // if tick excceeds 300, the sun wasn't collected in time and will be deleted
            if (tick >= 300)
            {
                GameScreen.removingSun = true; //tells the gamescreen to remove a sun, and gives it this object to remove
                GameScreen.sunToRemove = this;
            }
        }      
    }
}
