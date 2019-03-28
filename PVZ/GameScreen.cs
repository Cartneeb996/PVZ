using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PVZ
{
    public partial class GameScreen : UserControl
    {
        
        #region bitmaps and HB 
        Point pLoc;
        Point zLoc;
        Bitmap bSP;
        Bitmap bS;
        Bitmap bP;
        Bitmap bR;
        //Bitmap bBZ = new Bitmap(Properties.Resources.basic_zombie, new Size(50, 100));
        Image displayImage;
        Bitmap zB;
        Bitmap zBU;
        public static int plantHeight = 100;
        public static int plantWidth = 100;
        public static int zombieHeight = 150;
        public static int zombieWidth = 100;
        public static int projectileSize = 40;
        #endregion

        #region misc
        public SoundPlayer zombieTalk = new SoundPlayer(Properties.Resources.zombie);
        Random r = new Random();
        public static int sunVal = 100;
        public static int c = 0;
        public static bool b = false;
        string flower = "";
        int loc = 0;
        bool key = false;
        bool waveStarted = false;
        int ZSpawnTime = 600;
        bool buyingFlower = false;
        int flowerTab = 0;
        const int flowerCount = 3;
        private int gameTick = 0;
        #endregion

        #region gameover stuff
        int gameoverTicks = 0;
        bool gameover = false;
        int gameoverTextSize = 2;
        Point gameoverTextPoint;
        bool textUp = true;
        bool textLeft = true;
        #endregion

        #region rowVars
        public static int[] cols = { 60, 190, 315, 455, 585, 715, 850, 951, 1105 };
        public static int[] rows = { 190, 310, 440, 560, 670 };
        //this one is for checking if a tile is occupied
    public static bool[][] colOcc = { new bool[] { false, false, false, false, false }, new bool[] { false, false, false, false, false },
           new bool[] { false, false, false, false, false }, new bool[] { false, false, false, false, false }, new bool[] { false, false, false, false, false },
           new bool[] { false, false, false, false, false }, new bool[] { false, false, false, false, false }, new bool[] { false, false, false, false, false },
           new bool[] { false, false, false, false, false }};
        int startR = 0;
        int startC = 0;
        string tile = "0, 0";
        string tStr;
        public const int lane1Y = 10;
        #endregion

        #region objectLists
        public static List<projectile> projectiles = new List<projectile>();
        public static List<zombies> zombieList = new List<zombies>();
        public static List<plants> plantList = new List<plants>();
        public static List<sunProjectile> sunProj = new List<sunProjectile>();
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            float f = 2.3f;
            int s = (int)f;
            this.Width = Form1.f.Width;
            this.Height = Form1.f.Height; 
        }

        #region safeRemove
        public static bool removingSun = false;
        public static bool removingProj = false;
        public static bool removingFlower = false;
        public static bool removingZombie = false;
        public static projectile projToRemove;
        public static sunProjectile sunToRemove;
        public static plants flowerToRemove;
        public static zombies zombieToRemove;
        #endregion

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
                // debug e.Graphics.DrawString("P: " + flowerTab + " Z: " + zLoc, Font, new SolidBrush(Color.Black), 50, 300);
            e.Graphics.DrawString("sun: " + sunVal, new Font(Font.FontFamily, 20, Font.Style, Font.Unit), new SolidBrush(Color.Black), 10, 13);
            //draw sun value^
            // iterate, tick and move all zombies
            foreach (zombies z in zombieList)
            {
                Point r = new Point(z.HB.X, z.HB.Y); 

                if (z.x + z.HB.Width < cols[0]) gameover = true;

                e.Graphics.DrawImage(z.img, r);

                if (gameTick % 2 == 0) // move every 2 ticks
                {
                    z.move();
                    // debug zLoc = new Point(z.tile, z.tile);
                }
                //debug e.Graphics.DrawRectangle(new Pen(Color.Black), z.HB);
            }

            if (removingFlower) removeFlower(flowerToRemove);
            if (removingSun) removeSunProj(sunToRemove);
            if (removingProj) removeProj(projToRemove); // check if removing something is nessicary
            if (removingZombie) removeZombie(zombieToRemove);

            //iterate, tick, and attack with all plants
            foreach (plants p in plantList)
            {
                Point r = new Point(p.HB.X, p.HB.Y);
                r.Y -= p.HB.Height;
                e.Graphics.DrawImage(p.plantImage, r);

                p.Tick();
                if (p.tick > p.timeout) p.attack(); // if ready to attack, attack

                //debug pLoc = new Point(p.tileY, p.tileY);
            }

            if (removingFlower) removeFlower(flowerToRemove);
            if (removingSun) removeSunProj(sunToRemove);
            if (removingProj) removeProj(projToRemove);
            if (removingZombie) removeZombie(zombieToRemove);

            foreach (sunProjectile s in sunProj) // iterate, tick and move all sun projectiles
            {
                Point r = new Point(s.HB.X, s.HB.Y);
                r.Y -= s.HB.Height;
                e.Graphics.DrawImage(bSP, r);

                s.Tick();
                s.move();

                //debug  tStr = s.tile;
                //debug zLoc = new Point(s.HB.X, s.HB.Y);
            }

            if (removingFlower) removeFlower(flowerToRemove);
            if (removingSun) removeSunProj(sunToRemove);
            if (removingProj) removeProj(projToRemove);
            if (removingZombie) removeZombie(zombieToRemove);

            foreach (projectile pr in projectiles) // iterates, and moves all pea projectiles
            {               
                Point r = new Point(pr.HB.X, pr.HB.Y);
                e.Graphics.DrawImage(pr.pi, r);
                //debug pLoc = new Point(pr.HB.X, pr.HB.Y);
                e.Graphics.DrawRectangle(new Pen(Color.Black), pr.HB);

                pr.move();
                pr.collide(10);
            }

            if (buyingFlower) // if player is buying a flower, display it
            {
                switch(flowerTab)
                {
                    case 0:
                        displayImage = bS;
                        break;
                    case 1:
                        displayImage = bP;
                        break;
                    case 2:
                        displayImage = bR;
                        break;
                }

                e.Graphics.DrawImage(displayImage, cols[startC], rows[startR] - plantHeight);
            }
            else
            {
                //"cursor"
                e.Graphics.DrawRectangle(new Pen(Color.Black), cols[startC], rows[startR] - plantHeight, plantWidth, plantHeight);
            }

            if (removingFlower) removeFlower(flowerToRemove);
            if (removingSun) removeSunProj(sunToRemove);
            if (removingProj) removeProj(projToRemove);
            if (removingZombie) removeZombie(zombieToRemove);

            if(gameover) // if the game is over, either display lose or win text
            {              
                gameoverTextPoint = new Point((this.Width - gameoverTextSize * 9) / 2, (this.Height - gameoverTextSize) / 2);

                if (gameoverTextSize < 75) gameoverTextSize+=3;
                else gameoverTicks++;

                if(gameoverTicks > 100)
                {
                    gameTimer.Stop();
                    Form1 f = (Form1)FindForm();
                    f.switchScreen("GOS", this);
                    GameOverScreen.loadPrompt(); //loads gameover screen and prompt to restart          
                }
                // these give the lose text a jitter affect
                if (textLeft)
                {
                    gameoverTextPoint.X--;
                    textLeft = false;
                }
                else
                {
                    gameoverTextPoint.X++;
                    textLeft = true;
                }

                if (textUp)
                {
                    gameoverTextPoint.Y--;
                    textUp = false;
                }
                else
                {
                    gameoverTextPoint.Y++;
                    textUp = true;
                }

                if(waveBar.Value == waveBar.Maximum && !waveStarted)// if the progress bar is full, and all zombies are defeated,
                {
                    gameoverTextPoint = new Point((this.Width - gameoverTextSize * 7) / 2, (this.Height - gameoverTextSize) / 2);
                    e.Graphics.DrawString("Victory!", new Font(Font.FontFamily, gameoverTextSize, Font.Style), new SolidBrush(Color.Black), gameoverTextPoint);
                }
                else //else they must have lost
                {
                    e.Graphics.DrawString("GAME OVER", new Font(Font.FontFamily, gameoverTextSize, Font.Style), new SolidBrush(Color.Black), gameoverTextPoint);
                }
                
            }
            
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            if (gameTick % 30 == 0 && waveBar.Value < waveBar.Maximum && waveStarted) waveBar.Value++; // move the progress bar

            if (waveBar.Value >= waveBar.Maximum && zombieList.Count == 0) // sets win conditions
            {
                gameover = true;
                waveStarted = false;
            }

            if(waveBar.Value / waveBar.Maximum == 0.2F) // decreases spawn time 1/5 thru the game
            {
                ZSpawnTime = 300;
            }

            if (waveBar.Value / waveBar.Maximum == 0.5F) // decreases again if 1/2 thru the game
            {
                ZSpawnTime = 150;
            }

            /*if (sunVal >= 50) sunflowerPurchButton.Enabled = true;
            else sunflowerPurchButton.Enabled = false;
            if (sunVal >= 100) peashooterPurchButton.Enabled = true;
            else peashooterPurchButton.Enabled = false;
            if (sunVal >= 200) repeaterPurchButton.Enabled = true;
            else repeaterPurchButton.Enabled = false;
            */

            gameTick++;

            if(gameTick == 600)
            {
                waveStarted = true;
                zombieTalk.Play();
                zombieList.Add(new Zombies.basic_zombie(this.Width, rows[0] - 150, 0));
            }
            if(gameTick > 600 && gameTick % ZSpawnTime == 0 && waveStarted)
            {
                //these are unimplemented, if were to be patched in, the rarer, stronger buckethead and pylon zombies would be spawned in the lower chance ifs
                if (r.Next(0, 100) < -1)
                {
                    //like here would be buckethead
                }
                else if (r.Next(0, 100) < -1)
                {
                    // and here pylon
                }
                else if (r.Next(0, 100) > 0)
                {
                    int r1 = r.Next(0, 5);
                    zombieList.Add(new Zombies.basic_zombie(this.Width, rows[r1] - 150, r1)); //but instead, just normal zombies spawn
                }
            }

            this.Refresh();
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            // debug tile = startC + ", " + startR; 
            // debugkey = true;
           
            switch(e.KeyCode)
            {
                case Keys.Y:
                    int r1 = r.Next(0, 5);
                    zombieTalk.Play();
                    zombieList.Add(new Zombies.basic_zombie(this.Width, rows[r1] - zombieHeight, r1)); // debug zombie spawn key
                    break;
                case Keys.V:
                    if (buyingFlower) buyingFlower = false;
                    else buyingFlower = true; //toggle buying flower
                    //cancel
                    break;
                case Keys.X:
                    if (buyingFlower)
                    {
                        if (flowerTab + 1 < flowerCount) flowerTab++; //tab thru plants, fwd
                        else flowerTab = 0;
                    }
                    break;
                case Keys.C:
                    if (buyingFlower)
                    {
                        if (flowerTab - 1 > -1) flowerTab--; //tab thru plants, bkwd
                        else flowerTab = flowerCount - 1;
                    }
                    break;
                case Keys.Escape:
                    Prompt p = new Prompt(); // pause menu
                    p.ShowDialog("Quit to Main Menu?", "", PromptClick);
                    break;
                case Keys.N:
                    if (startR > 0) startR--; // move cursor btns
                    break;
                case Keys.Space:
                    if (startR < 4) startR++;
                    break;
                case Keys.B:
                    if (startC > 0) startC--;
                    break;
                case Keys.M:
                    if (startC < 8) startC++;
                    break;
                case Keys.Z: // place plant if funds available
                    if (buyingFlower)
                    {
                        switch (flowerTab)
                        {
                            case 0:
                                if (!colOcc[startC][startR] && sunVal >= 50)
                                {
                                    plantList.Add(new sunflower(cols[startC], rows[startR], startC, startR));
                                    sunVal -= 50;
                                    colOcc[startC][startR] = true;
                                }
                                break;
                            case 1:
                                if (!colOcc[startC][startR] && sunVal >= 100)
                                {
                                    plantList.Add(new Plants.peashooter(cols[startC], rows[startR], startC, startR));
                                    sunVal -= 100;
                                    colOcc[startC][startR] = true;
                                }
                                break;
                            case 2:
                                if (!colOcc[startC][startR] && sunVal >= 200)
                                {
                                    plantList.Add(new Plants.repeater(cols[startC], rows[startR], startC, startR));
                                    sunVal -= 200;
                                    colOcc[startC][startR] = true;
                                }
                                break;
                        }

                        buyingFlower = false;
                    }
                    else
                    {
                        foreach (sunProjectile s in sunProj)
                        {
                            tStr = s.tile;
                            if (tile == s.tile)
                            {
                                removingSun = true;
                                sunToRemove = s; // collect sun
                                sunVal += 25;
                            }
                        }                     
                    }
                    //this case will be for the sunflower for simplicty
                    break;
            }
        }
        //these functions remove objects from the lists safely (w/o crashing)
        public static void removeProj(projectile p)
        {
            GameScreen.projectiles.Remove(p);
            removingProj = false;
        }

        public static void removeSunProj(sunProjectile s)
        {
            GameScreen.sunProj.Remove(s);
            removingSun = false;
        }

        public static void removeFlower(plants p)
        {
            GameScreen.plantList.Remove(p);
            removingFlower = false;
        }

        public static void removeZombie(zombies z)
        {
            GameScreen.zombieList.Remove(z);
            removingZombie = false;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //initializing the values of the screen
            this.Width = 1280;
            this.Height = 720;
            bR = new Bitmap(Properties.Resources.repeater, new Size(plantWidth, plantHeight));
            bP = new Bitmap(Properties.Resources.pea_shooter, new Size(plantWidth, plantHeight));
            bS = new Bitmap(Properties.Resources.sunflower, new Size(plantWidth, plantHeight));
            bSP = new Bitmap(Properties.Resources.SunProj, new Size(projectileSize, projectileSize));
        }

        private bool PromptClick (object sender, EventArgs e) // a method for the pause prompt, passsed as a param
        {
            Button b = (Button)sender;
            Form1 f = Form1.f;

            switch (b.DialogResult)
            {
                case DialogResult.Yes:

                    f.switchScreen("MS", this);

                    break;
                case DialogResult.No:
                    
                    break;
            }
            Prompt.prompt.Close();
            return true;
        }
    }
}
