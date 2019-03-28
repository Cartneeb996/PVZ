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
    public partial class GameOverScreen : UserControl
    {
        
        public GameOverScreen()
        {
            InitializeComponent();
        }
        public static void loadPrompt()
        {
            Prompt p = new Prompt();
            p.ShowDialog("Game over\nPlay again?", ""); // creates a prompt in a seperate function to avoid loading issues
        }
    }
    public class Prompt
    {
        public static Form prompt;

        public string ShowDialog(string text, string caption)
        {
            prompt = new Form() // creates a pop up window, so that may restart or give up
            {
                Width = 700,
                Height = 550,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen               
            };

            Font f = new Font(Form1.DefaultFont.FontFamily, 30, FontStyle.Regular); // creates a larger font than standard
            int l = 350 - text.Length * 10; // centers based on text size
            Label textLabel = new Label() {Height = 200, Width = 400, Left = l, Top = 100, Text = text, Font = f};
            textLabel.TextAlign = ContentAlignment.MiddleLeft;
            Button yes = new Button() { BackColor = Color.Green, Text = "Yes", Font = f, Left = 50, Width = 200, Height = 100, Top = 350, DialogResult = DialogResult.Yes };
            Button no = new Button() { BackColor = Color.Red, Text = "No", Font = f, Left = 450, Width = 200, Height = 100, Top = 350, DialogResult = DialogResult.No };
            yes.Click += (sender, e) => { OnClick(sender, e); }; // creates yes/no buttons and assigns events to them when you click them
            no.Click += (sender, e) => { OnClick(sender, e); };
            yes.KeyDown += (sender, e) => { OnClick(sender, e); }; // creates yes/no buttons and assigns events to them when you click them
            no.KeyDown += (sender, e) => { OnClick(sender, e); };
            prompt.Controls.Add(yes);
            prompt.Controls.Add(no); // add controls
            prompt.Controls.Add(textLabel);

            return prompt.ShowDialog() == DialogResult.OK ? "" : "";
        }
        public string ShowDialog(string text, string caption, Func<object, EventArgs, bool> eventMethod) // same function, but allows you to pass your own event func
        {
            prompt = new Form()
            {
                Width = 700,
                Height = 550,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen

            };
            Font f = new Font(Form1.DefaultFont.FontFamily, 30, FontStyle.Regular);
            int l = 350 - text.Length * 10;
            Label textLabel = new Label() { Height = 200, Width = 400, Left = l, Top = 100, Text = text, Font = f };
            textLabel.TextAlign = ContentAlignment.MiddleLeft;
            //TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button yes = new Button() { BackColor = Color.Green, Text = "Yes", Font = f, Left = 50, Width = 200, Height = 100, Top = 350, DialogResult = DialogResult.Yes };
            Button no = new Button() { BackColor = Color.Red, Text = "No", Font = f, Left = 450, Width = 200, Height = 100, Top = 350, DialogResult = DialogResult.No };
            yes.Click += (sender, e) => { eventMethod(sender, e); };
            no.Click += (sender, e) => { eventMethod(sender, e); };
            yes.KeyDown += (sender, e) => { eventMethod(sender, e); };
            no.KeyDown += (sender, e) => { eventMethod(sender, e); };
            //prompt.Controls.Add(textBox);
            prompt.Controls.Add(yes);
            prompt.Controls.Add(no);
            prompt.Controls.Add(textLabel);
            //prompt.AcceptButton = confirmation;
            return prompt.ShowDialog() == DialogResult.OK ? "" : "";
        }
        public void OnClick(object sender, EventArgs e) // click event method
        {
            Button b = (Button)sender;
            Form1 f = Form1.f;

            switch (b.DialogResult) // if no, switch to MS, else return to GS
            {
                case DialogResult.No:
                    
                    f.switchScreen("MS", "GOS");

                    break;
                case DialogResult.Yes:
                    f.switchScreen("GS", "GOS");
                    break;
            }
            prompt.Close();
        }
    }
}
