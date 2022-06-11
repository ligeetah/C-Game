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
namespace clib.BL
{
    public class player
    {
        private PictureBox pb;
        private int r_count = 0;
        private int l_count = 0;
        private int jump_count = 0;
        private int walking_speed;
        private int jump_steps;
        private int G;
        private bool direction = false;
        public EventHandler onAdd;
        public int R_count { get { return r_count; } set { r_count = value; } }
        public PictureBox Pd { get { return pb; } set { pb = value; } }
        public player(int top, int left, int s, int jumpsteps, int g)
        {
            pb = new PictureBox();
            is_standing();
            pb.BackColor = Color.Transparent;
            pb.Size = new Size(120, 150);
            pb.Left = left / 2;
            pb.Top = top - pb.Height-20;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            walking_speed = s;
            jump_steps = jumpsteps;
            G = g;
        }
        public void moveright()
        {
            direction = true;
            pb.Left += walking_speed;
            r_count++;
            if (r_count == 7)
            {
                r_count = 1;
            }
            updatepic_right();
        }
        public void updatepic_right()
        {
            if (r_count == 1)
            {
                pb.Image = clib.Properties.Resource1._1;
            }
            else if (r_count == 2)
            {
                pb.Image = clib.Properties.Resource1._2;
            }
            else if (r_count == 3)
            {
                pb.Image = clib.Properties.Resource1._3;
            }
            else if (r_count == 4)
            {
                pb.Image = clib.Properties.Resource1._4;
            }
            else if (r_count == 5)
            {
                pb.Image = clib.Properties.Resource1._5;
            }
            else if (r_count == 6)
            {
                pb.Image = clib.Properties.Resource1._6;
            }
        }
        public void moveleft()
        {
            direction = false;
            pb.Left -= walking_speed;
            l_count++;
            if (l_count == 7)
            {
                l_count = 1;
            }
            updatepic_left();
        }
        public void updatepic_left()
        {
            if (l_count == 1)
            {
                pb.Image = clib.Properties.Resource1._1L;
            }
            else if (l_count == 2)
            {
                pb.Image = clib.Properties.Resource1._2L;
            }
            else if (l_count == 3)
            {
                pb.Image = clib.Properties.Resource1._3L;
            }
            else if (l_count == 4)
            {
                pb.Image = clib.Properties.Resource1._4L;
            }
            else if (l_count == 5)
            {
                pb.Image = clib.Properties.Resource1._5L;
            }
            else if (l_count == 6)
            {
                pb.Image = clib.Properties.Resource1._6L;
            }
        }
        public void is_standing()
        {
            if (direction)
            {
                pb.Image = clib.Properties.Resource1.RS;
            }
            else
            {
                pb.Image = clib.Properties.Resource1.LS;
            }
        }
        public bool Jump()
        {
            jump_count++;
            if (jump_count == 6)
            {
                jump_count = 0;
            }
            if (direction)
            {
                if (jump_count == 1)
                {
                    pb.Image = clib.Properties.Resource1.j1r;
                }
                else if (jump_count == 2)
                {
                    pb.Image = clib.Properties.Resource1.j2r;
                }
                else if (jump_count == 3)
                {
                    pb.Image = clib.Properties.Resource1.j3r;
                }
                else if (jump_count == 4)
                {
                    pb.Image = clib.Properties.Resource1.j4r;
                }
                else if (jump_count == 5)
                {
                    pb.Image = clib.Properties.Resource1.j5r;
                    return false;
                }
            }
            else
            {
                if (jump_count == 1)
                {
                    pb.Image = clib.Properties.Resource1.j1l;
                }
                else if (jump_count == 2)
                {
                    pb.Image = clib.Properties.Resource1.j2l;
                }
                else if (jump_count == 3)
                {
                    pb.Image = clib.Properties.Resource1.j3l;
                }
                else if (jump_count == 4)
                {
                    pb.Image = clib.Properties.Resource1.j4l;
                }
                else if (jump_count == 5)
                {
                    pb.Image = clib.Properties.Resource1.j5l;
                    return false;
                }
            }
            pb.Top -= jump_steps;
            return true;
        }
        public void gravity(List<Floor> list)
        {
            if(!check_under(list))
            {
                pb.Top += G;
            }
        }
        public bool check_under(List<Floor> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(pb.Bounds) && pb.Bottom > list[i].Pb.Top)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
