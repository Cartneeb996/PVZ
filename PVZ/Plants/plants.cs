using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PVZ
{
    public class plants
    {
        public int cost;
        public int x;
        public int y;
        public int health;
        public int tick = 0;
        public int timeout = 150;
        public int tileX;
        public int tileY;
        public Image plantImage;
        public Rectangle HB = new Rectangle(0, 0, GameScreen.plantWidth, GameScreen.plantHeight);

        public virtual bool attack()
        {
            return false; // is overriden in each of the subclasses
        }

        public void Tick() //shared among all plant classes
        {
            tick++; // if tick is greater than the invidual timeouts, attack if possible
            if (tick >= timeout)
            {
                bool reset = false;
                reset = attack();
                if(reset) tick = 0; // if attack succeeded
            }
        }

        public void takeDamage(int damage) // if zombie is attacking, take damage
        {
            if (health - damage < 0)
            {
                //die
                GameScreen.flowerToRemove = this;
                GameScreen.removingFlower = true;
                GameScreen.colOcc[tileX][tileY] = false;
            }
            else health -= damage;
        }
    }
}
