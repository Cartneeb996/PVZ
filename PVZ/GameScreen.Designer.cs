namespace PVZ
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.sunflowerPurchButton = new System.Windows.Forms.Button();
            this.peashooterPurchButton = new System.Windows.Forms.Button();
            this.repeaterPurchButton = new System.Windows.Forms.Button();
            this.waveBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 32;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // sunflowerPurchButton
            // 
            this.sunflowerPurchButton.BackColor = System.Drawing.Color.White;
            this.sunflowerPurchButton.BackgroundImage = global::PVZ.Properties.Resources.sunflower;
            this.sunflowerPurchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sunflowerPurchButton.Enabled = false;
            this.sunflowerPurchButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sunflowerPurchButton.FlatAppearance.BorderSize = 2;
            this.sunflowerPurchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sunflowerPurchButton.Location = new System.Drawing.Point(151, 10);
            this.sunflowerPurchButton.Margin = new System.Windows.Forms.Padding(2);
            this.sunflowerPurchButton.Name = "sunflowerPurchButton";
            this.sunflowerPurchButton.Size = new System.Drawing.Size(45, 40);
            this.sunflowerPurchButton.TabIndex = 0;
            this.sunflowerPurchButton.TabStop = false;
            this.sunflowerPurchButton.UseVisualStyleBackColor = false;
            // 
            // peashooterPurchButton
            // 
            this.peashooterPurchButton.BackColor = System.Drawing.Color.White;
            this.peashooterPurchButton.BackgroundImage = global::PVZ.Properties.Resources.pea_shooter;
            this.peashooterPurchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.peashooterPurchButton.Enabled = false;
            this.peashooterPurchButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.peashooterPurchButton.FlatAppearance.BorderSize = 2;
            this.peashooterPurchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.peashooterPurchButton.Location = new System.Drawing.Point(201, 10);
            this.peashooterPurchButton.Margin = new System.Windows.Forms.Padding(2);
            this.peashooterPurchButton.Name = "peashooterPurchButton";
            this.peashooterPurchButton.Size = new System.Drawing.Size(45, 40);
            this.peashooterPurchButton.TabIndex = 1;
            this.peashooterPurchButton.TabStop = false;
            this.peashooterPurchButton.UseVisualStyleBackColor = false;
            // 
            // repeaterPurchButton
            // 
            this.repeaterPurchButton.BackColor = System.Drawing.Color.White;
            this.repeaterPurchButton.BackgroundImage = global::PVZ.Properties.Resources.repeater;
            this.repeaterPurchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.repeaterPurchButton.Enabled = false;
            this.repeaterPurchButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.repeaterPurchButton.FlatAppearance.BorderSize = 2;
            this.repeaterPurchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repeaterPurchButton.Location = new System.Drawing.Point(250, 10);
            this.repeaterPurchButton.Margin = new System.Windows.Forms.Padding(2);
            this.repeaterPurchButton.Name = "repeaterPurchButton";
            this.repeaterPurchButton.Padding = new System.Windows.Forms.Padding(3);
            this.repeaterPurchButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.repeaterPurchButton.Size = new System.Drawing.Size(45, 40);
            this.repeaterPurchButton.TabIndex = 2;
            this.repeaterPurchButton.TabStop = false;
            this.repeaterPurchButton.UseVisualStyleBackColor = false;
            // 
            // waveBar
            // 
            this.waveBar.Location = new System.Drawing.Point(678, 10);
            this.waveBar.Name = "waveBar";
            this.waveBar.Size = new System.Drawing.Size(291, 23);
            this.waveBar.TabIndex = 3;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PVZ.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.waveBar);
            this.Controls.Add(this.repeaterPurchButton);
            this.Controls.Add(this.peashooterPurchButton);
            this.Controls.Add(this.sunflowerPurchButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1329, 584);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button sunflowerPurchButton;
        private System.Windows.Forms.Button peashooterPurchButton;
        private System.Windows.Forms.Button repeaterPurchButton;
        private System.Windows.Forms.ProgressBar waveBar;
    }
}
