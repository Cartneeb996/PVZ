using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace PVZ
{
    public class zombies
    {
        public int walkspeed;
        public int health;
        public int x;
        public int y;
        public Image img;
        public Rectangle HB = new Rectangle(0, 0, GameScreen.zombieWidth, GameScreen.zombieHeight);
        public int damage;
        public plants pclosest;
        public int tile;
        Random r = new Random();
        public SoundPlayer zombieTalk = new SoundPlayer(Properties.Resources.zombie);

        public void attack() // made useless by move function
        {

        }

        public void move()
        {
            if (r.Next(0, 100) < 1) zombieTalk.Play();
            if (GameScreen.plantList.Count > 0) // doesn't bother checking if plants are colliding if none exist
            {
                int xclosest = 0;
                pclosest = GameScreen.plantList[0];
                bool attacking = false;

                foreach (plants p in GameScreen.plantList)
                { //if colloding and the zombie is in the same row..
                    if (HB.X <= p.HB.X + p.HB.Width && HB.X + HB.Width >= p.HB.X && HB.Y + HB.Height >= p.HB.Y && HB.Y <= p.HB.Y + p.HB.Height && p.tileY == tile)
                    {
                        xclosest = p.x;
                        pclosest = p;
                        attacking = true;
                        if (pclosest.health <= damage) attacking = false; // if plant is dead ( or will be), don't attack again
                        pclosest.takeDamage(damage); // attack plant               
                    }
                }

                if(!attacking) // keep moving if nothing to attack
                {
                    HB.X-= walkspeed;
                    x-= walkspeed;
                }
                else
                {
                    //stop moving
                }
            }
            else  //move if no plants
            {
                HB.X-=walkspeed;
                x-=walkspeed;
            }
        }

        public void takeDamage(int damage) // if hit by proj
        {
            if (health - damage <= 0)
            {
                //die
                GameScreen.zombieToRemove = this;
                GameScreen.removingZombie = true;
            }
            else health -= damage;
        }
    }
}
