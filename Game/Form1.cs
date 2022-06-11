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
using clib.DL;
using EZInput;

namespace Game
{
    public partial class Form1 : Form
    {
        gameobjectDL objects = new gameobjectDL();
        FloorDL floors = new FloorDL();
        player P;
        bool key_pressed = false;
        bool jump = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objects.onAdd += new EventHandler(OnAdd);
            floors.onAdd += new EventHandler(OnAdd);
            P = new player(this.Height, this.Width, 20, 15, 20);
            floors.add_list(this.Height,this.Width,P.Pd);
            objects.add_list(Properties.Resources.ufoGreen, "up", P.Pd.Top, 60);
            this.Controls.Add(P.Pd);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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
            if(P.check_under(floors.Floors))
            {
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    jump = true;
                    key_pressed = true;
                }
            }
            if(jump)
            {
                jump = P.Jump();
                key_pressed = true;
            }
            if(!key_pressed)
            {
                P.is_standing();
            }
            if(!jump)
            {
                P.gravity(floors.Floors);
            }
            if (Keyboard.IsKeyPressed(Key.Escape))
            {
                this.Close();
            }
        }

        public void OnAdd(object sender, EventArgs e)
        {
            this.Controls.Add(sender as PictureBox);
        }
    }
}
