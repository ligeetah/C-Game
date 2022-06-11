using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace clib.game
{
    public class gameobject
    {
        private PictureBox pb;
        private string movement;

        public PictureBox Pb { get { return pb; } set { pb = value; } }
        public string Movement { get { return movement; } set { movement = value; } }

        public gameobject(Image p,string m,int top,int left)
        {
            pb = new PictureBox();
            pb.Image=p;
            pb.BackColor = Color.Transparent;
            movement = m;
            pb.Height = p.Height;
            pb.Width = p.Width;
            pb.Left = left;
            pb.Top = top;
        }
    }
}
