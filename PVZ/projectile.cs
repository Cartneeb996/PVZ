using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PVZ
{
    public class projectile
    {
        private int x;
        private int y;
        public Image pi;
        private int speed;
        private int size;
        public Rectangle HB;
        bool isVoid = false; // prevents mutliple registers of damage

        public projectile(int _x, int _y, int spd, int _size)
        { 
            pi = new Bitmap(Properties.Resources.pea_projectile, new Size(_size, _size));
            x = _x;
            y = _y;
            HB = new Rectangle(x, y, _size, _size);
            speed = spd;
            size = _size;
        }
        public void move()
        {
            x += speed;
            HB.X += speed; // move fwd

            try
            {
                if (x > Form1.ActiveForm.Width)
                {
                    GameScreen.projToRemove = this; // if moves off screen, kill this proj
                    GameScreen.removingProj = true;
                }
            }
            catch
            {

            }
        }

        public void collide(int potentialDmg)
        {
            foreach (zombies z in GameScreen.zombieList) // since this will only be generated if there are zombies, no need to check
            {
                if (HB.IntersectsWith(z.HB)) // if it hits a zombie, it will damage it and because of dimensions, it is impossible to hit others
            {
                    if (!isVoid)
                    {
                        z.takeDamage(potentialDmg);
                        GameScreen.projToRemove = this;
                        GameScreen.removingProj = true; // kill proj
                        GameScreen.b = true;
                        
                    }
                    isVoid = true;
                }// find closest zombie
            }
            
        }
    }
}
