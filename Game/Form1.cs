using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using clib.game;
using clib.BL;
using EZInput;

namespace Game
{
    public partial class Form1 : Form
    {
        gameobjectDL objects = new gameobjectDL();
        player P;
        bool key_pressed = false;
        bool jump = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objects.onAdd += new EventHandler(OnAdd11);
            objects.add_list(Properties.Resources.ufoGreen, "up", 30, 30);
            P = new player(this.Height, this.Width,20);
            this.Controls.Add(P.Pd);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //objects.gravity();
            key_pressed = false;
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                P.moveright();
                key_pressed = true;
            }
            else if(Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                P.moveleft();
                key_pressed = true;
            }
            if(Keyboard.IsKeyPressed(Key.Space))
            {
                jump = true;
                key_pressed = true;
            }
            if(jump)
            {
                p
            }
            if(!key_pressed)
            {
                P.is_standing();
            }






            if(Keyboard.IsKeyPressed(Key.Escape))
            {
                this.Close();
            }
        }

        public void OnAdd11(object sender, EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }
    }
}
