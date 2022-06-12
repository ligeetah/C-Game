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
    public class Character
    {
        public PictureBox pb;
        public int r_count = 0;
        public int l_count = 0;
        public int walking_speed;
        public int G;
        public bool direction = false;
        public List<PictureBox> fires;
        public EventHandler onAdd;
        public EventHandler onDelete;

        
        protected bool check_borders_right(PictureBox p, int w)
        {
            if (p.Right < w)
            {
                return true;
            }
            return false;
        }
        protected bool check_borders_left(PictureBox p)
        {
            if (p.Left > 0)
            {
                return true;
            }
            return false;
        }
        protected bool check_hurdles_left(List<Floor> list)
        {
            gameobject g = new gameobject(pb.Top, pb.Left - walking_speed, 80, 10);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(g.Pb.Bounds))
                {
                    return false;
                }
            }
            return true;
        }
        protected bool check_hurdles_right(List<Floor> list)
        {
            gameobject g = new gameobject(pb.Top, pb.Right + walking_speed, 80, 10);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(g.Pb.Bounds))
                {
                    return false;
                }
            }
            return true;

        }
        
        public void gravity(List<Floor> list)
        {
            if (!check_under(list))
            {
                pb.Top += G;
            }
        }
        public bool check_under(List<Floor> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pb.Bounds.IntersectsWith(pb.Bounds) && !location(pb, list[i].Pb))
                {
                    return true;
                }
            }
            return false;
        }
        public bool location(PictureBox obj, PictureBox surface)
        {
            if (!bound_right(obj, surface) && !bound_left(obj, surface) && !bound_down(obj, surface))
            {
                return false;
            }
            return true;
        }
        public bool bound_left(PictureBox obj, PictureBox surface)
        {
            if (obj.Left > surface.Right)
            {
                return true;
            }
            return false;
        }
        public bool bound_right(PictureBox obj, PictureBox surface)
        {
            if (obj.Right < surface.Left)
            {
                return true;
            }
            return false;
        }
        public bool bound_down(PictureBox obj, PictureBox surface)
        {
            if (obj.Bottom < surface.Top)
            {
                return true;
            }
            return false;
        }
        public bool bound_up(PictureBox obj, PictureBox surface)
        {
            if (obj.Top > surface.Bottom)
            {
                return true;
            }
            return false;
        }
        public void fire()
        {
            PictureBox p = new PictureBox();
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.BackColor = Color.Transparent;
            p.Size = new Size(50, 50);
            if (direction)
            {
                p.Image = clib.Properties.Resource1.fireright;
                p.Image.Tag = "right";
                p.Left = pb.Right;
                p.Top = pb.Top + pb.Height / 2 - 40;
            }
            else
            {
                p.Image = clib.Properties.Resource1.fireleft;
                p.Image.Tag = "left";
                p.Left = pb.Left - p.Width;
                p.Top = pb.Top + pb.Height / 2 - 40;
            }
            fires.Add(p);
            onAdd?.Invoke(p, EventArgs.Empty);
        }
        public void movefires(int width)
        {
            for (int i = 0; i < fires.Count; i++)
            {
                if (fires[i].Image.Tag.ToString() == "left")
                {
                    if (check_borders_left(fires[i]))
                    {
                        fires[i].Left -= 40;
                    }
                    else
                    {
                        onDelete?.Invoke(fires[i], EventArgs.Empty);
                        fires.RemoveAt(i);
                        i--;
                    }
                }
                else
                {
                    if (check_borders_right(fires[i], width))
                    {
                        fires[i].Left += 40;

                    }
                    else
                    {
                        onDelete?.Invoke(fires[i], EventArgs.Empty);
                        fires.RemoveAt(i);
                        i--;
                    }
                }
            }
        }


    }
}
