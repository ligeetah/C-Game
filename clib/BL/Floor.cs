using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace clib.BL
{
    public class Floor
    {
        private PictureBox pb;
        public PictureBox Pb { get { return pb; } set { pb = value; } }
        public Floor(int a,int b,int top,int left,PictureBox j)
        {
            pb = new PictureBox();
            pb.Image = clib.Properties.Resource1.Floor;
            pb.BackColor = Color.Transparent;
            pb.Parent = j;
            pb.Size = new Size(a, b);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Top = top-40;
            pb.Left = 0;
        }
    }
}
