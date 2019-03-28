using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVZ
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
            this.Refresh();
            //this.Width = 1280;
            //this.Height = 720;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.switchScreen("GS", this);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void startGameButton_KeyDown(object sender, KeyEventArgs e)
        {
            Form1 f = (Form1)Form.ActiveForm;
            f.switchScreen("GS", this);
        }

        private void quitButton_KeyDown(object sender, KeyEventArgs e)
        {
            Form1.ActiveForm.Close();
        }
    }
}
