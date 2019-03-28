using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVZ
{
    public partial class Form1 : Form
    {
        public static Form1 f;
        public static GameOverScreen gos;
        public static GameScreen gs;
        public static MainScreen ms;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            f = (Form1)FindForm();
            ms = new MainScreen(); // assigns global, static values so that anything can access them and prevent multiples
            gos = new GameOverScreen();
            gs = new GameScreen();
        }
        public void switchScreen(string next, UserControl current) // used to switch between user controls (screens)
        {
            UserControl c = new UserControl();

            switch(next)
            {
                case "MS":
                    //ms = new MainScreen();
                    c = ms;
                    break;
                case "GOS":
                    gos = new GameOverScreen(); // based on keyword, switch to a certain screen
                    c = gos;
                    break;
                case "GS":
                    gs = new GameScreen();
                    c = gs;
                    break;
            }

            Controls.Add(c);
            c.Location = new Point((this.Width - c.Width) / 2, (this.Height - c.Height) / 2);
            //c.Width = this.Width;
            //c.Height = this.Height; // remove prev cont, and add new
            Controls.Remove(current);
        }
        public void switchScreen(string next, string name) // same as the the other, but in case the function needs to be called in a static tense
        {
            UserControl c = new UserControl();
            
            switch (next)
            {
                case "MS":
                    //ms = new MainScreen();
                    c = ms;
                    break;
                case "GOS":
                    gos = new GameOverScreen();
                    c = gos;
                    break;
                case "GS":
                    gs = new GameScreen();
                    c = gs;
                    break;
            }
            UserControl cr = new UserControl();
            switch (name)
            {
                case "MS":
                    
                    cr = ms;
                    break;
                case "GOS":
                    
                    cr = gos;
                    break;
                case "GS":
                  
                    cr = gs;
                    break;
            }
            
            Controls.Add(c);
            Controls.Remove(cr);
            c.Location = new Point((this.Width - c.Width) / 2, (this.Height - c.Height) / 2);
            //c.Width = this.Width;
            //c.Height = this.Height;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(ms);
            ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
        }
    }
}
