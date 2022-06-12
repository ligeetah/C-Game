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
    public class Enemy:Character
    {
        public Enemy(int top, int left, int s, int g)
        {
            pb = new PictureBox();
            is_standing();
            pb.BackColor = Color.Transparent;
            pb.Size = new Size(100, 100);
            pb.Left = left;
            pb.Top = top;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            walking_speed = s;
            G = g;
            fires = new List<PictureBox>();
        }
        public void moveleft(List<Floor> list)
        {
            bool a = check_borders_left(pb);
            if(!a)
            {
                direction = true;
            }
            if ( a&& check_hurdles_left(list) && check_hurdles_left_down(list))
            {
                pb.Left -= walking_speed;
                l_count++;
                if (l_count == 7)
                {
                    l_count = 1;
                }
                updatepic_left();
            }
        }
        public void moveright(int width, List<Floor> list)
        {
            bool a = check_borders_right(pb, width);
            if(!a)
            {
                direction = false;
            }
            else if (a&& check_hurdles_right(list) && check_hurdles_right_down(list))
            {
                pb.Left += walking_speed;
                r_count++;
                if (r_count == 7)
                {
                    r_count = 1;
                }
                updatepic_right();
            }
        }
        public bool check_hurdles_right_down(List<Floor> list)
        {
            gameobject g = new gameobject(pb.Bottom, pb.Left+100, 50, 50);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(g.Pb.Bounds))
                {
                    return true;
                }
            }
            direction = false;
            return false;

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
        public bool check_hurdles_left_down(List<Floor> list)
        {
            gameobject g = new gameobject(pb.Bottom, pb.Left -100, 100, 100);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(g.Pb.Bounds))
                {
                    return true;
                }
            }
            direction = true;
            return false;
        }
        public void move(int w,List<Floor> list)
        {
            if(direction)
            {
                moveright(w,list);
            }
            else
            {
                //moveright(w, list);
                moveleft(list);
            }
        }
    }
}
